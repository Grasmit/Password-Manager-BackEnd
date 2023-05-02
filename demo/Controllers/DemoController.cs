using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using demo.Model;

namespace demo.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class DemoController : ControllerBase
    {
        readonly IItemRepository _itemRepository;

        public DemoController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DemoModel>>> Get()
        {

            return Ok(_itemRepository.GetItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DemoModel>> Get(int id)
        {
            return Ok(_itemRepository.GetUser(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<DemoModel>>> AddItem(Item user)
        {
            return Ok(_itemRepository.AddUser(user));
        }

        [HttpPut]
        public async Task<ActionResult<List<DemoModel>>> UpdateItem(Item user)
        { 
            return Ok(_itemRepository.UpdateUser(user));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<DemoModel>>> DeleteItem(int id)
        {
            return Ok(_itemRepository.DeleteUser(id));
        }
    }
}
