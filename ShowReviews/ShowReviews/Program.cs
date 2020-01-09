using ShowReviews.ApiHelper;
using ShowReviews.Microservice;
using ShowReviews.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ShowReviews
{
    class Program
    {
        //------------------LOG PATH------------------------//
        private static string logPath = @"C:/Users/Bruger/source/repos/SIExam/ShowReviewsClient/Log.txt";    // Christoffer
        //private static string logPath = "C:/Users/Jonas/..";      // Jonas mac 
        //private static string logPath = "C:/Users/Bruger/Documents/GitHub/..";   // Jonas
        //------------------LOG PATH------------------------//
        static async Task Main(string[] args)
        {
            List<Review> reviews = new List<Review>();
            Apihelper.InitializeClient();
            Processor processor = new Processor();
            await processor.getReviews();
            int averageRating = 0;
            string message;
            foreach (var item in processor.ReviewList)
            {
                averageRating = averageRating + item.Rating;
                Console.WriteLine($"--------------------------");
                Console.WriteLine($"Review rating {item.Rating}");
                Console.WriteLine($"Review description {item.Description}");
                Console.WriteLine($"The person who reviewed has the age {item.Age} and gender {item.Gender}");
                Console.WriteLine($"--------------------------");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Average rating is {averageRating = averageRating / processor.ReviewList.Count}");

            // LOGGING PROCES OF AVERAGE RATING
            message = "Average Rating " + averageRating;
            File.AppendAllText(logPath, TimeStampForLog(" ", message));

            Console.ReadLine();
        }
        private static string TimeStampForLog(string casestatus, string message)
        {
            string response = DateTime.Now + "    -    " + casestatus + "   -    with message: " + message + Environment.NewLine; ;
            return response;
        }
    }   
}
