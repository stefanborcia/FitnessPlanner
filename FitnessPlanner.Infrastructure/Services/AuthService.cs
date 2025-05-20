using AutoMapper;
using FitnessPlanner.Application.DTOs;
using FitnessPlanner.Application.Interfaces;
using FitnessPlanner.Application.Interfaces.Repositories;
using FitnessPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace FitnessPlanner.Infrastructure.Services
{
    public class AuthService(IUserRepository userRepository, IPasswordHasher<User> hasher, IConfiguration config, IMapper mapper) : IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher<User> _hasher = hasher;
        private readonly IConfiguration _config = config;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto?> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null) return null;

            var user = new User
            {
                Email = dto.Email,
                Goal = dto.Goal,
                BodyType = dto.BodyType,
                Subscription = dto.Subscription,
            };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) return null;

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Subscription", user.Subscription.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
