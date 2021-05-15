﻿namespace EncompassRest.LoanFolders
{
    /// <summary>
    /// The Loan Folders Apis exposed as extension methods
    /// within the EncompassRest.LoanFolders.v1 and v3 namespaces.
    /// </summary>
    public interface ILoanFolders : IApiObject
    {
    }

    internal sealed class LoanFolders : ApiObject, ILoanFolders
    {
        internal LoanFolders(EncompassRestClient client)
            : base(client, null)
        {
        }
    }
}