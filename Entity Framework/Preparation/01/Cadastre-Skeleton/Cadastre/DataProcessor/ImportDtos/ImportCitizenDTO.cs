using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDTO
    {
        [Required]
        [MinLength(ValidationConstants.CitizenFirstNameMinLegth)]
        [MaxLength(ValidationConstants.CitizenFirstNameMaxLegth)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.CitizenLastNameMinLegth)]
        [MaxLength(ValidationConstants.CitizenLastNameMaxLegth)]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string MaritalStatus { get; set; }

        public int[] Properties { get; set; }
    }
}
