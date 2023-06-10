using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Queries.GetAllPaymentsForWebsite;
public class GetAllPaymentsForWebsiteQueryHandler : IRequestHandler<GetAllPaymentsForWebsiteQuery, IEnumerable<WebsitePaymentDto>>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public GetAllPaymentsForWebsiteQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsitePaymentDto>> Handle(GetAllPaymentsForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _paymentRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<WebsitePaymentDto>>(fragranceCategories, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
