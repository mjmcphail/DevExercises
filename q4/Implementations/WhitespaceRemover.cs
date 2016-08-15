using q4.Interfaces;

namespace q4.Implementations
{
    public class WhitespaceRemover : IWhitespaceRemover
    {
        private const char WhiteSpace = ' ';
        private const char NullChar = '\0';
        
        /// <summary>
        /// "removes" white spaces from front and middle of the 
        /// character array.  This routine pushes white spaces them 
        /// to the end of the array then replaces each whitespace
        /// with the null character '\0'
        /// since we probably do not want to resize the array
        /// as that is an expensive operation
        /// this method tries to remove white spaces in as few passes
        /// as possible by pushing them to the end, then makes a second
        /// pass through the array to replace the whitespace with '\0'
        /// </summary>
        /// <param name="charArray">String represented as a character array</param>
        public void RemoveWhiteSpace(char[] charArray)
        {
            for (int index = 0; index < charArray.Length; index++)
            {
                if (charArray[index] == WhiteSpace)
                {
                    if (((index + 1) <= charArray.Length - 1) && 
                        (charArray[index + 1] != WhiteSpace))
                        SwapChars(charArray, index, index + 1);
                    else
                        SkipWhitespaceThenSwap(charArray, index);
                }
            }
            ReplaceWhitespaceWithNullChar(charArray);
        }
    
        /// <summary>
        /// Swaps chars in an array 
        /// - holds destination in temporary variable
        /// - puts source position array value into destination location
        /// - puts temporary variable into source location
        /// </summary>
        /// <param name="charArray">String represented as a character array</param>
        /// <param name="destination">destination index of char array</param>
        /// <param name="source">source index of char array</param>
        private void SwapChars(char[] charArray, int destination, int source)
        {
            char tempChar = charArray[destination];
            charArray[destination] = charArray[source];
            charArray[source] = tempChar;
        }

        /// <summary>
        /// Skips whitespace then swaps the next non-whitespace
        /// char with the character located at index
        /// </summary>
        /// <param name="charArray">String represented as a character array</param>
        /// <param name="index">Index to start skipping from</param>
        private void SkipWhitespaceThenSwap(char[] charArray, int index)
        {
            int tempIndex = index;
            while ((tempIndex != charArray.Length - 1) && 
                (charArray[tempIndex] == WhiteSpace))
                tempIndex++;

            if (charArray[tempIndex] != WhiteSpace)
                SwapChars(charArray, index, tempIndex);
        }

        /// <summary>
        /// Replaces space characters with the '\0'
        /// Null character.
        /// </summary>
        /// <param name="charArray">String represented as a character Array</param>
        private void ReplaceWhitespaceWithNullChar(char[] charArray)
        {
            for (int index = 0; index < charArray.Length; index++)
            {
                if (charArray[index] == WhiteSpace)
                    charArray[index] = NullChar;
            }
        }
    }
}
