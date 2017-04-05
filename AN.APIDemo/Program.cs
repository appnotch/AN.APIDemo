using AN.APIDemo.API;

namespace AN.APIDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var tenantApi = new TenantAPI();
			var tenants = tenantApi.GetActiveTenants(2417);
		}
	}
}
