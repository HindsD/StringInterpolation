using System;
using System.IO;
using System.Linq;

namespace _NetAssignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file = "date.txt";
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                 // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                StreamReader sr = new StreamReader("data.txt");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arrDate = line.Split(',');
                    string testArray2 = arrDate[0];
                    string[] dates = testArray2.Split("/");
                    int[] datesToInt = dates.Select(int.Parse).ToArray();
                    DateTime dateRead = new DateTime(datesToInt[2],datesToInt[0],datesToInt[1]);
                    string testArray = arrDate[1];
                    string[] arr = testArray.Split('|');
                    int[] hoursToInt = arr.Select(int.Parse).ToArray();
                    int sum = hoursToInt.Sum();
                    double avg = sum/7.00;
                    avg = Math.Round(avg, 1);




                    Console.WriteLine("\nWeek of {0:MMMM}, {0:dd}, {0:yyyy}", dateRead);
                    Console.WriteLine("{0,0}{1,5}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}","Mo","Tu","We","Th","Fr","Sa","Su","Tot","Avg");
                    Console.WriteLine("{0,0}{1,5}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}","--","--","--","--","--","--","--","---","---");
                    Console.WriteLine("{0,0}{1,5}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}",arr[0],arr[1],arr[2],arr[3],arr[4],arr[5],arr[6],sum,avg);
                }
            }
        }
    }
}
