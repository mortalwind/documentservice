using DocumentMono.Business.Dto;

namespace DocumentMono.Business;
/// <summary>
/// Flow steps transactions service
/// <para>Onay akışı adımları işlemleri servisi</para>
/// </summary>
public interface IFlowStepService
{

    /// <summary>
    /// Gets FlowStep's details by ID
    /// <para>Onay akışı detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">FlowStep's ID / Onay akışı IDsi</param>
    /// <returns></returns>
    Task<FlowStepDto> GetByIdAsync(int ID);

    /// <summary>
    /// Adds new FlowStep
    /// <para>Onay akışı varsa getirir</para>
    /// </summary>
    /// <param name="flowStepDto">FlowStep info / Onay akışı bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<FlowStepDto> AddFlowStepAysnc(FlowStepDto flowStepDto);

    /// <summary>
    /// Updates to exist FlowStep
    /// <para>Onay akışı bilgisini günceller</para>
    /// </summary>
    /// <param name="flowStepDto">FlowStep info / Onay akışı bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<FlowStepDto> UpdateFlowStepAysnc(FlowStepDto flowStepDto);
}

