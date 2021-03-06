using Bandwidth.Standard.Http.Request;
using System.Threading.Tasks;

namespace Bandwidth.Standard.Authentication
{
    internal interface IAuthManager
    {
        /// <summary>
        /// Add authentication information to the HTTP Request.
        /// </summary>
        HttpRequest Apply(HttpRequest httpRequest);

        /// <summary>
        /// Asynchronously add authentication information to the HTTP Request.
        /// </summary>
        Task<HttpRequest> ApplyAsync(HttpRequest httpRequest);
    }
}
