using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;

namespace AN.APIDemo
{
	/// <summary>
	/// AppNotch API Jwt wrapper.
	/// </summary>
	public class AppNotchJwt
	{
		private readonly string _subject;
		private readonly string _secret;

		public AppNotchJwt(string subject, string secret)
		{
			_secret = secret;
			_subject = subject;
		}

		public string GetToken()
		{
			// setup payload
			var payload = new
			{
				iss = "appnotch.com",
				sub = _subject,
				iat = DateTime.UtcNow.ToUnixTimestamp(),
				jti = Guid.NewGuid().ToString("N")
			};

			IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
			IJsonSerializer serializer = new JsonNetSerializer();
			IJwtEncoder encoder = new JwtEncoder(algorithm, serializer);

			// convert the secret to base64 string and use as key
			var base64Secret = Convert.FromBase64String(_secret);
			var token = encoder.Encode(payload, base64Secret);
			return token;
		}
	}
}