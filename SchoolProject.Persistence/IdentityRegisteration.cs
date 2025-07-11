﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Persistence
{
    public static class IdentityRegisteration
    {
        public static IServiceCollection AddIdentityDependencies(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;
                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;
                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
