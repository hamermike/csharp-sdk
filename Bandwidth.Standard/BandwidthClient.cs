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
using Bandwidth.Standard.Voice;

using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard
{
    public sealed class BandwidthClient: IConfiguration
    {
        internal readonly IDictionary<string, IAuthManager> authManagers;
        internal readonly IHttpClient httpClient;
        private readonly MessagingBasicAuthManager messagingBasicAuthManager; 
        private readonly VoiceBasicAuthManager voiceBasicAuthManager; 

        private readonly Lazy<MessagingClient> messaging;
        private readonly Lazy<VoiceClient> voice;

        /// <summary>
        /// Provides access to MessagingClient controller
        /// </summary>
        public MessagingClient Messaging => messaging.Value;

        /// <summary>
        /// Provides access to VoiceClient controller
        /// </summary>
        public VoiceClient Voice => voice.Value;

        internal static BandwidthClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_TIMEOUT");
            string messagingBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_MESSAGING_BASIC_AUTH_USER_NAME");
            string messagingBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_MESSAGING_BASIC_AUTH_PASSWORD");
            string voiceBasicAuthUserName = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_VOICE_BASIC_AUTH_USER_NAME");
            string voiceBasicAuthPassword = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_VOICE_BASIC_AUTH_PASSWORD");
            string environment = System.Environment.GetEnvironmentVariable("BANDWIDTH_STANDARD_ENVIRONMENT");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (environment != null)
            {
                builder.Environment(EnvironmentHelper.ParseString(environment));
            }
            if (messagingBasicAuthUserName != null && messagingBasicAuthPassword != null)
            {
                builder.MessagingBasicAuthCredentials(messagingBasicAuthUserName, messagingBasicAuthPassword);
            }
            if (voiceBasicAuthUserName != null && voiceBasicAuthPassword != null)
            {
                builder.VoiceBasicAuthCredentials(voiceBasicAuthUserName, voiceBasicAuthPassword);
            }

            return builder.Build();
        }

        private BandwidthClient(TimeSpan timeout, string messagingBasicAuthUserName,
                string messagingBasicAuthPassword, string voiceBasicAuthUserName,
                string voiceBasicAuthPassword, Environment environment,
                IDictionary<string, IAuthManager> authManagers, IHttpClient httpClient,
                IHttpClientConfiguration httpClientConfiguration)
        {
            messagingBasicAuthManager = new MessagingBasicAuthManager(messagingBasicAuthUserName, messagingBasicAuthPassword);
            voiceBasicAuthManager = new VoiceBasicAuthManager(voiceBasicAuthUserName, voiceBasicAuthPassword);
            Timeout = timeout;
            Environment = environment;
            this.httpClient = httpClient;
            this.authManagers = new Dictionary<string, IAuthManager>(authManagers);
            HttpClientConfiguration = httpClientConfiguration;



            this.authManagers["messaging"] = messagingBasicAuthManager;
            this.authManagers["voice"] = voiceBasicAuthManager;

            messaging = new Lazy<MessagingClient>(() => new MessagingClient(this));
            voice = new Lazy<VoiceClient>(() => new VoiceClient(this));

        }

        /// <summary>
        /// The configuration of the Http Client associated with this BandwidthClient.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// The username and password to use with basic authentication
        /// </summary>
        public IBasicAuthCredentials MessagingBasicAuthCredentials => messagingBasicAuthManager;

        /// <summary>
        /// The username and password to use with basic authentication
        /// </summary>
        public IBasicAuthCredentials VoiceBasicAuthCredentials => voiceBasicAuthManager;

        /// <summary>
        /// Http client timeout
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Current API environment
        /// </summary>
        public Environment Environment { get; }

        //A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "api.bandwidth.com" },
                    { Server.MessagingDefault, "https://messaging.bandwidth.com/api/v2" },
                    { Server.VoiceDefault, "https://voice.bandwidth.com" },
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
            };
            return kvpList;
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(Url, GetBaseUriParameters());
            return Url.ToString();
        }

        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(Timeout)
                .Environment(Environment)
                .MessagingBasicAuthCredentials(messagingBasicAuthManager.Username, messagingBasicAuthManager.Password)
                .VoiceBasicAuthCredentials(voiceBasicAuthManager.Username, voiceBasicAuthManager.Password)
                .HttpClient(httpClient)
                .AuthManagers(authManagers);

            return builder;
        }

        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(100);
            private string messagingBasicAuthUserName = String.Empty;
            private string messagingBasicAuthPassword = String.Empty;
            private string voiceBasicAuthUserName = String.Empty;
            private string voiceBasicAuthPassword = String.Empty;
            private Environment environment = Bandwidth.Standard.Environment.Production;
            private IHttpClient httpClient;
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private bool createCustomHttpClient = false;

            // Setter for Environment
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            // Setter for Timeout
            public Builder Timeout(TimeSpan timeout)
            {
                httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(100) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            // Setter for BasicAuthUserName and BasicAuthPassword
            public Builder MessagingBasicAuthCredentials(string username, string password)
            {
                this.messagingBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.messagingBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            // Setter for BasicAuthUserName and BasicAuthPassword
            public Builder VoiceBasicAuthCredentials(string username, string password)
            {
                this.voiceBasicAuthUserName = username ?? throw new ArgumentNullException(nameof(username));
                this.voiceBasicAuthPassword = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

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

                return new BandwidthClient(timeout, messagingBasicAuthUserName, messagingBasicAuthPassword, voiceBasicAuthUserName,
                        voiceBasicAuthPassword, environment, authManagers, httpClient, httpClientConfig);
            }
        }

    }
}
