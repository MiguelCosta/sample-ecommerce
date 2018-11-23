namespace Mpc.Ecommerce.BackOffice.Application.Services.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Mpc.Ecommerce.BackOffice.Application.Dto;
    using Mpc.Ecommerce.BackOffice.Application.Services.Mappings;
    using Mpc.Ecommerce.BackOffice.Application.Services.Security;
    using Mpc.Ecommerce.BackOffice.Domain.Core;
    using Polly;

    public class UserService : IUserService
    {
        private readonly IEncryptText _encryptText;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IEncryptText encryptText,
            IUnitOfWork unitOfWork)
        {
            _encryptText = encryptText;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(UserDto user)
        {
            var userModel = user.ToModel();
            userModel.Password = _encryptText.Encrypt(user.Password);

            await _unitOfWork.UsersRepository.InsertAsync(userModel).ConfigureAwait(false);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var policy = await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2))
                .ExecuteAndCaptureAsync(async () => await _unitOfWork.UsersRepository.GetByFilterAsync(1, 10).ConfigureAwait(false));

            return policy.Result.ToDto().ToList();
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            var user = await _unitOfWork.UsersRepository.GetByUsernameAsync(username).ConfigureAwait(false);

            return user.ToDto();
        }
    }
}
