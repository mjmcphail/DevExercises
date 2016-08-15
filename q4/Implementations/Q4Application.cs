using q4.Interfaces;
using RS.Common.Interfaces;
using System;

namespace q4.Implementations
{
    public class Q4Application : IApplication
    {
        private readonly string _fileName;
        private readonly IFileFacade _fileFacade;
        private readonly IWhitespaceRemover _whitespaceRemover;
        private readonly IDuplicateCharRemover _dupeCharRemover;

        public Q4Application(string fileName, IFileFacade fileFacade, IWhitespaceRemover whitespaceRemover, IDuplicateCharRemover dupeCharRemover)
        {
            _fileName = fileName;
            _fileFacade = fileFacade;
            _whitespaceRemover = whitespaceRemover;
            _dupeCharRemover = dupeCharRemover;
        }
        public void Run()
        {
            //read the lines of the file
            var lines = _fileFacade.ReadLines(_fileName);
            //go through each line and process it
            foreach (var line in lines)
            {
                //convert the string to a character array
                //because in .net strings are immutable
                //therefore we must do in-place string manipulation
                //using a character array
                char[] lineCharArray = line.ToCharArray();
                //remove all the white space
                _whitespaceRemover.RemoveWhiteSpace(lineCharArray);
                //remove any duplicate characters
                _dupeCharRemover.RemoveDuplicateCharacters(lineCharArray);
                //output the result to standard out
                Console.WriteLine(lineCharArray);
            }
        }
    }
}
