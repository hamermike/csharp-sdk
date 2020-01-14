/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;
using Bandwidth.Standard.Http.Request;
using Bandwidth.Standard.Http.Response;
using Bandwidth.Standard.Http.Client;
using Bandwidth.Standard.Messaging.Exceptions;

namespace Bandwidth.Standard.Messaging.Controllers
{
    public class APIController: BaseController
    {
        internal APIController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers) :
            base(config, httpClient, authManagers)
        { }

        /// <summary>
        /// getMessage
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public void GetMessage()
        {
            Task t = GetMessageAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// getMessage
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public async Task GetMessageAsync()
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/ping");

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// listMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="continuationToken">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.Media>> response from the API call</return>
        public ApiResponse<List<Models.Media>> ListMedia(string userId, string continuationToken = null)
        {
            Task<ApiResponse<List<Models.Media>>> t = ListMediaAsync(userId, continuationToken);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// listMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="continuationToken">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.Media>> response from the API call</return>
        public async Task<ApiResponse<List<Models.Media>>> ListMediaAsync(string userId, string continuationToken = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/users/{userId}/media");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "userId", userId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "Continuation-Token", continuationToken }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<List<Models.Media>>(_response.Body);
            ApiResponse<List<Models.Media>> apiResponse = new ApiResponse<List<Models.Media>>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// getMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Stream> response from the API call</return>
        public ApiResponse<Stream> GetMedia(string userId, string mediaId)
        {
            Task<ApiResponse<Stream>> t = GetMediaAsync(userId, mediaId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// getMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Stream> response from the API call</return>
        public async Task<ApiResponse<Stream>> GetMediaAsync(string userId, string mediaId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/users/{userId}/media/{mediaId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "userId", userId },
                { "mediaId", mediaId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpResponse _response = await GetClientInstance().ExecuteAsBinaryAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

                var _result = _response.RawBody;
            ApiResponse<Stream> apiResponse = new ApiResponse<Stream>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// uploadMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <param name="contentLength">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="contentType">Optional parameter: Example: </param>
        /// <param name="cacheControl">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void UploadMedia(
                string userId,
                string mediaId,
                long contentLength,
                string body,
                string contentType = null,
                string cacheControl = null)
        {
            Task t = UploadMediaAsync(userId, mediaId, contentLength, body, contentType, cacheControl);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// uploadMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <param name="contentLength">Required parameter: Example: </param>
        /// <param name="body">Required parameter: Example: </param>
        /// <param name="contentType">Optional parameter: Example: </param>
        /// <param name="cacheControl">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task UploadMediaAsync(
                string userId,
                string mediaId,
                long contentLength,
                string body,
                string contentType = null,
                string cacheControl = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/users/{userId}/media/{mediaId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "userId", userId },
                { "mediaId", mediaId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "Content-Length", contentLength.ToString() },
                { "Content-Type", contentType },
                { "Cache-Control", cacheControl }
            };

            //append body params
             var _body = body;

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PutBody(_queryUrl, _headers, _body);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// deleteMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void DeleteMedia(string userId, string mediaId)
        {
            Task t = DeleteMediaAsync(userId, mediaId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// deleteMedia
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="mediaId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task DeleteMediaAsync(string userId, string mediaId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/users/{userId}/media/{mediaId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "userId", userId },
                { "mediaId", mediaId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Delete(_queryUrl, _headers, null);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// createMessage
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.BandwidthMessage> response from the API call</return>
        public ApiResponse<Models.BandwidthMessage> CreateMessage(string userId, Models.MessageRequest body = null)
        {
            Task<ApiResponse<Models.BandwidthMessage>> t = CreateMessageAsync(userId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// createMessage
        /// </summary>
        /// <param name="userId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.BandwidthMessage> response from the API call</return>
        public async Task<ApiResponse<Models.BandwidthMessage>> CreateMessageAsync(string userId, Models.MessageRequest body = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.MessagingDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/users/{userId}/messages");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "userId", userId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);

            _request = authManagers["messaging"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new GenericClientException(@"400 Request is malformed or invalid", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new PathClientException(@"401 The specified user does not have access to the account", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new PathClientException(@"403 The user does not have access to this API", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new PathClientException(@"404 Path not found", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new GenericClientException(@"415 The content-type of the request is incorrect", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new GenericClientException(@"429 The rate limit has been reached", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<Models.BandwidthMessage>(_response.Body);
            ApiResponse<Models.BandwidthMessage> apiResponse = new ApiResponse<Models.BandwidthMessage>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

    }
} 