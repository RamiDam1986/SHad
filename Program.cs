using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Windows version: {0}", Environment.OSVersion);
            Console.WriteLine("64 Bit operating system? :{0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
            Console.WriteLine("PC Name : {0}", Environment.MachineName);
            Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
            Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
            
            int Numb_of_Spaces = 0;
            int Correct_Criteria = 0;
            bool Correct_Input;
            bool Uniuqe_Char = true;
            int BPZ = 0;
            bool Unique_Char_In_QUestion = false;
            int Correct_Answers_Count = 0;
            int Wrong_Answers_Count = 0;
            int Number_of_Q = 0;
            String name_and_SVU_Serial = "";
            String Unique_name_and_SVU_Serial = "";
            int Name_Char_Count = 0;
            Char[] Name_Table = { 'a' };

            while (Number_of_Q <= 0)
            {
                Console.Write("Please enter the maximum number of questions: ");
                Number_of_Q = Int32.Parse(Console.ReadLine());
                switch (Number_of_Q)
                {
                    case int n when n <= 0:
                        Console.WriteLine("The number of questions should be an integer > 0, please enter it again.");
                        break;
                }
            }

            Correct_Input = false;

            while (!Correct_Input)
            {
                Console.WriteLine("Please enter your Name (first name and last name) and your SVU ID number With a space between each part (Accepted Chars:A-Z a-z 0-9).\nThe entered text should contain at least 2 Accepted Chars");
                name_and_SVU_Serial = Console.ReadLine();
                Name_Char_Count = name_and_SVU_Serial.Length;
                Name_Table = name_and_SVU_Serial.ToCharArray();
                Numb_of_Spaces = 0;
                Correct_Criteria = 0;

                for (int i = 0; i < Name_Char_Count; i++)
                {
                    char c = Name_Table[i];
                    int charValue = (int)c;
                    switch (charValue)
                    {
                        case int n when (n >= 65 && n <= 90) || (n >= 97 && n <= 122) || (n >= 48 && n <= 57) || (n == 32):
                            Correct_Criteria++;
                            if (charValue == 32)
                            {
                                Numb_of_Spaces++;
                            }
                            break;
                        default:
                            break;
                    }
                }

                switch (Correct_Criteria)
                {
                    case int n when n < 2:
                        Console.WriteLine("You need to have at least 2 acceptable characters.");
                        break;
                    default:
                        switch (Numb_of_Spaces)
                        {
                            case int n when n < 2:
                                Console.WriteLine("You need to have at least 2 spaces.");
                                break;
                            default:
                                Correct_Input = true;
                                break;
                        }
                        break;
                }
            
        }
            int O = 0;
            while (O < Name_Char_Count)
            {
                Uniuqe_Char = true;
                int P = 0;
                while (P < Unique_name_and_SVU_Serial.Length)
                {
                    if (name_and_SVU_Serial[O] == Unique_name_and_SVU_Serial[P])
                    {
                        Uniuqe_Char = false;
                        break;
                    }
                    P++;
                }
                if (Uniuqe_Char && name_and_SVU_Serial[O] != ' ')
                {
                    Unique_name_and_SVU_Serial += name_and_SVU_Serial[O];
                }
                O++;
            }
            Console.WriteLine("Distinct Chars Are : " + Unique_name_and_SVU_Serial);
            Console.WriteLine("=========================");
            Random MM = new Random();
            string[][] Printable_Table = new string[Number_of_Q + 1][];
            for (int TS = 0; TS < Printable_Table.Length; TS++)
            {
                Printable_Table[TS] = new string[Number_of_Q + 1];
            }
            Printable_Table[0][0] = "Question";
            Printable_Table[0][1] = "Type";
            Printable_Table[0][2] = "Correct Answer";
            Printable_Table[0][3] = "User Answer";
            for (int Q = 0; Q < Number_of_Q; Q++)
            {
                string Random_Question = "";
                bool Correct_dificulty = false;
                int Difficulty_Level = 0;
                while (Correct_dificulty == false)
                {
                    BPZ = Q + 1;
                    Console.WriteLine("Question" + ": " + BPZ);
                    Console.WriteLine("Please enter integer value between 3 and 100 (the number of characters from which to enumerate the most or least repeated characters == Degree of difficulty)");
                    Difficulty_Level = Int32.Parse(Console.ReadLine());
                    if (Difficulty_Level >= 3 && Difficulty_Level <= 100)
                    {
                        Correct_dificulty = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter integer value between 3 and 100 (the number of characters from which to enumerate the most or least repeated characters == Degree of difficulty)");
                    }
                }
                for (int DD = 0; DD < Difficulty_Level; DD++)
                {
                    int MM_Random = MM.Next(3);
                    if (MM_Random == 0)
                    {
                        Random_Question += (char)(MM.Next(65, 91));
                    }
                    else if (MM_Random == 1)
                    {
                        Random_Question += (char)(MM.Next(48, 58));
                    }
                    else if (MM_Random == 2)
                    {
                        Random_Question += (char)(MM.Next(97, 123));
                    }
                }
                Console.WriteLine("What are the distinct characters existed in the following text:");
                Console.WriteLine(Random_Question);
                Console.WriteLine("To ignore the question type Ignore");
                int Question_Lingth = Random_Question.Length;
                string Deafult_Correct_Answer = "";
                int AB = 0;
                while (AB < Question_Lingth)
                {
                    Unique_Char_In_QUestion = true;
                    int ABQ = 0;
                    while (ABQ < Deafult_Correct_Answer.Length)
                    {
                        if (Random_Question[AB] == Deafult_Correct_Answer[ABQ])
                        {
                            Unique_Char_In_QUestion = false;
                            break;
                        }
                        ABQ++;
                    }
                    switch (Unique_Char_In_QUestion)
                    {
                        case true:
                            Deafult_Correct_Answer += Random_Question[AB];
                            break;
                        default:
                            break;
                    }
                    AB++;
                }
                Console.WriteLine(Deafult_Correct_Answer);
                string user_Answer = Console.ReadLine();

               
                Printable_Table[Q + 1][0] = Random_Question;
                Printable_Table[Q + 1][2] = Deafult_Correct_Answer;
                Printable_Table[Q + 1][3] = user_Answer;

                switch (user_Answer)
                {
                    case string s when s == Deafult_Correct_Answer:
                        Correct_Answers_Count++;
                        Console.WriteLine("===========================");
                        Printable_Table[Q + 1][1] = "Correct";
                        break;
                    default:
                        Wrong_Answers_Count++;
                        Console.WriteLine("Wrong Answer!!");
                        Printable_Table[Q + 1][1] = "Incorrect";
                        break;
                }
            }
            string User_choice = "";

            while (User_choice != "Exit")
            {
                Console.WriteLine("To get the number of correct answers type 1");
                Console.WriteLine("To get the number of wrong answers type 2");
                Console.WriteLine("To view the questions with correct and answered questions type 3");
                Console.WriteLine("To exit type Exit");
                User_choice = Console.ReadLine();
                switch (User_choice)
                {
                    case "1":
                        Console.WriteLine("The number of correct answers: " + Correct_Answers_Count);
                        break;
                    case "2":
                        Console.WriteLine("The number of correct answers: " + Wrong_Answers_Count);
                        break;
                    case "3":
                        for (int i = 0; i < Printable_Table.Length; i++)
                        {
                            for (int j = 0; j < Printable_Table[i].Length; j++)
                            {
                                Console.Write(Printable_Table[i][j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        break;
                    default:
                        break;
                }
            
        }



        }
    }
}
