/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Text;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Bandwidth.Standard.Authentication;
using Bandwidth.Standard.Http.Client;
using Bandwidth.Standard.Messaging;
using Bandwidth.Standard.TwoFactorAuth;
using Bandwidth.Standard.Voice;
using Bandwidth.Standard.WebRtc;

using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard
{
    public sealed class BandwidthClient: IConfiguration
    {
        internal readonly IDictionary<string, IAuthManager> authManagers;
        internal readonly IHttpClient httpClient;
        private readonly MessagingBasicAuthManager messagingBasicAuthManager;
        private readonly TwoFactorAuthBasicAuthManager twoFactorAuthBasicAuthManager;
        private readonly VoiceBasicAuthManager voiceBasicAuthManager;
        private readonly WebRtcBasicAuthManager webRtcBasicAuthManager;
        private readonly Lazy<MessagingClient> messaging;
        private readonly Lazy<TwoFactorAuthClient> twoFactorAuth;
        private readonly Lazy<VoiceClient> voice;
        private readonly Lazy<WebRtcClient> webRtc;

        /// <summary>
        /// Provides access to MessagingClient controller
        /// </summary>
        public MessagingClient Messaging => messaging.Value;

        /// <summary>
        /// Provides access to TwoFactorAuthClient controller
        /// </summary>
        public TwoFactorAuthClient TwoFactorAuth => twoFactorAuth.Value;

        /// <summary>
        /// Provides access to VoiceClient controller
        /// </summary>
        public VoiceClient Voice => voice.Value;

        /// <summary>
        /// Provides access to WebRtcClient controller
        /// </summary>
        public WebRtcClient WebRtc => webRtc.Value;

        internal static BandwidthClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_TIMEOUT");
            string messagingBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_MESSAGING_BASIC_AUTH_USER_NAME");
            string messagingBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_MESSAGING_BASIC_AUTH_PASSWORD");
            string twoFactorAuthBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_TWO_FACTOR_AUTH_BASIC_AUTH_USER_NAME");
            string twoFactorAuthBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_TWO_FACTOR_AUTH_BASIC_AUTH_PASSWORD");
            string voiceBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_VOICE_BASIC_AUTH_USER_NAME");
            string voiceBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_VOICE_BASIC_AUTH_PASSWORD");
            string webRtcBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_WEB_RTC_BASIC_AUTH_USER_NAME");
            string webRtcBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_WEB_RTC_BASIC_AUTH_PASSWORD");
            string environment = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_ENVIRONMENT");
            string baseUrl = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_BASE_URL");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (environment != null)
            {
                builder.Environment(EnvironmentHelper.ParseString(environment));
            }

            if (baseUrl != null)
            {
                builder.BaseUrl(baseUrl);
            }

            if (messagingBasicAuthUserName != null && messagingBasicAuthPassword != null)
            {
                builder.MessagingBasicAuthCredentials(messagingBasicAuthUserName, messagingBasicAuthPassword);
            }

            if (twoFactorAuthBasicAuthUserName != null && twoFactorAuthBasicAuthPassword != null)
            {
                builder.TwoFactorAuthBasicAuthCredentials(twoFactorAuthBasicAuthUserName, twoFactorAuthBasicAuthPassword);
            }

            if (voiceBasicAuthUserName != null && voiceBasicAuthPassword != null)
            {
                builder.VoiceBasicAuthCredentials(voiceBasicAuthUserName, voiceBasicAuthPassword);
            }

            if (webRtcBasicAuthUserName != null && webRtcBasicAuthPassword != null)
            {
                builder.WebRtcBasicAuthCredentials(webRtcBasicAuthUserName, webRtcBasicAuthPassword);
            }

            return builder.Build();
        }

        private BandwidthClient(TimeSpan timeout, string messagingBasicAuthUserName,
                string messagingBasicAuthPassword, string twoFactorAuthBasicAuthUserName,
                string twoFactorAuthBasicAuthPassword, string voiceBasicAuthUserName,
                string voiceBasicAuthPassword, string webRtcBasicAuthUserName,
                string webRtcBasicAuthPassword, Environment environment, string baseUrl,
                IDictionary<string, IAuthManager> authManagers, IHttpClient httpClient,
                IHttpClientConfiguration httpClientConfiguration)
        {
            messagingBasicAuthManager = new MessagingBasicAuthManager(messagingBasicAuthUserName, messagingBasicAuthPassword);
            twoFactorAuthBasicAuthManager = new TwoFactorAuthBasicAuthManager(twoFactorAuthBasicAuthUserName, twoFactorAuthBasicAuthPassword);
            voiceBasicAuthManager = new VoiceBasicAuthManager(voiceBasicAuthUserName, voiceBasicAuthPassword);
            webRtcBasicAuthManager = new WebRtcBasicAuthManager(webRtcBasicAuthUserName, webRtcBasicAuthPassword);
            Timeout = timeout;
            Environment = environment;
            BaseUrl = baseUrl;
            this.httpClient = httpClient;
            this.authManagers = new Dictionary<string, IAuthManager>(authManagers);
            HttpClientConfiguration = httpClientConfiguration;
            this.authManagers["messaging"] = messagingBasicAuthManager;
            this.authManagers["twoFactorAuth"] = twoFactorAuthBasicAuthManager;
            this.authManagers["voice"] = voiceBasicAuthManager;
            this.authManagers["webRtc"] = webRtcBasicAuthManager;

            messaging = new Lazy<MessagingClient>(() => new MessagingClient(this));
            twoFactorAuth = new Lazy<TwoFactorAuthClient>(() => new TwoFactorAuthClient(this));
            voice = new Lazy<VoiceClient>(() => new VoiceClient(this));
            webRtc = new Lazy<WebRtcClient>(() => new WebRtcClient(this));
        }

        /// <summary>
        /// The configuration of the Http Client associated with this BandwidthClient.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// The username and password to use with basic authentication.
        /// </summary>
        public IBasicAuthCredentials MessagingBasicAuthCredentials => messagingBasicAuthManager;

        /// <summary>
        /// The username and password to use with basic authentication.
        /// </summary>
        public IBasicAuthCredentials TwoFactorAuthBasicAuthCredentials => twoFactorAuthBasicAuthManager;

        /// <summary>
        /// The username and password to use with basic authentication.
        /// </summary>
        public IBasicAuthCredentials VoiceBasicAuthCredentials => voiceBasicAuthManager;

        /// <summary>
        /// The username and password to use with basic authentication.
        /// </summary>
        public IBasicAuthCredentials WebRtcBasicAuthCredentials => webRtcBasicAuthManager;

        /// <summary>
        /// Http client timeout
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Current API environment
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// BaseUrl value
        /// </summary>
        public string BaseUrl { get; }

        //A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "api.bandwidth.com" },
                    { Server.MessagingDefault, "https://messaging.bandwidth.com/api/v2" },
                    { Server.TwoFactorAuthDefault, "https://mfa.bandwidth.com/api/v1/" },
                    { Server.VoiceDefault, "https://voice.bandwidth.com" },
                    { Server.WebRtcDefault, "https://api.webrtc.bandwidth.com/v1" },
                }
            },
            {
                Environment.Custom, new Dictionary<Server, string>
                {
                    { Server.Default, "{base_url}" },
                    { Server.MessagingDefault, "{base_url}" },
                    { Server.TwoFactorAuthDefault, "{base_url}" },
                    { Server.VoiceDefault, "{base_url}" },
                    { Server.WebRtcDefault, "{base_url}" },
                }
            },
        };

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("base_url", BaseUrl),
            };
            return kvpList;
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(Url, GetBaseUriParameters());
            return Url.ToString();
        }

        /// <summary>
        /// Creates an object of the BandwidthClient using the values provided for the builder.
        /// </summary>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(Timeout)
                .Environment(Environment)
                .BaseUrl(BaseUrl)
                .MessagingBasicAuthCredentials(messagingBasicAuthManager.Username, messagingBasicAuthManager.Password)
                .TwoFactorAuthBasicAuthCredentials(twoFactorAuthBasicAuthManager.Username, twoFactorAuthBasicAuthManager.Password)
                .VoiceBasicAuthCredentials(voiceBasicAuthManager.Username, voiceBasicAuthManager.Password)
                .WebRtcBasicAuthCredentials(webRtcBasicAuthManager.Username, webRtcBasicAuthManager.Password)
                .HttpClient(httpClient)
                .AuthManagers(authManagers);

            return builder;
        }

        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(100);
            private string messagingBasicAuthUserName = String.Empty;
            private string messagingBasicAuthPassword = String.Empty;
            private string twoFactorAuthBasicAuthUserName = String.Empty;
            private string twoFactorAuthBasicAuthPassword = String.Empty;
            private string voiceBasicAuthUserName = String.Empty;
            private string voiceBasicAuthPassword = String.Empty;
            private string webRtcBasicAuthUserName = String.Empty;
            private string webRtcBasicAuthPassword = String.Empty;
            private Environment environment = Bandwidth.Standard.Environment.Production;
            private string baseUrl = "https://www.example.com";
            private IHttpClient httpClient;
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private bool createCustomHttpClient = false;

            /// <summary>
            /// Setter for Environment.
            /// </summary>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Setter for BaseUrl.
            /// </summary>
            public Builder BaseUrl(string baseUrl)
            {
                this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
                return this;
            }

            /// <summary>
            /// Setter for Timeout.
            /// </summary>
            public Builder Timeout(TimeSpan timeout)
            {
                httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(100) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            /// <summary>
            /// Setter for BasicAuthUserName and BasicAuthPassword.
            /// </summary>
            public Builder MessagingBasicAuthCredentials(string username, string password)
            {
                this.messagingBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.messagingBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Setter for BasicAuthUserName and BasicAuthPassword.
            /// </summary>
            public Builder TwoFactorAuthBasicAuthCredentials(string username, string password)
            {
                this.twoFactorAuthBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.twoFactorAuthBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Setter for BasicAuthUserName and BasicAuthPassword.
            /// </summary>
            public Builder VoiceBasicAuthCredentials(string username, string password)
            {
                this.voiceBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.voiceBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Setter for BasicAuthUserName and BasicAuthPassword.
            /// </summary>
            public Builder WebRtcBasicAuthCredentials(string username, string password)
            {
                this.webRtcBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.webRtcBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Creates an object of the BandwidthClient using the values provided for the builder.
            /// </summary>
            public BandwidthClient Build()
            {
                if (createCustomHttpClient) 
                {
                    httpClient = new HttpClientWrapper(httpClientConfig);
                } 
                else 
                {
                    httpClient = new HttpClientWrapper();
                }

                return new BandwidthClient(timeout, messagingBasicAuthUserName, messagingBasicAuthPassword,
                        twoFactorAuthBasicAuthUserName, twoFactorAuthBasicAuthPassword, voiceBasicAuthUserName,
                        voiceBasicAuthPassword, webRtcBasicAuthUserName, webRtcBasicAuthPassword, environment, baseUrl,
                        authManagers, httpClient, httpClientConfig);
            }
        }

    }
}
