using BlazorServerApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlazorServerApp.Controllers
{
    public class WorkShareController : Controller
    {
        readonly IWebHostEnvironment environment;
        public WorkShareController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        [Route("api/getworkshare/{id}")]
        public IActionResult GetWorkShareAsync(int id)
        {
            try
            {
                var content = string.Empty;
                if (System.IO.File.Exists(Path.Combine(environment.WebRootPath + @"\workshares", $"{id}.txt")))
                {
                    content = System.IO.File.ReadAllText(Path.Combine(environment.WebRootPath + @"\workshares", $"{id}.txt"));
                }
                return Content(JsonSerializer.Serialize(new WorkShare() { Id = id, Content = content }), "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/setworkshare/{workShareJson}")]
        public IActionResult SetWorkShareAsync(string workShareJson)
        {
            try
            {
                var workShare = JsonSerializer.Deserialize<WorkShare>(workShareJson);
                System.IO.File.WriteAllText(Path.Combine(environment.WebRootPath + @"\workshares", $"{workShare.Id}.txt"), workShare.Content);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
