namespace AspBlog.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Oponent {  get; set; }
        public string Place { get; set; }
        public string Score { get; set; }
        public string Cathegory { get; set; }
        public DateTime DateOfGame { get; set; }
        public string? Describtion { get; set; }


        public ICollection<Comments> Commentars { get; set; } = new List<Comments>();
        public virtual ICollection<Pictures> Pictures { get; set; } = new List<Pictures>(); 
    }
}
