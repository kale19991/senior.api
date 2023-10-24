using Microsoft.AspNetCore.Http;
using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.LocalityCommands;

public class UploadCsvCommand : ICommand
{
    public UploadCsvCommand(IFormFile uploadFile)
    {
        UploadFile = uploadFile;
    }

    public IFormFile UploadFile { get; }
}
