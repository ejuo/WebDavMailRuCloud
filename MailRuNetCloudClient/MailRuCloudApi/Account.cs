//-----------------------------------------------------------------------
// <created file="Account.cs">
//     Mail.ru cloud client created in 2016.
// </created>
// <author>Korolev Erast.</author>
//-----------------------------------------------------------------------

using System.IO;
using System.Linq;

namespace MailRuCloudApi
{
    using System;
    using System.Net;
    using System.Text;

    /// <summary>
    /// MAIL.RU account info.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Default cookies.
        /// </summary>
        private CookieContainer _cookies;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="login">Login name as email.</param>
        /// <param name="password">Password related with this login</param>
        public Account(string login, string password)
        {
            LoginName = login;
            Password = password;
        }

        /// <summary>
        /// Gets or sets connection proxy.
        /// </summary>
        /// <value>Proxy settings.</value>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// Gets authorization token.
        /// </summary>
        /// <value>Access token.</value>
        public string AuthToken { get; private set; }

        /// <summary>
        /// Gets account cookies.
        /// </summary>
        /// <value>Account cookies.</value>
        public CookieContainer Cookies => _cookies ?? (_cookies = new CookieContainer());

        /// <summary>
        /// Gets or sets login name.
        /// </summary>
        /// <value>Account email.</value>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets email password.
        /// </summary>
        /// <value>Password related with login.</value>
        public string Password { get; set; }

        public AccountInfo Info { get; set; }

		/// <summary>
        /// First step csrf-token.
        /// </summary>
		public string Csrf { get; set; }

        /// <summary>
        /// Authorize on MAIL.RU server.
        /// </summary>
        /// <returns>True or false result operation.</returns>
        public bool Login()
        {
            if (string.IsNullOrEmpty(LoginName))
            {
                throw new ArgumentException("LoginName is null or empty.");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException("Password is null or empty.");
            }

            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
            Proxy = WebRequest.DefaultWebProxy;
            

            string reqString = $"Login={LoginName}&Domain={ConstSettings.Domain}&Password={Password}";
            byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            var request = (HttpWebRequest)WebRequest.Create($"{ConstSettings.AuthDomen}/cgi-bin/auth");
            request.Proxy = Proxy;
            request.CookieContainer = Cookies;
            request.Method = "POST";
            request.ContentType = ConstSettings.DefaultRequestType;
            request.Accept = ConstSettings.DefaultAcceptType;
            request.UserAgent = ConstSettings.UserAgent;
            using (var s = request.GetRequestStream())
            {
                s.Write(requestData, 0, requestData.Length);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (Cookies != null && Cookies.Count > 0)
                        {
							if (response.ResponseUri.OriginalString == $"{ConstSettings.AuthDomen}/cgi-bin/secstep")
							{
								string response_text = new MailRuCloud().ReadResponseAsText(response);
								var csrf = response_text.Split(new[] { "csrf" }, StringSplitOptions.None)[1].Split(',')[0].Where(char.IsLetterOrDigit).ToArray();
								this.Csrf = new string(csrf);
							}
							else
							{
								EnsureSdcCookie();
								return GetAuthToken();
							}
                        }
                        return false;
                    }
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Retrieve SDC cookies.
        /// </summary>
        private void EnsureSdcCookie()
        {
            var request = (HttpWebRequest)WebRequest.Create($"{ConstSettings.AuthDomen}/sdc?from={ConstSettings.CloudDomain}/home");
            request.Proxy = Proxy;
            request.CookieContainer = Cookies;
            request.Method = "GET";
            request.ContentType = ConstSettings.DefaultRequestType;
            request.Accept = ConstSettings.DefaultAcceptType;
            request.UserAgent = ConstSettings.UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Get authorization token.
        /// </summary>
        /// <returns>True or false result operation.</returns>
        private bool GetAuthToken()
        {
            var uri = new Uri($"{ConstSettings.CloudDomain}/api/v2/tokens/csrf");
            var request = (HttpWebRequest)WebRequest.Create(uri.OriginalString);
            request.Proxy = Proxy;
            request.CookieContainer = Cookies;
            request.Method = "GET";
            request.ContentType = ConstSettings.DefaultRequestType;
            request.Accept = "application/json";
            request.UserAgent = ConstSettings.UserAgent;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response == null || response.StatusCode == HttpStatusCode.OK)
                {
                    return !string.IsNullOrEmpty(AuthToken = JsonParser.Parse(new MailRuCloud().ReadResponseAsText(response), PObject.Token) as string);
                }
                throw new Exception();
            }
        }

		/// <summary>
		/// 2-step auth.
		/// </summary>
		/// <param name="authCode">AuthCode</param>
		/// <returns>True or false result operation.</returns>
		public bool SecondStep(string authCode)
		{
			var request = (HttpWebRequest)WebRequest.Create($"{ConstSettings.AuthDomen}/cgi-bin/secstep");
			string reqString = $"csrf={this.Csrf}&Login={this.LoginName}&AuthCode={authCode}";
			byte[] requestData = Encoding.UTF8.GetBytes(reqString);
			request.Proxy = this.Proxy;
			request.CookieContainer = this.Cookies;
			request.Method = "POST";
			request.ContentType = ConstSettings.DefaultRequestType;
			request.Accept = ConstSettings.DefaultAcceptType;
			request.UserAgent = ConstSettings.UserAgent;
			using (var s = request.GetRequestStream())
			{
				s.Write(requestData, 0, requestData.Length);
				using (var response = (HttpWebResponse)request.GetResponse())
				{
					if (response.StatusCode == HttpStatusCode.OK)
					{
						EnsureSdcCookie();
						return GetAuthToken();
						
					}
					else
					{
						throw new Exception();
					}
				}
			}
		}

    }
}
