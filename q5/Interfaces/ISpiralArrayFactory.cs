using System.Collections.Generic;

namespace q5.Interfaces
{
    public interface ISpiralArrayFactory
    {
        IEnumerable<string> Create(string[,] array);
    }
}
