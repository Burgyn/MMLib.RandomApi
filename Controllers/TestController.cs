using Microsoft.AspNetCore.Mvc;

namespace MMLib.RandomApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController
    {
        [HttpGet]
        public string Test() => "I'm alive";
    }
}