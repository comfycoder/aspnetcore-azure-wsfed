namespace WSFedSample.Security
{
    public interface IRequestMetadataService
    {
        bool GetClaimBooleanValue(string claimType);
        int GetClaimIntValue(string claimType);
        string GetClaimStringValue(string claimType);
        string GetHeaderValue(string keyName);
    }
}