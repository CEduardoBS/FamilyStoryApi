using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Core.ValueObjects;
using System.Text;

namespace FamilyStoryApi.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName: FirstName inválido");

            if (string.IsNullOrEmpty(lastName))
                AddNotification("Name.LastName: FirstName inválido");
        }

        public override string ToString() 
        { 
            StringBuilder sb = new();
            sb.Append(FirstName);
            sb.Append(' ');
            sb.Append(LastName);

            return sb.ToString();
        }
    }
}
