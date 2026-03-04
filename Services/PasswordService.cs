//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Entities;
//using Repository;
//namespace Services
//{
//    public class PasswordService : IPasswordService
//    {
//<<<<<<< HEAD
//        public async Task<PasswordEntity> CheckPasswordStrength(string password)
//=======
//        public PasswordEntity Level(string password)
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        {
//            var _result = Zxcvbn.Core.EvaluatePassword(password);
//            int _levelPass = _result.Score;
//            PasswordEntity _passRes = new PasswordEntity();
//            _passRes.Password = password;
//            _passRes.Strength = _levelPass;
//            return _passRes;

//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository;

namespace Services
{
    public class PasswordService : IPasswordService
    {
        public int CheckPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score; // מחזיר ציון בין 0 ל-4
        }
    }
}
