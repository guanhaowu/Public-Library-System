using Newtonsoft.Json;

namespace PLS.model
{
    class Settings
    {
        [JsonProperty(PropertyName = "FirstRun_Book")]
        public bool FirstRun_Book { get; set; } = true;
        [JsonProperty(PropertyName = "FirstRun_PersonList")]
        public bool FirstRun_PersonList { get; set; } = true;
    }
}
