using System.Runtime.Serialization;

namespace EncompassRest.Loans.Enums;

/// <summary>
/// AdditionalSigVerbiageType
/// </summary>
public enum AdditionalSigVerbiageType
{
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE "ADDENDUM TO NOTE", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE \"ADDENDUM TO NOTE\", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHEADDENDUMTONOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 0,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE "RIDER TO NOTE", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE \"RIDER TO NOTE\", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHERIDERTONOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 1,
    /// <summary>
    /// THE PROVISIONS IN THE ADDENDUM ATTACHED HERETO ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS IN THE ADDENDUM ATTACHED HERETO ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSINTHEADDENDUMATTACHEDHERETOAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 2,
    /// <summary>
    /// THE TERMS OF THIS LOAN CONTAIN A PROVISION WHICH MAY REQUIRE A BALLOON PAYMENT AT MATURITY.
    /// </summary>
    [EnumMember(Value = "THE TERMS OF THIS LOAN CONTAIN A PROVISION WHICH MAY REQUIRE A BALLOON PAYMENT AT MATURITY.")]
    THETERMSOFTHISLOANCONTAINAPROVISIONWHICHMAYREQUIREABALLOONPAYMENTATMATURITY = 3,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE "ADDENDUM TO NOTE" AND "RIDER TO NOTE", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE \"ADDENDUM TO NOTE\" AND \"RIDER TO NOTE\", SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHEADDENDUMTONOTEANDRIDERTONOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 4,
    /// <summary>
    /// SEE BALLOON NOTE ADDENDUM ATTACHED HERETO AND MADE A PART HEREOF.
    /// </summary>
    [EnumMember(Value = "SEE BALLOON NOTE ADDENDUM ATTACHED HERETO AND MADE A PART HEREOF.")]
    SEEBALLOONNOTEADDENDUMATTACHEDHERETOANDMADEAPARTHEREOF = 5,
    /// <summary>
    /// DO NOT SIGN THIS LOAN AGREEMENT BEFORE YOU READ IT. THIS AGREEMENT PROVIDES FOR THE PAYMENT OF A PENALTY IF YOU WISH TO REPAY THE LOAN PRIOR TO THE DATE PROVIDED FOR REPAYMENT IN THE LOAN AGREEMENT.
    /// </summary>
    [EnumMember(Value = "DO NOT SIGN THIS LOAN AGREEMENT BEFORE YOU READ IT. THIS AGREEMENT PROVIDES FOR THE PAYMENT OF A PENALTY IF YOU WISH TO REPAY THE LOAN PRIOR TO THE DATE PROVIDED FOR REPAYMENT IN THE LOAN AGREEMENT.")]
    DONOTSIGNTHISLOANAGREEMENTBEFOREYOUREADITTHISAGREEMENTPROVIDESFORTHEPAYMENTOFAPENALTYIFYOUWISHTOREPAYTHELOANPRIORTOTHEDATEPROVIDEDFORREPAYMENTINTHELOANAGREEMENT = 6,
    /// <summary>
    /// THE NOTE PROVIDES FOR A BALLOON PAYMENT AT MATURITY. DO NOT SIGN IT UNTIL YOU READ THE BALLOON NOTE ADDENDUM ATTACHED HERETO AND MADE A PART HEREOF.
    /// </summary>
    [EnumMember(Value = "THE NOTE PROVIDES FOR A BALLOON PAYMENT AT MATURITY. DO NOT SIGN IT UNTIL YOU READ THE BALLOON NOTE ADDENDUM ATTACHED HERETO AND MADE A PART HEREOF.")]
    THENOTEPROVIDESFORABALLOONPAYMENTATMATURITYDONOTSIGNITUNTILYOUREADTHEBALLOONNOTEADDENDUMATTACHEDHERETOANDMADEAPARTHEREOF = 7,
    /// <summary>
    /// NOTICE TO THE BORROWER - DO NOT SIGN THIS ADDENDUM TO THE NOTE BEFORE YOU READ IT.  THIS ADDENDUM TO THE NOTE PROVIDES FOR THE PAYMENT OF A PENALTY IF YOU WISH TO REPAY THE LOAN PRIOR TO THE DATE PROVIDED FOR REPAYMENT IN THE NOTE.
    /// </summary>
    [EnumMember(Value = "NOTICE TO THE BORROWER - DO NOT SIGN THIS ADDENDUM TO THE NOTE BEFORE YOU READ IT.  THIS ADDENDUM TO THE NOTE PROVIDES FOR THE PAYMENT OF A PENALTY IF YOU WISH TO REPAY THE LOAN PRIOR TO THE DATE PROVIDED FOR REPAYMENT IN THE NOTE.")]
    NOTICETOTHEBORROWERDONOTSIGNTHISADDENDUMTOTHENOTEBEFOREYOUREADITTHISADDENDUMTOTHENOTEPROVIDESFORTHEPAYMENTOFAPENALTYIFYOUWISHTOREPAYTHELOANPRIORTOTHEDATEPROVIDEDFORREPAYMENTINTHENOTE = 8,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE LOW DOWN PAYMENT MORTGAGE ADDENDUM TO NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE LOW DOWN PAYMENT MORTGAGE ADDENDUM TO NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHELOWDOWNPAYMENTMORTGAGEADDENDUMTONOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 9,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE LOW DOWN PAYMENT MORTGAGE ADDENDUM TO ADJUSTABLE RATE NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE LOW DOWN PAYMENT MORTGAGE ADDENDUM TO ADJUSTABLE RATE NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHELOWDOWNPAYMENTMORTGAGEADDENDUMTOADJUSTABLERATENOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 10,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE INTEREST ONLY ADDENDUM TO THE NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE INTEREST ONLY ADDENDUM TO THE NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHEINTERESTONLYADDENDUMTOTHENOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 11,
    /// <summary>
    /// THE PROVISIONS CONTAINED IN THE LOAN MODIFICATION OPTION TO NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.
    /// </summary>
    [EnumMember(Value = "THE PROVISIONS CONTAINED IN THE LOAN MODIFICATION OPTION TO NOTE, SIGNED BY ALL BORROWERS NAMED HEREIN, ARE HEREBY INCORPORATED INTO AND SHALL AMEND AND SUPPLEMENT THIS NOTE.")]
    THEPROVISIONSCONTAINEDINTHELOANMODIFICATIONOPTIONTONOTESIGNEDBYALLBORROWERSNAMEDHEREINAREHEREBYINCORPORATEDINTOANDSHALLAMENDANDSUPPLEMENTTHISNOTE = 12
}