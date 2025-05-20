namespace AspBlog.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int? GameId { get; set; }
        public int? NewsId { get; set; }

        public PageContent? PageContent { get; set; }
        public Games? Games { get; set; }

    }
}
