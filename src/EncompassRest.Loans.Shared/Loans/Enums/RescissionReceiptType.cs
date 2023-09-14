using System.Runtime.Serialization;

namespace EncompassRest.Loans.Enums
{
    /// <summary>
    /// Recission Receipt Type
    /// </summary>
    public enum RecissionReceiptType
    {
        /// <summary>
        /// Delivered By Mail
        /// </summary>
        DeliveredByMail = 0,

        /// <summary>
        /// Delivered In Person
        /// </summary>
        DeliveredInPerson = 1,

        /// <summary>
        /// Delivered Electronically
        /// </summary>
        DeliveredElectronically = 2,
    }
}
