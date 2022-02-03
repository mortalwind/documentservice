using DocumentMono.Business.Dto;

namespace DocumentMono.Business;
/// <summary>
/// Citizen transactions service
/// <para>Vatandaş işlemleri servisi</para>
/// </summary>
public interface ICitizenService
{

    /// <summary>
    /// Gets Citizen's details by ID
    /// <para>Vatandaş detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">Citizen's ID / Vatandaş IDsi</param>
    /// <returns></returns>
    Task<CitizenDto> GetByIdAsync(int ID);

    /// <summary>
    /// Adds new Citizen
    /// <para>Vatandaş varsa getirir</para>
    /// </summary>
    /// <param name="citizenDto">Citizen info / Vatandaş bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<CitizenDto> AddCitizenAysnc(CitizenDto citizenDto);

    /// <summary>
    /// Updates to exist Citizen
    /// <para>Vatandaş bilgisini günceller</para>
    /// </summary>
    /// <param name="citizenDto">Citizen info / Vatandaş bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<CitizenDto> UpdateCitizenAysnc(CitizenDto citizenDto);

    /// <summary>
    /// Lists Citizens with paging
    /// <para>Sayfalama ile Vatandaşları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    Task<PagingModel<CitizenDto>> GetCitizens(string keyword, int pageSize, int pageIndex);
}
