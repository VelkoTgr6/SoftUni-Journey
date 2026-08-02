using System.ComponentModel.DataAnnotations;

namespace Text_Splitter.Models
{
    public class TextViewModel
    {
		public string Text { get; set; } = null!;
        public string SplitText { get; set; } = null!;
    }
}
