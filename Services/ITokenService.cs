﻿namespace CharityClinic.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email, string fullName);
    }
}
