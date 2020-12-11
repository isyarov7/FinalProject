namespace YNV.Api.Models
{
    public class CreatePostRequest
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public string Visability { get; set; }
    }
}
