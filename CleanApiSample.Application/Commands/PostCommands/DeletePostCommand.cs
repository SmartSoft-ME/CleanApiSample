﻿using CleanApiSample.Shared.Abstractions.Application.Commands;

using MediatR;

namespace CleanApiSample.Application.Commands.PostCommands
{
    public record DeleteUserCommand(int Id) : ICommand<Unit>;
}
