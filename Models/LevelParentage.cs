using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Model
{
    [Table("level_parentage")]
    public class LevelParentage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("lvl_id")]
        public int LevelParentageId { get; set; }

        [Column("lvl_level")]
        public int Level { get; set; }

        [Column("lvl_description")]
        public string Description { get; set; } = string.Empty;

        [Column("lvl_is_deleted")]
        public int IsDeleted { get; set; }

        [Column("lvl_is_active")]
        public int IsActive { get; set; }
    }
}
