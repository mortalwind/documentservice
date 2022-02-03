using DocumentMono.Business.Dto;

namespace DocumentMono.Business;

/// <summary>
/// Civil servant's transactions service
/// <para>Memur işlemleri servisi</para>
/// </summary>
public interface IServantService
{

    /// <summary>
    /// Gets CivilServant's details by ID
    /// <para>Memur detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">CivilServant's ID / Memur IDsi</param>
    /// <returns></returns>
    Task<CivilServantDto> GetByIdAsync(int ID);

    /// <summary>
    /// Adds new CivilServant
    /// <para>Memur varsa getirir</para>
    /// </summary>
    /// <param name="civilServantDto">CivilServant info / Memur bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<CivilServantDto> AddCivilServantAysnc(CivilServantDto civilServantDto);

    /// <summary>
    /// Updates to exist Civil Servant
    /// <para>Memur bilgisini günceller</para>
    /// </summary>
    /// <param name="civilServantDto">CivilServant info / Memur bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<CivilServantDto> UpdateCivilServantAysnc(CivilServantDto civilServantDto);

    /// <summary>
    /// Lists CivilServants with paging
    /// <para>Sayfalama ile Memurları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    Task<PagingModel<CivilServantDto>> GetCivilServants(string keyword, int pageSize, int pageIndex);
}

