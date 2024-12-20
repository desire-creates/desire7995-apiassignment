using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiassignment.Models{
    public class order{
        public int ID{get; set;}
        public int userID{get; set;}
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        
        public virtual user User { get; set; }

        [JsonIgnore]        
        public virtual ICollection<product> Products { get; set; } = new List<product>();
    }
}