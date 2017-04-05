using AN.APIDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AN.APIDemo.API
{
    public class TenantAPI : APIWrapper
    {

        #region GET methods

        /// <summary>
        /// Retrieves full details of all Tenants for an Application, including disabled ones. Returns Not Found if App doesn't exist or is not a Multi-Tenant App.
        /// </summary>
        /// <param name="appId">Application Id to fetch tenants for.</param>
        /// <param name="tag">Optional case sensitive value to filter results on their tag with.</param>
        public List<Tenant> GetTenants(int appId, string tag = "")
        {
            var url = string.IsNullOrEmpty(tag)
                ? $"v2/apps/{appId}/tenants"
                : $"v2/apps/{appId}/tenants/full?tag={tag}";

            var result = ExecuteGet<List<Tenant>>(url);

            return result;
        }

        /// <summary>
        /// Retrieves full details of all active Tenants for an Application. Returns Not Found if App doesn't exist or is not a Multi-Tenant App.
        /// </summary>
        /// <param name="appId">Application Id to fetch tenants for.</param>
        /// <param name="tag">Optional case sensitive value to filter results on their tag with.</param>
        public List<Tenant> GetActiveTenants(int appId, string tag = "")
        {
            var url = string.IsNullOrEmpty(tag)
                ? $"v2/apps/{appId}/tenants/active"
                : $"v2/apps/{appId}/tenants/active/full?tag={tag}";

            var result = ExecuteGet<List<Tenant>>(url);

            return result;
        }

        /// <summary>
        /// Retrieves all active Tenants for an Application. Returns Not Found if App doesn't exist or is not a Multi-Tenant App.
        /// </summary>
        /// <param name="appId">Application Id to fetch tenants for.</param>
        /// <param name="page">Next page you want to get.</param>
        /// <param name="display">Number of records to get.</param>
        public TenantPagedList GetActiveTenants(int appId, int page, int display)
        {
            var url = $"v2/apps/{appId}/tenants/active/page/{page}/display?display={display}";

            var result = ExecuteGet<TenantPagedList>(url);

            return result;
        }

        /// <summary>
        /// Retreives all tenants within the app that matches the filter.
        /// </summary>
        /// <param name="appId">Application Id to fetch tenants for.</param>
        /// <param name="searchFilter">Filter (Tenant Name).</param>
        public List<Tenant> SearchTenants(int appId, string searchFilter)
        {
            var url = $"v2/apps/{appId}/tenants/active/search?searchFilter={searchFilter}";

            var result = ExecuteGet<List<Tenant>>(url);

            return result;
        }

        /// <summary>
        /// Retrieves full or partial information for a tenant of an Application.
        /// </summary>
        /// <param name="appId">Application Id to fetch tenants for.</param>
        /// <param name="tenantId">Id of the Tenant to retrieve.</param>
        /// <param name="isFull">True to get full info about the tenant app.</param>
        public Tenant GetTenant(int appId, int tenantId, bool isFull = false)
        {
            var url = isFull
                ? $"v2/apps/{appId}/tenants/{tenantId}/full"
                : $"v2/apps/{appId}/tenants/{tenantId}";

            var result = ExecuteGet<Tenant>(url);

            return result;
        }

        /// <summary>
        /// Retrieves all members that has access to the tenant. Returns Not Found if it does not have any information to return.
        /// </summary>
        /// <param name="appId">Application Id.</param>
        /// <param name="tenantId">Tenant Id to fetch the members for.</param>
        public List<TenantMember> GetAllTenantMembers(int appId, int tenantId)
        {
            var url = $"v2/apps/{appId}/tenants/{tenantId}/members";

            var result = ExecuteGet<List<TenantMember>>(url);

            return result;
        }

        #endregion

        #region DELETE method

        public void DeleteTenant(int appId, int tenantId)
        {
            var url = $"v2/apps/{appId}/tenants/{tenantId}";

            ExecuteDelete(url);
        }

        #endregion

        #region PUT method

        /// <summary>
        /// Update a tenant for a specific app.
        /// </summary>
        /// <param name="appId">Application Id.</param>
        /// <param name="tenantId">Tenant id to update.</param>
        /// <param name="tenantEditor">Editor object that contains the updated data.</param>
        public Tenant Update(int appId, int tenantId, TenantEditor tenantEditor)
        {
            var url = $"v2/apps/{appId}/tenants/{tenantId}";

            var result = ExecutePut<Tenant>(url, tenantEditor);

            return result;
        }

        #endregion

        #region POST method

        /// <summary>
        /// Create a new tenant for a specific app.
        /// </summary>
        /// <param name="appId">Application Id.</param>
        /// <param name="tenantEditor">Editor object that contains the updated data.</param>
        public Tenant Create(int appId, TenantEditor tenantEditor)
        {
            var url = $"v2/apps/{appId}/tenants";

            var result = ExecutePost<Tenant>(url, tenantEditor);

            return result;
        }

        #endregion

    }
}
