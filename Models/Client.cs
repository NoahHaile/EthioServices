namespace EthioServices.Models
{
    public class Client
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public string location { get; set; }

        public double moneySpent { get; set; }

        public string? description { get; set; }
        public string imageUrl { get; set; }


        public double rating { get; set; }

        public int postedJobs { get; set; }

        public int activeJobs { get; set; }

        public float balance { get; set; }

        public List<JobStatus>? activeJobsList { get; set; }

        public List<JobStatus>? allJobsList { get; set; }


        public Client()
        {
               
        }
    }
}
