using static DocumentMono.Common.Enums;

namespace DocumentMono.Business.Dto;

public class UserDto : BaseDto
{

    /// <summary>
    /// User's ID / Kullanıcı IDsi
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Username for login / Giriş için kullanıcı adı
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// User's status / Kullanıcının protaldaki durumu
    /// </summary>
    public UserStatus Status { get; set; }


}
