using FamilyStoryApi.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyStoryApi.WebApi.ViewModels.User
{
    public class GetUserViewModel()
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }

        public GetUserViewModel(int id, string name, string email, DateTime createAt) : this()
        {
            Id = id;
            Name = name;
            Email = email;
            CreateAt = createAt;
        }
    }
}
