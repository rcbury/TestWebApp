using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SortApp
{
    public class MyList
    {
        public List<string> List { get; set; }
        public List<string> Sorted { get; set; }

        public MyList(string collection) 
        {
            List = new List<string>();
            Sorted = new List<string>();
            foreach (var item in collection.Split(",")) 
            {
                List.Add(item);
            }
        }

        public void Sort(string sortId) 
        {
            switch (sortId) 
            {
                case "1": 
                    {
                        var tempTree = new BinaryTree<string>();
                        foreach (var item in List)
                        {
                            tempTree.Add(item);
                        }
                        foreach (var item in tempTree.Root)
                        {
                            Sorted.Add(item);
                        }
                        break;
                    }
                case "2":
                    {
                        var tempTree = new BinaryTree<string>();
                        foreach (var item in List)
                        {
                            tempTree.Add(item);
                        }
                        foreach (var item in tempTree.Root)
                        {
                            Sorted.Add(item);
                        }
                        Sorted.Reverse();
                        break;
                    }
                case "3":
                    {
                        Sorted = List;
                        Sorted.Reverse();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
