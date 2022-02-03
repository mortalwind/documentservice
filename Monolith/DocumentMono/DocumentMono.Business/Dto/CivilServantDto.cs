namespace DocumentMono.Business.Dto;

public class CivilServantDto : BaseDto
{
    /// <summary>
    /// Servant's ID / Memurun IDsi
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Servant's name / Memurun adı
    /// </summary>
    public string ServantName { get; set; }

    /// <summary>
    /// Servant's lastname / Memurun soyadı
    /// </summary>
    public string ServantLastName { get; set; }

    /// <summary>
    /// Servant's position / Memurun pozisyonu
    /// </summary>
    public string Position { get; set; }
}
