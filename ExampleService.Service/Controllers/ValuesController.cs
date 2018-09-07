namespace ExampleService.Service.Controllers
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;

	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		// http://localhost:5000/api/values/hello
		[HttpGet]
		[Route("hello")]
        public IEnumerable<string> HelloWorld()
        {
            return new string[] { "Hello", "World!" };
        }

		// GET api/values
		// http://localhost:5000/api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
