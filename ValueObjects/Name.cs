using FamilyStoryApi.Core.ValueObjects;

namespace FamilyStoryApi.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", message: "FirstName inválido");

            if (string.IsNullOrEmpty(lastName))
                AddNotification("Name.LastName", message: "FirstName inválido");
        }
    }
}
