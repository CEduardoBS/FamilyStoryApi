using FamilyStoryApi.Application.Commands.Auth;
using FamilyStoryApi.Application.Handlers.Interface;
using FamilyStoryApi.Application.Results;
using FamilyStoryApi.Application.Services;
using FamilyStoryApi.Core.Entities;
using FamilyStoryApi.Infra.Entities;
using FamilyStoryApi.Infra.Repository;

namespace FamilyStoryApi.Application.Handlers.Auth
{
    public class AuthHandler : Notifiable, IHandlerAsync<AuthCommand, CommandResult<LoginResult>>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly TokenService _tokenService;

        public AuthHandler(IUserInfoRepository userInfoRepository, TokenService tokenService)
        {
            _userInfoRepository = userInfoRepository;
            _tokenService = tokenService;
        }

        public async Task<CommandResult<LoginResult>> HandleAsync(AuthCommand command)
        {
            CommandResult<LoginResult> result;
            LoginResult? loginResult = null;

            try
            {
                if (command.Validate())
                {
                    UserInfo? user = await _userInfoRepository.GetUserByEmail(command.Login.Address);

                    if (user is not null)
                    {
                        if (user.ValidPassword(command.Password))
                        {
                            string tokenGenerated = _tokenService.GenerateToken(user);

                            loginResult = new LoginResult
                                (
                                    name: user.Name,
                                    email: command.Login.Address,
                                    token: tokenGenerated
                                );
                        }
                        else
                        {
                            this.AddNotification("AuthHandler.HandleAsync: Senha incorreta!");
                        }
                    }
                    else
                    {
                        this.AddNotification("AuthHandler.HandleAsync: Email não cadastrado!");
                    }
                }
                else
                {
                    this.AddNotification("AuthHandler.HandleAsync: Email e/ou senha incorretos!");
                }

                this.AddNotifications(command.Login);

                result = new
                    (
                        success: loginResult != null,
                        message: loginResult == null ? "Erro ao validar login" : "Sucesso ao validar login",
                        data: loginResult
                    );
            }
            catch (Exception err)
            {
                result = new
                    (
                        success: false,
                        message: err.Message
                    );

                this.AddNotification($"AuthHandler.HandleAsync: Erro ao validar login: {err.Message}");
            }

            return result;
        }
    }
}
