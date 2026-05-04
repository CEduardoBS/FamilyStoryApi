using System.Text.Json.Serialization;

namespace FamilyStoryApi.Application.Stories.Results
{
    public class GetStoryByIdResult
    {
        [JsonPropertyName("storyId")]
        public int StoryId { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("relativesId")]
        public int RelativesId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("mediaUrl")]
        public string MediaUrl { get; set; } = string.Empty;

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; } = string.Empty;

        [JsonPropertyName("createAt")]
        public DateTime CreateAt { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
