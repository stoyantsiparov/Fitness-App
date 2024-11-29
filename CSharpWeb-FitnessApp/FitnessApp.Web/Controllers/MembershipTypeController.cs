﻿using FitnessApp.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
				ModelState.AddModelError(string.Empty, "The membership type does not exist.");
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

			if (model != null)
			{
				await _membershipTypeService.RemoveMyMembershipAsync(userId, model);
			}
		}
		catch (InvalidOperationException ex)
		{
			ModelState.AddModelError(string.Empty, ex.Message);
		}

		return RedirectToAction(nameof(MyMembershipType));
	}
}