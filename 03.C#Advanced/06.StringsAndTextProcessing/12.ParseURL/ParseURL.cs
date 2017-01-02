using System;

class ParseURL
{
    static void Main()
    {
        string url = Console.ReadLine();

        int indexOfDoubleDots = url.IndexOf(':');
        int indexFrom = indexOfDoubleDots + 3;
        int indexTo = url.IndexOf('/', indexFrom);
        string protocol = url.Substring(0, indexOfDoubleDots);
        string server = url.Substring(indexFrom, indexTo - indexFrom);
        string resource = url.Substring(indexTo);
        Console.WriteLine("[protocol] = {0}",protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }
}
