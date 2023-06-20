using System;
using System.Collections.Generic;
using System.Text;

namespace EncompassRest.Webhook.v1
{
    /// <summary>
    /// WebhookDeliveryPolicy
    /// </summary>
    public sealed class WebhookDeliveryPolicy : ExtensibleObject
    {
        /// <summary>
        /// Webhook Rety type spcifier
        /// </summary>
        public StringEnumValue<WebhookRetryType> Backoff { get; set; }
    }
}
