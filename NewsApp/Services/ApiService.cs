using NewsAPP.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewsAPP.Services
{ 
	public class ApiService
	{
		public async Task<Root> GetNews(string categoryName)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category=general&lang=zh&country=tw&max=10&apikey=dd82f47e449cf644fbbc0f38adb9caf5");
			return JsonConvert.DeserializeObject<Root>(response);

		}
	}
}