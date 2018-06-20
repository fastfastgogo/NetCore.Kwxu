using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kw.Web.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kw.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private ILogFac  _logger;
        private IService _service;
        public UsersController(ILogFac  logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // 演示日志输出
            _logger.LogInformation("This is Information Log!");
            _logger.LogWarning("This is Warning Log!");
            _logger.LogError("This is Error Log!");
            _service.Log("service log");
            var user = new User() { Id = id, Name = "Name:" + id, Sex = "Male" };
            return View(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // TODO：新增操作
            user.Id = new Random().Next(1, 10);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // TODO: 更新操作
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO: 删除操作

        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }

    public class Service : IService
    {

        private ILogFac  _logger;

        public Service(ILogFac  logger)
        {
            _logger = logger;
        }

        public void Log(string message) => _logger.LogInformation(message);

    }

    public interface IService
    {

        void Log(string message);

    }
}