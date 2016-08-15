using System.Collections.Generic;
using q5.Interfaces;

namespace q5.Implementations
{
    /// <summary>
    /// This class creates an enumerable of integers
    /// given a 2 dimentional array of integers.
    /// It iterates through the array going from 
    /// top, right, bottom, left in a spiral direction
    /// to generate the enumerable.
    /// </summary>
    public class SpiralArrayFactory : ISpiralArrayFactory
    {
        /// <summary>
        /// Creates an enumerable of integers
        /// from a 2 dimentional array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public IEnumerable<string> Create(string[,] array)
        {
            var result = new List<string>();

            //if our array is empty just return 
            //an empty enumerable
            if (array.Length == 0)
                return result;

            //for this we need to track where
            //we are in the array
            //top, bottom, left and right
            var top = 0;
            var bottom = array.GetLength(0) - 1;
            var left = 0;
            var right = array.GetLength(1) - 1;

            //as long as we have not hit the bottom
            //and right and left have not closed in
            while ((top < bottom) && (left < right))
            {
                //take the top most row and put it into the result
                BuildTop(result, array, left, right, top);
                //move top down so we start on the next row
                top += 1;

                //take the right most column of array and put into result
                BuildRight(result, array, top, bottom, right);
                //move the right side in
                right -= 1;

                //take the bottom most row of array and put into result
                BuildBottom(result, array, right, left, bottom);
                //move the bottom row up
                bottom -= 1;

                //take the left most column of the array and put into result
                BuildLeft(result, array, bottom, top, left);
                //move the left side in
                left += 1;
            }
            //catch last row across
            if ((top == bottom) && (top >= 0))
                BuildTop(result, array, left, right, top);

            return result;
        }

        /// <summary>
        /// Takes to the top most row and inserts
        /// each element into result
        /// </summary>
        /// <param name="result">Result to store data in</param>
        /// <param name="array">2D array data source</param>
        /// <param name="left">Left posistion in 2D array</param>
        /// <param name="right">Right position in 2D array</param>
        /// <param name="top">Top position in 2D array</param>
        private static void BuildTop(ICollection<string> result, string[,] array, int left, int right, int top)
        {
            for (var index = left; index <= right; index++)
                result.Add(array[top, index]);
        }

        /// <summary>
        /// Takes the right most column and
        /// inserts each element into result
        /// </summary>
        /// <param name="result">Result to store data in</param>
        /// <param name="array">2D array data source</param>
        /// <param name="top">Top position in 2D array</param>
        /// <param name="bottom">Bottom position in 2D array</param>
        /// <param name="right">Right position in 2D array</param>
        private static void BuildRight(ICollection<string> result, string[,] array, int top, int bottom, int right)
        {
            for (var index = top; index <= bottom; index++)
                result.Add(array[index, right]);
        }

        /// <summary>
        /// Takes the bottom most row and 
        /// inserts each element into result
        /// </summary>
        /// <param name="result">Result to store data in</param>
        /// <param name="array">2D array data source</param>
        /// <param name="right">Right position in 2D array</param>
        /// <param name="left">Left position in 2D array</param>
        /// <param name="bottom">Bottom position in 2D array</param>
        private static void BuildBottom(ICollection<string> result, string[,] array, int right, int left, int bottom)
        {
            for (var index = right; index >= left; index--)
                result.Add(array[bottom, index]);
        }

        /// <summary>
        /// Takes the left most column and 
        /// inserts each element into result
        /// </summary>
        /// <param name="result">Result to store data in</param>
        /// <param name="array">2D array data source</param>
        /// <param name="bottom">Bottom position in 2D array</param>
        /// <param name="top">Top position in 2D array</param>
        /// <param name="left">Left position in 2D array</param>
        private static void BuildLeft(ICollection<string> result, string[,] array, int bottom, int top, int left)
        {
            for (var index = bottom; index >= top; index--)
                result.Add(array[index, left]);
        }
    }
}
