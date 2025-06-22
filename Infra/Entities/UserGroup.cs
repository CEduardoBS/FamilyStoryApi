using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Infra.Entities
{
    [Table("user_group")]
    public class UserGroup
    {
        [Column("grp_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [Column("grp_name")]
        public string Name { get; set; } = string.Empty;

        [Column("grp_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("grp_is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("grp_is_active")]
        public bool IsActive { get; set; }
    }
}
