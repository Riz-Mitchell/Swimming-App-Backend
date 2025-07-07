using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SwimmingAppBackend.Enum;

namespace SwimmingAppBackend.Api.DTOs
{
    public class AppleNotificationReqDTO
    {
        [JsonProperty("signedPayload")]
        public string SignedPayload { get; set; } = string.Empty;
    }

    public class AppleNotificationV2DTO
    {
        [JsonProperty("notificationType")]
        public NotificationType NotificationType { get; set; }

        [JsonProperty("subtype")]
        public NotificationSubtype Subtype { get; set; }

        [JsonProperty("notificationUUID")]
        public string NotificationUUID { get; set; }

        [JsonProperty("notificationVersion")]
        public int NotificationVersion { get; set; }

        [JsonProperty("data")]
        public AppleNotificationV2DataDTO Data { get; set; }
    }

    public class AppleNotificationV2DataDTO
    {
        [JsonProperty("appAppleId")]
        public string AppAppleId { get; set; }

        [JsonProperty("bundleId")]
        public string BundleId { get; set; }

        [JsonProperty("bundleVersion")]
        public string BundleVersion { get; set; }

        [JsonProperty("environment")]
        public AppleEnvironment Environment { get; set; }

        [JsonProperty("signedRenewalInfo")]
        public string SignedRenewalInfo { get; set; }

        [JsonProperty("signedTransactionInfo")]
        public string SignedTransactionInfo { get; set; }
    }

    public class RenewalInfoV2DTO
    {
        [JsonProperty("appAccountToken")]
        public string AppTransactionId { get; set; }

        [JsonProperty("autoRenewProductId")]
        public string AutoRenewProductId { get; set; }

        [JsonProperty("autoRenewStatus")]
        [Range(0, 1)]
        public int AutoRenewStatus { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("originalTransactionId")]
        public string OriginalTransactionId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }

    public class TransactionInfoV2DTO
    {
        [JsonProperty("appAccountToken")]
        public string AppAccountToken { get; set; }

        [JsonProperty("appTransactionId")]
        public string AppTransactionId { get; set; }

        [JsonProperty("bundleId")]
        public string BundleId { get; set; }

        [JsonProperty("purchaseDate")]
        public string PurchaseDate { get; set; }

        [JsonProperty("expiresDate")]
        public string ExpiresDate { get; set; }

        [JsonProperty("isUpgraded")]
        public bool IsUpgraded { get; set; }

        [JsonProperty("storefront")]
        public string Storefront { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("transactionReason")]
        public string TransactionReason { get; set; }
    }
}