﻿namespace AuthenticationServer.Core.Request.Authentication;

public class Register
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
}