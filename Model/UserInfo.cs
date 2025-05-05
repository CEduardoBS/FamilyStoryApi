using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Model
{
    [Table("user_info")]
    public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("usr_id")]
        public int UserId { get; set; }

        [Column("usr_email")]
        public string Email { get; set; } = string.Empty;

        [Column("usr_name")]
        public string Name { get; set; } = string.Empty;

        [Column("usr_password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("usr_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("usr_is_deleted")]
        public int IsDeleted { get; set; }

        [Column("usr_is_active")]
        public int IsActive { get; set; }

        [Column("usr_group")]
        [ForeignKey("UserGroupId")]
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
