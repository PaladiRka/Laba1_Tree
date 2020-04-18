using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace Laba1_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new BinaryTree<int>();
            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(5);
            numbers.Add(6);

            Console.WriteLine("Print begin tree:");
            numbers.PrintHighToLow();
            Console.WriteLine("Print begin tree:");
            numbers.PrintLowToHigh();
            
            Node<int> node = numbers.Search(2);
            
            Console.WriteLine("Search node with data 2 : {0:D}", node.Data);
            
            numbers.Delete(3);
            
            Console.WriteLine("Print begin tree after delete elem with data 3:");
            numbers.PrintLowToHigh();
        }
    }
    
}