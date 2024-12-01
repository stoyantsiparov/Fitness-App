﻿using FitnessApp.Web.ViewModels.ClassViewModels;

namespace FitnessApp.Services.Data.Contracts;

public interface IClassService
{
    Task<IEnumerable<AllClassesViewModel>> GetAllClassesAsync();
    Task<ClassesViewModel?> GetClassByIdAsync(int id);
    Task<ClassesDetailsViewModel?> GetClassDetailsAsync(int id);
    Task<IEnumerable<AllClassesViewModel>> GetMyClassesAsync(string userId);
    Task AddToMyClassesAsync(string userId, ClassesViewModel? classesViewModel);
    Task RemoveFromMyClassesAsync(string userId, ClassesViewModel? classesViewModel);
    Task<AddClassViewModel> GetClassForAddAsync();
    Task AddClassAsync(AddClassViewModel model, string userId);
    Task EditClassAsync(ClassesViewModel model);
    Task<DeleteClassViewModel?> GetClassForDeleteAsync(int id);
    Task DeleteClassAsync(int id);
}