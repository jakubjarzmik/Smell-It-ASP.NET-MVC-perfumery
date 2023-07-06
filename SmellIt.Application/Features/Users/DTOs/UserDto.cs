﻿using SmellIt.Application.Features.Roles.DTOs;

namespace SmellIt.Application.Features.Users.DTOs;

public class UserDto
{
    public string Id { get; set; } = default!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public IEnumerable<string>? Roles { get; set; }
}