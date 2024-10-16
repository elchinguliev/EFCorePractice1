using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployerProject> EmployerProjects { get; set; }

    }
}
