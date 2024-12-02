namespace AdventOfCode2022.Utils
{
    public static class Reader
    {
        public static IEnumerable<string> Read(string filepath)
        {
            return File.ReadLines(filepath);
        }

    }
}
