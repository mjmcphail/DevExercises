using System;
using q5.Interfaces;
using RS.Common.Interfaces;

namespace q5.Implementations
{
    /// <summary>
    /// This is the main logic class for the application
    /// Fairly simple logic
    /// 1.  Load the data from the file into a 2D array
    /// 2.  Process the 2D array to produce an enumeration
    /// 3.  Print the values in the enumeration
    /// </summary>
    public class Q5Application : IApplication
    {
        private readonly string _fileName;
        private readonly IMatrixDataLoader _matrixDataLoader;
        private readonly ISpiralArrayFactory _spiralArrayFactory;

        /// <summary>
        /// Constructor - dependencies injected
        /// </summary>
        /// <param name="fileName">Name of data file</param>
        /// <param name="matrixDataLoader">Matrix data loader dependency</param>
        /// <param name="spiralArrayFactory">Spiral array factory dependency</param>
        public Q5Application(string fileName, IMatrixDataLoader matrixDataLoader, ISpiralArrayFactory spiralArrayFactory)
        {
            _fileName = fileName;
            _matrixDataLoader = matrixDataLoader;
            _spiralArrayFactory = spiralArrayFactory;
        }
        public void Run()
        {
            //load the data from the file
            var dataArray = _matrixDataLoader.Load(_fileName);
            //generate an enumeration of strings from the 2D array
            var spiralArray = _spiralArrayFactory.Create(dataArray);
            //output the results
            foreach (var item in spiralArray)
                Console.Write(string.Format("{0} ", item));
        }
    }
}
