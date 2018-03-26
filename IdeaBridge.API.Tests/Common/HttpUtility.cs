using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Tests.Common
{
    public class HttpUtility
    {
        const string API_KEY = "X-some-key";
        public HttpUtility(string userName, string password, string baseUrl)
        {
            this.UserName = userName;
            this.Password = password;
            this.BaseUrl = baseUrl;
        }

        public string GetBasicAuthenticationHeader()
        {
            return "Basic " + Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(this.UserName + ":" + this.Password));
        }

        public string Password { get; private set; }
        public string UserName { get; private set; }
        public string BaseUrl { get; private set; }

        public async Task<ReturnMessage<string>> GetRequest(string urlSuffix, string extraParams = "")
        {
            var retValue = new ReturnMessage<string>();
            try
            {
                UriBuilder builder = new UriBuilder(this.BaseUrl);
                builder.Path += urlSuffix;
                var url = builder.Uri.ToString();
                url += ($"?API_KEY={API_KEY}{(!string.IsNullOrWhiteSpace(extraParams) ? "&" + extraParams : string.Empty)}");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                var accessToken = this.GetBasicAuthenticationHeader();
                request.Headers["Authorization"] = accessToken;
                request.Accept = "application/json";
                var response = await request.GetResponseAsync() as HttpWebResponse;
                using (response)
                {
                    var myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    var responseText = myStreamReader.ReadToEnd();

                    retValue.HttpStatusCode = response.StatusCode;
                    retValue.SetSuccess(responseText);
                }
            }
            catch (WebException ex)
            {
                var exceptionDetails = string.Empty;
                if (ex.Response != null)
                {
                    exceptionDetails = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                }
                else
                    exceptionDetails = ex.ToString();

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        retValue.HttpStatusCode = response.StatusCode;
                    }
                }
                retValue.SetError(ex, $"API {urlSuffix} failed for GET. {Environment.NewLine} The error given is {exceptionDetails}");
            }
            return retValue;
        }

        public async Task<ReturnMessage<string>> PostRequest(string urlSuffix, string method, string requestBody, string extraParams)
        {
            var retValue = new ReturnMessage<string>();
            try
            {
                UriBuilder builder = new UriBuilder(this.BaseUrl);
                builder.Path += urlSuffix;
                var url = builder.Uri.ToString();
                url += ($"?API_KEY={API_KEY}{(!string.IsNullOrWhiteSpace(extraParams) ? "&" + extraParams : string.Empty)}");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                var accessToken = this.GetBasicAuthenticationHeader();
                request.Headers["Authorization"] = accessToken;
                request.Accept = "application/json";
                request.Method = method;
                if (!string.IsNullOrEmpty(requestBody))
                {
                    var bytes = Encoding.UTF8.GetBytes(requestBody);
                    request.ContentLength = bytes.Length;
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }
                }
                var response = await request.GetResponseAsync() as HttpWebResponse;
                using (response)
                {
                    retValue.HttpStatusCode = response.StatusCode;
                    var myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    retValue.SetSuccess(myStreamReader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                var exceptionDetails = string.Empty;
                if (ex.Response != null)
                {
                    exceptionDetails = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                }
                else
                    exceptionDetails = ex.ToString();

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        retValue.HttpStatusCode = response.StatusCode;
                    }
                }
                retValue.SetError(ex, $"API {urlSuffix} failed for {method}. {Environment.NewLine} The error given is {exceptionDetails}");
            }
            return retValue;
        }
    }
}
