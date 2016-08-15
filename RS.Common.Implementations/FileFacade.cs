using RS.Common.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace RS.Common.Implementations
{
    /// <summary>
    /// This class is intended to 
    /// provide a simple wrapper to 
    /// getting lines of data from a file
    /// </summary>
    public class FileFacade : IFileFacade
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                return File.ReadLines(filePath);
            }
            throw new FileNotFoundException("Specified file does not exist.", filePath);
        }
    }
}
