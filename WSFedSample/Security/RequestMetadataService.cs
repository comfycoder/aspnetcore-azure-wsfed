using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace WSFedSample.Security
{
    /// <summary>
    /// Used to retrieve header variables and user claims.
    /// </summary>
    public class RequestMetadataService : IRequestMetadataService
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// An HttpContextAccessor object instance.
        /// </param>
        public RequestMetadataService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Internal routine providing safe reading of header values.
        /// </summary>
        /// <param name="keyName">
        /// Name of an HTTP request header variable.
        /// </param>
        /// <returns>
        /// An an HTTP request header variable value.
        /// </returns>
        public string GetHeaderValue(string keyName)
        {
            string value = string.Empty;

            if (_httpContextAccessor?.HttpContext != null)
            {
                if (String.IsNullOrWhiteSpace(value) && !String.IsNullOrWhiteSpace(keyName))
                {
                    IHeaderDictionary headersDictionary = _httpContextAccessor.HttpContext?.Request?.Headers;

                    if (headersDictionary != null && headersDictionary.Keys.Contains(keyName))
                    {
                        var headers = headersDictionary[keyName];

                        if (headers.Any())
                        {
                            value = headers[0];
                        }
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// Get a claim string value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a string.
        /// </returns>
        public string GetClaimStringValue(string claimType)
        {
            string result = string.Empty;

            var user = _httpContextAccessor?.HttpContext?.User;

            if (user != null)
            {
                var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

                if (claim != null)
                {
                    if (!string.IsNullOrWhiteSpace(claim.Value))
                    {
                        result = claim.Value;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get a claim integer value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as an integer.
        /// </returns>
        public int GetClaimIntValue(string claimType)
        {
            int result = 0;

            var user = _httpContextAccessor?.HttpContext?.User;

            if (user != null)
            {
                var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

                if (claim != null)
                {
                    if (!string.IsNullOrWhiteSpace(claim.Value))
                    {
                        int.TryParse(claim.Value, out result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get a claim boolean value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a boolean.
        /// </returns>
        public bool GetClaimBooleanValue(string claimType)
        {
            bool result = false;

            var user = _httpContextAccessor?.HttpContext?.User;

            if (user != null)
            {
                var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

                if (claim != null)
                {
                    if (!string.IsNullOrWhiteSpace(claim.Value))
                    {
                        var value = claim.Value.ToLower();

                        switch (value)
                        {
                            case "true":
                            case "yes":
                            case "on":
                            case "1":
                                result = true;
                                break;

                            case "false":
                            case "no":
                            case "off":
                            case "0":
                                result = false;
                                break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
