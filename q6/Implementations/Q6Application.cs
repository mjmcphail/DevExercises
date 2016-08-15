using System.Collections.Generic;
using System.Linq;
using q6.Interfaces;
using RS.Common.Interfaces;
using System;

namespace q6.Implementations
{
    /// <summary>
    /// This class encapsulates the main logic of the application
    /// because all dependencies are injected
    /// the Run logic is fairly simple.
    /// </summary>
    public class Q6Application : IApplication
    {
        private readonly string _fileName;
        private readonly IBinaryTreeFactory _binaryTreeFactory;
        private readonly IFileFacade _fileFacade;
        private readonly ITreeComparer _treeComparer;

        public Q6Application(string fileName, IFileFacade fileFacade, IBinaryTreeFactory binaryTreeFactory, ITreeComparer treeComparer)
        {
            _fileName = fileName;
            _fileFacade = fileFacade;
            _binaryTreeFactory = binaryTreeFactory;
            _treeComparer = treeComparer;
        }

        public void Run()
        {
            //read the lines of the file
            var lines = _fileFacade.ReadLines(_fileName);
            
            //put each tree into list and
            //use our factory to create the main and sub-trees from the data provided
            List<IBinaryTree<string>> trees = 
                lines.Select(line => _binaryTreeFactory.Create(line)).ToList();

            //get our main and subtree from the list
            var mainTree = trees.Count > 0 ? trees[0].Root : null;
            var subTree = trees.Count == 2 ? trees[1].Root : null;
            
            //compare the main and sub-tree
            var isSubTree = _treeComparer.IsSubtree(mainTree, subTree);
            
            //output results to screen
            Console.WriteLine(isSubTree ? "Yes" : "No");
        }
    }
}
