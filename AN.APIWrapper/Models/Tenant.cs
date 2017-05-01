namespace AN.APIWrapper.Models
{
	public class Tenant
	{
		public int Id { get; set; }
		public int AppId { get; set; }
		public string DisplayName { get; set; }
		public string IconUrl { get; set; }
		public string SplashUrl { get; set; }
		public string Url { get; set; }
		public bool Disabled { get; set; }
		public bool Hidden { get; set; }
		public int DisplayOrder { get; set; }
		public string FooterUrl { get; set; }
		public string ShareContent { get; set; }
		public string BranchUrl { get; set; }
		public string Description { get; set; }
	}
}
