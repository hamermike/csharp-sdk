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
using Bandwidth.Standard.Voice.Exceptions;

namespace Bandwidth.Standard.Voice.Controllers
{
    public class APIController: BaseController
    {
        internal APIController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers) :
            base(config, httpClient, authManagers)
        { }

        /// <summary>
        /// Creates a call request
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.ApiCallResponse> response from the API call</return>
        public ApiResponse<Models.ApiCallResponse> CreateCall(string accountId, Models.ApiCreateCallRequest body = null)
        {
            Task<ApiResponse<Models.ApiCallResponse>> t = CreateCallAsync(accountId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a call request
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.ApiCallResponse> response from the API call</return>
        public async Task<ApiResponse<Models.ApiCallResponse>> CreateCallAsync(string accountId, Models.ApiCreateCallRequest body = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId }
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

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<Models.ApiCallResponse>(_response.Body);
            ApiResponse<Models.ApiCallResponse> apiResponse = new ApiResponse<Models.ApiCallResponse>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// Interrupts and replaces an active call's BXML document
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void ModifyCall(string accountId, string callId, Models.ApiModifyCallRequest body = null)
        {
            Task t = ModifyCallAsync(accountId, callId, body);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Interrupts and replaces an active call's BXML document
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task ModifyCallAsync(string accountId, string callId, Models.ApiModifyCallRequest body = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PostBody(_queryUrl, _headers, _body);

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ApiException(@"The call can't be modified in its current state", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new ApiException(@"The call never existed, no longer exists, or is inaccessible to you", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// Pauses or resumes a recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void ModifyCallRecordingState(string accountId, string callId, Models.ModifyCallRecordingState body = null)
        {
            Task t = ModifyCallRecordingStateAsync(accountId, callId, body);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Pauses or resumes a recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="body">Optional parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task ModifyCallRecordingStateAsync(string accountId, string callId, Models.ModifyCallRecordingState body = null)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}/recording");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "content-type", "application/json; charset=utf-8" }
            };

            //append body params
            var _body = ApiHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().PutBody(_queryUrl, _headers, _body);

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ApiException(@"The call can't be modified in its current state", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new ApiException(@"The call never existed, no longer exists, or is inaccessible to you", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// Returns a (potentially empty) list of metadata for the recordings that took place during the specified call
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.RecordingMetadataResponse>> response from the API call</return>
        public ApiResponse<List<Models.RecordingMetadataResponse>> GetQueryMetadataForAccountAndCall(string accountId, string callId)
        {
            Task<ApiResponse<List<Models.RecordingMetadataResponse>>> t = GetQueryMetadataForAccountAndCallAsync(accountId, callId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a (potentially empty) list of metadata for the recordings that took place during the specified call
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.RecordingMetadataResponse>> response from the API call</return>
        public async Task<ApiResponse<List<Models.RecordingMetadataResponse>>> GetQueryMetadataForAccountAndCallAsync(string accountId, string callId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}/recordings");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<List<Models.RecordingMetadataResponse>>(_response.Body);
            ApiResponse<List<Models.RecordingMetadataResponse>> apiResponse = new ApiResponse<List<Models.RecordingMetadataResponse>>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// Returns metadata for the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.RecordingMetadataResponse> response from the API call</return>
        public ApiResponse<Models.RecordingMetadataResponse> GetMetadataForRecording(string accountId, string callId, string recordingId)
        {
            Task<ApiResponse<Models.RecordingMetadataResponse>> t = GetMetadataForRecordingAsync(accountId, callId, recordingId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns metadata for the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Models.RecordingMetadataResponse> response from the API call</return>
        public async Task<ApiResponse<Models.RecordingMetadataResponse>> GetMetadataForRecordingAsync(string accountId, string callId, string recordingId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}/recordings/{recordingId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId },
                { "recordingId", recordingId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new ApiException(@"The recording never existed, no longer exists, or is inaccessible to you", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<Models.RecordingMetadataResponse>(_response.Body);
            ApiResponse<Models.RecordingMetadataResponse> apiResponse = new ApiResponse<Models.RecordingMetadataResponse>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// Deletes the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void DeleteRecording(string accountId, string callId, string recordingId)
        {
            Task t = DeleteRecordingAsync(accountId, callId, recordingId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Deletes the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task DeleteRecordingAsync(string accountId, string callId, string recordingId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}/recordings/{recordingId}");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId },
                { "recordingId", recordingId }
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

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new ApiException(@"The recording never existed, no longer exists, or is inaccessible to you", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// Downloads the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Stream> response from the API call</return>
        public ApiResponse<Stream> GetStreamRecordingMedia(string accountId, string callId, string recordingId)
        {
            Task<ApiResponse<Stream>> t = GetStreamRecordingMediaAsync(accountId, callId, recordingId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Downloads the specified recording
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <param name="callId">Required parameter: Example: </param>
        /// <param name="recordingId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<Stream> response from the API call</return>
        public async Task<ApiResponse<Stream>> GetStreamRecordingMediaAsync(string accountId, string callId, string recordingId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/calls/{callId}/recordings/{recordingId}/media");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId },
                { "callId", callId },
                { "recordingId", recordingId }
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

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpResponse _response = await GetClientInstance().ExecuteAsBinaryAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 404)
            {
                throw new ApiException(@"The recording never existed, no longer exists, or is inaccessible to you", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

                var _result = _response.RawBody;
            ApiResponse<Stream> apiResponse = new ApiResponse<Stream>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

        /// <summary>
        /// Returns a (potentially empty; capped at 1000) list of metadata for the recordings associated with the specified account
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.RecordingMetadataResponse>> response from the API call</return>
        public ApiResponse<List<Models.RecordingMetadataResponse>> GetQueryMetadataForAccount(string accountId)
        {
            Task<ApiResponse<List<Models.RecordingMetadataResponse>>> t = GetQueryMetadataForAccountAsync(accountId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a (potentially empty; capped at 1000) list of metadata for the recordings associated with the specified account
        /// </summary>
        /// <param name="accountId">Required parameter: Example: </param>
        /// <return>Returns the ApiResponse<List<Models.RecordingMetadataResponse>> response from the API call</return>
        public async Task<ApiResponse<List<Models.RecordingMetadataResponse>>> GetQueryMetadataForAccountAsync(string accountId)
        {
            //the base uri for api requests
            string _baseUri = config.GetBaseUri(Server.VoiceDefault);

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/api/v2/accounts/{accountId}/recordings");

            //process optional template parameters
            ApiHelper.AppendUrlWithTemplateParameters(_queryBuilder, new Dictionary<string, object>()
            {
                { "accountId", accountId }
            });

            //validate and preprocess url
            string _queryUrl = ApiHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            { 
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = GetClientInstance().Get(_queryUrl,_headers);

            _request = authManagers["voice"].Apply(_request);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await GetClientInstance().ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request, _response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 400)
            {
                throw new ErrorResponseException(@"Something didn't look right about that request. Please fix it before trying again.", _context);
            }

            if (_response.StatusCode == 401)
            {
                throw new ApiException(@"Please authenticate yourself", _context);
            }

            if (_response.StatusCode == 403)
            {
                throw new ErrorResponseException(@"Your credentials are invalid. Please use your API credentials for the Bandwidth Dashboard.", _context);
            }

            if (_response.StatusCode == 415)
            {
                throw new ErrorResponseException(@"We don't support that media type. Please send us `application/json`.", _context);
            }

            if (_response.StatusCode == 429)
            {
                throw new ErrorResponseException(@"You're sending requests to this endpoint too frequently. Please slow your request rate down and try again.", _context);
            }

            if (_response.StatusCode == 500)
            {
                throw new ErrorResponseException(@"Something unexpected happened. Please try again.", _context);
            }

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            var _result = ApiHelper.JsonDeserialize<List<Models.RecordingMetadataResponse>>(_response.Body);
            ApiResponse<List<Models.RecordingMetadataResponse>> apiResponse = new ApiResponse<List<Models.RecordingMetadataResponse>>(_response.StatusCode, _response.Headers, _result);
            return apiResponse;
        }

    }
} 