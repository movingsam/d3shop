﻿using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCorePal.D3Shop.Web.Application.Commands.Identity.Client;
using NetCorePal.D3Shop.Web.Application.Queries.Identity.Client;
using NetCorePal.D3Shop.Web.Controllers.Identity.Client.Requests;
using NetCorePal.D3Shop.Web.Controllers.Identity.Client.Responses;
using NetCorePal.D3Shop.Web.Helper;
using NetCorePal.Extensions.Dto;

namespace NetCorePal.D3Shop.Web.Controllers.Identity.Client;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ClientUserAccountController(
    IMediator mediator,
    ClientUserQuery clientUserQuery,
    TokenGenerator tokenGenerator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ResponseData<ClientUserLoginResponse>> LoginAsync([FromBody] ClientUserLoginRequest request)
    {
        var userAuthInfo = await clientUserQuery.RetrieveClientWithAuthInfoByPhoneAsync(request.Phone);
        var passwordHash = NewPasswordHasher.HashPassword(request.Password, userAuthInfo.PasswordSalt);

        var loginResult = await mediator.Send(new ClientUserLoginCommand(
            userAuthInfo.UserId,
            passwordHash,
            DateTime.UtcNow,
            request.LoginMethod,
            request.IpAddress,
            request.UserAgent
        ));

        if (!loginResult.IsSuccess)
            return ClientUserLoginResponse.Failure(loginResult.FailedMessage).AsResponseData();

        var token = tokenGenerator.GenerateJwtAsync([
            new Claim(ClaimTypes.NameIdentifier, userAuthInfo.UserId.ToString())
        ]);
        return ClientUserLoginResponse.Success(token).AsResponseData();
    }

    [HttpPost("register")]
    public async Task<ResponseData<string>> RegisterAsync([FromBody] ClientUserRegisterRequest request)
    {
        var (passwordHash, passwordSalt) = NewPasswordHasher.HashPassword(request.Password);

        var userId = await mediator.Send(new CreateClientUserCommand(
            request.NickName,
            request.Avatar,
            request.Phone,
            passwordHash,
            passwordSalt,
            request.Email
        ));

        var token = tokenGenerator.GenerateJwtAsync([
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        ]);
        return token.AsResponseData();
    }
}