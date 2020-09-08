using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HuguosMilkshakesBar.Models
{
    public class User
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
