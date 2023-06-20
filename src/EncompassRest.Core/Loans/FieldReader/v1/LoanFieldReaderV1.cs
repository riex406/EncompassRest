﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EncompassRest.Loans.v1;
using EncompassRest.Utilities;

namespace EncompassRest.Loans.FieldReader.v1
{
    /// <summary>
    /// The Loan Field Reader Apis.
    /// </summary>
    public interface ILoanFieldReaderV1 : ILoanApiObject
    {
        /// <summary>
        /// Retrieve values for specific fields in a loan as raw json.
        /// </summary>
        /// <param name="fieldIds">Field IDs of the values you want to retrieve from the loan as raw json.</param>
        /// <param name="queryString">The query string to include in the request.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns></returns>
        Task<string> GetLoanFieldValuesRawAsync(string fieldIds, string? queryString = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Retrieve values for specific fields in a loan.
        /// </summary>
        /// <param name="includeMetadata">If set to true, the response will include the metadata for the fields specified, and returns details such as format, description, type, options and readOnly indicator.Default behavior is false, in which case, only the fieldId and value are returned for the fields in the request body.</param>
        /// <param name="fieldIds">Field IDs of the values you want to retrieve from the loan.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns></returns>
        Task<List<LoanFieldValue>> GetLoanFieldValuesAsync(bool? includeMetadata, IEnumerable<string> fieldIds, CancellationToken cancellationToken = default);
    }

    internal sealed class LoanFieldReaderV1 : LoanApiObjectV1, ILoanFieldReaderV1
    {
        internal LoanFieldReaderV1(EncompassRestClient client, ILoanApis loanApis, string loanId)
            : base(client, loanApis, loanId, "fieldReader")
        {
        }

        public Task<List<LoanFieldValue>> GetLoanFieldValuesAsync(bool? includeMetadata, IEnumerable<string> fieldIds, CancellationToken cancellationToken = default)
        {
            Preconditions.NotNullOrEmpty(fieldIds, nameof(fieldIds));

            QueryParameters? queryParameters = null;
            if (includeMetadata.HasValue)
            {
                queryParameters = new QueryParameters();
                queryParameters.Add("includeMetadata", includeMetadata.ToString().ToLower());
            }

            return PostAsync<List<LoanFieldValue>>(null, queryParameters?.ToString(), JsonStreamContent.Create(fieldIds), nameof(GetLoanFieldValuesAsync), null, cancellationToken);
        }

        public Task<string> GetLoanFieldValuesRawAsync(string fieldIds, string? queryString = null, CancellationToken cancellationToken = default)
        {
            Preconditions.NotNullOrEmpty(fieldIds, nameof(fieldIds));

            return PostRawAsync(null, queryString, new JsonStringContent(fieldIds), nameof(GetLoanFieldValuesRawAsync), null, cancellationToken);
        }
    }
}