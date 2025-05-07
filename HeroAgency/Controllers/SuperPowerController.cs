using HeroAgency.Application.Interfaces.SuperHero;
using Microsoft.AspNetCore.Mvc;

namespace HeroAgency.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SuperPowerController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllSuperPowerUseCase useCase)
        {
            var result = await useCase.Execute();
            
            return StatusCode((int)result.Type, result.ToJson());
        }
    }
}
