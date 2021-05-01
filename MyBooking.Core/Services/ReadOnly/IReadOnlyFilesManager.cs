namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyFilesManager
    {
        string ProjectPath { get; }
        string WebRootPath { get; }

        bool FileExists(string filePath);
    }
}