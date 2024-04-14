using System.Collections;

public class MusicCatalog 
{
    public Hashtable musicCDs = new Hashtable();

    public MusicCD GetMusicCD(string title) {
        if (musicCDs.ContainsKey(title) && musicCDs[title] is MusicCD cd) {
            return cd;
        }
        return null;
    }

    public void AddMusicCD(string title, string artist)
    {
        try
        {
            if (title == null || artist == null)
                throw new ArgumentNullException("ArgumentNullException. Title or artist cannot be null.");
            musicCDs.Add(title, new MusicCD(title, artist));
            Console.WriteLine($"Music CD '{title}' added successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error adding CD: {ex.Message}");
        }
    }

    public void RemoveMusicCD(string title)
    {
        try
        {
            if (!musicCDs.ContainsKey(title))
                throw new KeyNotFoundException("KeyNotFoundException. CD not found.");
            musicCDs.Remove(title);
            Console.WriteLine($"Music CD '{title}' removed successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error removing CD: {ex.Message}");
        }
    }
    public void AddSong(string cdTitle, string songTitle, string artist, double duration)
    {
        try
        {
            if (!musicCDs.ContainsKey(cdTitle))
                throw new KeyNotFoundException($"KeyNotFoundException. CD '{cdTitle}' not found.");

            if (musicCDs[cdTitle] is MusicCD cd)
            {
                if (duration <= 0)
                    throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException. Duration must be positive.");
                if (duration >= int.MaxValue)
                    throw new OverflowException("OverflowException. Duration is too long.");

                if (cd.songs.Count == int.MaxValue)
                    throw new OverflowException("OverflowException. Maximum number of songs reached.");

                cd.songs.Add(songTitle, new Song(songTitle, artist, duration));
                Console.WriteLine($"Song '{songTitle}' by '{artist}' added successfully to '{cdTitle}'.");
            }
            else
            {
                throw new InvalidCastException($"InvalidCastException. Unexpected type found for CD '{cdTitle}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding song: {ex.Message}");
        }
    }

    public void DisplayCatalog()
    {
        Console.WriteLine("---Music Catalog:");
        foreach (DictionaryEntry entry in musicCDs)
        {
            if (entry.Value is MusicCD cd)
            {
                Console.WriteLine($"Displaying songs on '{cd.Title}':");
                cd.DisplaySongs();
            }
            else
            {
                throw new ArrayTypeMismatchException("ArrayTypeMismatchException. Non-MusicCD item found in the musicCDs collection.");
            }
        }
    }


    public void SearchByArtist(string artist)
    {
        Console.WriteLine($"---Songs by artist '{artist}':");
        foreach (DictionaryEntry entry in musicCDs)
        {
            if (entry.Value is MusicCD cd)
            {
                foreach (DictionaryEntry songEntry in cd.songs)
                {
                    if (songEntry.Value is Song song && song.Artist == artist)
                    {
                        Console.WriteLine($"   on CD '{cd.Title}', {song.Title}: {song.Duration} minutes");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid entry found in catalog.");
            }
        }
    }
}