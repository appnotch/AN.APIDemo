using AN.APIDemo.Models;

namespace AN.APIDemo.API
{
	public class TenantMemberAPI : APIWrapper
	{
		#region GET

		/// <summary>
		/// Get tenant member by Id.
		/// </summary>
		/// <param name="id">Tenant member id.</param>
		public TenantMember GetTenantMember(int id)
		{
			var url = $"v2/tenantmember/{id}";

			var result = ExecuteGet<TenantMember>(url);

			return result;
		}

		/// <summary>
		/// Get tenant member by email.
		/// </summary>
		/// <param name="email">Tenant member email.</param>
		public TenantMember GetTenantMember(string email)
		{
			var url = $"v2/tenantmember?email={email}";

			var result = ExecuteGet<TenantMember>(url);

			return result;
		}

		/// <summary>
		/// Create a new tenant member.
		/// </summary>
		/// <param name="tenantMember">Tenant member to create.</param>
		public TenantMember Create(TenantMember tenantMember)
		{
			var url = $"v2/tenantmember";

			var result = ExecutePost<TenantMember>(url, tenantMember);

			return result;
		}

		/// <summary>
		/// Assiciate tenant member with the tenant.
		/// </summary>
		/// <param name="tenantMemberId">Tenant member id.</param>
		/// <param name="tenantId">Tenant id.</param>
		public TenantMember Associate(int tenantMemberId, int tenantId)
		{
			var url = $"v2/tenantmember/{tenantMemberId}/associate/{tenantId}";

			var result = ExecutePost<TenantMember>(url);

			return result;
		}

		/// <summary>
		/// Update existing tenant member.
		/// </summary>
		/// <param name="tenantMember">Tenant member with updated information.</param>
		/// <returns></returns>
		public TenantMember Update(TenantMember tenantMember)
		{
			var url = $"v2/tenantmember/{tenantMember.Id}";

			var result = ExecutePost<TenantMember>(url, tenantMember);

			return result;
		}

		#endregion
	}
}
