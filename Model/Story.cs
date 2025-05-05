using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyStoryApi.Model
{
    [Table("story")]
    public class Story
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Column("str_id")]
        public int StoryId { get; set; }

        [Column("str_user_id")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserInfo UserInfo { get; set; }

        [Column("str_relative_id")]
        [ForeignKey("RelativesId")]
        public int RelativesId { get; set; }
        public Relatives Relatives { get; set; }

        [Column("str_title")]
        public string Title { get; set; } = string.Empty;

        [Column("str_content")]
        public string Content { get; set; } = string.Empty;

        [Column("str_media_url")]
        public string MediaUrl { get; set; } = string.Empty;

        [Column("str_media_type")]
        public string MediaType { get; set; } = string.Empty;

        [Column("str_created_at")]
        public DateTime CreateAt { get; set; }

        [Column("str_is_deleted")]
        public int IsDeleted { get; set; }

        [Column("str_is_active")]
        public int IsActive { get; set; }
    }
}
