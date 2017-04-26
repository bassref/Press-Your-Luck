/* Group Members: Clarence Williams and Rephael Edwards
 * Date: 10-6-2016
   Class: CMPS 4143
   Professor: Dr. Catherine Stringfellow
 * Description: This file contains the definition of the class Database
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Press_Your_Luck
{
    class Database
    {
        private int ansIndex;
        //A struct to hold the question and asnwer
        private struct data
        {
            public string question, answer;
            public data(string ques, string ans)
            {
                question = ques;
                answer = ans;
            }
        }

        //A List of structs to hold all the questions
        private List<data> trivia = new List<data>();

        //constructor
        public Database()
        {
        }

        //destructor
        ~Database()
        {
        }

        //Purpose:To return the length of the list
        //Precond:None
        //Postcond:Length is returned
        public int getLength()
        {
            return trivia.Count;
        }

        //Purpose:To return the question stored at the specified index
        //Precond:index must be initialized
        //Postcond:question is reutrned
        public string getQuestion(int index)
        {
            return trivia[index].question;
        }

        //Purpose:To return the answer stored at the specified index
        //Precond:index must be initialized
        //Postcond:answer is returned
        public string getAnswer(int index)
        {
            return trivia[index].answer;
        }

        //Purpose:To determine if the answer given by the user is correct
        //Precond:temp and index must be initialized
        //Postcond:A boolean value is returned
        public bool isAns(string temp, int index)
        {
            if (trivia[index].answer == temp)
            {
                ansIndex = index;
                return true;
            }                
            else
                return false;
        }

        //Purpose:To read in the questions and answers from the input file
        //Precond:None
        //Postcond:None
        public void getTrivia()
        {
            data tempData;
            string line;
            List<string> lines = new List<string>();

            System.IO.StreamReader file =
   new System.IO.StreamReader("..\\..\\Input.txt");
            //while line is not equal to the end of the array
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            for (int i = 0; i < lines.Count; i += 2)
            {
                //The first line is the question and the second line is the answer
                tempData = new data(lines[i], lines[i + 1].ToUpper());
                trivia.Add(tempData);
            }
        }
    }
}
