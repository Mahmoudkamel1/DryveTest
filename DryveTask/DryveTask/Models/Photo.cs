using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Prism.Mvvm;

namespace DryveTask.Models
{
    public class Photo : BindableBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("author_id")]
        public string AuthorID { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("media")]
        private JToken ImageToken { get; set; }

        public string imaageUrl => (ImageToken["m"].ToString()).Replace("_m.jpg", "_b.jpg");

    }
}