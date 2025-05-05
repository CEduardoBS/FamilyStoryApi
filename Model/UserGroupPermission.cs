using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Model
{
    [Table("user_group_permission")]
    public class UserGroupPermission
    {
        [Key]
        [Column("prm_id"), DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int UserGroupPermissionId { get; set; }

        [Column("prm_id_group")]
        [ForeignKey("UserGroupId")]
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        [Required]
        [Column("prm_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("prm_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("prm_is_deleted")]
        public int IsDeleted { get; set; }

        [Column("prm_is_active")]
        public int IsActive { get; set; }
    }
}
