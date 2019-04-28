namespace TurtleGame.Models
{
    using System;

    public class Game
    {
        private readonly Board board;

        private readonly Exit exit;

        private readonly Mines mines;

        private readonly Turtle turtle;

        private int actionNumber;

        private GameAction lastAction;

        public Game(Board board, Mines mines, Exit exit, Turtle turtle)
        {
            this.board = board;
            this.mines = mines;
            this.exit = exit;
            this.turtle = turtle;
            this.Status = GameStatus.Playing;
            this.actionNumber = 0;
        }

        public enum GameAction
        {
            Rotate,

            Move
        }

        public enum GameStatus
        {
            Playing = 0,

            Success = 2,

            MineHit = 3,

            HitWall = 4
        }

        public GameStatus Status { get; set; }

        public void Action(GameAction action)
        {
            Console.WriteLine(this.turtle);

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
            Console.Write($"Action {this.actionNumber} -> ");
            Console.ForegroundColor = this.lastAction == GameAction.Rotate ? ConsoleColor.Yellow : ConsoleColor.Cyan;
            Console.WriteLine(this.lastAction);

            if (this.turtle.IsOver(this.exit))
            {
                this.Status = GameStatus.Success;
                Console.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and found the exit!");
            }
            else if (this.mines.IsOver(this.turtle))
            {
                this.Status = GameStatus.MineHit;
                Console.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and trigged a mine!");
            }
            else if (this.board.LeftMap(this.turtle))
            {
                this.Status = GameStatus.HitWall;
                Console.WriteLine($"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y} and hitted a wall!");
            }
            else
            {
                Console.WriteLine(this.lastAction == GameAction.Rotate
                        ? $"The turtle was point to {this.turtle.LastDirection} and rotated to {this.turtle.Direction}."
                        : $"The turtle moved from {this.turtle.LastX}-{this.turtle.LastY} to {this.turtle.X}-{this.turtle.Y}.");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}