using Application.Common.Dto;
using Application.Interfaces.Users;
using Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoy userRepositoy;
        public UserService(IUserRepositoy userRepositoy)
        {
            this.userRepositoy = userRepositoy;
        }

        public async Task<User> login(LoginDto loginDto)
        {
            try
            {
                var user = await userRepositoy.GetUserByEmail(loginDto.Email);
                if(user == null)
                {

                }
                else
                {
                    if(!VerifyPasswordHash
                        (loginDto.Password, user.PasswordHash, user.PasswordSalt))
                    {

                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
