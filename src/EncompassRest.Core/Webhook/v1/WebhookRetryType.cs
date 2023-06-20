using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EncompassRest.Webhook.v1
{
    /// <summary>
    /// WebhookRetryType
    /// </summary>
    public enum WebhookRetryType
    {
        /// <summary>
        /// linear
        /// </summary>
        [EnumMember(Value = "linear")]
        Linear = 0,
        /// <summary>
        /// exponential
        /// </summary>
        [EnumMember(Value = "exponential")]
        Exponential = 1
    }
}
