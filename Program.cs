﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace OOPAssignment3
{
    class Program
    {

        static void Main(string[] args)
        {
        
            FileManipulation fileManipulation = new FileManipulation();

           

            fileManipulation.ObtainGitRepos();

            fileManipulation.DisplayGitRepos();

            fileManipulation.ChooseGitRepos();

            fileManipulation.CompareFiles();

            fileManipulation.LogFile();


            Console.WriteLine("\nThe file comparisons will be available to read in the Output.txt file!");

            Console.ReadKey();
        }
    }
}
