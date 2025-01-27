namespace ProjectManagementAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }  // Mapeia para a coluna 'title'
        public string? Description { get; set; }  // Mapeia para a coluna 'description'
        public string? ProjectUrl { get; set; }  // Mapeia para a coluna 'projectUrl'
        public string? Language { get; set; }  // Mapeia para a coluna 'language'
        public string? Category { get; set; }  // Mapeia para a coluna 'category'
        public string? TechnicalDetails { get; set; }  // Mapeia para a coluna 'technicalDetails'
        public string? Statistics { get; set; }  // Mapeia para a coluna 'statistics'
        public string? Documentation { get; set; }  // Mapeia para a coluna 'documentation'

        // Alteração para string[] em vez de List<string>
        public string[]? Images { get; set; }  // Mapeia para a coluna 'images'
    }
}
