static List<KeyValuePair<int, string>> InsertIntoSortedCollection(
    List<KeyValuePair<int, string>> kvPairsSortedByKey, int key, string value)
{
    var smallerValues = kvPairsSortedByKey.TakeWhile(kv => kv.Key < key);
    var biggerValues = kvPairsSortedByKey.SkipWhile(kv => kv.Key < key);

    return smallerValues.Append(new KeyValuePair<int, string>(key, value)).Concat(biggerValues).ToList();
}