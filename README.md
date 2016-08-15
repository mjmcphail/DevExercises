# DevExercises
Development exercises

This solution contains some development exercises that demonstrate problem solving, coding style, quality and some design.

- All the code has unit tests which cover most cases (i.e. high code coverage should exist)
- For unit testing, the Moq framework was used
- All code was written against an interface specification to help make unit testing easier
- In addition, the Autofac IoC dependency injection container was used to help demonstrate some design principles

The problems are described below:

========================
q4 – String Manipulation
========================

Write a function to compact a string in place: 
A.	strip whitespace from the string.
B.	remove duplicate characters if they are next to each other

For example, consider the following input:
***
abb cddpddef gh
***

Then the output of your program should be:
***
abcdpdefgh
***
====================
q5 - Spiral printing
====================
Write a function to print a 2-D array (n x m) in spiral order (clockwise).

For example, consider the following input:
***
1 2 3 
4 5 6         
7 8 9 
***

Then the output of your program should be:
***
1 2 3 6 9 8 7 4 5
***

===============
q6 – Sub-Trees
===============
Write a function to check if binary tree 1 is a subtree of another binary tree 2. Tree 1 is a subtree of Tree 2 if and only if we can find a subtree in Tree 2 that has the same structure as Tree 1 and each node has the same value.  Input for this problem will use a breadth-first heap style representation.

For example:                                                 Represents this tree:
4,2,5                                                                             4
                                                                                   /   \
                                                                                 2     5

Which is a subtree of:
1,5,4,,3,2,5,,,,,,,0,8                                                       1
                                                                                   /   \
                                                                                 5     4
                                                                                   \   /  \
                                                                                   3 2    5
                                                                                           / \
                                                                                         0   8
        
But it's not a subtree of:
1,5,4,,3,2,9,,,,,,,0,8                                                       1
                                                                                   /   \
                                                                                 5     4
                                                                                   \   /  \
                                                                                   3 2    9
                                                                                           / \
                                                                                         0   8

For example, consider the following input:
***
1,5,4,,3,2,5,,,,,,,0,8
4,2,5
***

Then the output of your program should be:
***
Yes
***





Hint:
How to create a binary tree? Visit: http://cslibrary.stanford.edu/110/BinaryTrees.html

Sample struct and function in C:
typedef struct {
	int val;
	Node *left;
	Node *right;
}Node;

Node *subtree(Node *t1, Node *t2);



