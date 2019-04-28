namespace TurtleGame.Services
{
    using System;

    using TurtleGame.Models;
    using TurtleGame.Output;
    using TurtleGame.Services.Enums;

    public class GameService
    {
        private readonly Board board;

        private readonly Exit exit;

        private readonly Mines mines;

        private readonly IOutput output;

        private readonly Turtle turtle;

        private int actionNumber;

        private GameAction lastAction;

        public GameService(Board board, Mines mines, Exit exit, Turtle turtle, IOutput output)
        {
            this.board = board;
            this.mines = mines;
            this.exit = exit;
            this.turtle = turtle;
            this.output = output;
            this.Status = GameStatus.Playing;
            this.actionNumber = 0;
        }

        public GameStatus Status { get; set; }

        public void Action(GameAction action)
        {
            this.output.WriteLine(this.turtle);

            this.actionNumber++;
            this.lastAction = action;
            switch (action)
            {
                case GameAction.Move:
                    this.turtle.Move();
                    break;
                case GameAction.Rotate:
                    this.turtle.Rotate();
                    break;
            }

            this.UpdateStatus();
        }

        private void UpdateStatus()
        {
            this.output.Write($"Action {this.actionNumber} -> ");
            this.output.SetColor(this.lastAction == GameAction.Rotate ? ConsoleColor.Yellow : ConsoleColor.Cyan);
            this.output.WriteLine(this.lastAction);

            if (this.turtle.IsOver(this.exit))
            {
                this.Status = GameStatus.Success;
                this.output.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and found the exit!");
            }
            else if (this.mines.IsOver(this.turtle))
            {
                this.Status = GameStatus.MineHit;
                this.output.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and trigged a mine!");
            }
            else if (this.board.LeftMap(this.turtle))
            {
                this.Status = GameStatus.HitWall;
                this.output.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and hitted a wall!");
            }
            else
            {
                this.output.WriteLine(
                    this.lastAction == GameAction.Rotate
                        ? $"The turtle was point to {this.turtle.LastDirection} and rotated to {this.turtle.Direction}."
                        : $"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y}.");
            }

            this.output.WriteLine();
            this.output.SetColor(ConsoleColor.Gray);
        }
    }
}