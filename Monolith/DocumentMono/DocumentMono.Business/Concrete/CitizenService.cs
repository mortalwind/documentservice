using AutoMapper;
using DocumentMono.Business.Dto;
using DocumentMono.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DocumentMono.Business;
/// <summary>
/// Citizen transactions service
/// <para>Vatandaş işlemleri servisi</para>
/// </summary>
public class CitizenService : ICitizenService
{
    private readonly DocumentDbContext dbContext;
    private readonly Mapper citizenMapper;

    public CitizenService()
    {
        dbContext = new DocumentDbContext();
        var CitizenMapConfig = new MapperConfiguration(c => c.CreateMap<Citizen, CitizenDto>().ReverseMap());
        citizenMapper = new Mapper(CitizenMapConfig);
    }

    private Citizen GetCitizenByID(int ID)
    {
        var root = (IQueryable<Citizen>)dbContext.Citizens;

        var citizen = root.FirstOrDefault(x => x.ID == ID);
        return citizen;
    }

    /// <summary>
    /// Gets Citizen's details by ID
    /// <para>Vatandaş detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">Citizen's ID / Vatandaş IDsi</param>
    /// <returns></returns>
    public async Task<CitizenDto> GetByIdAsync(int ID)
    {
        return await Task.FromResult(citizenMapper.Map<Citizen, CitizenDto>(GetCitizenByID(ID)));
    }

    /// <summary>
    /// Adds new Citizen
    /// <para>Vatandaş varsa getirir</para>
    /// </summary>
    /// <param name="citizenDto">Citizen info / Vatandaş bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CitizenDto> AddCitizenAysnc(CitizenDto citizenDto)
    {

        var citizen = citizenMapper.Map<CitizenDto, Citizen>(citizenDto);
        dbContext.Citizens.Add(citizen);
        await dbContext.SaveChangesAsync();
        return citizenMapper.Map<Citizen, CitizenDto>(citizen);
    }

    /// <summary>
    /// Updates to exist Citizen
    /// <para>Vatandaş bilgisini günceller</para>
    /// </summary>
    /// <param name="citizenDto">Citizen info / Vatandaş bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<CitizenDto> UpdateCitizenAysnc(CitizenDto citizenDto)
    {

        var citizen = citizenMapper.Map<CitizenDto, Citizen>(citizenDto);
        dbContext.Citizens.Update(citizen);
        await dbContext.SaveChangesAsync();
        return citizenMapper.Map<Citizen, CitizenDto>(citizen);
    }




    /// <summary>
    /// Lists Citizens with paging
    /// <para>Sayfalama ile Vatandaşları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    public async Task<PagingModel<CitizenDto>> GetCitizens(string keyword, int pageSize, int pageIndex)
    {
        var root = (IQueryable<Citizen>)dbContext.Citizens;

        var filteredCitizens = root.Where(x => x.FirstName.Contains(keyword) ||
                                                       x.LastName.Contains(keyword) ||
                                                       string.IsNullOrEmpty(keyword));

        var totalCount = await filteredCitizens.LongCountAsync();

        var citizensOnPage = await filteredCitizens
                            .Skip(pageSize * pageIndex)
                            .Take(pageSize)
                            .ToListAsync();
        var listCitizendto = citizenMapper.Map<List<Citizen>, List<CitizenDto>>(citizensOnPage);
        return new PagingModel<CitizenDto>(totalCount, pageIndex, pageSize, listCitizendto);
    }
}

