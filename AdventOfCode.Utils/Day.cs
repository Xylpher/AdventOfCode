using AdventOfCode2022.Utils;

namespace AdventOfCode.Utils
{
    public abstract class Day
    {
        protected string inputPath;
        protected IEnumerable<string> lines;
        public Day(int day)
        {
            //inputPath = $@"D:\VisualStudio\AdventOfCode\AdventOfCode{year}\Inputs\input{day}.txt";
            inputPath = $@"..\..\..\Inputs\input{day}.txt";

            lines = Reader.Read(inputPath);
        }

        public virtual string ProblemOne()
        {
            return "";
        }
        public virtual string ProblemTwo()
        {
            return "";
        }



    }
}
