using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.DataAcess.Entities;

namespace Games.Domain.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(UserEntity user, List<string> roles);
    }
}
