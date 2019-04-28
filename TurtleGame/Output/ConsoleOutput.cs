namespace TurtleGame.Output
{
    using System;

    public class ConsoleOutput : IOutput
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
