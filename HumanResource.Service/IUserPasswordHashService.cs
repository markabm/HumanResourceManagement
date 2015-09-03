using System;
namespace HumanResource.Service
{
    public interface IUserPasswordHashService
    {
        bool ByteArraysEqual(byte[] b1, byte[] b2);
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}
