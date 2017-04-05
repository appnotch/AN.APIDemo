using System.Collections.Generic;

namespace AN.APIDemo.Models
{
	public class TenantEditor
	{
		public int AppId { get; set; }
		public string DisplayName { get; set; }
		public string IconUrl { get; set; }
		public string SplashUrl { get; set; }
		public string Url { get; set; }
		public bool Disabled { get; set; }
		public bool Hidden { get; set; }
		public int DisplayOrder { get; set; }
		public string Description { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string SupportEmail { get; set; }
		public string SupportSite { get; set; }
		public Footer Footer { get; set; }
		public string Tag { get; set; }
		public string SocialDescription { get; set; }
	}

	public enum FooterType
	{
		NoFooter,
		IconAndText,
		TextOnly,
		IconOnly
	}

	public enum FooterItemType
	{
		Home,
		Url,
		OpenUrl,
		Map,
		Email,
		Phone,
		Pushlog,
		Facebook,
		Pinterest,
		Twitter,
		Vimeo,
		YouTube,
		Camera,
		Share,
	}

	public class Footer
	{
		public FooterType FooterType { get; set; }
		public List<FooterItem> FooterData { get; set; }
	}

	public class FooterItem
	{
		public string Title { get; set; }
		public string Url { get; set; }
		public string Image { get; set; }
		public string FColor { get; set; }
		public string BColor { get; set; }
		public string STabColor { get; set; }
		public FooterItemType? Type { get; set; }
	}
}
