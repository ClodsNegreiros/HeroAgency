﻿using HeroAgency.Application.Commands.SuperHero.CreateSuperHero;
using HeroAgency.Application.Interfaces.SuperHero;
using HeroAgency.Application.Queries.SuperHero.GetAllSuperHero;
using MediatR;

namespace HeroAgency.Application.UseCases.SuperHero.Queries
{
    public class GetAllSuperHeroUseCase : BaseUseCase, IGetAllSuperHeroUseCase
    {
        public GetAllSuperHeroUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<GetAllSuperHeroQueryResult> Execute()
        {
            return await mediator.Send(new GetAllSuperHeroQuery());
        }
    }
}
