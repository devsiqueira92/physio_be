﻿using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;

namespace Physio.Infrasctructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(
        IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public async Task<string> GenerateAsync(UserEntity user, Guid? clinicId)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("accType", user.LoginType.ToString()),
            new("isRegistred", user.IsRegistred.ToString()),
        };

        if (clinicId != null )
            claims.Add(new("cln", clinicId.ToString()));

        //HashSet<string> permissions = await _permissionService
        //    .GetPermissionsAsync(Guid.Parse(user.Id));

        //foreach (string permission in permissions)
        //{
        //    claims.Add(new(CustomClaims.Permissions, permission));
        //}

        var signingCredentials = new SigningCredentials(
             new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(_options.SecretKey)),
             SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler()
             .WriteToken(token);

        return tokenValue;
    }
}
