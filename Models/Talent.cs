namespace EthioServices.Models
{
    public class Talent
    {
        public int Id { get; set; }

        public string email { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public string location { get; set; }

        public double salary { get; set; }

        public string? description { get; set; }
        public string imageUrl { get; set; }

        public string? portfolioUrl { get; set; }

        public double rating { get; set; }

        public int acceptedJobs { get; set; }

        public int appliedJobs { get; set; }

        public float balance { get; set; }

        public List<JobStatus>? currentJobsList { get; set; }

        public List<JobStatus>? invitedJobsList { get; set; }

        public List<JobStatus>? allJobsList { get; set; }


        public Talent()
        {
                
        }



    }
}
