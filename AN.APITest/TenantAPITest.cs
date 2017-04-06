using AN.APIDemo.API;
using AN.APIDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AN.APITest
{
    [TestClass]
    public class TenantAPITest
    {
        private TenantAPI _tenantApi = new TenantAPI();

        [TestMethod]
        public void GetActiveTenantsByAppId()
        {
            var tenants = _tenantApi.GetActiveTenants(TenantTestData.APP_ID);
            Assert.IsTrue(tenants.Any());
        }

        [TestMethod]
        public void GetActiveTenantsByAppIdAndTag()
        {
            var tenants = _tenantApi.GetActiveTenants(TenantTestData.APP_ID, TenantTestData.TENANT_TAG);
            Assert.IsTrue(tenants.Any());
        }

        [TestMethod]
        public void GetTenantsByAppId()
        {
            var tenants = _tenantApi.GetTenants(TenantTestData.APP_ID);
            Assert.IsTrue(tenants.Any());
        }

        [TestMethod]
        public void GetTenantsByAppIdAndTag()
        {
            var tenants = _tenantApi.GetTenants(TenantTestData.APP_ID, TenantTestData.TENANT_TAG);
            Assert.IsTrue(tenants.Any());
        }

        [TestMethod]
        public void GetTenantsByAppIdPaged()
        {
            var tenants = _tenantApi.GetActiveTenants(TenantTestData.APP_ID, 0, 10);
            Assert.IsTrue(tenants.List.Any());
        }

        [TestMethod]
        public void GetTenantsByKeyword()
        {
            var tenants = _tenantApi.SearchTenants(TenantTestData.APP_ID, TenantTestData.SEARCH_FILTER);
            Assert.IsTrue(tenants.Any());
        }

        [TestMethod]
        public void GetTenantById()
        {
            var tenant = _tenantApi.GetTenant(TenantTestData.APP_ID, TenantTestData.TENANT_ID);
            Assert.IsNotNull(tenant);
        }

        [TestMethod]
        public void GetTenantFullById()
        {
            var tenant = _tenantApi.GetTenant(TenantTestData.APP_ID, TenantTestData.TENANT_ID, true);
            Assert.IsNotNull(tenant);
        }

        [TestMethod]
        public void GetTenantMembers()
        {
            var members = _tenantApi.GetAllTenantMembers(TenantTestData.APP_ID, TenantTestData.TENANT_ID);
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
                SupportSite = "https://appnotch.com/converter/api",
                Tag = "test_tenant",
                Url = "https://appnotch.com"
            };

            var newTenant = _tenantApi.Create(TenantTestData.APP_ID, tenantEditor);
            Assert.IsTrue(newTenant.AppId > 0);

            // update 
            const string updatedDescription = "Updated description";
            const string updatedDisplayName = "My updated tenant";
            tenantEditor.Description = updatedDescription;
            tenantEditor.DisplayName = updatedDisplayName;

            var updatedTenant = _tenantApi.Update(TenantTestData.APP_ID, newTenant.Id, tenantEditor);

            Assert.IsTrue(updatedTenant.Description == updatedDescription);
            Assert.IsTrue(updatedTenant.DisplayName == updatedDisplayName);

            _tenantApi.DeleteTenant(TenantTestData.APP_ID, updatedTenant.Id);

            var deletedApp = _tenantApi.GetTenant(TenantTestData.APP_ID, updatedTenant.Id);

            Assert.IsNull(deletedApp);
        }
    }
}
