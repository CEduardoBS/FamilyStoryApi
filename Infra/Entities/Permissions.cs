using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Infra.Entities
{
    [Table("permissions")]
    public class Permissions
    {
        [Key]
        [Column("perm_id")]
        public int PermissionId { get; set; }

        [Column("perm_key")]
        public string Key { get; set; }

        [Column("perm_description")]
        public string Description { get; set; }

        [Column("perm_is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("perm_is_active")]
        public bool IsActive { get; set; }
    }
}
