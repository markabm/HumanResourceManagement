using System;
namespace HumanResource.Service
{
    public interface IAuthenticationService
    {
        bool HasValidUsernameAndPassword(string userName, string password);
    }
}
