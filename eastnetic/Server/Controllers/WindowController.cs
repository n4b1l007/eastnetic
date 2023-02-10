using eastnetic.Server.Interfaces;
using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eastnetic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindow _IWindow;

        public WindowController(IWindow iWindow)
        {
            _IWindow = iWindow;
        }

        [HttpGet]
        public async Task<List<WindowDto>> Get()
        {
            return await Task.FromResult(_IWindow.GetWindowDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            WindowDto Window = _IWindow.GetWindowData(id);
            if (Window != null)
            {
                return Ok(Window);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(WindowDto Window)
        {
            _IWindow.AddWindow(Window);
        }

        [HttpPut]
        public void Put(WindowDto Window)
        {
            _IWindow.UpdateWindowDetails(Window);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IWindow.DeleteWindow(id);
            return Ok();
        }
    }
}