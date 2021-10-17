using Newtonsoft.Json;

namespace QuestionSolutions.SharedKernel.MediatR.Models
{
    public class Pagination
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("limit" )]
        public int Limit  { get; set; }
        [JsonProperty("total" )]
        public int Total  { get; set; }
    }
}
