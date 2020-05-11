using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class CarResponse
    {
        [JsonProperty(PropertyName = "image")]
        public string image { get; set; }

        [JsonProperty(PropertyName = "remainingRight")]
        public int remainingRight { get; set; }
    }
}
