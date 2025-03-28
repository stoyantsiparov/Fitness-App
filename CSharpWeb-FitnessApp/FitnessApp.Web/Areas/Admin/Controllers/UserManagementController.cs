﻿using FitnessApp.Services.Data.Contracts;
using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationsConstants;
using static FitnessApp.Common.ErrorMessages.User;
using static FitnessApp.Common.SuccessfulValidationMessages.User;

namespace FitnessApp.Web.Areas.Admin.Controllers;

[Area(AdminRole)]
[Authorize(Roles = AdminRole)]
public class UserManagementController : BaseController
{
    private readonly IUserService _userService;

    public UserManagementController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var allUsers = await _userService.GetAllUsersAsync();

        return View(allUsers);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(string userId, string role)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
        {
            TempData["ErrorMessage"] = UserIdOrRoleCannotBeEmpty;
            return RedirectToAction(nameof(Index));
        }

        bool userExists = await _userService.UserExistsByIdAsync(userId);

        if (!userExists)
        {
            TempData["ErrorMessage"] = UserDoesNotExist;
            return RedirectToAction(nameof(Index));
        }

        bool assignResult = await _userService.AssignUserToRoleAsync(userId, role);

        if (!assignResult)
        {
            TempData["ErrorMessage"] = FailedToAssignRole;
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = RoleAssigned;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> RemoveRole(string userId, string role)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role))
        {
            TempData["ErrorMessage"] = UserIdOrRoleCannotBeEmpty;
            return RedirectToAction(nameof(Index));
        }

        bool userExists = await _userService.UserExistsByIdAsync(userId);

        if (!userExists)
        {
            TempData["ErrorMessage"] = UserDoesNotExist;
            return RedirectToAction(nameof(Index));
        }

        bool removeRoleResult = await _userService.RemoveUserRoleAsync(userId, role);

        if (!removeRoleResult)
        {
            TempData["ErrorMessage"] = FailedToRemoveRole;
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = RoleRemoved;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            TempData["ErrorMessage"] = UserIdOrRoleCannotBeEmpty;
            return RedirectToAction(nameof(Index));
        }

        bool userExists = await _userService.UserExistsByIdAsync(userId);

        if (!userExists)
        {
            TempData["ErrorMessage"] = UserDoesNotExist;
            return RedirectToAction(nameof(Index));
        }

        bool deleteResult = await _userService.DeleteUserAsync(userId);

        if (!deleteResult)
        {
            TempData["ErrorMessage"] = FailedToDeleteRole;
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = RoleDeleted;
        return RedirectToAction(nameof(Index));
    }
}