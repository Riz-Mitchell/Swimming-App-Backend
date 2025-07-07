using System.Text.Json.Serialization;

namespace SwimmingAppBackend.Enum
{
    public enum NotificationType
    {
        DID_RENEW,
        DID_FAIL_TO_RENEW,
        EXPIRED,
        DID_CHANGE_RENEWAL_STATUS,
        DID_CHANGE_RENEWAL_PREF,
        REVOKE,
        SUBSCRIBED,
        OFFER_REDEEMED,
        PRICE_INCREASE,
    }
}