using System;
using System.Threading;

namespace Anticaptcha_example
{
    internal class Program
    {
        private const string Host = "api.anti-captcha.com";
        private const string ClientKey = "111f8abdca1b023d01b5c607aaed6090";

        private static void Main(string[] args)
        {
            var task1 = AnticaptchaApiWrapper.CreateNoCaptchaTask(
                Host,
                ClientKey,
                "http://www.adidas.com/us/nmd_c1-trail-shoes/S81834.html",
                "6Le4AQgUAAAAAABhHEq7RWQNJwGR_M-6Jni9tgtA",
                AnticaptchaApiWrapper.ProxyType.http,
                "46.163.73.94",
                3128,
                "",
                "",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36"
                );


            Console.WriteLine("Recaptcha task is sent, will wait for the result.");
            Thread.Sleep(10000);
            ProcessTask(task1);

            

            // Exit
            Console.ReadKey();
        }

        private static String ProcessTask(AnticaptchaTask task)
        {
            AnticaptchaResult response;

            do
            {
                response = AnticaptchaApiWrapper.GetTaskResult(Host, ClientKey, task);

                if (response.GetStatus().Equals(AnticaptchaResult.Status.ready))
                {
                    break;
                }

                Console.WriteLine("Not done yet, waiting...");
                Thread.Sleep(1000);
            } while (response != null && response.GetStatus().Equals(AnticaptchaResult.Status.processing));

            if (response == null || response.GetSolution() == null)
            {
                Console.WriteLine("Unknown error occurred...");
                Console.WriteLine("Response dump:");
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("The answer is '" + response.GetSolution() + "'");
            }

            return response.GetSolution();
        }
    }
}