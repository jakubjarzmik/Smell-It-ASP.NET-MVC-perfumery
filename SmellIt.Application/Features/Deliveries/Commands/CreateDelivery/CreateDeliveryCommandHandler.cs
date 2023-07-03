﻿using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Commands.CreateDelivery;
public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository, ILanguageRepository languageRepository,IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
    {
        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var delivery = _mapper.Map<Delivery>(request);

        if (plLanguage != null && enLanguage != null)
        {
            delivery.DeliveryTranslations = new List<DeliveryTranslation>
            {
                new DeliveryTranslation { Language = plLanguage, Name = request.NamePl, Description = request.DescriptionPl },
                new DeliveryTranslation { Language = enLanguage, Name = request.NameEn, Description = request.DescriptionEn }
            };
        }

        await _deliveryRepository.CreateAsync(delivery);
        return Unit.Value;
    }
}