namespace WSFedSample.Security
{
    /// <summary>
    /// Logon Identity Service
    /// </summary>
    public class LogonIdentityService : ILogonIdentityService
    {
        private readonly IRequestMetadataService _requestMetadataService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogonIdentityService(IRequestMetadataService requestMetadataService)
        {
            _requestMetadataService = requestMetadataService;
        }

        /// <summary>
        /// Gets and identity object for the CU Member and indicates whether they have been authorized.
        /// </summary>
        /// <returns></returns>
        public LogonIdentity GetLogonIdentity()
        {
            LogonIdentity logonIdentity = null;

            bool isAuthorized = false;

            var firstName = _requestMetadataService.GetClaimStringValue(ClaimType.FirstName);

            var lastName = _requestMetadataService.GetClaimStringValue(ClaimType.LastName);

            var displayName = _requestMetadataService.GetClaimStringValue(ClaimType.DisplayName);

            var emailAddress = _requestMetadataService.GetClaimStringValue(ClaimType.EmailAddress);

            var userId = emailAddress;

            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                isAuthorized = true;
            }

            logonIdentity = new LogonIdentity(isAuthorized, userId, firstName, lastName, displayName, emailAddress);

            return logonIdentity;
        }
    }
}
