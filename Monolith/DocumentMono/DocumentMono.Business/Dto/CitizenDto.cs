namespace DocumentMono.Business.Dto;

public class CitizenDto : BaseDto
{
    /// <summary>
    /// Citizen's ID / Vatandaş IDsi
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Citizen's identity number / Kimlik numarası
    /// </summary>
    public string IdentityNumber { get; set; }
    /// <summary>
    /// Adı / First name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name / Soyadı
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email address / EPosta adresi
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Birth of date / Doğum tarihi
    /// </summary>
    public DateOnly BirthDate { get; set; }
}
