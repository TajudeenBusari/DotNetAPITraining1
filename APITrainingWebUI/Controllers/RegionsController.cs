using Microsoft.AspNetCore.Mvc;

namespace APITrainingWebUI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                //GET All Regions from web API
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7208/api/regions");

                //since it is nullable
                httpResponseMessage.EnsureSuccessStatusCode();

                var stringResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                ViewBag.stringResponseBody = stringResponseBody;

               
            }
            catch (Exception ex)
            {
                //Log the exception
                
            }

            return View();
        }
    }
}




/*From this link https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-8.0
 get the documentation on how to consume a web api
Inject the httpClient factory in the program.cs
we will call the Get all regions method from the API Training here
Ideallly, https://localhost:7208/api/regions should come from the package's 
appsettings.json of the APITrainingWebUI 
highlight and press Ctrl + k + s to get the try catch block automatically*/