using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HuguosMilkshakesBar.Models
{
    class Post
    {
        [JsonProperty("headline")]
        public string Headline { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
