using AutoMapper;
using SmellIt.Application.Dtos;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Domain.Entities;
using SmellIt.Application.Extensions;

namespace SmellIt.Application.Helpers;
public class CreateTranslations : IMappingAction<BrandDto, Brand>
{
    private readonly IMapper _mapper;
    private readonly ITranslationEngbService _translationEngbService;
    private readonly ITranslationPlplService _translationPlplService;

    public CreateTranslations(IMapper mapper, ITranslationEngbService translationEngbService, ITranslationPlplService translationPlplService)
    {
        _mapper = mapper;
        _translationEngbService = translationEngbService;
        _translationPlplService = translationPlplService;
    }

    public void Process(BrandDto source, Brand destination, ResolutionContext context)
    {
        var key = source.NameEN.ConvertNameToKey();

        var translationPlplName = new TranslationPlpl { Key = key, Value = source.NamePL };
        var translationEngbName = new TranslationEngb { Key = key, Value = source.NameEN };

        var createTask1 = Task.Run(() => Create(translationPlplName, translationEngbName));

        Task createTask2 = null!;
        if (!string.IsNullOrWhiteSpace(source.DescriptionPL))
        {
            var translationPlplDescription = new TranslationPlpl { Key = key + "Desc", Value = source.DescriptionPL ?? "" };
            var translationEngbDescription = new TranslationEngb { Key = key + "Desc", Value = source.DescriptionEN ?? "" };

            createTask2 = Task.Run(() => Create(translationPlplDescription, translationEngbDescription));
        }
        
        Task.WhenAll(createTask1, createTask2).Wait();
    }

    private async Task Create(TranslationPlpl translationPlpl, TranslationEngb translationEngb)
    {
        await _translationPlplService.Create(translationPlpl);
        await _translationEngbService.Create(translationEngb);
    }
}
