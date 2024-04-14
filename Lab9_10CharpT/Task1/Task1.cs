public class Task1
{
    public static void Program1()
    {
        try
        {
            MusicCatalog catalog = new MusicCatalog();
            catalog.AddMusicCD("CD1", "Different Artists");
            catalog.AddMusicCD("CD2", "Artist 1");
            Console.WriteLine("-----------------------------");

            catalog.AddSong("CD1", "Song 1", "Artist 1", 3.5);
            catalog.AddSong("CD1", "Song 2", "Artist 2", 4.2);
            catalog.AddSong("CD1", "Song 11", "Artist 1", 4.0);
            catalog.AddSong("CD2", "Song 3", "Artist 1", 5.0);
            catalog.AddSong("CD2", "Song 4", "Artist 1", 6.0);
            catalog.AddSong("CD2", "Song 5", "Artist 1", 6.0);
            catalog.AddSong("CD2", "Song 6", "Artist 1", 5.0);
            Console.WriteLine("\n-----------------------------");

            catalog.DisplayCatalog();
            Console.WriteLine("\n-----------------------------");

            Console.WriteLine($"Average duration on CD2: {catalog.GetMusicCD("CD2").CalculateAverageDuration()}");
            Console.WriteLine("\n-----------------------------");

            catalog.SearchByArtist("Artist 1");
            Console.WriteLine("\n-----------------------------");


            // // DivideByZeroException
            // Console.WriteLine($"Average duration on an empty CD: {new MusicCD("CD2", "Artist 1").CalculateAverageDuration()}");
            // Console.WriteLine("-----------------------------");

            // // ArrayTypeMismatchException
            // catalog.musicCDs.Add("Faulty CD", "Artist 1");
            // catalog.DisplayCatalog();
            // Console.WriteLine("-----------------------------");

            // // OverflowException
            // catalog.AddSong("CD1", "Impossible Song", "Artist 99", double.MaxValue);
            // Console.WriteLine("-----------------------------");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex.Message}");
        }
    }
}





