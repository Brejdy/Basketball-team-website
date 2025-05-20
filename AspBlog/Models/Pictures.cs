namespace AspBlog.Models
{
    public class Pictures
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int? PageContentId { get; set; }
        public PageContent? PageContent { get; set; }

        public int? GameId { get; set; }
        public Games? Game { get; set; }
    }
}
