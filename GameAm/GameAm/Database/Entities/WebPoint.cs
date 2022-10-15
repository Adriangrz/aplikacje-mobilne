namespace GameAm.Database.Entities
{
    public class WebPoint
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
