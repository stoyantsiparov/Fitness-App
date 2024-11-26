﻿using FitnessApp.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
	public class ClassController : BaseController
	{
		private readonly IClassService _classService;

		public ClassController(IClassService classService)
		{
			_classService = classService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var model = await _classService.GetAllClassesAsync();

			return View(model);
		}

		public async Task<IActionResult> MyClasses()
		{
			var userId = GetUserId();

			var model = await _classService.GetMyClassesAsync(userId);

			return View(model);
		}

		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			var model = await _classService.GetClassDetailsAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		public async Task<IActionResult> AddToMyClasses(int id)
		{
			var userId = GetUserId();

			try
			{
				var model = await _classService.GetClassByIdAsync(id);
				if (model == null)
				{
					ModelState.AddModelError(string.Empty, "The fitness class does not exist.");
					return RedirectToAction(nameof(Details), new { id });
				}

				// Добавяне на потребителя към избрания клас
				await _classService.AddToMyClassesAsync(userId, model);

				return RedirectToAction(nameof(MyClasses));
			}
			catch (InvalidOperationException ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return RedirectToAction(nameof(Details), new { id });
			}
		}

		public async Task<IActionResult> RemoveFromMyClasses(int id)
		{
			var userId = GetUserId();

			try
			{
				var model = await _classService.GetClassByIdAsync(id);
				await _classService.RemoveFromMyClassesAsync(userId, model);
			}
			catch (InvalidOperationException ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}

			return RedirectToAction(nameof(MyClasses));
		}
	}
}