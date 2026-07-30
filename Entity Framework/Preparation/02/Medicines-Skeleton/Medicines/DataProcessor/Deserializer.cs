namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            ImportPatientDTO[] importPatientDTOs=JsonConvert.DeserializeObject<ImportPatientDTO[]>(jsonString);

            var sb=new StringBuilder();

            List<Patient> patientList = new List<Patient>();

            foreach (var pDto in importPatientDTOs)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = pDto.FullName,
                    AgeGroup = (AgeGroup)pDto.AgeGroup,
                    Gender = (Gender)pDto.Gender,
                    PatientsMedicines=new List<PatientMedicine>()
                };

                foreach (int medId in pDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medId,
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }
                    patientList.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient,patient.FullName,patient.PatientsMedicines.Count()));
            }

            context.AddRange(patientList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            ImportPharmacyDTO[] importPharmacyDTOs = XmlHelper.DeserializeFromXml<ImportPharmacyDTO[]>(xmlString,"Pharmacies");

            var sb=new StringBuilder();

            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (var pharmacyDTO in importPharmacyDTOs)
            {
                if (!IsValid(pharmacyDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                Pharmacy pharmacy = new Pharmacy()
                {
                    IsNonStop =bool.Parse(pharmacyDTO.IsNonStop),
                    Name = pharmacyDTO.Name,
                    PhoneNumber = pharmacyDTO.PhoneNumber,
                    Medicines = new List<Medicine>()
                };

                foreach (var medicineDTO in pharmacyDTO.Medicines)
                {
                    if (!IsValid(medicineDTO)) 
                    {
                        sb.AppendLine(ErrorMessage);
                        continue; 
                    }

                    var productionDateParsed = DateTime.ParseExact(medicineDTO.ProductionDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    var expiryDateParsed = DateTime.ParseExact(medicineDTO.ExpiryDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (productionDateParsed >= expiryDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(m=>m.Name == medicineDTO.Name && m.Producer == medicineDTO.Producer))
                    {
                        sb.AppendLine(ErrorMessage); 
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Category = (Category)medicineDTO.Category,
                        Name = medicineDTO.Name,
                        Price = medicineDTO.Price,
                        ProductionDate = productionDateParsed,
                        ExpiryDate = expiryDateParsed,
                        Producer = medicineDTO.Producer,
                    };

                    pharmacy.Medicines.Add(medicine);
                }
                pharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy,pharmacy.Name,pharmacy.Medicines.Count()));
            }

            context.AddRange(pharmacies);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
