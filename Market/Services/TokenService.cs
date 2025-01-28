
namespace Market.Services;


public class TokenService
{
    public string DefaultToken => HashHelper.ComputeHash512(ServiceHelper.GetService<GetDeviceInfo>().GetDeviceID());
    public string? Token { get; private set; }

    public void SetToken(string token) => Token = token;
}