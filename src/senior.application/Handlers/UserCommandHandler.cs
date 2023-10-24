using SecureIdentity.Password;
using senior.application.Abstractions.Messages;
using senior.application.Commands;
using senior.application.Commands.UserCommands;
using senior.application.Services;
using senior.application.Validations.UserValidations;
using senior.application.ViewModels.Account;
using senior.domain.Abstractions;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;

namespace senior.application.Handlers;

public class UserCommandHandler :
    BaseHandler,
    ICommandHandler<RegisterUserCommand>,
    ICommandHandler<UpdateUserCommand>,
    ICommandHandler<LoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationMessage _validationMessage;
    private readonly TokenService _tokenService;

    public UserCommandHandler(
        IUnitOfWork unitOfWork,
        IValidationMessage validationMessage,
        IUserRepository userRepository,
        TokenService tokenService) : base(validationMessage)
    {
        _unitOfWork = unitOfWork;
        _validationMessage = validationMessage;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> Handle(
        RegisterUserCommand command, 
        CancellationToken cancelationToken)
    {
        if (!ExecuteValidation(new RegisterUserValidation(), command))
        {
            return new CommandResult(
                false,
                "Errors de validações",
                _validationMessage.GetErrorMessages());
        }

        var userExist = await _userRepository.GetUserByEmailAsync(command.Email);
        if (userExist != null)
        {
            return new CommandResult(
            false,
            "Email já registrado",
            command);
        }

        User user = new(
            command.Name, 
            command.Email);

        var password = PasswordGenerator.Generate(25);
        user.SetPassword(PasswordHasher.Hash(password));

        _userRepository.Create(user);

        await _unitOfWork.CommitAsync(cancelationToken);

        //enviar e-mail com a senha

        return new CommandResult(
            true,
            $"Usuário registrado com sucesso, ATENÇÃO a senha foi enviada no email {command.Email}",
            command);
    }

    public async Task<ICommandResult> Handle(
        UpdateUserCommand command, 
        CancellationToken cancelationToken)
    {
        if (!ExecuteValidation(new UpdateUserValidation(), command))
        {
            return new CommandResult(
                false,
                "Errors de validações",
                _validationMessage.GetErrorMessages());
        }

        var userModel = new ListUserViewModel
        {
            Email = command.Email,
        };

        var userExist = await _userRepository.GetUserByEmailAsync(command.Email);
        if (userExist == null)
        {
            return new CommandResult(
            false,
            "Email não registrado",
            userModel);
        }

        if (!PasswordHasher.Verify(userExist.PasswordHash, command.Password))
        {
            return new CommandResult(
            false,
            "Usuário ou Senha inválida",
            userModel);
        }

            userExist.AlterName(command.Name);

        _userRepository.Update(userExist);

        await _unitOfWork.CommitAsync(cancelationToken);

        return new CommandResult(
            true,
            $"Nome do usuário alterado com sucesso",
            userModel);
    }

    public async Task<ICommandResult> Handle(
        LoginCommand command, 
        CancellationToken cancelationToken)
    {
        if (!ExecuteValidation(new LoginValidation(), command))
        {
            return new CommandResult(
                false,
                 "Errors de validações",
                _validationMessage.GetErrorMessages());
        }

        var userModel = new ListUserViewModel
        {
            Email = command.Email,
        };

        var userExist = await _userRepository.GetUserByEmailAsync(command.Email);
        if (userExist == null)
        {
            return new CommandResult(
            false,
            "Email não registrado",
            userModel);
        }

        if (!PasswordHasher.Verify(userExist.PasswordHash, command.Password))
        {
            return new CommandResult(
            false,
            "Usuário ou Senha inválida",
            userModel);
        }

        var token = _tokenService.Create(userExist);

        return new CommandResult(
            true,
            "Credencial conferida",
            new TokenViewModel
            {
                Token = token,
            });
    }
}
