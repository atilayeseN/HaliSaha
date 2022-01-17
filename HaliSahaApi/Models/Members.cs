
using System.ComponentModel.DataAnnotations.Schema;

namespace HaliSahaApi.Models
{
    public class Members
    {

        public int ID { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is Members members &&
                   ID == members.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
