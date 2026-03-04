//using Entities;

//namespace Services
//{
//    public interface IPasswordService
//    {
//<<<<<<< HEAD
//        Task<PasswordEntity> CheckPasswordStrength(string password);
//=======
//        PasswordEntity Level(string password);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}

namespace Services
{
    public interface IPasswordService
    {
        int CheckPasswordStrength(string password);
    }
}