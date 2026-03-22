using System.Text.Json.Serialization;

namespace FamilyStoryApi.Application.LevelParentages.Results
{
    public class CreateLevelParentageResult(int id, string description, int level)
    {
        public int Id { get; set; } = id;
        public string Description { get; set; } = description;
        public int Level { get; set; } = level;
    }
}
