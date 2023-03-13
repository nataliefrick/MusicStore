namespace MusicStore.Models
{
    public class AlbumViewModel
    {
        public IEnumerable<Album>? Albums { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }

        public string SearchTerm { get; set; } = "";
        public string FilteredGenre { get; set; } = "";
    }
}
