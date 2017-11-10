using AN.APIWrapper.API;
using AN.APIWrapper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AN.APITest
{
	[TestClass]
	public class TenantAPITest
	{
		private TenantAPI GetTenantApi()
		{
			var url = ConfigurationManager.AppSettings["AN-APIUrl"];
			var subject = ConfigurationManager.AppSettings["AN-Subject"];
			var secret = ConfigurationManager.AppSettings["AN-Secret"];

			return new TenantAPI(url, subject, secret);
		}

		[TestMethod]
		public void GetActiveTenantsByAppId()
		{
			var tenants = GetTenantApi().GetActiveTenants(TenantTestData.APP_ID);
			Assert.IsTrue(tenants.Any());
		}

		[TestMethod]
		public void GetActiveTenantsByAppIdAndTag()
		{
			var tenants = GetTenantApi().GetActiveTenants(TenantTestData.APP_ID, TenantTestData.TENANT_TAG);
			Assert.IsTrue(tenants.Any());
		}

		[TestMethod]
		public void GetTenantsByAppId()
		{
			var tenants = GetTenantApi().GetTenants(TenantTestData.APP_ID);
			Assert.IsTrue(tenants.Any());
		}

		[TestMethod]
		public void GetTenantsByAppIdAndTag()
		{
			var tenants = GetTenantApi().GetTenants(TenantTestData.APP_ID, TenantTestData.TENANT_TAG);
			Assert.IsTrue(tenants.Any());
		}

		[TestMethod]
		public void GetTenantsByAppIdPaged()
		{
			var tenants = GetTenantApi().GetActiveTenants(TenantTestData.APP_ID, 0, 10);
			Assert.IsTrue(tenants.List.Any());
		}

		[TestMethod]
		public void GetTenantsByKeyword()
		{
			var tenants = GetTenantApi().SearchTenants(TenantTestData.APP_ID, TenantTestData.SEARCH_FILTER);
			Assert.IsTrue(tenants.Any());
		}

		[TestMethod]
		public void GetTenantById()
		{
			var tenant = GetTenantApi().GetTenant(TenantTestData.APP_ID, TenantTestData.TENANT_ID);
			Assert.IsNotNull(tenant);
		}

		[TestMethod]
		public void GetTenantFullById()
		{
			var tenant = GetTenantApi().GetTenant(TenantTestData.APP_ID, TenantTestData.TENANT_ID, true);
			Assert.IsNotNull(tenant);
		}

		[TestMethod]
		public void GetTenantMembers()
		{
			var members = GetTenantApi().GetAllTenantMembers(TenantTestData.APP_ID, TenantTestData.TENANT_ID);
			Assert.IsTrue(members.Any());
		}

		[TestMethod]
		public void CreateUpdateDeleteTenant()
		{
			// creeate
			var tenantEditor = new TenantEditor
			{
				AppId = TenantTestData.APP_ID,
				Description = "New tenant from test.",
				Disabled = false,
				DisplayName = "My new tenant",
				DisplayOrder = 1,
				FirstName = "John",
				LastName = "Doe",
				Footer = new Footer
				{
					FooterType = FooterType.IconAndText,
					FooterData = new List<FooterItem>()
				},
				Hidden = false,
				IconUrl = "https://appnotch.com",
				Phone = "(314) 210-1234",
				SocialDescription = "My social description.",
				SplashUrl = "https://appnotch.com",
				SupportEmail = "test@appnotch.com",
				SupportSite = "https://api.appnotch.com",
				Tag = "test_tenant",
				Url = "https://appnotch.com"
			};

			var newTenant = GetTenantApi().Create(TenantTestData.APP_ID, tenantEditor);
			Assert.IsTrue(newTenant.AppId > 0);

			// update 
			const string updatedDescription = "Updated description";
			const string updatedDisplayName = "My updated tenant";
			tenantEditor.Description = updatedDescription;
			tenantEditor.DisplayName = updatedDisplayName;

			var updatedTenant = GetTenantApi().Update(TenantTestData.APP_ID, newTenant.Id, tenantEditor);

			Assert.IsTrue(updatedTenant.Description == updatedDescription);
			Assert.IsTrue(updatedTenant.DisplayName == updatedDisplayName);

			GetTenantApi().DeleteTenant(TenantTestData.APP_ID, updatedTenant.Id);

			var deletedApp = GetTenantApi().GetTenant(TenantTestData.APP_ID, updatedTenant.Id);

			Assert.IsNull(deletedApp);
		}
	}
}
