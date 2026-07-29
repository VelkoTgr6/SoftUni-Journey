using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private StudentRepository students;
        private SubjectRepository subjects;
        private UniversityRepository universities;

        public Controller()
        {
            students = new StudentRepository();
            subjects = new SubjectRepository();
            universities= new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            int id = students.Models.Count + 1;
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            IStudent student = new Student(id,firstName, lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully,firstName,lastName,nameof(StudentRepository)).TrimEnd();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject;
            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(TechnicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                int subjectId = subjects.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }
            }
            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully,subjectType, subjectName,nameof(SubjectRepository)).TrimEnd();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            var result = "";
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            else
            {
                List<int> intCollection = new List<int>();
                foreach (var item in requiredSubjects)
                {
                    var subject = subjects.FindByName(item);
                    var subjectId = subject.Id;
                    intCollection.Add(subjectId);
                }

                IUniversity university =
                       new University(this.universities.Models.Count + 1, universityName, category, capacity, intCollection);
                this.universities.AddModel(university);

                 result = string
                     .Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));

            }
            return result.TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            if (students.FindByName(studentName) == null)
            {
                var arr = studentName.Split(" ");
                return string.Format(OutputMessages.StudentNotRegitered, arr[0], arr[1]);
            }
            else if (universities.FindByName(universityName) == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!universities.FindByName(universityName).RequiredSubjects.All(x=>students.FindByName(studentName).CoveredExams.Any(e=>e==x)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (students.FindByName(studentName).University!= null &&
                students.FindByName(studentName).University.Name == universityName)
            {
                var selectedStudent = students.FindByName(studentName);
                return string.Format(OutputMessages.StudentAlreadyJoined, selectedStudent.FirstName, selectedStudent.LastName, universityName);
            }
            var university = universities.FindByName(universityName);
            var student = students.FindByName(studentName);
            students.FindByName(studentName).JoinUniversity(university);
            
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName,student.FirstName, universityName).TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId)==null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            else if (subjects.FindById(subjectId)== null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            else if (students.FindById(studentId).CoveredExams.Any(e=>e==subjectId))
            {
                var SelectedStudent = students.FindById(studentId);
                var selectedSubject=subjects.FindById(subjectId);
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, SelectedStudent.FirstName,
                    SelectedStudent.LastName, selectedSubject.Name);
            }
            var student=students.FindById(studentId);
            var subject=subjects.FindById(subjectId);
            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam,student.FirstName,student.LastName,subject.Name).TrimEnd();
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);
            var studentsAdmitted = students.Models.Where(u => u.University == university).Count();
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsAdmitted}");
            sb.AppendLine($"University vacancy: { university.Capacity - studentsAdmitted}");

            return sb.ToString().TrimEnd();
        }
    }
}
