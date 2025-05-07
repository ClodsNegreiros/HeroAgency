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

            return StatusCode((int)result.Type, result.ToJson());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateSuperHeroRequest request,
            [FromServices] IUpdateSuperHeroUseCase useCase)
        {
            var result = await useCase.Execute(id, request);

            return StatusCode((int)result.Type, result.ToJson());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IDeleteSuperHeroUseCase useCase)
        {
            var result = await useCase.Execute(id);

            return StatusCode((int)result.Type, result.ToJson());
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllSuperHeroUseCase useCase)
        {
            var result = await useCase.Execute();
            
            return StatusCode((int)result.Type, result.ToJson());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(
            [FromRoute] int id,
            [FromServices] IGetSuperHeroByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }
    }
}
