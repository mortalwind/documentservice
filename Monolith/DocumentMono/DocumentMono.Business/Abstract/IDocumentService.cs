using DocumentMono.Business.Dto;

namespace DocumentMono.Business;

/// <summary>
/// Document transactions service
/// <para>Belge işlemleri servisi</para>
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Gets Document's details by ID
    /// <para>Belge detayını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">Document's ID / Belge IDsi</param>
    /// <returns></returns>
    Task<DocumentDto> GetByIdAsync(int ID);

    /// <summary>
    /// Adds new Document
    /// <para>Belge varsa getirir</para>
    /// </summary>
    /// <param name="citizenDto">Document info / Belge bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<DocumentDto> AddDocumentAysnc(DocumentDto citizenDto);

    /// <summary>
    /// Updates to exist Document
    /// <para>Belge bilgisini günceller</para>
    /// </summary>
    /// <param name="citizenDto">Document info / Belge bilgisi</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<DocumentDto> UpdateDocumentAysnc(DocumentDto citizenDto);

    /// <summary>
    /// Lists Documents with paging
    /// <para>Sayfalama ile Belgeleri getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <returns></returns>
    Task<PagingModel<DocumentDto>> GetDocuments(string keyword, int pageSize, int pageIndex);
}

