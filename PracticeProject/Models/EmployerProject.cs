namespace PracticeProject.Models
{
    public class EmployerProject
    {
        public int EmployerId { get; set; }
        public int ProjectId { get; set; }
        public Employer Employer { get; set; }
        public Project Project { get; set; }
    }
}
