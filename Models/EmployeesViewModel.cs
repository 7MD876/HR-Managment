using LearningManagementSystem.Data;
using LearningManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
    public class EmployeesViewModel
    {
        public int IdEmployees { get; set; }

        public string Name { get; set; } = null!;

        public int Identitynumber { get; set; }

        public int Employeenumber { get; set; }

        public int Gender { get; set; }

        public int RankId { get; set; }

        public int jobId { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender GenderType { get; set; }
        public virtual ICollection<Jop> listJobs { get; set; } = new List<Jop>();

        public virtual ICollection<Rank> listRanks { get; set; } = new List<Rank>();
        public ICollection<Employee> listemployees { get; set; }= new List<Employee>();


    }
}
