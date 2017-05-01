using System.Collections.Generic;

namespace AN.APIWrapper.Models
{
    public class TenantPagedList
    {
        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// Total number of records found.
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// List of tenants.
        /// </summary>
        public List<Tenant> List { get; set; }
    }
}
