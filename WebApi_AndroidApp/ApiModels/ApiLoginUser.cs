using System.Text.Json.Serialization;

namespace WebApi_AndroidApp.ApiModels
{
    public class ApiLoginUser
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = "";

        [JsonPropertyName("password")]
        public string Password { get; set; } = "";
    }
}
