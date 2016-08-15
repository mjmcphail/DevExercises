using System.Collections.Generic;
using q4.Interfaces;

namespace q4.Implementations
{
    public class DuplicateCharRemover : IDuplicateCharRemover
    {
        private const char NullChar = '\0';

        /// <summary>
        /// This is the main function to remove duplicate characters
        /// from a character array.  This function assumes that 
        /// the array contains no spaces within the array and the 
        /// array is either full of valid characters or has null 
        /// characters padding the end of the array.
        /// </summary>
        /// <param name="charArray">String represented as a character array</param>
        public void RemoveDuplicateCharacters(char[] charArray)
        {
            //first find the indexes where duplicate characters occur in the char array
            var duplicateIndexes = FindDuplicateIndexes(charArray);
            //while duplicates exist - remove the duplicates
            while (duplicateIndexes.Length > 0)
            {
                //remove the duplicates
                RemoveDuplicates(charArray, duplicateIndexes);
                //recalculate the duplicate indexes
                duplicateIndexes = FindDuplicateIndexes(charArray);
            }
        }

        /// <summary>
        /// This method takes the duplicate indexes array and 
        /// for each item in that array, shifts the character array
        /// left starting at the current duplicate array index value
        /// after the shift is done, a null character is places on the end
        /// of the character array, and the duplicate indexes are updated as 
        /// they have changed due to the array shift that was made
        /// </summary>
        /// <param name="charArray"></param>
        /// <param name="duplicateIndexes"></param>
        private void RemoveDuplicates(char[] charArray, int[] duplicateIndexes)
        {
            //go through all duplicate indexes and shift the array left
            for (int index = 0; index < duplicateIndexes.Length; index++)
            {
                //shift elements in the array left starting at the first instance
                //of a duplicate value and go to the end of the array
                for (int charIndex = duplicateIndexes[index]; charIndex < charArray.Length - 1; charIndex++)
                    charArray[charIndex] = charArray[charIndex + 1];

                //as the shift left has occurred - put null on end
                charArray[charArray.Length - 1] = NullChar;

                //adjust the duplicate indexes because the array has shifted
                for (int dupeIndex = index + 1; dupeIndex < duplicateIndexes.Length; dupeIndex++)
                    duplicateIndexes[dupeIndex] = duplicateIndexes[dupeIndex] - 1;
            }
        }

        /// <summary>
        /// This function finds the indexes where duplicate characters exist
        /// in the character array.  This is done in an attempt to make the 
        /// removal of duplicate items in the array more efficient
        /// </summary>
        /// <param name="charArray">String represented as a character array</param>
        /// <returns>Integer array of indexes because the array of indexes might need to be changed while it is being iterated over</returns>
        private int[] FindDuplicateIndexes(char[] charArray)
        {
            var duplicateIndexes = new List<int>();

            for (var index = 0; index < charArray.Length; index++)
            {
                if ((index + 1) < charArray.Length - 1)
                {
                    var next = index + 1;
                    if ((charArray[index] == charArray[next]) && (charArray[index] != NullChar))
                        duplicateIndexes.Add(next);
                }
            }
            return duplicateIndexes.ToArray();
        }
    }
}
