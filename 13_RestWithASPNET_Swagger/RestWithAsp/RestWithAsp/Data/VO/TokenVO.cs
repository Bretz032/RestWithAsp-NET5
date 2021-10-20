using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiration, string accessToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AcessToken = accessToken;
            RefreshToken = refreshToken;
        }
 

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
