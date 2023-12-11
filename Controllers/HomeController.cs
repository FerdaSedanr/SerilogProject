using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerilogProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
        {
			_logger = logger;
            
        }
        [HttpGet]
		public IEnumerable<string> Get()
		{
			try
			{
				// Log  hata mesajı
				_logger.LogError("Bu bir hata mesajı.");
				_logger.LogWarning("Loq Warning");
				_logger.LogTrace("LogTrace");
				string text = "Log bilgi metni";
				_logger.LogInformation("{text} LogInformation",text);

				return new string[] { "value1", "value2" };
			}
			catch (Exception ex)
			{
				// Bir hata durumunda loglamak için
				_logger.LogError(ex, "Get metodu bir istisna fırlattı.");

				// İstisnayı tekrar fırlatma veya işleme alma
				throw;
			}
		}

		// GET api/<HomeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<HomeController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<HomeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HomeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
