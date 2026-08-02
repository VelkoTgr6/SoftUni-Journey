using Homies.Data;

namespace Homies.Models.Event
{
    public class EventInfoViewModel
    {
        public EventInfoViewModel(int id,string name,DateTime start,string type,string organizer)
        {
            Id = id;
            Name = name;
            Start = start.ToString(DataConstants.DateFormat);
            Type = type;
            Organiser = organizer;
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Start { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Organiser { get; set; } = string.Empty;
    }
}
