using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Infra.Entities
{
    [Table("relatives")]
    public class Relatives
    {
        [Column("rlt_id"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelativesId { get; set; }

        [Column("rlt_user_id")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserInfo? UserInfo { get; set; }

        [Column("rlt_name")]
        public string Name { get; set; } = string.Empty;

        [Column("rlt_relation")]
        public string Relation { get; set; } = string.Empty;

        [Column("rlt_parentage")]
        [ForeignKey("Level")]
        public int LevelParentageId { get; set; }
        public LevelParentage? LevelParentage { get; set; }

        [Column("rlt_birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("rlt_photo_url")]
        public string PhotoUrl { get; set; } = string.Empty;

        [Column("rlt_created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("rlt_is_deleted")]
        public int IsDeleted { get; set; }

        [Column("rlt_is_active")]
        public int IsActive { get; set; }
    }
}
