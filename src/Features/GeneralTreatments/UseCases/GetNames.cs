﻿namespace DentallApp.Features.GeneralTreatments.UseCases;

public class GetGeneralTreatmentNamesResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
}

public class GetGeneralTreatmentNamesUseCase
{
    private readonly DbContext _context;

    public GetGeneralTreatmentNamesUseCase(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetGeneralTreatmentNamesResponse>> ExecuteAsync()
    {
        var generalTreatments = await _context.Set<GeneralTreatment>()
            .Select(treatment => new GetGeneralTreatmentNamesResponse
            {
                Id   = treatment.Id,
                Name = treatment.Name
            })
            .AsNoTracking()
            .ToListAsync();

        return generalTreatments;
    }
}
