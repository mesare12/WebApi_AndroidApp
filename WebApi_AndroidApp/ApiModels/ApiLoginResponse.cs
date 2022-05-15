using WebApi_AndroidApp.Models;
using System.Text.Json.Serialization;

namespace WebApi_AndroidApp.ApiModels
{
    /// <summary>
    /// Användardata som returneras vid inloggning.
    /// </summary>
    public class ApiLoginResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbUser"></param>
        public ApiLoginResponse(UserItem dbUser)
        {
            UserID = dbUser.UserID ?? -1;
            FirstName = dbUser.FirstName;
            LastName = dbUser.LastName;
            Token = dbUser.Token;
        }

        /// <summary>
        /// Användar ID i databasen.
        /// </summary>
        [JsonPropertyName("userID")]
        public long UserID { get; set; }


        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }


        [JsonPropertyName("lastName")]
        public string LastName { get; set; }


        [JsonPropertyName("token")]
        public string Token { get; set; }


        [JsonPropertyName("message")]
        public string Message { get; set; } = "";
    }
}
