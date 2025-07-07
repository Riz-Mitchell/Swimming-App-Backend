using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SwimmingAppBackend.Api.DTOs;

namespace SwimmingAppBackend.Domain.Helpers
{
    public static class AppleSignatureHelper
    {
        public static VerifiedDecodedDataDTO<TNotificationData> GetVerifiedDecodedData<TNotificationData>(string signedPayload)
        {
            if (string.IsNullOrEmpty(signedPayload))
            {
                throw new ArgumentException("Signed Payload is null");
            }

            var splitParts = signedPayload.Split('.');      // Split into JWS header, payload, and signature representations

            CheckSplitParts(splitParts);

            var valid = VerifyToken(signedPayload);

            var payload = splitParts[1];

            return new VerifiedDecodedDataDTO<TNotificationData>
            {
                DecodedPayload = valid ? DecodeFromBase64<TNotificationData>(payload) : default,
                IsValid = valid
            };
        }

        private static void CheckSplitParts(string[] split)
        {
            if (split.Length != 3)
            {
                throw new ArgumentException("Invalid signedPayload");
            }

            if (string.IsNullOrEmpty(split[0]))
            {
                throw new ArgumentException("Invalid jws_header part");
            }

            if (string.IsNullOrEmpty(split[1]))
            {
                throw new ArgumentException("Invalid jws_payload part");
            }

            if (string.IsNullOrEmpty(split[2]))
            {
                throw new ArgumentException("Invalid jws_signature part");
            }
        }

        private static bool VerifyToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecToken = handler.ReadJwtToken(token);

                var x5c = jwtSecToken.Header.TryGetValue("x5c", out object x5cCertificates);

                if (!x5c || x5cCertificates == null)
                {
                    throw new KeyNotFoundException("Token Header does not contain x5c");
                }

                var certificateItems = JsonConvert.DeserializeObject<IEnumerable<string>>(x5cCertificates.ToString());
                if (certificateItems == null || !certificateItems.Any())
                {
                    throw new ArgumentNullException("Certificates are null");
                }

                var securityToken = Validate(handler, token, certificateItems.First());

                return securityToken != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static SecurityToken? Validate(JwtSecurityTokenHandler tokenHandler, string jwtToken, string publicKey)
        {
            var certificateBytes = Convert.FromBase64String(publicKey);
            var certificate = new X509Certificate2(certificateBytes);
            var eCDsa = certificate.GetECDsaPublicKey();

            if (eCDsa == null)
            {
                throw new CryptographicException("ECDSA public key not found in certificate");
            }

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://appleid.apple.com",
                IssuerSigningKey = new ECDsaSecurityKey(eCDsa),
            };

            tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out var securityToken);
            return securityToken;
        }

        private static TObj DecodeFromBase64<TObj>(string encodedString)
        {
            var data = Base64UrlTextEncoder.Decode(encodedString);
            string decodedString = Encoding.UTF8.GetString(data);

            var obj = JsonConvert.DeserializeObject<TObj>(decodedString);
            return obj;
        }
    }
}