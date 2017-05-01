using System;

namespace AN.APIWrapper.Models
{
	public class PushNotification
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public string Message { get; set; }
		public DateTime DateSent { get; set; }
		public bool IsGeo { get; set; }
		public bool PreviewerOnly { get; set; }
		public bool IsExternalLink { get; set; }
		public string MediaImage { get; set; }
	}
}
