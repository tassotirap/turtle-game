namespace TurtleGame.FileModels
{
    using TurtleGame.Models;

    public class ConfigFile
    {
        public Board Board { get; set; }

        public Turtle Turtle { get; set; }

        public Exit Exit { get; set; }

        public Mines Mines { get; set; }
    }
}
