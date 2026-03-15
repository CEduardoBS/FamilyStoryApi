namespace FamilyStoryApi.Application.Stories.Results
{
    public class CreateStoryResult(int storyId, string title, string createAt)
    {
        public int StoryId { get; set; } = storyId;
        public string Title { get; set; } = title;
        public string CreateAt { get; set; } = createAt;
    }
}
