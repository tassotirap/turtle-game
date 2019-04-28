namespace TurtleGame
{
    using System;
    using System.IO;

    using Newtonsoft.Json;

    using TurtleGame.FileModels;
    using TurtleGame.Output;
    using TurtleGame.Services;
    using TurtleGame.Services.Enums;

    public class Program
    {
        public static void Main(string[] args)
        {
            var configFile = GetConfigFile(args);
            var game = new GameService(configFile.Board, configFile.Mines, configFile.Exit, configFile.Turtle, new ConsoleOutput());

            var movements = GetMovementFile(args);
            foreach (var movement in movements.Movements)
            {
                game.Action(movement);
                if (game.Status != GameStatus.Playing)
                {
                    break;
                }
            }

            Console.ReadKey();
        }

        private static ConfigFile GetConfigFile(string[] args)
        {
            if (args.Length > 0)
            {
                var file = File.ReadAllText($"{args[0]}.yml");
                return JsonConvert.DeserializeObject<ConfigFile>(file);
            }
            else
            {
                var file = File.ReadAllText("Config.yml");
                return JsonConvert.DeserializeObject<ConfigFile>(file);
            }
        }

        private static MovementFile GetMovementFile(string[] args)
        {
            if (args.Length > 1)
            {
                var file = File.ReadAllText($"{args[1]}.yml");
                return JsonConvert.DeserializeObject<MovementFile>(file);
            }
            else
            {
                var file = File.ReadAllText("Success.yml");
                return JsonConvert.DeserializeObject<MovementFile>(file);
            }
        }
    }
}
