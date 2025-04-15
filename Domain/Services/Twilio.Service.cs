// TwilioService.cs
using System;
using System.Collections.Concurrent;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;

namespace SwimmingAppBackend.Domain.Services
{
    public interface ITwilioService
    {
        Task<string> SendVerificationCodeAsync(string phoneNumber, string name);
        bool ValidateVerificationCode(string phoneNumber, string code);
    }

    public class TwilioService : ITwilioService
    {
        private readonly string _twilioAccountSid;
        private readonly string _twilioAuthToken;
        private readonly string _twilioPhoneNumber;

        // In-memory storage for verification codes and expiration
        private static readonly ConcurrentDictionary<string, (string Code, DateTime ExpiryTime)> _verificationCodes = new();

        public TwilioService(IConfiguration configuration)
        {
            _twilioAccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            _twilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            _twilioPhoneNumber = Environment.GetEnvironmentVariable("TWILIO_PHONE_NUM");        // Only for aus
        }

        public async Task<string> SendVerificationCodeAsync(string phoneNumber, string name)
        {
            Console.WriteLine($"Sending verification code to {phoneNumber}");
            try
            {
                TwilioClient.Init(_twilioAccountSid, _twilioAuthToken);

                // Generate the verification code
                var verificationCode = GenerateVerificationCode();

                // Set the expiration time (e.g., 5 minutes from now)
                var expiryTime = DateTime.UtcNow.AddMinutes(5);

                // Store the verification code and its expiration
                _verificationCodes[phoneNumber] = (verificationCode, expiryTime);

                // Send the verification code via SMS
                var message = await MessageResource.CreateAsync(
                    body: "Hello " + name + " your verification code is: " + verificationCode,
                    from: new PhoneNumber(_twilioPhoneNumber),
                    to: new PhoneNumber(phoneNumber)
                );

                Console.WriteLine($"Message sent: {message.Sid}");

                return message.Sid;
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending SMS: " + ex.Message);
            }
        }

        public bool ValidateVerificationCode(string phoneNumber, string code)
        {
            // Check if the phone number exists in the dictionary
            if (!_verificationCodes.ContainsKey(phoneNumber))
            {
                return false; // Code not found
            }

            var (storedCode, expiryTime) = _verificationCodes[phoneNumber];

            // Check if the code is expired
            if (DateTime.UtcNow > expiryTime)
            {
                _verificationCodes.TryRemove(phoneNumber, out _); // Remove expired code
                return false; // Code expired
            }

            // Check if the code matches
            if (storedCode != code)
            {
                return false; // Invalid code
            }

            // Code is valid and used, remove it after successful validation
            _verificationCodes.TryRemove(phoneNumber, out _);
            return true;
        }

        private string GenerateVerificationCode()
        {
            // Generate a simple random 6-digit verification code
            Random rand = new();
            return rand.Next(100000, 999999).ToString();
        }
    }
}