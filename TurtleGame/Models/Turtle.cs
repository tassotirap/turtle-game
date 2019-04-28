namespace TurtleGame.Models
{
    public class Turtle : Item
    {
        public Turtle(int x, int y)
        {
            this.X = this.LastX = x;
            this.Y = this.LastY = y;
            this.Direction = this.LastDirection = TurtleDirection.Right;
        }

        public enum TurtleDirection
        {
            Left = 0,
            Right = 1,
            Up = 2,
            Down = 3
        }

        public TurtleDirection Direction { get; set; }

        public TurtleDirection LastDirection { get; set; }

        public int LastX { get; set; }

        public int LastY { get; set; }

        public void Rotate()
        {
            switch (this.Direction)
            {
                case TurtleDirection.Down:
                    this.LastDirection = this.Direction;
                    this.Direction = TurtleDirection.Left;
                    break;
                case TurtleDirection.Left:
                    this.LastDirection = this.Direction;
                    this.Direction = TurtleDirection.Up;
                    break;
                case TurtleDirection.Up:
                    this.LastDirection = this.Direction;
                    this.Direction = TurtleDirection.Right;
                    break;
                case TurtleDirection.Right:
                    this.LastDirection = this.Direction;
                    this.Direction = TurtleDirection.Down;
                    break;
            }
        }

        public void Move()
        {
            switch (this.Direction)
            {
                case TurtleDirection.Down:
                    this.LastY = this.Y;
                    this.LastX = this.X;
                    this.Y--;
                    break;
                case TurtleDirection.Left:
                    this.LastY = this.Y;
                    this.LastX = this.X;
                    this.X--;
                    break;
                case TurtleDirection.Up:
                    this.LastY = this.Y;
                    this.LastX = this.X;
                    this.Y++;
                    break;
                case TurtleDirection.Right:
                    this.LastY = this.Y;
                    this.LastX = this.X;
                    this.X++;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Turtle | Position: {this.X}-{this.Y} | Direction: {this.Direction}";
        }
    }
}