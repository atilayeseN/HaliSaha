namespace HaliSahaApi.Models
{
    public class Posts
    {

        public int Id { get; set; }
        public Members? Owner { get; set; }

        public List<Members>? Participants { get; set; }

        public DateTime Time { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Posts posts &&
                   Id == posts.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
