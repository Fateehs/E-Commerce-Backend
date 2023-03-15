﻿namespace ETradeAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second);

        string CreateRefreshToken();
    }
}
