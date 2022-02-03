using AutoMapper;
using DocumentMono.Business.Dto;
using DocumentMono.DataAccess;

namespace DocumentMono.Business;

/// <summary>
/// Flow steps transactions service
/// <para>Onay akışı adımları işlemleri servisi</para>
/// </summary>
public class FlowStepService : IFlowStepService
{
    private readonly DocumentDbContext dbContext;
    private readonly Mapper flowStepMapper;

    public FlowStepService()
    {
        dbContext = new DocumentDbContext();
        var FlowStepMapConfig = new MapperConfiguration(c => c.CreateMap<FlowStep, FlowStepDto>().ReverseMap());
        flowStepMapper = new Mapper(FlowStepMapConfig);
    }

    private FlowStep GetFlowStepByID(int DocumentID)
    {
        var root = (IQueryable<FlowStep>)dbContext.FlowSteps;

        var flowStep = root.FirstOrDefault(x => x.DocumentID == DocumentID);
        return flowStep;
    }

    /// <summary>
    /// Gets FlowStep's details by ID
    /// <para>Onay akışı detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">FlowStep's ID / Onay akışı IDsi</param>
    /// <returns></returns>
    public async Task<FlowStepDto> GetByIdAsync(int ID)
    {
        return await Task.FromResult(flowStepMapper.Map<FlowStep, FlowStepDto>(GetFlowStepByID(ID)));
    }

    /// <summary>
    /// Adds new FlowStep
    /// <para>Onay akışı varsa getirir</para>
    /// </summary>
    /// <param name="flowStepDto">FlowStep info / Onay akışı bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<FlowStepDto> AddFlowStepAysnc(FlowStepDto flowStepDto)
    {

        var flowStep = flowStepMapper.Map<FlowStepDto, FlowStep>(flowStepDto);
        dbContext.FlowSteps.Add(flowStep);
        await dbContext.SaveChangesAsync();
        return flowStepMapper.Map<FlowStep, FlowStepDto>(flowStep);
    }

    /// <summary>
    /// Updates to exist FlowStep
    /// <para>Onay akışı bilgisini günceller</para>
    /// </summary>
    /// <param name="flowStepDto">FlowStep info / Onay akışı bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<FlowStepDto> UpdateFlowStepAysnc(FlowStepDto flowStepDto)
    {

        var flowStep = flowStepMapper.Map<FlowStepDto, FlowStep>(flowStepDto);
        dbContext.FlowSteps.Update(flowStep);
        await dbContext.SaveChangesAsync();
        return flowStepMapper.Map<FlowStep, FlowStepDto>(flowStep);
    }
}
