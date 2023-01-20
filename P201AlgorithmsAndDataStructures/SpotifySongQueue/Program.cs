using TurboCollections;

TurboLinkedQueue<string> songList = new TurboLinkedQueue<string>();
while (true) 
{
    Console.WriteLine("What would you like to do? [s]kip or [a]dd?");
    
    var input = Console.ReadKey().Key;
    
    Console.WriteLine();
    
    if (input == ConsoleKey.A) 
    {
        Console.WriteLine("Enter the Song's Name");
        songList.Enqueue(Console.ReadLine() ?? string.Empty);
    }
    if (input == ConsoleKey.S)
    {
        Console.WriteLine(songList.Count == 0
            ? "There is no more songs in the Queue."
            : $"Now Playing: {songList.Dequeue()}");
    }
}