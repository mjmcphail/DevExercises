using System.Collections.Generic;

namespace RS.Common.Interfaces
{
    public interface IFileFacade
    {
        IEnumerable<string> ReadLines(string filePath);   
    }
}
