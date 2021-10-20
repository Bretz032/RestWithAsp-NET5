using RestWithAsp.Data.VO;

namespace RestWithAsp.Negocios
{
    public interface ILoginNegocios
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);



    }
}
