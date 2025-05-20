namespace AspBlog.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<PageContent> Articles { get; set; }
        public IEnumerable<Games> Games { get; set; }
    }

}
