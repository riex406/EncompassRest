﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncompassRest.Loans;
using EncompassRest.Loans.Enums;
using EncompassRest.Loans.v1;
using EncompassRest.Schema;
using EncompassRest.Schema.v1;
using EncompassRest.Tests;
using EnumsNET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EncompassRest
{
    public static class EntityGenerator
    {
        static EntityGenerator()
        {
            var sharedEnumTypes = new[]
            {
                typeof(YOrN),
                typeof(YNOrNA),
                typeof(YesOrNo),
                typeof(YesNoOrNA),
                typeof(TrueOrFalse),
                typeof(AcceptOrReject),
                typeof(IncreasedOrDecreased),
                typeof(UtilitiesDescription),
                typeof(TermType),
                typeof(SignedByTyp),
                typeof(TotalClosingCostRemark),
                typeof(PartyType),
                typeof(AUS),
                typeof(AUSRecommendation),
                typeof(BankruptcyForeclosureStatus),
                typeof(LicenseAuthType),
                typeof(BorContingentLiabilitiesLiabilityDescription),
                typeof(BorrowerType),
                typeof(ClosingCostFundsType),
                typeof(FundsTypeDescription),
                typeof(ClosingCostSourceType),
                typeof(SourceTypeDescription),
                typeof(DocsLoanProgramType),
                typeof(ServicingType),
                typeof(CorrespondentOptionDesc),
                typeof(CreditChargeType),
                typeof(DenialReason),
                typeof(DisclosureMethod),
                typeof(DownPaymentSourceType),
                typeof(YNOrOther),
                typeof(Hud1EsPayToFeeType),
                typeof(RefundableType),
                typeof(RecSamePtyTypeDesc),
                typeof(FreddieBorrowerAlienStatus),
                typeof(FreddieDownPaymentType),
                typeof(FullPrepaymentPenaltyOptionType),
                typeof(ATRQMStatus),
                typeof(ImpoundType),
                typeof(ClosingCostImpoundType),
                typeof(ImpoundWaived),
                typeof(IncludeOriginationPointsCreditType),
                typeof(InformationTypesWeCollect),
                typeof(ProjectType),
                typeof(MonthOrYear),
                typeof(CanGoOrGoes),
                typeof(OrgTyp),
                typeof(IsOrIsNot),
                typeof(LimitSharing),
                typeof(ScsrsClaus),
                typeof(CanIncreaseOrIncreases),
                typeof(LoanAmountType),
                typeof(LoanDocumentationType),
                typeof(LoanPurposeType),
                typeof(LoanType),
                typeof(RefinancePurpose),
                typeof(PropertyType),
                typeof(LienType),
                typeof(DoesOrDoesNot),
                typeof(DoesOrDoesNot2),
                typeof(OpenBankruptcy),
                typeof(InterestRateImpactedStatus),
                typeof(StateDisclosureFeePaidBy),
                typeof(Owner),
                typeof(PaidBy),
                typeof(PaidType),
                typeof(PenaltyTerm),
                typeof(OccupancyIntent),
                typeof(PrepaymentPenaltyBasedOn),
                typeof(PropertyUsageType),
                typeof(PTB),
                typeof(DaysInYear),
                typeof(TypeOfPurchaser),
                typeof(RiskClassification),
                typeof(RoundingMethod),
                typeof(SignatureType),
                typeof(FinalSignatureType),
                typeof(SofDBorrowerAddressType),
                typeof(TimesToCollect),
                typeof(TrstSamePtyTypDesc),
                typeof(ProfitManagementItemType),
                typeof(UCDPayoffType),
                typeof(UlddBorrowerType),
                typeof(VestingTrusteeOfType),
                typeof(WholePocPaidByType),
                typeof(AmortizationType),
                typeof(ApplicationTakenMethodType),
                typeof(OtherPropertyType),
                typeof(RiskAssessmentType),
                typeof(ActionTaken),
                typeof(IndexMargin),
                typeof(PropertyFormType),
                typeof(Conversion),
                typeof(HmdaLoanPurpose),
                typeof(PaidToOrBy),
                typeof(BorrowerOrCoBorrower),
                typeof(NonVolAdjustmentType),
                typeof(HudLoanDataResidencyType),
                typeof(LienPosition),
                typeof(HelocCalcSign),
                typeof(HelocPaymentBasis),
                typeof(HelocBalance),
                typeof(MortgageType),
                typeof(RefinanceType),
                typeof(PerDiemCalculationMethodType),
                typeof(UnitType),
                typeof(HmdaCreditScoreForDecisionMaking),
                typeof(HmdaCreditScoringModel),
                typeof(YNOrExempt),
                typeof(RefinanceCashOutDeterminationType),
                typeof(GovernmentRefinanceType),
                typeof(ConstructionToPermanentClosingType),
                typeof(AssetType),
                typeof(OtherAssetType),
                typeof(CounselingFormatType),
                typeof(Description),
                typeof(JointAssetLiabilityReportingIndicator),
                typeof(IncreaseOrDecrease),
                typeof(PaymentBasisType),
                typeof(ReoPropertyUsageType),
                typeof(AdditionalLoanLienPosition),
                typeof(BuydownContributor),
                typeof(FloodZone),
                typeof(AppraisalPropertyType),
                typeof(BuildingStatusType),
                typeof(AttachmentType),
                typeof(PropertyImprovementsType),
                typeof(PropertyRightsType),
                typeof(ValuationAwareness),
                typeof(PublicOrPrivate),
                typeof(LienStatus),
                typeof(HmdaPropertyType),
                typeof(BorrLenderPaid),
                typeof(ProjectLegalStructureType),
                typeof(ApprovalStatus)
            };
            s_sharedEnums = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var sharedEnumType in sharedEnumTypes)
            {
                s_sharedEnums.Add(sharedEnumType.Name, new HashSet<string>(Enums.GetMembers(sharedEnumType).Select(m => m.AsString(EnumFormat.EnumMemberValue, EnumFormat.Name))));
            }
        }

        private static readonly Dictionary<string, HashSet<string>> s_sharedEnums;

        private static readonly HashSet<string> s_enumPropertyNamesToUseNotExactSharedEnum = new()
        {
            "AUS2",
            "AUS3",
            "AUS4",
            "AUS5",
            "AUSRecommendation2",
            "AUSRecommendation3",
            "AUSRecommendation4",
            "AUSRecommendation5",
            "DenialReason2",
            "DenialReason3",
            "DenialReason4",
            "AdjustsTermType",
            "PrepaymentPenaltyPayOffInDateType",
            "LogDUPropertyType",
            "ClosingCost2FundsTypeOtherDescription",
            "ClosingCost3FundsTypeOtherDescription",
            "ClosingCost4FundsTypeOtherDescription",
            "ClosingCostFundsTypeOtherDescription",
            "DownPaymentOtherTypeDescription",
            "HmdaCreditScoreForDecisionMaking",
            "Hmda2CreditScoreForDecisionMaking",
            "HmdaCreditScoringModel",
            "Hmda2CreditScoringModel",
            "GovernmentRefinanceType",
            "PropertyFormType",
            "InsuranceProjectType",
            "LogLPPropertyType",
            "PropertyRightsType",
            "MortgageType",
            "FreddieMortgageType",
            "FannnieMortgageType",
            "IsEthnicityBasedOnVisual",
            "IsRaceBasedOnVisual",
            "IsSexBasedOnVisual",
            "NmlsLienStatus",
            "AppraisalFloodZone"
        };

        private static readonly HashSet<string> s_enumPropertyNamesToUseEntityTypeInName = new(StringComparer.OrdinalIgnoreCase)
        {
            "PurposeOfLoan",
            "LoanType",
            "PropertyType",
            "FeeType",
            "RiskClass",
            "LoanPurpose",
            "BorrowerType",
            "MortgageOriginator",
            "AppraisalType",
            "MortgageType",
            "RefinanceType",
            "AssetType",
            "Description",
            "CounselingFormatType",
            "Source"
        };

        private static readonly Dictionary<string, string> s_explicitStringEnumValues = new()
        {
            { $"{nameof(LoanAssociate)}.{nameof(LoanAssociate.LoanAssociateType)}", nameof(LoanAssociateType) },
            { $"{nameof(LoanAssociate)}.{nameof(LoanAssociate.EnableWriteAccess)}", nameof(YOrN) },
            { $"{nameof(AdditionalStateDisclosure)}.{nameof(AdditionalStateDisclosure.StateCode)}", nameof(State) },
            { $"{nameof(FreddieMac)}.{nameof(FreddieMac.CondoClass)}", nameof(CondoClass) },
            { $"{nameof(MilestoneTaskContact)}.{nameof(MilestoneTaskContact.State)}", nameof(State) },
            { $"{nameof(Miscellaneous)}.{nameof(Miscellaneous.State)}", nameof(State) },
            { $"{nameof(Correspondent)}.{nameof(Correspondent.ProjectClass)}", nameof(ProjectType) },
            { $"{nameof(Valuation)}.{nameof(Valuation.StatedPropertyType)}", nameof(PropertyType) },
            { $"{nameof(DocumentAuditAlert)}.{nameof(DocumentAuditAlert.Type)}", nameof(AlertType) },
            { $"{nameof(DocumentAuditAlert)}.{nameof(DocumentAuditAlert.Source)}", nameof(DocumentAuditAlertSource) },
            { $"{nameof(EnhancedConditionLog)}.{nameof(EnhancedConditionLog.SourceOfCondition)}", nameof(SourceOfCondition) },
            { $"{nameof(PriceAdjustment)}.{nameof(PriceAdjustment.RateLockAdjustmentType)}", nameof(RateLockAdjustmentType) },
            { $"{nameof(DocumentOrderLog)}.{nameof(DocumentOrderLog.OrderType)}", nameof(OrderType) },
            { $"{nameof(OrderedDocument)}.{nameof(OrderedDocument.Type)}", nameof(OrderedDocumentType) },
            { $"{nameof(OrderedDocument)}.{nameof(OrderedDocument.SignatureType)}", nameof(OrderedDocumentSignatureType) },
            { $"{nameof(DisclosureForm)}.{nameof(DisclosureForm.FormType)}", nameof(DisclosureFormType) },
            { $"{nameof(LoanEstimate1)}.{nameof(LoanEstimate1.ClosingCostEstimateExpirationTimeZone)}", nameof(SpecificTimeZone) },
            { $"{nameof(Residence)}.{nameof(Residence.ResidencyBasisType)}", nameof(ResidencyBasisType) }
        };

        private static readonly Dictionary<string, HashSet<string>> s_stringDictionaryProperties = new()
        {
            { nameof(Loan), new() { nameof(Loan.VirtualFields) } },
            { nameof(DocumentOrderLog), new() { nameof(DocumentOrderLog.DocumentFields) } },
            { nameof(ElliUCDDetail), new() { nameof(ElliUCDDetail.CDFields), nameof(ElliUCDDetail.LEFields) } }
        };

        private static readonly HashSet<string> s_propertiesToNotGenerate = new() { "Contact.Contact", "Loan.CurrentApplication", "Borrower.Application", "Uldd.ENoteIndicator", "GoodFaithFeeVarianceCureLog.GffVAlertTriggerFieldLog", "VaLoanData.VaEemIncludedinBaseLoanAmountIndicator", "VaLoanData.VaEnergyEfficientImprovementsFinancedAmount", "VaLoanData.VaFinancedClosingCostsToExcludeAmount", "VaLoanData.VaRateReducedSolelybyDiscountPointsIndicator", "VaLoanData.VaStatutoryClosingCosts", "VaLoanData.VaStatutoryMonthlyPayment", "VaLoanData.VaStatutoryMonthlyReduction", "VaLoanData.VaStatutoryRecoupmentMonths" };

        private static readonly Dictionary<string, Dictionary<string, string>> s_propertiesToRename = new()
        {
            { nameof(AlertChangeCircumstance), new Dictionary<string, string> { { "AlertTriggerFielDID", "AlertTriggerFieldID" } } },
            { nameof(ExportLogServiceType), new Dictionary<string, string> { { "name", "Name" } } }
        };

        private static readonly Dictionary<string, EntitySchema> s_explicitSchemas = new()
        {
            { nameof(ElliUCDDetail), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "CDFields", new PropertySchema { Type = PropertySchemaType.String } }, { "LEFields", new PropertySchema { Type = PropertySchemaType.String } } } } },
            { nameof(DocumentAudit), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "ReportKey", new PropertySchema { Type = PropertySchemaType.String } }, { "TimeStamp", new PropertySchema { Type = PropertySchemaType.DateTime } }, { "Alerts", new PropertySchema { Type = PropertySchemaType.List, ElementType = "DocumentAuditAlert" } } } } },
            { nameof(DocumentAuditAlert), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "Source", new PropertySchema { Type = PropertySchemaType.String } }, { "Type", new PropertySchema { Type = PropertySchemaType.String } }, { "Text", new PropertySchema { Type = PropertySchemaType.String } }, { "Fields", new PropertySchema { Type = PropertySchemaType.List, ElementType = "string" } } } } },
            { nameof(EmailDocument), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "DocId", new PropertySchema { Type = PropertySchemaType.String } }, { "DocTitle", new PropertySchema { Type = PropertySchemaType.String } } } } },
            { nameof(OrderedDocument), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "Id", new PropertySchema { Type = PropertySchemaType.String } }, { "Title", new PropertySchema { Type = PropertySchemaType.String } }, { "Type", new PropertySchema { Type = PropertySchemaType.String } }, { "Category", new PropertySchema { Type = PropertySchemaType.String } }, { "SignatureType", new PropertySchema { Type = PropertySchemaType.String } }, { "PairId", new PropertySchema { Type = PropertySchemaType.String } }, { "DataKey", new PropertySchema { Type = PropertySchemaType.String } }, { "Size", new PropertySchema { Type = PropertySchemaType.Int } }, { "TemplateId", new PropertySchema { Type = PropertySchemaType.String } }, { "DocumentServiceId", new PropertySchema { Type = PropertySchemaType.String } }, { "OverflowDataKey", new PropertySchema { Type = PropertySchemaType.String } }, { "Overflows", new PropertySchema { Type = PropertySchemaType.List, ElementType = "OrderedDocumentOverflow" } } } } },
            { nameof(OrderedDocumentOverflow), new EntitySchema { Properties = new Dictionary<string, PropertySchema> { { "CoordinateBottom", new PropertySchema { Type = PropertySchemaType.String } }, { "CoordinateTop", new PropertySchema { Type = PropertySchemaType.String } }, { "CoordinateLeft", new PropertySchema { Type = PropertySchemaType.String } }, { "CoordinateRight", new PropertySchema { Type = PropertySchemaType.String } }, { "OriginalText", new PropertySchema { Type = PropertySchemaType.String } }, { "PageNumber", new PropertySchema { Type = PropertySchemaType.Int } }, { "TemplateFieldName", new PropertySchema { Type = PropertySchemaType.String } } } } }
        };

        private static readonly Dictionary<string, Dictionary<string, PropertySchema>> s_explicitPropertySchemas = new()
        {
            { nameof(NonVol), new Dictionary<string, PropertySchema> { { "Id", new PropertySchema { Type = PropertySchemaType.String } }, { "NonVolIndex", new PropertySchema { Type = PropertySchemaType.Int } }, { "NonVolId", new PropertySchema { Type = PropertySchemaType.String } } } },
            { nameof(CrmLog), new Dictionary<string, PropertySchema> { { "Alerts", new PropertySchema { Type = PropertySchemaType.List, ElementType = LoanEntity.LogAlert } }, { "CommentList", new PropertySchema { Type = PropertySchemaType.List, ElementType = LoanEntity.LogComment } }, { "Comments", new PropertySchema { Type = PropertySchemaType.String } }, { "DateUtc", new PropertySchema { Type = PropertySchemaType.DateTime } }, { "FileAttachmentsMigrated", new PropertySchema { Type = PropertySchemaType.Bool } }, { "Guid", new PropertySchema { Type = PropertySchemaType.String } }, { "IsSystemSpecificIndicator", new PropertySchema { Type = PropertySchemaType.Bool } }, { "LogRecordIndex", new PropertySchema { Type = PropertySchemaType.Int } } } },
            { nameof(DocumentOrderLog), new Dictionary<string, PropertySchema> { { "OrderedDocuments", new PropertySchema { Type = PropertySchemaType.List, ElementType = "OrderedDocument" } } } },
            { nameof(FundingFee), new Dictionary<string, PropertySchema> { { "Amount", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocAmount", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PtcAmount", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocBorrower2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocSeller2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocBroker2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocOther2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PacBroker2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PacLender2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PacOther2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, { "PocLender2015", new PropertySchema { Type = PropertySchemaType.Decimal } }, } },
            { nameof(HtmlEmailLog), new Dictionary<string, PropertySchema> { { "DocList", new PropertySchema { Type = PropertySchemaType.List, ElementType = "EmailDocument" } } } },
            { nameof(SelfEmployedIncome), new Dictionary<string, PropertySchema> { { "FieldValue", new PropertySchema { Type = PropertySchemaType.String, FieldInstances = new Dictionary<string, List<string>>
                {
                    { "FM1084.X105", new List<string> { "Application_SelfEmployedIncomes_Form1065_OwnershipPercent" } },
                    { "FM1084.X114", new List<string> { "Application_SelfEmployedIncomes_Form1120S_OwnershipPercent" } },
                    { "FM1084.X127", new List<string> { "Application_SelfEmployedIncomes_Form1120_OwnershipPercent" } },
                    { "FM1084.X134", new List<string> { "Application_SelfEmployedIncomes_None_Year2_FormB" } },
                    { "FM1084.X50", new List<string> { "Application_SelfEmployedIncomes_None_Year2_FormA" } },
                    { "FM1084.X6", new List<string> { "Application_SelfEmployedIncomes_None_Year1_FormA" } },
                    { "FM1084.X96", new List<string> { "Application_SelfEmployedIncomes_None_Year1_FormB" } }
                } } } } }
        };

        private static readonly Dictionary<string, HashSet<string>> s_explicitDateTimeProperties = new()
        {
            { nameof(DisclosureTracking2015Log), new() { nameof(DisclosureTracking2015Log.ActualFulfillmentDate), nameof(DisclosureTracking2015Log.ApplicationDate), nameof(DisclosureTracking2015Log.BorrowerActualReceivedDate), nameof(DisclosureTracking2015Log.BorrowerPresumedReceivedDate), nameof(DisclosureTracking2015Log.CDDateIssued), nameof(DisclosureTracking2015Log.ClosingDate), nameof(DisclosureTracking2015Log.CoBorrowerActualReceivedDate), nameof(DisclosureTracking2015Log.CoBorrowerPresumedReceivedDate), nameof(DisclosureTracking2015Log.DisclosedDate), nameof(DisclosureTracking2015Log.IntentToProceedDate), nameof(DisclosureTracking2015Log.LockedBorrowerPresumedReceivedDate), nameof(DisclosureTracking2015Log.LockedCoBorrowerPresumedReceivedDate), nameof(DisclosureTracking2015Log.LockedDisclosedDateField), nameof(DisclosureTracking2015Log.LockedDisclosedReceivedDate), nameof(DisclosureTracking2015Log.PresumedFulfillmentDate), nameof(DisclosureTracking2015Log.ReceivedDate), nameof(DisclosureTracking2015Log.RevisedDueDate), nameof(DisclosureTracking2015Log.ChangesReceivedDate) } }
        };

        private static readonly Dictionary<string, HashSet<string>> s_explicitStringDecimalValueProperties = new()
        {
            { nameof(Hmda), new() { nameof(Hmda.CLTV), nameof(Hmda.DebtToIncomeRatio), nameof(Hmda.DiscountPoints), nameof(Hmda.InterestRate), nameof(Hmda.LenderCredits), nameof(Hmda.PropertyValue), nameof(Hmda.RateSpread) } }
        };

        private static readonly Dictionary<string, HashSet<string>> s_enumOptionsToIgnore = new()
        {
            { nameof(LoanDocumentationType), new HashSet<string> { "NoIncomeon1003" } }
        };

        private static readonly HashSet<string> s_ignoredEntities = new() { "EntityRefContract" };

        private static readonly Dictionary<string, List<string>> s_mergeEntities = new() { };

        public static async Task Main()
        {
            try
            {
                Dictionary<string, EntitySchema> entityTypes;
                var standardFields = new Dictionary<string, Schema.v3.StandardFieldSchema>();
                var virtualFields = new Dictionary<string, Schema.v3.VirtualFieldSchema>();
                using (var client = await TestBaseClass.GetTestClientAsync().ConfigureAwait(false))
                {
                    entityTypes = (await client.Schema.GetLoanSchemaAsync(true).ConfigureAwait(false)).EntityTypes;
                    int start;
                    const int limit = 10000;
                    do
                    {
                        start = standardFields.Count;
                        var newFields = await Schema.v3.SchemaExtensions.GetStandardFieldSchemaAsync(client.Schema, new Schema.v3.StandardFieldRetrievalOptions(start, limit));
                        foreach (var newField in newFields)
                        {
                            standardFields.Add(newField.Id, newField);
                        }
                    } while (standardFields.Count > start);
                    var virtualFieldSchema = await Schema.v3.SchemaExtensions.GetVirtualFieldSchemaAsync(client.Schema).ConfigureAwait(false);
                    foreach (var virtualField in virtualFieldSchema)
                    {
                        virtualFields.Add(virtualField.Id, virtualField);
                    }
                }

                foreach (var ignoredEntity in s_ignoredEntities)
                {
                    entityTypes.Remove(ignoredEntity);
                }

                foreach (var pair in s_mergeEntities)
                {
                    var properties = entityTypes[pair.Key].Properties;
                    foreach (var entityToMerge in pair.Value)
                    {
                        var entityTypeToMerge = entityTypes[entityToMerge];
                        foreach (var p in entityTypeToMerge.Properties)
                        {
                            var name = p.Key;
                            if (!properties.ContainsKey(name))
                            {
                                properties.Add(name, p.Value);
                                Console.WriteLine($"Merged {entityToMerge}.{name} into {pair.Key}");
                            }
                        }
                        entityTypes.Remove(entityToMerge);
                    }
                }

                foreach (var pair in s_explicitSchemas)
                {
                    var entityName = pair.Key;
                    if (entityTypes.ContainsKey(entityName))
                    {
                        Console.WriteLine($"Can now retrieve schema for {entityName}");
                        entityTypes[entityName] = pair.Value;
                    }
                    else
                    {
                        entityTypes.Add(entityName, pair.Value);
                    }
                }

                foreach (var pair in s_explicitPropertySchemas)
                {
                    var entityName = pair.Key;
                    var properties = entityTypes[entityName].Properties;
                    foreach (var p in pair.Value)
                    {
                        var propertyName = p.Key;
                        if (properties.ContainsKey(propertyName))
                        {
                            Console.WriteLine($"Can now retrieve schema property {entityName}.{propertyName}");
                            properties[propertyName] = p.Value;
                        }
                        else
                        {
                            properties.Add(propertyName, p.Value);
                        }
                    }
                }

                foreach (var pair in entityTypes)
                {
                    if (s_propertiesToRename.TryGetValue(pair.Key, out var propertiesToRename))
                    {
                        var properties = pair.Value.Properties;
                        foreach (var p in propertiesToRename)
                        {
                            var property = properties[p.Key];
                            properties.Remove(p.Key);
                            properties.Add(p.Value, property);
                        }
                    }
                }

                var destinationPath = "Generated\\Loans\\v1";
                var @namespace = "EncompassRest.Loans.v1";
                Directory.CreateDirectory(destinationPath);

                var loanEntitySchema = entityTypes["Loan"];
                var fields = new Dictionary<string, StandardFieldInfo>(StringComparer.OrdinalIgnoreCase);
                var fieldPatterns = new Dictionary<string, StandardFieldInfo>(StringComparer.OrdinalIgnoreCase)
                {
                    { "CX.{0}", new StandardFieldInfo("CX.{0}", "Loan.CustomFields[(FieldName == 'CX.{0}')].StringValue", "loan.customFields[(fieldName == 'CX.{0}')].value") },
                    { "CUST{0:00}FV", new StandardFieldInfo("CUST{0:00}FV", "Loan.CustomFields[(FieldName == 'CUST{0:00}FV')].StringValue", "loan.customFields[(fieldName == 'CUST{0:00}FV')].value") }
                };

                var otherEnums = new Dictionary<string, Dictionary<string, string>>();

                LoanFieldDescriptors.PopulateFieldMappings("Loan", "Loan", null, loanEntitySchema, null, entityTypes, fields, fieldPatterns, extendedFieldInfo: false, (string entityName, Type ellieType, EntitySchema entitySchema, HashSet<string> requiredProperties, bool serializeWholeList) => GenerateClassFileFromSchema(destinationPath, @namespace, entityName, ellieType, entitySchema, otherEnums, requiredProperties, serializeWholeList), fieldId => standardFields.TryGetValue(fieldId, out var standardField) ? standardField.Description : null, Console.Out);

                entityTypes.Remove("Loan");

                foreach (var pair in entityTypes)
                {
                    var entityName = pair.Key;
                    if (!s_ignoredEntities.Contains(entityName))
                    {
                        Console.WriteLine($"{entityName} is not connected to the Loan schema");
                        GenerateClassFileFromSchema(destinationPath, @namespace, entityName, null, pair.Value, otherEnums, null, false);
                    }
                }

                var orderedFields = fields.Values.OrderBy(p => p.ModelPathV1.Substring(0, p.ModelPathV1.LastIndexOfAny(new[] { '.', '[' }))).ThenBy(p => p.ModelPathV1).ToList();

                var orderedFieldPatterns = fieldPatterns.Values.OrderBy(p => p.ModelPathV1.Substring(0, p.ModelPathV1.LastIndexOf('.'))).ThenBy(p => p.ModelPathV1).ToList();

                foreach (var field in orderedFields)
                {
                    if (standardFields.TryGetValue(field.FieldId, out var standardFieldSchema))
                    {
                        field.ModelPathV3 = standardFieldSchema.ContractPath;
                    }
                    else
                    {
                        Console.WriteLine($"Could not find field {field.FieldId} in standard fields");
                    }

                    if (field.NonSerializedFormat == LoanFieldFormat.YN)
                    {
                        if (standardFields.TryGetValue(field.FieldId, out var sdkDescriptor) && sdkDescriptor.Format != LoanFieldFormat.YN && sdkDescriptor.Options?.Count > 0 && (sdkDescriptor.Options.Count != 2 || (sdkDescriptor.Options[0].Value != "Y" && sdkDescriptor.Options[0].Value != "N") || (sdkDescriptor.Options[1].Value != "Y" && sdkDescriptor.Options[1].Value != "N")))
                        {
                            field.Format = sdkDescriptor.Format;
                            field.Options = sdkDescriptor.Options;
                            if (field.Options.Count > 1 && field.Options[1].Value.StartsWith("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                field.Options.Reverse();
                            }
                            field.ReadOnly = sdkDescriptor.ReadOnly;
                            Console.WriteLine($"{field.FieldId} {sdkDescriptor.Format} != {field.NonSerializedFormat}");
                        }
                    }
                }

                foreach (var field in orderedFieldPatterns)
                {
                    if (standardFields.TryGetValue(string.Format(field.FieldId, 0), out var standardFieldSchema) && !field.FieldId.StartsWith("CUST"))
                    {
                        field.ModelPathV3 = standardFieldSchema.ContractPath.Replace("%", "{0}");
                    }
                    else
                    {
                        Console.WriteLine($"Could not find field {field.FieldId} in standard fields");
                    }
                }

                using (var fs = new FileStream("Generated\\LoanFields.json", FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        JsonSerializer.Create(new JsonSerializerSettings { Formatting = Formatting.Indented }).Serialize(sw, orderedFields);
                    }
                }

                using (var fs = new FileStream("Generated\\LoanFieldPatterns.json", FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        JsonSerializer.Create(new JsonSerializerSettings { Formatting = Formatting.Indented }).Serialize(sw, orderedFieldPatterns);
                    }
                }

                var virtualFieldInfos = new List<VirtualFieldInfo>();
                var virtualFieldPatterns = new List<VirtualFieldInfo>();
                foreach (var virtualField in virtualFields.Values)
                {
                    VirtualFieldInfo virtualFieldInfo;
                    if (virtualField.MultiInstance)
                    {
                        virtualFieldInfo = new VirtualFieldInfo($"{virtualField.Id}.{{0}}")
                        {
                            Description = $@"{virtualField.Description} - {{0}}"
                        };
                        virtualFieldPatterns.Add(virtualFieldInfo);
                    }
                    else
                    {
                        virtualFieldInfo = new VirtualFieldInfo(virtualField.Id)
                        {
                            Description = virtualField.Description
                        };
                        virtualFieldInfos.Add(virtualFieldInfo);
                    }
                    virtualFieldInfo.Format = virtualField.Format;
                }

                var orderedVirtualFields = virtualFieldInfos.OrderBy(v => v.FieldId).ToList();
                var orderedVirtualFieldPatterns = virtualFieldPatterns.OrderBy(v => v.FieldId).ToList();

                using (var fs = new FileStream("Generated\\VirtualFields.json", FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        JsonSerializer.Create(new JsonSerializerSettings { Formatting = Formatting.Indented }).Serialize(sw, orderedVirtualFields);
                    }
                }

                using (var fs = new FileStream("Generated\\VirtualFieldPatterns.json", FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        JsonSerializer.Create(new JsonSerializerSettings { Formatting = Formatting.Indented }).Serialize(sw, orderedVirtualFieldPatterns);
                    }
                }

                using (var fs = new FileStream("Generated\\LoanFields.zip", FileMode.Create))
                {
                    using (var zip = new ZipArchive(fs, ZipArchiveMode.Create))
                    {
                        var serializer = JsonSerializer.Create();

                        var loanFieldsEntry = zip.CreateEntry("LoanFields.json", CompressionLevel.Optimal);
                        using (var sw = new StreamWriter(loanFieldsEntry.Open()))
                        {
                            serializer.Serialize(sw, orderedFields);
                        }

                        var loanFieldPatternsEntry = zip.CreateEntry("LoanFieldPatterns.json", CompressionLevel.Optimal);
                        using (var sw = new StreamWriter(loanFieldPatternsEntry.Open()))
                        {
                            serializer.Serialize(sw, orderedFieldPatterns);
                        }

                        var virtualFieldsEntry = zip.CreateEntry("VirtualFields.json", CompressionLevel.Optimal);
                        using (var sw = new StreamWriter(virtualFieldsEntry.Open()))
                        {
                            serializer.Serialize(sw, orderedVirtualFields);
                        }

                        var virtualFieldPatternsEntry = zip.CreateEntry("VirtualFieldPatterns.json", CompressionLevel.Optimal);
                        using (var sw = new StreamWriter(virtualFieldPatternsEntry.Open()))
                        {
                            serializer.Serialize(sw, orderedVirtualFieldPatterns);
                        }
                    }
                }

                var otherEnumsAsHashSet = otherEnums.ToDictionary(p => p.Key, p => new HashSet<string>(p.Value.Keys));

                foreach (var enumPair in s_sharedEnums.Concat(otherEnumsAsHashSet))
                {
                    foreach (var innerEnumPair in otherEnumsAsHashSet)
                    {
                        if (enumPair.Key != innerEnumPair.Key && innerEnumPair.Value.IsSubsetOf(enumPair.Value))
                        {
                            if (innerEnumPair.Value.SetEquals(enumPair.Value))
                            {
                                if (enumPair.Key.CompareTo(innerEnumPair.Key) < 0)
                                {
                                    Console.WriteLine($"{enumPair.Key} and {innerEnumPair.Key} are equal");
                                }
                            }
                            else
                            {
                                var diff = enumPair.Value.Except(innerEnumPair.Value).ToList();
                                if (diff.Count <= 2)
                                {
                                    Console.WriteLine($"{enumPair.Key} contains all members of {innerEnumPair.Key} but adds {string.Join(", ", diff)}");
                                }
                            }
                        }
                    }
                }
                var enumsPath = $"Generated\\Loans\\Enums";
                Directory.CreateDirectory(enumsPath);
                foreach (var pair in s_sharedEnums.ToDictionary(p => p.Key, p => p.Value.ToDictionary(s => s, s => (string)null)).Concat(otherEnums))
                {
                    GenerateEnumFileFromOptions(enumsPath, "EncompassRest.Loans.Enums", pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.Write("Press Enter to End.");
            Console.ReadLine();
        }

        private static void GenerateClassesFromJson(string destinationPath, string @namespace, string entityName, JObject jObject, HashSet<string> names, string nameSuffix = null)
        {
            var systemNamespace = false;
            var collectionsNamespace = false;
            var newtonsoftNamespace = false;

            var properties = new StringBuilder();
            var entities = new List<(string entityName, JObject jObject)>();

            foreach (var property in jObject.Properties().OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase))
            {
                var name = property.Name;
                var cleanName = new string(name.Where(c => char.IsLetterOrDigit(c)).ToArray());
                var propertyName = $"{char.ToUpper(cleanName[0])}{cleanName.Substring(1)}";
                string propertyType;
                string getter;
                var setter = "SetValue(value)";
                switch (property.Value.Type)
                {
                    case JTokenType.Boolean:
                        propertyType = "bool?";
                        getter = $"GetValue<{propertyType}>";
                        break;
                    case JTokenType.Date:
                        propertyType = "DateTime?";
                        systemNamespace = true;
                        getter = $"GetValue<{propertyType}>";
                        break;
                    case JTokenType.Float:
                        propertyType = "decimal?";
                        getter = $"GetValue<{propertyType}>";
                        break;
                    case JTokenType.Guid:
                    case JTokenType.String:
                        propertyType = "string?";
                        getter = $"GetValue<{propertyType}>";
                        break;
                    case JTokenType.Object:
                        propertyType = $"{propertyName}{nameSuffix}?";
                        if (!names.Add(propertyType))
                        {
                            propertyType = $"{entityName.Substring(0, entityName.Length - nameSuffix?.Length ?? 0)}{propertyName}{nameSuffix}?";
                            if (!names.Add(propertyType))
                            {
                                propertyType = $"{propertyName}Class{nameSuffix}?";
                                if (!names.Add(propertyType))
                                {
                                    propertyType = $"{entityName.Substring(0, entityName.Length - nameSuffix?.Length ?? 0)}{propertyName}Class{nameSuffix}?";
                                    if (!names.Add(propertyType))
                                    {
                                        throw new InvalidOperationException();
                                    }
                                }
                            }
                        }
                        entities.Add((propertyType, (JObject)property.Value));
                        getter = $"GetEntity<{propertyType}>";
                        setter = "SetEntity(value)";
                        break;
                    default:
                        // Need to handle the array case
                        throw new NotSupportedException();
                }

                properties.AppendLine().AppendLine($@"    /// <summary>
    /// {entityName} {propertyName}
    /// </summary>");
                if (cleanName != name)
                {
                    properties.AppendLine($"    [JsonProperty(\"{name}\")]");
                    newtonsoftNamespace = true;
                }
                properties.AppendLine($"    public {propertyType} {propertyName} {{ get => {getter}; set => {setter}; }}");
            }

            using (var sw = new StreamWriter(Path.Combine(destinationPath, entityName + ".cs")))
            {
                sw.Write($@"{(systemNamespace ? @"using System;
" : string.Empty)}{(collectionsNamespace ? @"using System.Collections.Generic;
" : string.Empty)}{(newtonsoftNamespace ? @"using Newtonsoft.Json;
" : string.Empty)}{(systemNamespace || collectionsNamespace || newtonsoftNamespace ? Environment.NewLine : string.Empty)}namespace {@namespace};

/// <summary>
/// {entityName}
/// </summary>
public sealed class {entityName} : DirtyExtensibleObject, IIdentifiable
{{{properties}}}");
            }

            foreach (var entity in entities)
            {
                GenerateClassesFromJson(destinationPath, @namespace, entity.entityName, entity.jObject, names, nameSuffix);
            }
        }

        private static void GenerateClassFileFromSchema(string destinationPath, string @namespace, string entityName, Type ellieType, EntitySchema entitySchema, Dictionary<string, Dictionary<string, string>> otherEnums, HashSet<string> requiredProperties, bool serializeWholeList)
        {
            var sb = new StringBuilder();

            var entityArguments = string.Empty;
            if (requiredProperties?.Count > 0)
            {
                entityArguments = $"PropertiesToAlwaysSerialize = nameof({string.Join(") + \",\" + nameof(", requiredProperties.OrderBy(p => p))})";
            }
            if (serializeWholeList)
            {
                entityArguments += $"{(entityArguments.Length > 0 ? ", " : string.Empty)}SerializeWholeListWhenDirty = true";
            }

            var systemNamespace = false;
            var collectionsNamespace = false;
            var enumsNamespace = false;
            var schemaNamespace = false;
            var codeAnalysisNamespace = false;

            if (ellieType != null)
            {
                foreach (var property in ellieType.GetProperties())
                {
                    if (!entitySchema.Properties.Any(p => string.Equals(p.Key.Replace("_", string.Empty), property.Name.Replace("_", string.Empty), StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"EncompassRest missing {ellieType.Name}.{property.Name} on {entityName}");
                    }
                }
            }

            var properties = new StringBuilder();

            foreach (var pair in entitySchema.Properties.OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase))
            {
                var propertyName = pair.Key.Replace("_", string.Empty);
                var entityPropertyName = $"{entityName}.{propertyName}";
                if (ellieType != null)
                {
                    var ellieProperty = ellieType.GetProperties().FirstOrDefault(p => string.Equals(propertyName, p.Name.Replace("_", string.Empty), StringComparison.OrdinalIgnoreCase));
                    var elliePropertyType = ellieProperty?.PropertyType;
                    if (ellieProperty == null)
                    {
                        Console.WriteLine($"Ellie missing {entityName}.{propertyName}");
                    }
                }
                if (!s_propertiesToNotGenerate.Contains(entityPropertyName))
                {
                    var propertySchema = pair.Value;
                    var attributeProperties = new List<string>();
                    var isField = !string.IsNullOrEmpty(propertySchema.FieldId) || propertySchema.FieldInstances?.Count > 0 || propertySchema.FieldPatterns?.Count > 0;
                    if (!string.IsNullOrEmpty(propertySchema.Format))
                    {
                        if (propertySchema.Format.EnumValue != LoanFieldFormat.STATE && propertySchema.Format.EnumValue != LoanFieldFormat.DECIMAL_2)
                        {
                            attributeProperties.Add($"Format = LoanFieldFormat.{propertySchema.Format.EnumValue?.GetName()}");
                            schemaNamespace = isField;
                        }
                    }
                    else
                    {
                        switch (propertySchema.Type.EnumValue)
                        {
                            case PropertySchemaType.DateTime:
                                attributeProperties.Add($"Format = LoanFieldFormat.DATETIME");
                                schemaNamespace = isField;
                                break;
                        }
                    }
                    if (propertySchema.ReadOnly == true)
                    {
                        attributeProperties.Add($"ReadOnly = true");
                    }
                    var propertyType = GetPropertyOrElementType(propertySchema, out var isEntity, out var isList);
                    HashSet<string> props;
                    if (s_explicitStringEnumValues.TryGetValue(entityPropertyName, out var enumName))
                    {
                        propertyType = $"StringEnumValue<{enumName}>";
                    }
                    else if (s_explicitDateTimeProperties.TryGetValue(entityName, out props) && props.Contains(propertyName))
                    {
                        propertyType = "DateTime?";
                    }
                    else if (s_explicitStringDecimalValueProperties.TryGetValue(entityName, out props) && props.Contains(propertyName))
                    {
                        propertyType = "StringDecimalValue";
                    }
                    else if (propertySchema.AllowedValues?.Count > 0)
                    {
                        if (propertyType == "string?")
                        {
                            var optionValues = propertySchema.AllowedValues.Where(o => !string.IsNullOrEmpty(o.Value) || !string.IsNullOrEmpty(o.Text)).Distinct().ToDictionary(o => o.Value, o => o.Text);
                            if (s_enumOptionsToIgnore.TryGetValue(propertyName, out var ignoredOptions))
                            {
                                foreach (var ignoredOption in ignoredOptions)
                                {
                                    optionValues.Remove(ignoredOption);
                                }
                            }
                            foreach (var enumPair in s_sharedEnums)
                            {
                                var setEquals = enumPair.Value.SetEquals(optionValues.Keys);
                                if (setEquals || (s_enumPropertyNamesToUseNotExactSharedEnum.Contains(propertyName) && enumPair.Value.IsSupersetOf(optionValues.Keys)))
                                {
                                    if (!setEquals)
                                    {
                                        var missingOptions = enumPair.Value.Except(optionValues.Keys);
                                        attributeProperties.Add($@"MissingOptionsJson = ""{JsonConvert.SerializeObject(missingOptions).Replace("\\", "\\\\").Replace("\"", "\\\"")}""");
                                    }
                                    enumName = enumPair.Key;
                                    var existingEnumType = typeof(ActionTaken).Assembly.GetType($"EncompassRest.Loans.Enums.{enumName}") ?? typeof(YOrN).Assembly.GetType($"EncompassRest.Loans.Enums.{enumName}");
                                    foreach (var member in Enums.GetMembers(existingEnumType))
                                    {
                                        var existingText = member.AsString(EnumFormat.Description, EnumFormat.EnumMemberValue, EnumFormat.Name);
                                        var value = member.AsString(EnumFormat.EnumMemberValue, EnumFormat.Name);
                                        if (optionValues.TryGetValue(value, out var text) && string.Equals(existingText, text, StringComparison.Ordinal))
                                        {
                                            optionValues.Remove(value);
                                        }
                                    }
                                    if (optionValues.Count > 0)
                                    {
                                        attributeProperties.Add($@"OptionsJson = ""{JsonConvert.SerializeObject(optionValues).Replace("\\", "\\\\").Replace("\"", "\\\"")}""");
                                    }
                                    break;
                                }
                            }
                            if (enumName == null)
                            {
                                enumName = GetEnumName(entityName, propertyName);
                                if (otherEnums.TryGetValue(enumName, out var enumValues))
                                {
                                    Console.WriteLine($"{entityName} Duplicate {enumName}: `{string.Join(", ", optionValues.Keys)}` - `{string.Join(", ", enumValues.Keys)}`");
                                }
                                else if (s_sharedEnums.TryGetValue(enumName, out var sharedEnumValues))
                                {
                                    Console.WriteLine($"{entityName} Shared Duplicate {enumName}: `{string.Join(", ", optionValues.Keys)}` - `{string.Join(", ", sharedEnumValues)}`");
                                }
                                else
                                {
                                    otherEnums.Add(enumName, optionValues);
                                }
                            }
                            propertyType = $"StringEnumValue<{enumName}>";
                        }
                        else if (propertyType == "bool?")
                        {
                            var optionValues = propertySchema.AllowedValues.Where(o => !string.IsNullOrEmpty(o.Text) && ((string.Equals(o.Value, "true", StringComparison.Ordinal) && !string.Equals(o.Text, "Yes", StringComparison.Ordinal)) || (string.Equals(o.Value, "false", StringComparison.Ordinal) && !string.Equals(o.Text, "No", StringComparison.Ordinal)))).ToDictionary(o => string.Equals(o.Value, "true", StringComparison.Ordinal) ? "Y" : "N", o => o.Text);
                            if (optionValues.Count > 0)
                            {
                                attributeProperties.Add($@"OptionsJson = ""{JsonConvert.SerializeObject(optionValues).Replace("\\", "\\\\").Replace("\"", "\\\"")}""");
                            }
                        }
                        else
                        {
                            var optionValues = propertySchema.AllowedValues.Where(o => !string.IsNullOrEmpty(o.Value) || !string.IsNullOrEmpty(o.Text)).ToDictionary(o => o.Value, o => o.Text);
                            if (optionValues.Count > 0)
                            {
                                attributeProperties.Add($@"OptionsJson = ""{JsonConvert.SerializeObject(optionValues).Replace("\\", "\\\\").Replace("\"", "\\\"")}""");
                            }
                        }
                    }
                    if (propertyType.StartsWith("StringEnumValue<"))
                    {
                        if (propertyType != "StringEnumValue<State>")
                        {
                            enumsNamespace = true;
                        }
                    }
                    else if (propertyType == "DateTime?")
                    {
                        systemNamespace = true;
                    }
                    var elementType = propertyType;
                    var isStringDictionary = s_stringDictionaryProperties.TryGetValue(entityName, out props) && props.Contains(propertyName);
                    if (isStringDictionary || isList)
                    {
                        collectionsNamespace = true;
                    }
                    var isNullable = propertySchema.Nullable == true;
                    if (isEntity && isNullable)
                    {
                        propertyType = $"{propertyType}?";
                    }
                    properties.AppendLine().AppendLine($@"    /// <summary>
    /// {(string.IsNullOrEmpty(propertySchema.Description) ? $"{entityName} {propertyName}" : propertySchema.Description.Replace("&", "&amp;"))}{(string.IsNullOrEmpty(propertySchema.FieldId) ? (propertySchema.FieldInstances?.Count >= 1 && propertySchema.FieldInstances.Count <= 2 ? $" [{string.Join("], [", propertySchema.FieldInstances.Keys)}]" : (propertySchema.FieldPatterns?.Count >= 1 && propertySchema.FieldPatterns.Count <= 2 ? $" [{string.Join("], [", propertySchema.FieldPatterns.Keys)}]" : string.Empty)) : $" [{propertySchema.FieldId}]")}
    /// </summary>");
                    if ((isEntity && !isNullable) || isList || isStringDictionary)
                    {
                        properties.AppendLine($"    [AllowNull]");
                        codeAnalysisNamespace = true;
                    }
                    if (isField && attributeProperties.Count > 0)
                    {
                        properties.AppendLine($"    [LoanFieldProperty({string.Join(", ", attributeProperties)})]");
                    }
                    if (isEntity && !isNullable)
                    {
                        properties.AppendLine($"    public {propertyType} {propertyName} {{ get => GetEntity<{propertyType}>(); set => SetEntity(value); }}");
                    }
                    else if (isList)
                    {
                        properties.AppendLine($"    public IList<{elementType}> {propertyName} {{ get => GetList<{elementType}>(); set => SetList(value); }}");
                    }
                    else if (isStringDictionary)
                    {
                        properties.AppendLine($"    public IDictionary<string, string?> {propertyName} {{ get => GetDictionary<string, string?>(); set => SetDictionary(value); }}");
                    }
                    else
                    {
                        properties.AppendLine($"    public {propertyType} {propertyName} {{ get => GetValue<{propertyType}>(); set => SetValue(value); }}");
                    }
                }
            }

            using (var sw = new StreamWriter(Path.Combine(destinationPath, entityName + ".cs")))
            {
                sw.Write($@"{(systemNamespace ? @"using System;
" : string.Empty)}{(collectionsNamespace ? @"using System.Collections.Generic;
" : string.Empty)}{(codeAnalysisNamespace ? @"using System.Diagnostics.CodeAnalysis;
" : string.Empty)}{(enumsNamespace ? $@"using EncompassRest.Loans.Enums;
" : string.Empty)}{(schemaNamespace ? @"using EncompassRest.Schema;
" : string.Empty)}{(systemNamespace || collectionsNamespace || enumsNamespace || schemaNamespace ? Environment.NewLine : string.Empty)}namespace {@namespace};

/// <summary>
/// {entityName}
/// </summary>
{(entityArguments.Length > 0 ? $@"[Entity({entityArguments})]
" : string.Empty)}public sealed partial class {entityName} : DirtyExtensibleObject, IIdentifiable
{{{properties}}}");
            }
        }

        private static void GenerateEnumFileFromOptions(string destinationPath, string @namespace, string enumName, Dictionary<string, string> options)
        {
            var componentModelNamespace = false;
            var serializationNamespace = false;

            var members = new StringBuilder();

            var enumMemberNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var existingEnumType = typeof(ActionTaken).Assembly.GetType($"EncompassRest.Loans.Enums.{enumName}");
            var existingEnumValues = new HashSet<int>();
            var first = true;
            if (existingEnumType != null)
            {
                var existingMembersNowMissing = new List<EnumMember>();
                foreach (var member in Enums.GetMembers(existingEnumType))
                {
                    if (!first)
                    {
                        members.AppendLine(",");
                    }
                    var name = member.Name;
                    var value = member.AsString(EnumFormat.EnumMemberValue);
                    var text = member.AsString(EnumFormat.Description);
                    if (options.TryGetValue(value ?? name, out var optionText) && optionText != null)
                    {
                        text = optionText;
                    }
                    members.AppendLine($@"    /// <summary>
    /// {(text ?? value ?? name).Replace("&", "&amp;")}
    /// </summary>");

                    if (!string.IsNullOrEmpty(text) && !string.Equals(text, value ?? name, StringComparison.Ordinal))
                    {
                        members.AppendLine($@"    [Description(""{text.Replace("\\", "\\\\").Replace("\"", "\\\"")}"")]");
                        componentModelNamespace = true;
                    }
                    if (value != null && !string.Equals(value, name, StringComparison.Ordinal))
                    {
                        members.AppendLine($@"    [EnumMember(Value = ""{value.Replace("\\", "\\\\").Replace("\"", "\\\"")}"")]");
                        serializationNamespace = true;
                    }
                    enumMemberNames.Add(name);
                    if (!options.Remove(value ?? name))
                    {
                        existingMembersNowMissing.Add(member);
                    }
                    var intValue = member.ToInt32();
                    existingEnumValues.Add(intValue);
                    members.Append($"    {name} = {intValue}");
                    first = false;
                }
                if (existingMembersNowMissing.Count > 0)
                {
                    Console.WriteLine($"{existingEnumType} is now missing the existing members {string.Join(", ", existingMembersNowMissing)}");
                }
            }
            var i = 0;
            foreach (var pair in options)
            {
                while (existingEnumValues.Contains(i))
                {
                    ++i;
                }
                if (!first)
                {
                    members.AppendLine(",");
                }
                var value = pair.Key;
                var text = pair.Value;
                var option = value;
                if (string.IsNullOrEmpty(option))
                {
                    option = text;
                }
                var nameBuilder = new StringBuilder(option.Length);
                var startWord = true;
                for (var j = 0; j < option.Length; ++j)
                {
                    var c = option[j];
                    if (j == 0 && char.IsDigit(c))
                    {
                        nameBuilder.Append('n');
                    }
                    if (!char.IsLetterOrDigit(c))
                    {
                        if (!startWord && c != '\'')
                        {
                            startWord = true;
                        }
                    }
                    else
                    {
                        if (startWord)
                        {
                            c = char.ToUpper(c);
                            startWord = false;
                        }
                        nameBuilder.Append(c);
                    }
                }
                var name = nameBuilder.ToString();
                if (name.Length > 0 && enumMemberNames.Add(name))
                {
                    members.AppendLine($@"    /// <summary>
    /// {(text ?? value).Replace("&", "&amp;")}
    /// </summary>");
                    if (!string.IsNullOrEmpty(text) && !string.Equals(value, text, StringComparison.Ordinal))
                    {
                        members.AppendLine($@"    [Description(""{text.Replace("\\", "\\\\").Replace("\"", "\\\"")}"")]");
                        componentModelNamespace = true;
                    }
                    if (!string.Equals(value, name, StringComparison.Ordinal))
                    {
                        members.AppendLine($@"    [EnumMember(Value = ""{value.Replace("\\", "\\\\").Replace("\"", "\\\"")}"")]");
                        serializationNamespace = true;
                    }
                    members.Append($"    {name} = {i}");
                    first = false;
                    ++i;
                }
                else if (i > 0)
                {
                    members.Length -= 1 + Environment.NewLine.Length;
                }
            }

            using (var sw = new StreamWriter(Path.Combine(destinationPath, enumName + ".cs")))
            {
                sw.Write($@"{(componentModelNamespace ? @"using System.ComponentModel;
" : string.Empty)}{(serializationNamespace ? @"using System.Runtime.Serialization;
" : string.Empty)}{(componentModelNamespace || serializationNamespace ? Environment.NewLine : string.Empty)}namespace {@namespace};

/// <summary>
/// {enumName}
/// </summary>
public enum {enumName}
{{
{members}
}}");
            }
        }

        private static string GetPropertyOrElementType(PropertySchema propertySchema, out bool isEntity, out bool isList)
        {
            isEntity = false;
            isList = false;
            if (propertySchema.Format.EnumValue == LoanFieldFormat.STATE)
            {
                return "StringEnumValue<State>";
            }

            var propertyType = propertySchema.Type;
            switch (propertyType.EnumValue)
            {
                case PropertySchemaType.String:
                case PropertySchemaType.Uuid:
                    return "string?";
                case PropertySchemaType.NADecimal:
                    return "NA<decimal>";
                case PropertySchemaType.Decimal:
                case PropertySchemaType.Bool:
                case PropertySchemaType.Int:
                    return $"{propertyType}?";
                case PropertySchemaType.Date:
                case PropertySchemaType.DateTime:
                    return "DateTime?";
                case PropertySchemaType.Set:
                case PropertySchemaType.List:
                    isList = true;
                    var elementType = propertySchema.ElementType.Value;
                    return elementType == "EntityRefContract" ? "EntityReference" : elementType;
                case PropertySchemaType.Entity:
                    isEntity = true;
                    var propertyEntityType = propertySchema.EntityType.Value;
                    return propertyEntityType == "EntityRefContract" ? "EntityReference" : propertyEntityType;
                default:
                    return $"PROBLEM<{propertyType}>";
            }
        }

        private static string GetEnumName(string entityType, string propertyName)
        {
            if (!s_enumPropertyNamesToUseEntityTypeInName.Contains(propertyName))
            {
                return propertyName;
            }
            var firstWord = propertyName;
            var camelCasedName = new CamelCaseNamingStrategy().GetPropertyName(propertyName, false);
            for (var i = 1; i < camelCasedName.Length; ++i)
            {
                if (!char.IsLower(camelCasedName[i]))
                {
                    firstWord = camelCasedName.Substring(0, i);
                    break;
                }
            }
            if (entityType.EndsWith(firstWord))
            {
                return $"{entityType.Substring(0, entityType.Length - firstWord.Length)}{propertyName}";
            }
            return $"{entityType}{propertyName}";
        }
    }
}