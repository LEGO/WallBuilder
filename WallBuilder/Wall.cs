using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallBuilder
{
    public class Wall
    {
        private const int minWidth = 2;
        private const int minHeight = 2;
        private const int maxWidth = 40;
        private const int maxHeight = 20;
        private static int theWidth;
        public static int theHeight;
        public static string theRule = "";
        public void SetWidth(string value) { theWidth = int.Parse(value); }
        public void SetHeight(string value) { theHeight = int.Parse(value); }
        public int GetWidth() { return theWidth; }
        public int GetHeight() { return theHeight; }
        public void SetRule(string value) { theRule = value; }
        public string GetRule() { return theRule; }

        private List<string> theWall;
        public Wall()
        {
            theWall = new List<string>();
        }
        //  default method, build a wall without any rules
        public void BuildWall()
        {
            if (GetRule().Length > 0)
            {
                Console.WriteLine(GetRule() + " to be implemented!");
            }
            Bricks bricks = new Bricks();
            bricks.ShowBricks();
            if (theWall is null)
            {
                theWall = new List<string>();
            }
            for (int row = 0; row < theHeight; row++)
            {
                theWall.Add(bricks.BuildRow(theWidth));
            }
        }
        public void PrintWall()
        {
            //  Wall is built bottom up, so it must be reversed before printing
            Console.WriteLine("The Wall:");
            theWall.Reverse();
            foreach (string wall in theWall)
            {
                Console.WriteLine(wall);
            }
        }
        //  Validation
        public bool ValidateWidth(string width)
        {
            if (string.IsNullOrEmpty(width)) { return false; }
            if (int.TryParse(width, out int value))
            {
                return value >= minWidth && value <= maxWidth;
            }
            return false;
        }
        public bool ValidateHeight(string height)
        {
            if (string.IsNullOrEmpty(height)) { return false; }
            if (int.TryParse(height, out int value))
            {
                return value >= minHeight && value <= maxHeight;
            }
            return false;
        }
        public string ValidateRule(string rule)
        {
            string[] rules = { "interconnect", "addholes" };
            return rules.Contains(rule) ? rule : "";
        }
        public string InvalidWidth()
        {
            return "1st argument must be integer and between " + minWidth + " and " + maxWidth;
        }
        public string InvalidHeight()
        {
            return "2nd argument must be integer and between " + minHeight + " and " + maxHeight;
        }
        public string InvalidArguments()
        {
            return "Invalid arguments!\nMust be e.g.: WallBuilder 20 10";
        }
    }
}
