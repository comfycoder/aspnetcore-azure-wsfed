namespace WSFedSample.Security
{
    /// <summary>
    /// Authenticated user identity module for the CU Member.
    /// </summary>
    public class LogonIdentity
    {
        /// <summary>
        /// Indicates whether the Credit Union Member user has been granted permission 
        /// to obtain their financial account information.
        /// </summary>
        public bool IsAuthorized { get; private set; }

        /// <summary>
        /// The user identifier.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// The user first name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// The user last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// The user display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The user email address.
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogonIdentity()
        {
            IsAuthorized = false;
            UserId = null;
            FirstName = null;
            LastName = null;
            DisplayName = null;
            EmailAddress = null;
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="isAuthorized">
        /// True if source party client authorized, False if source party client NOT authorized.
        /// </param>
        public LogonIdentity(bool isAuthorized, string userId, string firstName, 
            string lastName, string displayName, string emailAddress)
        {
            IsAuthorized = isAuthorized;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            DisplayName = displayName;
            EmailAddress = emailAddress;
        }
    }
}
