using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.BoardGameNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public double Rating {  get; set; }

        [Required]
        public int YearPublished {  get; set; }

        [Required]
        public CategoryType CategoryType {  get; set; }

        [Required]
        public string Mechanics {  get; set; }

        [Required]
        public int CreatorId {  get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual Creator Creator { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
