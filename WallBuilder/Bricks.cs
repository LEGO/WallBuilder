using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallBuilder
{
    class Bricks
    {
        private Dictionary<int, string> validBricks = new Dictionary<int, string>()
        {
            { 1, "A" },
            { 2, "BB" },
            { 3, "CCC" },
            { 4, "DDDD" },
            { 6, "FFFFFF" },
            { 8, "HHHHHHHH" },
            { 10, "JJJJJJJJJJ" },
            { 12, "LLLLLLLLLLLL" }
        };
        public Bricks() { }
        public int LargestBrick()
        {
            return validBricks.Keys.Max();
        }
        public void ShowBricks()
        {
            Console.WriteLine("Largest brick is " + LargestBrick() + " knobs wide");
            Console.WriteLine("The Bricks:");
            foreach (KeyValuePair<int,string> kvp in validBricks)
            {
                Console.WriteLine("1x" + kvp.Key + " : " + kvp.Value);
            }
        }
        private KeyValuePair<int, string> GetRandomBrick(Random rnd, int maxSize)
        {
            int size = rnd.Next(1, maxSize);
            //Console.WriteLine("maxSize: " + maxSize + " size: " + size);
            for (int i = size; i > 0; i--)
            {
                if (validBricks.ContainsKey(i))
                {
                    //Console.WriteLine("Found > i: " + i + " validBricks[i]: " + validBricks[i]);
                    return new KeyValuePair<int, string>(i, validBricks[i]);
                }
            }
            return validBricks.First();
        }
        private int GetRndLimit(int width, int rowLength)
        {
            return LargestBrick() < width - rowLength ? LargestBrick() : width - rowLength;
        }
        //  Return random row, without any rule
        public string GetRow(int width)
        {
            string row = string.Empty;
            Random rnd = new Random();
            do
            {
                row += GetRandomBrick(rnd, GetRndLimit(width, row.Length)).Value;
                //Console.WriteLine("row: " + row);
            }
            while (row.Length < width);
            return row;
        }
    }
}
