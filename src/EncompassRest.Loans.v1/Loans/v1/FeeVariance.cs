using EncompassRest.Loans.Enums;

namespace EncompassRest.Loans.v1;

/// <summary>
/// FeeVariance
/// </summary>
[Entity(PropertiesToAlwaysSerialize = nameof(FeeVarianceChargeIndex) + "," + nameof(FeeVarianceFeeType))]
public sealed partial class FeeVariance : DirtyExtensibleObject, IIdentifiable
{
    /// <summary>
    /// FeeVariance CD
    /// </summary>
    public decimal? CD { get => GetValue<decimal?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance Description
    /// </summary>
    public string? Description { get => GetValue<string?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance FeeVarianceChargeIndex
    /// </summary>
    public int? FeeVarianceChargeIndex { get => GetValue<int?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance FeeVarianceFeeType
    /// </summary>
    public StringEnumValue<FeeVarianceFeeType> FeeVarianceFeeType { get => GetValue<StringEnumValue<FeeVarianceFeeType>>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance Id
    /// </summary>
    public string? Id { get => GetValue<string?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance InitialLE
    /// </summary>
    public decimal? InitialLE { get => GetValue<decimal?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance Itemization
    /// </summary>
    public decimal? Itemization { get => GetValue<decimal?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance LE
    /// </summary>
    public decimal? LE { get => GetValue<decimal?>(); set => SetValue(value); }

    /// <summary>
    /// FeeVariance Line
    /// </summary>
    public string? Line { get => GetValue<string?>(); set => SetValue(value); }
}