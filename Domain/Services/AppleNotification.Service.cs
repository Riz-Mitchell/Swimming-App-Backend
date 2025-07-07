using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Domain.Helpers;

namespace SwimmingAppBackend.Domain.Services
{
    public interface IAppleNotificationService
    {
        void HandleNotification(AppleNotificationReqDTO notification);
    }

    public class AppleNotificationService : IAppleNotificationService
    {
        // private readonly IUserSubscriptionService _userSubscriptionService;

        // public AppleNotificationService(IUserSubscriptionService userSubscriptionService)
        // {
        //     _userSubscriptionService = userSubscriptionService;
        // }

        public void HandleNotification(AppleNotificationReqDTO notification)
        {
            var v2Notification = AppleSignatureHelper.GetVerifiedDecodedData<AppleNotificationV2DTO>(notification.SignedPayload);
            if (v2Notification?.DecodedPayload?.Data == null || !v2Notification.IsValid)
            {
                throw new ArgumentNullException($"{nameof(v2Notification.DecodedPayload.Data)} is null or not valid");
            }

            RenewalInfoV2DTO? renewalInfo = null;
            if (!string.IsNullOrEmpty(v2Notification.DecodedPayload.Data.SignedRenewalInfo))
            {
                var renewalInfoV2Verified = AppleSignatureHelper.GetVerifiedDecodedData<RenewalInfoV2DTO>(v2Notification.DecodedPayload.Data.SignedRenewalInfo);
                if (renewalInfoV2Verified.IsValid) renewalInfo = renewalInfoV2Verified.DecodedPayload;
            }

            var transactionInfoRes = AppleSignatureHelper.GetVerifiedDecodedData<TransactionInfoV2DTO>(v2Notification.DecodedPayload.Data.SignedTransactionInfo);
            TransactionInfoV2DTO? transactionInfo = null;
            if (transactionInfoRes.IsValid) transactionInfo = transactionInfoRes.DecodedPayload;

            Console.WriteLine(JsonConvert.SerializeObject(v2Notification, Formatting.Indented));

            Console.WriteLine(JsonConvert.SerializeObject(renewalInfo, Formatting.Indented));

            Console.WriteLine(JsonConvert.SerializeObject(transactionInfo, Formatting.Indented));


        }
    }
}