﻿using FitnessApp.Data;
using FitnessApp.Services.Data.Contracts;
using FitnessApp.Web.ViewModels.Admin.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services.Data;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    /// <summary>
    /// Get all users from the database
    /// </summary>
    public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
    {
        var users = await _userManager.Users
            .ToListAsync();

        var userViewModels = new List<AllUsersViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            userViewModels.Add(new AllUsersViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = roles
            });
        }

        return userViewModels;
    }

    /// <summary>
    /// Check if user exists by id
    /// </summary>
    public async Task<bool> UserExistsByIdAsync(string userId)
    {
        var user = await _userManager
            .FindByIdAsync(userId);

        return user != null;
    }

    /// <summary>
    /// Assign user to role
    /// </summary>
    public async Task<bool> AssignUserToRoleAsync(string userId, string role)
    {
        var user = await _userManager
            .FindByIdAsync(userId);

        bool roleExists = await _roleManager
            .RoleExistsAsync(role);

        if (user == null || !roleExists)
        {
            return false;
        }

        bool alreadyInRole = await _userManager
            .IsInRoleAsync(user, role);

        if (!alreadyInRole)
        {
            var result = await _userManager
                .AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Remove user from role
    /// </summary>
    public async Task<bool> RemoveUserRoleAsync(string userId, string role)
    {
        var user = await _userManager
            .FindByIdAsync(userId);

        bool roleExists = await _roleManager
            .RoleExistsAsync(role);

        if (user == null || !roleExists)
        {
            return false;
        }

        bool alreadyInRole = await _userManager
            .IsInRoleAsync(user, role);

        if (alreadyInRole)
        {
            var result = await _userManager
                .RemoveFromRoleAsync(user, role);

            if (!result.Succeeded)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Delete user from the database
    /// </summary>
    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await _userManager
            .FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        // Delete related records in ClassesRegistrations
        var relatedRegistrations = _context.ClassesRegistrations
            .Where(cr => cr.MemberId == userId);
        _context.ClassesRegistrations.RemoveRange(relatedRegistrations);

        // Delete related records in SpaRegistrations
        var relatedSpaRegistrations = _context.SpaRegistrations
            .Where(sr => sr.MemberId == userId);
        _context.SpaRegistrations.RemoveRange(relatedSpaRegistrations);

        // Delete related records in EventRegistrations
        var relatedEventRegistrations = _context.EventRegistrations
            .Where(er => er.MemberId == userId);
        _context.EventRegistrations.RemoveRange(relatedEventRegistrations);

        // Save changes to delete related records
        await _context.SaveChangesAsync();

        // Delete the user
        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            return false;
        }

        return true;
    }
}