// See https://aka.ms/new-console-template for more information
//using WallBuilder;
namespace WallBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("argument count: " + args.Length);
            //foreach (string arg in args)
            //{
            //    Console.WriteLine("args: " + arg);
            //}
            /*
             * Expected arguments:
             * 1. width (int)
             * 2. height (int)
             * 3. rule (optional)
             */

            Wall wall = new Wall();

            //  Validate arguments one by one, fail fast
            if (args.Length < 2)
            {
                Console.WriteLine(wall.InvalidArguments());
                return;
            }

            if (!wall.ValidateWidth(args[0]))
            {
                Console.WriteLine(wall.InvalidWidth());
                return;
            }
            wall.SetWidth(args[0]);
            Console.WriteLine("theWidth: " + wall.GetWidth());

            if (!wall.ValidateHeight(args[1]))
            {
                Console.WriteLine(wall.InvalidHeight());
                return;
            }
            wall.SetHeight(args[1]);
            Console.WriteLine("theHeight: " + wall.GetHeight());

            if (args.Length == 3)
            {
                wall.SetRule(args[2]);
                if (wall.GetRule().Length > 0)
                {
                    Console.WriteLine("Using Rule: " + wall.GetRule());
                }
            }

            wall.BuildWall();
            wall.PrintWall();
        }
    }
}