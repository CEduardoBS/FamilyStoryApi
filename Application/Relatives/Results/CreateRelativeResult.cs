namespace FamilyStoryApi.Application.Relatives.Results
{
    public class CreateRelativeResult(string name, string relation)
    {
        public string Name { get; set; } = name;
        public string Relation { get; set; } = relation;
    }
}
