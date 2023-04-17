namespace Dev33.UltimateTeam.Application.Encyptors
{
    public interface IEncryptor
    {
        string EncryptData(string data);
        string DecryptData(string data);
    }
}