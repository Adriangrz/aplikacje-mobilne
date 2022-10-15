namespace GameAm.Database.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public ICollection<WebPoint> WebPoints { get; set; }
    }
}
