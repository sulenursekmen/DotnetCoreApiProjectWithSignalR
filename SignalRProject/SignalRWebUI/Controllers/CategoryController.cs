using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string apiUrl = "https://localhost:7168/api/Category";
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client =_httpClientFactory.CreateClient();
          
            var responseMessage = await client.GetAsync(apiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                //Deserialize -> json data when deserialising (list)
                //serialise -> normal text to json data when serialising (add-update)
                var values =JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,System.Text.Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(apiUrl,stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

		public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
          
			var responseMessage = await client.DeleteAsync($"{apiUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
				TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
				return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Kategori silinirken bir hata oluştu.";
            return View();
        }

        [HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync($"{apiUrl}/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(values);
			}
			
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(apiUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
