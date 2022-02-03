using AutoMapper;
using DocumentMono.Business.Dto;
using DocumentMono.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DocumentMono.Business;
/// <summary>
/// Document transactions service
/// <para>Belge işlemleri servisi</para>
/// </summary>
public class DocumentService : IDocumentService
{
    private readonly DocumentDbContext dbContext;
    private readonly Mapper citizenMapper;

    public DocumentService()
    {
        dbContext = new DocumentDbContext();
        var DocumentMapConfig = new MapperConfiguration(c => c.CreateMap<Document, DocumentDto>().ReverseMap());
        citizenMapper = new Mapper(DocumentMapConfig);
    }

    private Document GetDocumentByID(int ID)
    {
        var root = (IQueryable<Document>)dbContext.Documents;

        var citizen = root.FirstOrDefault(x => x.ID == ID);
        return citizen;
    }

    /// <summary>
    /// Gets Document's details by ID
    /// <para>Belge detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">Document's ID / Belge IDsi</param>
    /// <returns></returns>
    public async Task<DocumentDto> GetByIdAsync(int ID)
    {
        return await Task.FromResult(citizenMapper.Map<Document, DocumentDto>(GetDocumentByID(ID)));
    }

    /// <summary>
    /// Adds new Document
    /// <para>Belge varsa getirir</para>
    /// </summary>
    /// <param name="citizenDto">Document info / Belge bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<DocumentDto> AddDocumentAysnc(DocumentDto citizenDto)
    {

        var citizen = citizenMapper.Map<DocumentDto, Document>(citizenDto);
        dbContext.Documents.Add(citizen);
        await dbContext.SaveChangesAsync();
        return citizenMapper.Map<Document, DocumentDto>(citizen);
    }

    /// <summary>
    /// Updates to exist Document
    /// <para>Belge bilgisini günceller</para>
    /// </summary>
    /// <param name="citizenDto">Document info / Belge bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<DocumentDto> UpdateDocumentAysnc(DocumentDto citizenDto)
    {

        var citizen = citizenMapper.Map<DocumentDto, Document>(citizenDto);
        dbContext.Documents.Update(citizen);
        await dbContext.SaveChangesAsync();
        return citizenMapper.Map<Document, DocumentDto>(citizen);
    }




    /// <summary>
    /// Lists Documents with paging
    /// <para>Sayfalama ile Belgeleri getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    public async Task<PagingModel<DocumentDto>> GetDocuments(string keyword, int pageSize, int pageIndex)
    {
        var root = (IQueryable<Document>)dbContext.Documents;

        var filteredDocuments = root.Where(x => x.FileName.Contains(keyword) || string.IsNullOrEmpty(keyword));

        var totalCount = await filteredDocuments.LongCountAsync();

        var citizensOnPage = await filteredDocuments
                            .Skip(pageSize * pageIndex)
                            .Take(pageSize)
                            .ToListAsync();
        var listDocumentdto = citizenMapper.Map<List<Document>, List<DocumentDto>>(citizensOnPage);
        return new PagingModel<DocumentDto>(totalCount, pageIndex, pageSize, listDocumentdto);
    }
}
