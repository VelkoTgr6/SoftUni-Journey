namespace SeminarHub.Models.Seminar
{
    public class SeminarAllViewModel
    {
        public SeminarAllViewModel(int id, string topic, string lecturer, string category, string organizer, string dateAndTime)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Category = category;
            Organizer = organizer;
            DateAndTime = dateAndTime;
        }

        public int Id { get; set; }

        public string Topic { get; set; }=string.Empty;

        public string Lecturer { get; set; } = string.Empty;

        public string Category { get; set; } =string.Empty;
        public string Organizer {  get; set; } =string.Empty;
        public string DateAndTime {  get; set; } = string.Empty;
    }
}
