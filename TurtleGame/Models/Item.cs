namespace TurtleGame.Models
{
    public class Item
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool IsOver(Item obj)
        {
            return obj.X == this.X && obj.Y == this.Y;
        }
    }
}
