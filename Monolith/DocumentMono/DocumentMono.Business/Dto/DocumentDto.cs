namespace DocumentMono.Business.Dto;

public class DocumentDto : BaseDto
{
    /// <summary>
    /// Document's ID / Belgenin IDsi
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// File name / Dosya adı
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// File content / Dosya içeriği
    /// </summary>
    public string FileContent { get; set; }
    /// <summary>
    /// Date of create / Oluşturulma tarihi
    /// </summary>
    public DateTime DateCreated { get; set; }
    /// <summary>
    /// Is file approved? / Belge onaylandı mı?
    /// </summary>
    public bool IsApproved { get; set; }
    /// <summary>
    /// Last update date / Son güncelleme tarihi
    /// </summary>
    public DateTime? LastUpdatedDate { get; set; }
}
