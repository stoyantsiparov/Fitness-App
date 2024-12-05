﻿using FitnessApp.Services.Data.Contracts;
using FitnessApp.Web.ViewModels.MembershipTypeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationsConstants;
using static FitnessApp.Common.ErrorMessages.MembershipType;

namespace FitnessApp.Web.Controllers;
public class MembershipTypeController : BaseController
{
	private readonly IMembershipTypeService _membershipTypeService;

	public MembershipTypeController(IMembershipTypeService membershipTypeService)
	{
		_membershipTypeService = membershipTypeService;
	}

	[AllowAnonymous]
	public async Task<IActionResult> Index()
	{
		var model = await _membershipTypeService.GetAllMembershipTypesAsync();

		return View(model);
	}

	public async Task<IActionResult> MyMembershipType()
	{
		var userId = GetUserId();

		var model = await _membershipTypeService.GetMyMembershipTypesAsync(userId);

		return View(model);
	}

	[AllowAnonymous]
	public async Task<IActionResult> Details(int id)
	{
		var model = await _membershipTypeService.GetMembershipTypeDetailsAsync(id);

		if (model == null)
		{
			return RedirectToAction(nameof(Index));
		}

		return View(model);
	}
	
	public async Task<IActionResult> AddMyMembership(int id)
	{
		var userId = GetUserId();

		try
		{
			var model = await _membershipTypeService.GetMembershipTypeByIdAsync(id);
			if (model == null)
			{
				ModelState.AddModelError(string.Empty, MembershipTypeDoesNotExist);
				return RedirectToAction(nameof(Details), new { id });
			}

			await _membershipTypeService.AddMyMembershipAsync(userId, model);
			return RedirectToAction(nameof(MyMembershipType));
		}
		catch (InvalidOperationException ex)
		{
			TempData["ErrorMessage"] = ex.Message;
			return RedirectToAction(nameof(Details), new { id });
		}
	}

	public async Task<IActionResult> RemoveMyMembership(int id)
	{
		var userId = GetUserId();

		try
		{
			var model = await _membershipTypeService.GetMembershipTypeByIdAsync(id);
			if (model == null)
			{
				TempData["ErrorMessage"] = MembershipTypeDoesNotExist;
				return RedirectToAction(nameof(MyMembershipType));
			}

			await _membershipTypeService.RemoveMyMembershipAsync(userId, model);
		}
		catch (InvalidOperationException ex)
		{
			TempData["ErrorMessage"] = ex.Message;
		}

		return RedirectToAction(nameof(MyMembershipType));
	}

	[HttpGet]
	[Authorize(Roles = AdminRole)]
	public async Task<IActionResult> Add()
	{
		var model = await _membershipTypeService.GetMembershipTypeForAddAsync();

		return View(model);
	}

	[HttpPost]
    [Authorize(Roles = AdminRole)]
    public async Task<IActionResult> Add(AddMembershipTypeViewModel model)
	{
		if (ModelState.IsValid == false)
		{
			return View(model);
		}

		var userId = GetUserId();
		await _membershipTypeService.AddMembershipTypeAsync(model, userId);

		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
    [Authorize(Roles = AdminRole)]
    public async Task<IActionResult> Edit(int id)
	{
		var model = await _membershipTypeService.GetMembershipTypeByIdAsync(id);

		if (model != null)
		{
			return View(model);
		}

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
    [Authorize(Roles = AdminRole)]
    public async Task<IActionResult> Edit(MembershipTypeViewModel model)
	{
		if (ModelState.IsValid == false)
		{
			return View(model);
		}

        var userId = GetUserId();

        await _membershipTypeService.EditMembershipTypeAsync(model, userId);

		return RedirectToAction(nameof(Details),new { id = model.Id });
	}

	[HttpGet]
    [Authorize(Roles = AdminRole)]
    public async Task<IActionResult> Delete(int id)
	{
		var model = await _membershipTypeService.GetMembershipTypeForDeleteAsync(id);

		if (model != null)
		{
			return View(model);
		}

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
    [Authorize(Roles = AdminRole)]
    public async Task<IActionResult> Delete(DeleteMembershipTypeViewModel model)
	{
        var userId = GetUserId();

        await _membershipTypeService.DeleteMembershipTypeAsync(model.Id, userId);

		return RedirectToAction(nameof(Index));
	}
}