using FamilyStoryApi.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace FamilyStoryApi.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        [EmailAddress(ErrorMessage = "E-mail inváliedo")]
        public string Address { get; set; }

        public Email() { }

        public Email(string email) 
        {
            try
            {
                Address = email;
            }
            catch (Exception err)
            {
                Address = string.Empty;
                AddNotification($"Email.Address: {err.Message}");
            }
        }
    }
}
