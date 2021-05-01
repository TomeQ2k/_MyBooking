namespace MyBooking.Core.Models.Helpers
{
    public class FileModel
    {
        public string Path { get; }
        public string Url { get; }

        public FileModel(string path, string url)
        {
            Path = path;
            Url = url;
        }
    }
}