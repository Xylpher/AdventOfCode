namespace AdventOfCode.Utils
{
    public static class Extensions
    {
        public static void AddOrAppend<TKey>(this IDictionary<TKey, long> dictionary, TKey key, long value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = dictionary[key] + value;
            else
                dictionary.Add(key, value);
        }

        public static void AddOrAppend<TKey>(this IDictionary<TKey, int> dictionary, TKey key, int value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = dictionary[key] + value;
            else
                dictionary.Add(key, value);
        }

    }
}
