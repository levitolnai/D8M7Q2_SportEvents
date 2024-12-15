using System.ComponentModel.DataAnnotations.Schema;

namespace D8M7Q2_SportEvents.Entities
{
    public class SportEvent
    {
        public SportEvent(string title, string date, int applicantLimit)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Date = date;
            ApplicantLimit = applicantLimit;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Date { get; set; }
        public int ApplicantLimit { get; set; }

        [NotMapped]
        public virtual ICollection<Competitor>? Competitors { get; set; }
    }
}
