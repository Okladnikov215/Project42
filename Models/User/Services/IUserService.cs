using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Models.User.Services
{
    public interface IUserService
    {
        Task ValidateUserAsync(User userToValidate);
        User CreateUser(UserRegistrationInfo cardToCreate);
        Task<bool> AddUserAsync(User userToAdd, string password, CancellationToken cancellationToken);
        Task<User> AuthenticateAsync(string username, string password);
        Task<User> GetById(Guid id);
        Task<bool> Delete(Guid id);
        void Update(UserPatchInfo userToUpdate, string password = null);
    }
}