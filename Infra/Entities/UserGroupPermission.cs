using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Infra.Entities
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
        public UserGroup? UserGroup { get; set; }

        [Column("prm_id_permission")]
        [ForeignKey("PermissionId")]
        public int PermissionId { get; set; }
        public Permissions Permission { get; set; } = new();

        [Column("prm_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("prm_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("prm_is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("prm_is_active")]
        public bool IsActive { get; set; }
    }
}
