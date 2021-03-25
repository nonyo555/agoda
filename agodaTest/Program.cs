using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace agodaTest
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.WriteLine("Enter the reposity name (format:owner/reposity)");
            var reposN = Console.ReadLine();
            Console.WriteLine("Enter the information type (pull requests,issues)");
            var type = Console.ReadLine();
            Console.WriteLine("Hello World!");
            var path = "";
            httpgitReq client = new httpgitReq(reposN);
            if(type.Equals("pull-request")){
                client.callapiPull();
            }
            else if(type.Equals("issues")){
                path = "https://api.github.com/user/issues";
            };
            httpgitReq.callapiTest();
        }
    }
}