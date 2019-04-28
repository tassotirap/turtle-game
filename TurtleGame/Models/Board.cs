namespace TurtleGame.Models
{
    public class Board
    {
        public int Height { get; set; }

        public int Weight { get; set; }

        public bool LeftMap(Item item)
        {
            return item.Y < 0 || item.X < 0 || item.Y > this.Height || item.X > this.Weight;
        }
    }
}
