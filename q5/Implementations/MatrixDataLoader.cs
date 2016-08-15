using System;
using System.Collections.Generic;
using System.Linq;
using q5.Interfaces;
using RS.Common.Interfaces;

namespace q5.Implementations
{
    /// <summary>
    /// This class will generate a 2 dimentional
    /// array of strings given a file path
    /// where the file has rows of data with values 
    /// separated by spaces
    /// </summary>
    public class MatrixDataLoader : IMatrixDataLoader
    {
        private readonly IFileFacade _fileFacade;

        public MatrixDataLoader(IFileFacade fileFacade)
        {
            _fileFacade = fileFacade;
        }

        /// <summary>
        /// This function generates a 2D string array
        /// for the data file given in the filePath parameter
        /// Strings are used because we do not know the data type
        /// of the data in the file.
        /// </summary>
        /// <param name="filePath">Path of the data file</param>
        /// <returns>2D array of strings</returns>
        public string[,] Load(string filePath)
        {
            var dataLines = _fileFacade.ReadLines(filePath).ToList();

            //if count > 0 rows = count, otherwise 0
            var rows = dataLines.Count > 0 ? dataLines.Count : 0;
            //if count > 0 cols = number of items in the first row, otherwise 0
            var cols = dataLines.Count > 0 ? dataLines[0].Trim().Split(new char[]{' '}, 
                StringSplitOptions.RemoveEmptyEntries).Count() : 0;
            var result = new string[rows, cols];
            var currentRow = 0;
            foreach (var line in dataLines)
            {
                LoadArrayRow(result, line.Trim(), currentRow);
                currentRow++;
            }
            return result;
        }

        /// <summary>
        /// Loads a single row of data into the 2D array.
        /// </summary>
        /// <param name="result">2D array result</param>
        /// <param name="line">Data file data line</param>
        /// <param name="currentRow">Current row number of the 2D array</param>
        private static void LoadArrayRow(string[,] result, string line, int currentRow)
        {
            var currentCol = 0;
            IEnumerable<string> rowItems = line.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var rowItem in rowItems)
            {
                result[currentRow, currentCol] = rowItem;
                currentCol++;
            }
        }
    }
}
