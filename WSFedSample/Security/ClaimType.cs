namespace WSFedSample.Security
{
    /// <summary>
    /// Types of claims.
    /// </summary>
    public class ClaimType
    {
        public const string DisplayName = "http://schemas.microsoft.com/identity/claims/displayname";

        public const string LastName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname";

        public const string FirstName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";

        public const string EmailAddress = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
    }
}
