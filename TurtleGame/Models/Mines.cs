namespace TurtleGame.Models
{
    using System.Collections.Generic;

    public class Mines
    {
        public List<Mine> List { get; set; }

        public bool IsOver(Item item)
        {
            foreach (var mine in this.List)
            {
                if (item.IsOver(mine))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
