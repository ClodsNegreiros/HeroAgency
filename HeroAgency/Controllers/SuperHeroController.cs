using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Requests.SuperHero;
using Microsoft.AspNetCore.Mvc;

namespace HeroAgency.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateSuperHeroRequest request,
            [FromServices] ICreateSuperHeroUseCase useCase)
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}
