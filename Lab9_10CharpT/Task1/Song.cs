
public class Song {
    public string Title { get; set; }
    public string Artist { get; set; }
    public double Duration { get; set; }

    public Song(string title, string artist, double duration) {
        Title = title;
        Artist = artist;
        Duration = duration;
    }
}
