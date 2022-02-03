using DocumentMono.Business.Dto;
using static DocumentMono.Common.Enums;

namespace DocumentMono.Business;
/// <summary>
/// User login and other transactions service
/// <para>Kullanıcı giriş ve diğer işlemlerin yapıldığı servis</para>
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Gets user's details by ID
    /// <para>Kullanıcı detayyını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <returns></returns>
    Task<UserDto> GetByIdAsync(int ID);

    /// <summary>
    /// Gets user if exist
    /// <para>Kullanıcı varsa getirir</para>
    /// </summary>
    /// <param name="Username">Username / Kullanıcı adı</param>
    /// <param name="Password">Password / Parola</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<UserDto> GetUserAsync(string Username, string Password);


    /// <summary>
    /// Adds new user
    /// <para>Kullanıcı varsa getirir</para>
    /// </summary>
    /// <param name="Username">Username / Kullanıcı adı</param>
    /// <param name="Password">Password / Parola</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task<UserDto> AddUserAysnc(string Username, string Password);

    /// <summary>
    /// Change user's password
    /// <para>Kullanıcı parolasını günceller</para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <param name="Password">Users's password/ Kullanıcının parolası</param>
    /// <returns></returns>
    Task<UserDto> UpdateUserAysnc(int ID, string Password);

    /// <summary>
    /// Change user's status
    /// <para>Kullanıcı durumunu günceller</para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <param name="userStatus">Users's status/ Kullanıcının durumu</param>
    /// <returns></returns>
    Task<UserDto> UpdateUserAysnc(int ID, UserStatus userStatus);

    /// <summary>
    /// Lists users with paging
    /// <para>Sayfalama ile kullanıcıları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <param name="userStatus">Users's status (optional) / Kullanıcı durumu (opsiyonel)</param>
    /// <returns></returns>
    Task<PagingModel<UserDto>> GetUsers(string keyword, int pageSize, int pageIndex, UserStatus? userStatus = null);
}
