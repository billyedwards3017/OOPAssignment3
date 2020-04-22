using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace OOPAssignment3
{
    class FileManipulation
    {
        private Dictionary<int, string> GitRepos = new Dictionary<int, string>();
        private int Choice1;
        private int Choice2;
        private string temp;
        private string Git1a;
        private string Git1b;
        private string[] lines1;
        private string[] lines2;
        //Declaring the variables required for the program

        private List<int> difflines = new List<int>();
        //this line of code creates a list which will contain the lines in the files which have differences 

        public void ObtainGitRepos()
        {
            GitRepos.Add(1, "GitRepositories_1a.txt");
            GitRepos.Add(2, "GitRepositories_1b.txt");
            GitRepos.Add(3, "GitRepositories_2a.txt");
            GitRepos.Add(4, "GitRepositories_2b.txt");
            GitRepos.Add(5, "GitRepositories_3a.txt");
            GitRepos.Add(6, "GitRepositories_3b.txt");
        }
        ////This adds the key and value pairs into the dictionary for the viable text documents
        public void DisplayGitRepos()
        {
            foreach (KeyValuePair<int, string> item in GitRepos)
            {
                Console.WriteLine("Please enter {0} if you want to use {1}", item.Key, item.Value);
            }
            //This will write to the console each option of text document that the user can choose from, allowing new text docuemtns to be added easily
        }

        public void ChooseGitRepos()
            {
            do
            {
                Console.WriteLine("Input the value corrosponding to the first text file you would like to compare");
                temp = (Console.ReadLine());
                int.TryParse(temp, out Choice1);
            } while (!(Choice1 == 1 || Choice1 == 2 || Choice1 == 3 || Choice1 == 4 || Choice1 == 5 || Choice1 == 6));
            //This will take the users input in the first text document that they will want to use. This also includes a error handle which means the only viable inputs are the displayed options
            
            do
            { 
            Console.WriteLine("Input the value corrosponding to the second text file you would like to compare");
            temp = (Console.ReadLine());
            int.TryParse(temp, out Choice2);
            } while (!(Choice2 == 1 || Choice2 == 2 || Choice2 == 3 || Choice2 == 4 || Choice2 == 5 || Choice2 == 6));
            //this does the same as the above code but for the second option

            Git1a = File.ReadAllText(Convert.ToString(GitRepos[Choice1]));
            Git1b = File.ReadAllText(Convert.ToString(GitRepos[Choice2]));
            //This will extract the text from the chosen text file into string variables
        }

        public void CompareFiles()
        {
            if (Git1a == Git1b)
            {
                Console.WriteLine($"{GitRepos[Choice1]} and {GitRepos[Choice2]} are not different.");
            }
            else
            {

                Console.WriteLine($"{GitRepos[Choice1]} & {GitRepos[Choice2]} are different.");
                //this section of code compares the text of each file and if there are no differences, it will write to the console there are no diferences and vice versa

                lines1 = Git1a.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                lines2 = Git1b.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                //this section of code will create arrays of the text in the files with each item of the array being a line of the file
                
                for (int x = 0; x <= lines1.Length - 1; x++)
                {
                    if (lines1[x] != lines2[x])
                    {
                        difflines.Add(x);
                    }
                }
                //this for loop will actually compare each line of the two text files against eachother and add the line number to the list if there is a difference

                Console.WriteLine("You have differences on the following lines:");

                foreach (int diffline in difflines)
                {
                    Console.WriteLine(diffline);
                }
                //this foreach loop will write each line number entered into the difflines list

            }
        }

        

        public void LogFile()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            //these are the variables needed for this method.
            File.WriteAllText("./Output.txt", string.Empty);
            //This line of code clears the output log for the new run through the console
            //In a actual log file i would leave it all there but this one is for the purpose of demonstration.
            try
            {
                ostrm = new FileStream("./Output.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Output.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            //this try catch conditional will attempt to open the output text file and if it cant be opened, will generate a error message stating the reason why.

            Console.SetOut(writer);
            Console.WriteLine("Finished comparing the files.\n");

            if (difflines.Count() != 0)
            {

                Console.WriteLine("There are differences in the files on the following lines:");

                foreach (int diffline in difflines)
                {
                    Console.WriteLine(diffline);
                }
            }
            else
            {
                Console.WriteLine("There are no differences in the files");
            }
            Console.SetOut(oldOut);
            //this will write a summary of the differences in the lines of the files which will be written to the output file.
            writer.Close();
            ostrm.Close();
            //this closes the connection to the output file
        }
    }
}
