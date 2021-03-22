using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace agodaTest{
    class httpgitReq{
        private string token = "Bearer dac14126ffc5ceec22e364d463f84b5cc7b30b5e";
        private string url  ="https://api.github.com/user/";
        private HttpClient client = new HttpClient();
        private string ownAndRepo ="";

        public object JsonConvert { get; private set; }

        public httpgitReq(string ownAndRepo){
            this.ownAndRepo = ownAndRepo;
        }
         async public void callapiPull(){
                    var param  = "?per_page=10&page=1";
                    Console.WriteLine($"Repsoity {ownAndRepo} top pull are:");
                    HttpResponseMessage response = await client.GetAsync(url+"repos/"+ownAndRepo+"pulls"+param);
                    //Console.WriteLine("response.IsSuccessStatusCode");
                    var body = new 
                    {
                        perpage = 10,
                        page= 1
                    };
                    response.Headers.Add("Authorization",token);
                    //requestMessage.Content.GetHashCode
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        Console.WriteLine(rawResponse);
                    }
                    //Console.WriteLine("Complete");
                }
        async public void callapiIssues(){
                    Console.WriteLine($"Repsoity {ownAndRepo} top issues are:");
                    var param  = "?per_page=10&page=1";
                    HttpResponseMessage response = await client.GetAsync(url+"repos/"+ownAndRepo+"issues"+param);
   
                    response.Headers.Add("Authorization",token);
                    //requestMessage.Content.GetHashCode
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        Console.WriteLine(rawResponse);
                    }
                    Console.WriteLine("Complete");
                }
        async public static void callapiTest(){
                    Console.WriteLine($"Repsoity  top issues are:");
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync("https://api.github.com/user/repos");
                    response.Headers.Add("Authorization","Bearer dac14126ffc5ceec22e364d463f84b5cc7b30b5e");
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        Console.WriteLine(rawResponse);
                    }
                    //Console.WriteLine("Complete");
                }
    }
}