using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HuguosMilkshakesBar.Models
{
    public class Milkshake
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        //public Uri Picture
        //{ 
        //    get {
        //        return new Uri(PictureString);
        //    }
        //}
    }
}
