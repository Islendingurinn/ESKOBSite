namespace ESKOBSite.Models
{
    public class Hashtag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public Idea Idea { get; set; }
    }
}