using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IFirebaseService
    {
        Task<string> SendPushNotificationAsync(string deviceToken, string title, string body);
        Task<bool> VerifyPhoneNumIdTokenAsync(string idToken);
    }

    public class FirebaseService : IFirebaseService
    {
        private static bool _isInitialized = false;

        public FirebaseService(string serviceAccountPath)
        {
            if (!_isInitialized)
            {
                InitializeFirebase(serviceAccountPath);
                _isInitialized = true;
            }
        }

        private void InitializeFirebase(string serviceAccountPath)
        {
            if (!File.Exists(serviceAccountPath))
                throw new FileNotFoundException("Firebase service account file not found.", serviceAccountPath);

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(serviceAccountPath)
            });
        }

        public async Task<string> SendPushNotificationAsync(string deviceToken, string title, string body)
        {
            var message = new Message
            {
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                },
                Token = deviceToken
            };

            return await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

        public async Task<bool> VerifyPhoneNumIdTokenAsync(string idToken)
        {
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                return decodedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}