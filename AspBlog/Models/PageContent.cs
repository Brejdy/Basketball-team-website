﻿namespace AspBlog.Models
{
    public class PageContent
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string SectionName { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}
