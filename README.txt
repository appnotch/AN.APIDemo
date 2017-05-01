# AN.APIDemo
This C# .NET solution illustrates how you can interact with the AppNotch Tenant API that will enable automation for your organization.

What is in the solution?
========================================================
1.) AN.APIDemo : A C# console applciation that contains the wrapper for creating the JWT token and the wrapper that contains the call to
    the tenant API.
2.) AN.APITest : Test project. To be able to run the tests within this project, you need to configure the TenantTestData.cs class found
    within this project.

A couple you need to know aside from C# programming knowelge and the .NET framework
========================================================
1.) This project uses JWT Nuget package. (https://github.com/jwt-dotnet/jwt)
2.) This project uses Newtonsoft.Json NuGet package to serialize/deserialize the parameters and result from the API calls.
3.) The API User and Secret are stored in the config file which are being ulled by a static class called Configration.
4.) If you are curious about the authorization part, look into AppNotchJwt class within the demo project.

How to use the TenantAPI?
========================================================
Simple, within the class that will use the API, initialize an instance of the TenantAPI class then call API methods directly from it.

	var tenantApi = new TenantAPI();
	var tenants = tenantApi.GetActiveTenants(1 /* my app id */);
      
Calling methods within this class will handle creation of JWT tokens (per request) add it into the header for the request and return
the result is applicable.

