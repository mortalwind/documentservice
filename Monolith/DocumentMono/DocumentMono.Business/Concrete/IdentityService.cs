using AutoMapper;
using DocumentMono.Business.Dto;
using DocumentMono.DataAccess;
using Microsoft.EntityFrameworkCore;
using static DocumentMono.Common.Enums;

namespace DocumentMono.Business;

/// <summary>
/// User login and other transactions service
/// <para>Kullanıcı giriş ve diğer işlemlerin yapıldığı servis</para>
/// </summary>
public class IdentityService : IIdentityService
{
    private readonly DocumentDbContext dbContext;
    private readonly Mapper userMapper;

    public IdentityService()
    {
        dbContext = new DocumentDbContext();
        var userMapConfig = new MapperConfiguration(c => c.CreateMap<User, UserDto>().ReverseMap());
        userMapper = new Mapper(userMapConfig);
    }

    private User GetUserByID(int ID)
    {
        var root = (IQueryable<User>)dbContext.Users;

        var user = root.FirstOrDefault(x => x.ID == ID);
        return user;
    }

    /// <summary>
    /// Gets user's details by ID
    /// <para>Kullanıcı detayyını getirir</para>
    /// <para></para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <returns></returns>
    public async Task<UserDto> GetByIdAsync(int ID)
    {
        return await Task.FromResult(userMapper.Map<User, UserDto>(GetUserByID(ID)));
    }

    /// <summary>
    /// Gets user if exist
    /// <para>Kullanıcı varsa getirir</para>
    /// </summary>
    /// <param name="Username">Username / Kullanıcı adı</param>
    /// <param name="Password">Password / Parola</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserDto> GetUserAsync(string Username, string Password)
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            throw new Exception("Kullanıcı adı veya parola boş olamaz.");
        }
        var root = (IQueryable<User>)dbContext.Users;
        var chipperPassword = Common.CryptographyHelper.GetChipperPassword(Password);
        var user = root.FirstOrDefault(x => x.Username == Username && x.Password == chipperPassword);
        if (user is null)
        {
            return new UserDto();
        }
        return await Task.FromResult(userMapper.Map<User, UserDto>(user));


    }


    /// <summary>
    /// Adds new user
    /// <para>Kullanıcı varsa getirir</para>
    /// </summary>
    /// <param name="Username">Username / Kullanıcı adı</param>
    /// <param name="Password">Password / Parola</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserDto> AddUserAysnc(string Username, string Password)
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            throw new Exception("Kullanıcı adı veya parola boş olamaz.");
        }
        var user = new User()
        {
            Username = Username,
            Password = Password,
            Status = UserStatus.Active
        };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return userMapper.Map<User, UserDto>(user);
    }

    /// <summary>
    /// Change user's password
    /// <para>Kullanıcı parolasını günceller</para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <param name="Password">Users's password/ Kullanıcının parolası</param>
    /// <returns></returns>
    public async Task<UserDto> UpdateUserAysnc(int ID, string Password)
    {

        var user = GetUserByID(ID);
        var chipperPassword = Common.CryptographyHelper.GetChipperPassword(Password);
        user.Password = chipperPassword;

        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
        return userMapper.Map<User, UserDto>(user);
    }

    /// <summary>
    /// Change user's status
    /// <para>Kullanıcı durumunu günceller</para>
    /// </summary>
    /// <param name="ID">User's ID / Kullanıcı IDsi</param>
    /// <param name="userStatus">Users's status/ Kullanıcının durumu</param>
    /// <returns></returns>
    public async Task<UserDto> UpdateUserAysnc(int ID, UserStatus userStatus)
    {

        var user = GetUserByID(ID);
        user.Status = userStatus;

        dbContext.Users.Update(user);
        await dbContext.SaveChangesAsync();
        return userMapper.Map<User, UserDto>(user);
    }


    /// <summary>
    /// Lists users with paging
    /// <para>Sayfalama ile kullanıcıları getirir</para>
    /// </summary>
    /// <param name="keyword">Search Keyword / Arama kelimesi</param>
    /// <param name="pageSize">Data count per page / Sayfa başına kayıt sayısı</param>
    /// <param name="pageIndex">Index of page / Kaçıncı sayfa</param>
    /// <param name="userStatus">Users's status (optional) / Kullanıcı durumu (opsiyonel)</param>
    /// <returns></returns>
    public async Task<PagingModel<UserDto>> GetUsers(string keyword, int pageSize, int pageIndex, UserStatus? userStatus = null)
    {
        var root = (IQueryable<User>)dbContext.Users;

        var filteredUsers = root.Where(x => (x.Username.Contains(keyword) || string.IsNullOrEmpty(keyword))
                                    && (x.Status == userStatus || userStatus == null));

        var totalCount = await filteredUsers.LongCountAsync();

        var usersOnPage = await filteredUsers
                            .Skip(pageSize * pageIndex)
                            .Take(pageSize)
                            .ToListAsync();
        var listUserdto = userMapper.Map<List<User>, List<UserDto>>(usersOnPage);
        return new PagingModel<UserDto>(totalCount, pageIndex, pageSize, listUserdto);
    }
}
