﻿using Application.Common.Dto.Authen;
using Application.Common.Dto.Exception;
using Application.Interfaces.Users;
using AutoMapper;
using Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoy userRepositoy;
        private readonly IMapper mapper;
        public UserService
            (IUserRepositoy userRepositoy, IMapper mapper)
        {
            this.userRepositoy = userRepositoy;
            this.mapper = mapper;
        }

        public async Task<Token> Login(LoginDto loginDto)
        {
            try
            {
                var user = await userRepositoy.GetUserByEmail(loginDto.Email);
                var token = new Token();
                if(user == null)
                {
                    throw new MyException("Tên đăng nhập không đúng hoặc không tồn tại.", 404);
                }
                else
                {
                    if(!VerifyPasswordHash
                        (loginDto.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        throw new MyException("Mật khẩu của bạn không đúng.", 404);
                    }
                    else
                    {
                        return mapper.Map<Token>(user);
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task Register(RegisterDto registerDto)
        {
            try
            {
                if (await userRepositoy.GetUserByEmail
                    (registerDto.Email) is not null)
                {
                    throw new MyException("Email đã tồn tại.", 404);
                }else if(!registerDto.PasswordConfirm
                    .Equals(registerDto.PasswordConfirm)){
                    throw new MyException("Mật khẩu không khớp.", 404);
                }

                CreatePasswordHash(registerDto.Password, out byte[] password_hash, out byte[] password_salt);

                var user = mapper.Map<RegisterDto, User>(registerDto,
                opt => opt.AfterMap((src, des) =>
                {
                    des.PasswordHash = password_hash;
                    des.PasswordSalt = password_salt;
                }));

                await userRepositoy.Insert(user);
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
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
