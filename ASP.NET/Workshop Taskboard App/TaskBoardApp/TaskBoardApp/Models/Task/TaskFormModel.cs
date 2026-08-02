using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.TaskTitleMaxLength, MinimumLength = DataConstants.TaskTitleMinLength
            ,ErrorMessage = "Title should be at lease {2} characters long.")]
        public string Title { get; set; }= string.Empty;

        [Required]
        [StringLength(DataConstants.TaskDescriptionMaxLength, MinimumLength = DataConstants.TaskDescriptionMinLength
            , ErrorMessage = "Description should be at lease {2} characters long.")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
