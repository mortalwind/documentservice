using AutoMapper;
using DocumentMono.Business.Dto;
using DocumentMono.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DocumentMono.Business;

/// <summary>
/// Civil servant's transactions service
/// <para>Memur işlemleri servisi</para>
/// </summary>
public class ServantService : IServantService
{
    private readonly DocumentDbContext dbContext;
    private readonly Mapper civilServantMapper;

    public ServantService()
    {
        dbContext = new DocumentDbContext();
        var CivilServantMapConfig = new MapperConfiguration(c => c.CreateMap<CivilServant, CivilServantDto>().ReverseMap());
        civilServantMapper = new Mapper(CivilServantMapConfig);
    }

    private CivilServant GetCivilServantByID(int ID)
    {
        var root = (IQueryable<CivilServant>)dbContext.CivilServants;

        var civilServant = root.FirstOrDefault(x => x.ID == ID);
        return civilServant;
    }

    /// <summary>
    /// Gets CivilServant's details by ID
    /// <para>Memur detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">CivilServant's ID / Memur IDsi</param>
    /// <returns></returns>
    public async Task<CivilServantDto> GetByIdAsync(int ID)
    {
        return await Task.FromResult(civilServantMapper.Map<CivilServant, CivilServantDto>(GetCivilServantByID(ID)));
    }

    /// <summary>
    /// Adds new CivilServant
    /// <para>Memur varsa getirir</para>
    /// </summary>
    /// <param name="civilServantDto">CivilServant info / Memur bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CivilServantDto> AddCivilServantAysnc(CivilServantDto civilServantDto)
    {

        var civilServant = civilServantMapper.Map<CivilServantDto, CivilServant>(civilServantDto);
        dbContext.CivilServants.Add(civilServant);
        await dbContext.SaveChangesAsync();
        return civilServantMapper.Map<CivilServant, CivilServantDto>(civilServant);
    }

    /// <summary>
    /// Updates to exist Civil Servant
    /// <para>Memur bilgisini günceller</para>
    /// </summary>
    /// <param name="civilServantDto">CivilServant info / Memur bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CivilServantDto> UpdateCivilServantAysnc(CivilServantDto civilServantDto)
    {

        var civilServant = civilServantMapper.Map<CivilServantDto, CivilServant>(civilServantDto);
        dbContext.CivilServants.Update(civilServant);
        await dbContext.SaveChangesAsync();
        return civilServantMapper.Map<CivilServant, CivilServantDto>(civilServant);
    }




    /// <summary>
    /// Lists CivilServants with paging
    /// <para>Sayfalama ile Memurları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    public async Task<PagingModel<CivilServantDto>> GetCivilServants(string keyword, int pageSize, int pageIndex)
    {
        var root = (IQueryable<CivilServant>)dbContext.CivilServants;

        var filteredCivilServants = root.Where(x => x.ServantName.Contains(keyword) ||
                                                       x.ServantLastName.Contains(keyword) ||
                                                       string.IsNullOrEmpty(keyword));

        var totalCount = await filteredCivilServants.LongCountAsync();

        var civilServantsOnPage = await filteredCivilServants
                            .Skip(pageSize * pageIndex)
                            .Take(pageSize)
                            .ToListAsync();
        var listCivilServantdto = civilServantMapper.Map<List<CivilServant>, List<CivilServantDto>>(civilServantsOnPage);
        return new PagingModel<CivilServantDto>(totalCount, pageIndex, pageSize, listCivilServantdto);
    }
}
