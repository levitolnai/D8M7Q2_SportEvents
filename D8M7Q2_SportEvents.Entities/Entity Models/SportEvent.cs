using D8M7Q2_SportEvents.Entities.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D8M7Q2_SportEvents.Entities
{
    public class SportEvent: IIdEntity
    {
        public SportEvent(string title, string description, string date, int competitorLimit)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            Date = date;
            CompetitorLimit = competitorLimit;
        }
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public string Date { get; set; }
        public int CompetitorLimit { get; set; }

        [NotMapped]
        public virtual ICollection<Competitor>? Competitors { get; set; }
    }
}
