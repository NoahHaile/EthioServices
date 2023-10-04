namespace EthioServices.Models
{
    public class Jobs
    {

        public int Id { get; set; }
        public string name { get; set; }

        public string? ownerId { get; set; }
        public string type { get; set; }

        public string location { get; set; }

        public double? salary { get; set; }

        public double? payment {get; set; }

        public string? description { get; set; }


        public int appliedPeople { get; set; }


        public List<JobStatus>? peopleAppliedList { get; set; }

        public int? acceptedTalent { get; set; }

        public Jobs()
        {
                
        }
    }
}
