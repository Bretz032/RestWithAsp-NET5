using RestWithAsp.Data.VO;
using RestWithAsp.Model;

namespace RestWithAsp.Repository
{
   public  interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
