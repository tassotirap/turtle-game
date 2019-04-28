namespace TurtleGame.Output
{
    using System;

    public interface IOutput
    {
        void Write(object obj);

        void WriteLine(object obj);

        void WriteLine();

        void SetColor(ConsoleColor color);
    }
}
