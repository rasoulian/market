using Refit;
using System.Text.Json.Serialization;

namespace Market.Services;

public interface IPlatformHttpMessageHandler
{
    HttpMessageHandler GetHttpMessageHandler();
}

public interface IApiServices
{
    [Headers("Authorization: Bearer")]
    [Get("/car/services")]
    Task<IEnumerable<CarServiceDto>> Get();
}





public class CarServiceDto
{
    [JsonPropertyName("brand")]
    public string brand { get; set; }
    [JsonPropertyName("kind")]
    public string kind { get; set; }
    [JsonPropertyName("5K")]
    public string _5K { get; set; }
    [JsonPropertyName("10K")]
    public string _10K { get; set; }
    [JsonPropertyName("20K")]
    public string _20K { get; set; }
    [JsonPropertyName("30K")]
    public string _30K { get; set; }
    [JsonPropertyName("40K")]
    public string _40K { get; set; }
    [JsonPropertyName("50K")]
    public string _50K { get; set; }
    [JsonPropertyName("60K")]
    public string _60K { get; set; }
    [JsonPropertyName("70K")]
    public string _70K { get; set; }
    [JsonPropertyName("80K")]
    public string _80K { get; set; }
    [JsonPropertyName("90K")]
    public string _90K { get; set; }
    [JsonPropertyName("pic_s")]
    public string pic_s { get; set; }
    [JsonPropertyName("pic_l")]
    public string pic_l { get; set; }
}