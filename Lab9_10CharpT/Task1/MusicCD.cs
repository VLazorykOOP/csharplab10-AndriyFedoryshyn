using System.Collections;

public class MusicCD {
    public string Title { get; set; }
    public string Artist { get; set; }
    public Hashtable songs = new Hashtable();

    public MusicCD(string title, string artist) {
        Title = title;
        Artist = artist;
    }

    public void AddSong(string title, string artist, double duration) {
        if (duration <= 0 )
            throw new ArgumentOutOfRangeException("ARGUMENT OUT OF RANGE. Duration must be positive.");
        if (songs.Count == int.MaxValue)
            throw new OverflowException("OverflowException. Maximum number of songs reached.");
        songs.Add(title, new Song(title, artist, duration));
        Console.WriteLine($"Song '{title}' by '{artist}' added successfully.");
    }

    public double CalculateAverageDuration() {
        if (songs.Count == 0)
            throw new DivideByZeroException("DIVIDE BY ZERO EXCEPTION. No songs in CD to calculate average duration.");
        double totalDuration = 0;
        foreach (Song song in songs.Values) {
            totalDuration += song.Duration;
        }
        return totalDuration / songs.Count;
    }

    public void DisplaySongs() {
        Console.WriteLine($"---Songs on CD '{Title}':");
        foreach (DictionaryEntry entry in songs) {
            if (entry.Value is Song song) {
                Console.WriteLine($"   {song.Title} by {song.Artist}: {song.Duration} minutes");
            } else {
                throw new ArrayTypeMismatchException("Non-song item found in songs collection.");
            }
        }
    }
}
