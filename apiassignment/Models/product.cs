using System.Text.Json.Serialization;

namespace apiassignment.Models{
    public class product{
        public int productID{get; set;}
        public string productName{get;set;} = string.Empty;
        public int productPrice{get;set;}
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual ICollection<order> Orders { get; set; } = new List<order>();

    }
}