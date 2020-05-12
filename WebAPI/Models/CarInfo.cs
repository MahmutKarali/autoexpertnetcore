using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class CarInfo
    {
        [JsonProperty(PropertyName = "userName")]
        public string userName { get; set; }

        [JsonProperty(PropertyName = "item1")]
        public int item1 { get; set; }

        [JsonProperty(PropertyName = "item2")]
        public int item2 { get; set; }

        [JsonProperty(PropertyName = "item3")]
        public int item3 { get; set; }

        [JsonProperty(PropertyName = "item4")]
        public int item4 { get; set; }

        [JsonProperty(PropertyName = "item5")]
        public int item5 { get; set; }

        [JsonProperty(PropertyName = "item6")]
        public int item6 { get; set; }
        [JsonProperty(PropertyName = "item7")]
        public int item7 { get; set; }

        [JsonProperty(PropertyName = "item8")]
        public int item8 { get; set; }
        [JsonProperty(PropertyName = "item9")]
        public int item9 { get; set; }

        [JsonProperty(PropertyName = "item10")]
        public int item10 { get; set; }

        [JsonProperty(PropertyName = "item11")]
        public int item11 { get; set; }

        [JsonProperty(PropertyName = "plate")]
        public string plate { get; set; }

        [JsonProperty(PropertyName = "sasiNo")]
        public string sasiNo { get; set; }

        [JsonProperty(PropertyName = "motorNo")]
        public string motorNo { get; set; }
    }
}
