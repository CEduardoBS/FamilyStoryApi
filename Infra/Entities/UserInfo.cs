using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Infra.Entities
{
    [Table("user_info")]
    public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usr_id")]
        public int UserId { get; set; }

        [EmailAddress]
        [Column("usr_email")]
        public string Email { get; set; } = string.Empty;

        [Column("usr_name")]
        public string Name { get; set; } = string.Empty;

        [Column("usr_password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("usr_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("usr_is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("usr_is_active")]
        public bool IsActive { get; set; }

        [Column("usr_group")]
        [ForeignKey("UserGroupId")]
        public int UserGroupId { get; set; }
        public UserGroup? UserGroup { get; set; }

        public void PasswordToBase64()
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(this.PasswordHash);
            this.PasswordHash = Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        public bool ValidPassword(string passwordDigited)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(passwordDigited);
            string passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);

            return passwordBase64.Equals(this.PasswordHash);
        }
    }
}
