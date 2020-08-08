using Newtonsoft.Json;

namespace BPDTSApiTests.Helpers
{
    public class InstructionsResponse
    {
        [JsonProperty("todo")]
        public string ToDo { get; set; }
    }
}
