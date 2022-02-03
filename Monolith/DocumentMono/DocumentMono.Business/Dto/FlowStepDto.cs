using static DocumentMono.Common.Enums;

namespace DocumentMono.Business.Dto;

public class FlowStepDto : BaseDto
{
    /// <summary>
    /// Document's ID / Belge IDsi
    /// </summary>
    public int DocumentID { get; set; }
    /// <summary>
    /// Approver user's ID / Onaylayacak kişi IDsi
    /// </summary>
    public int UserID { get; set; }

    /// <summary>
    /// Approval Status / Onay durumu
    /// </summary>
    public FlowStatus FlowStatus { get; set; }

    /// <summary>
    /// Approver ansver date / Onaycının yanıtladığı tarih
    /// </summary>
    public DateTime? AnsverDate { get; set; }
}
