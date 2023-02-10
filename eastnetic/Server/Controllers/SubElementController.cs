using eastnetic.Server.Interfaces;
using eastnetic.Shared.DTO;
using eastnetic.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace eastnetic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElement _ISubElement;

        public SubElementController(ISubElement iSubElement)
        {
            _ISubElement = iSubElement;
        }

        [HttpGet]
        public async Task<List<SubElementDto>> Get()
        {
            return await Task.FromResult(_ISubElement.GetSubElementDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SubElementDto SubElement = _ISubElement.GetSubElementData(id);
            if (SubElement != null)
            {
                return Ok(SubElement);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(SubElementDto SubElement)
        {
            _ISubElement.AddSubElement(SubElement);
        }

        [HttpPut]
        public void Put(SubElementDto SubElement)
        {
            _ISubElement.UpdateSubElementDetails(SubElement);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ISubElement.DeleteSubElement(id);
            return Ok();
        }
    }
}