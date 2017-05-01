using AN.APIWrapper.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AN.APIWrapper.API
{
	public abstract class APIWrapper
    {
		private string _apiBaseUrl;
		private string _subject;
		private string _secret;
		
		public APIWrapper(string apiUrl, string subject, string secret)
		{
			_apiBaseUrl = apiUrl;
			_subject = subject;
			_secret = secret;
		}

        #region Http GET

        /// <summary>
        /// Executes a GET to the specified endpoint;
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected T ExecuteGet<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(ExecuteGet(url));
        }

        /// <summary>
        /// Executes a GET to the specified endpoint;
        /// </summary>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected string ExecuteGet(string url)
        {
            return Execute(url, HttpMethod.Get);
        }

        #endregion

        #region Http POST

        /// <summary>
        /// Executes a POST to the specified endpoint;
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected T ExecutePost<T>(string url, object param = null)
        {
            return JsonConvert.DeserializeObject<T>(ExecutePost(url, param));
        }

        /// <summary>
        /// Executes a POST to the specified endpoint;
        /// </summary>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected string ExecutePost(string url, object param = null)
        {
            return Execute(url, HttpMethod.Post, param);
        }

        #endregion

        #region Http PUT

        /// <summary>
        /// Executes a PUT to the specified endpoint;
        /// </summary>
        /// <typeparam name="T">Return type.</typeparam>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected T ExecutePut<T>(string url, object param = null)
        {
            return JsonConvert.DeserializeObject<T>(ExecutePut(url, param));
        }

        /// <summary>
        /// Executes a PUT to the specified endpoint;
        /// </summary>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected string ExecutePut(string url, object param = null)
        {
            return Execute(url, HttpMethod.Put, param);
        }

        #endregion

        #region Http DELETE

        /// <summary>
        /// Executes a DELETE to the specified endpoint;
        /// </summary>
        /// <param name="url">API endpoint url.</param>
        /// <param name="param">Optional API parameter.</param>
        protected void ExecuteDelete(string url, object param = null)
        {
            Execute(url, HttpMethod.Delete, param);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Executes an API call to the specified endpoint;
        /// </summary>
        /// <param name="url">API endpoint url.</param>
        /// <param name="httpMethod">Http method to use for the request.</param>
        /// <param name="param">Optional API parameter.</param>
        private string Execute(string url, HttpMethod httpMethod, object param = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            var requestUrl = _apiBaseUrl + url;

            // Create a new instance of an HttpClient object.
            var client = new HttpClient();

            // Add the authentication header using the token we've generated from the AppNotchJwt class
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken(_subject, _secret));

            // Create a request message.
            var request = new HttpRequestMessage(httpMethod, requestUrl);

            Task<HttpResponseMessage> response = null;
            StringContent content = null;

            if (param != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            }

            switch (httpMethod.Method)
            {
                case "POST":
                    // Send the request to the client.
                    response = client.PostAsync(requestUrl, content);
                    break;
                case "PUT":
                    // Send the request to the client.
                    response = client.PutAsync(requestUrl, content);
                    break;
                case "DELETE":
                    // Send the request to the client.
                    response = client.DeleteAsync(requestUrl);
                    break;
                default:
                    // Send the request to the client.
                    response = client.SendAsync(request);
                    break;
            }

            // Get the json result.
            var responseJson = response.Result.Content.ReadAsStringAsync();

            // Return the JSON result to the caller.
            return responseJson.Result;
        }

        /// <summary>
        /// Creates a new token.
        /// </summary>
        private string GetToken(string subject, string secret)
        {
            var jwt = new AppNotchJwt(subject, secret);
			return jwt.GetToken();
        }

        #endregion

    }
}
