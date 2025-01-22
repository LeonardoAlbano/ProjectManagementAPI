namespace ProjectManagementAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ProjectLink { get; set; }
        public string? LanguagesUsed { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? TechnicalDetails { get; set; }
        public string? Statistics { get; set; }
        public string? Documentation { get; set; }
    }
}
