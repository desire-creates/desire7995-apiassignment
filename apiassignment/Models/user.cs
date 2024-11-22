using System.Text.Json.Serialization;

namespace apiassignment.Models{
    public class user{
        public int userID{get;set;}
        public string username{get;set;} = string.Empty;
        public string email {get; set;} = string.Empty;
        public string Password {get; set;} = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual ICollection<order> Orders { get; set;} = new List<order>();

    }
}