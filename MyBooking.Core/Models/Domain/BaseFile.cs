using System;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public abstract class BaseFile
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Path { get; protected set; }
        public DateTime DateCreated { get; protected set; } = DateTime.Now;

        public static T Create<T>(string path) where T : BaseFile, new() => new T
        {
            Path = path
        };
    }
}