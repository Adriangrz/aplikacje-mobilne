namespace GameAm.Models
{
    public class CreateWebPointDto
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
