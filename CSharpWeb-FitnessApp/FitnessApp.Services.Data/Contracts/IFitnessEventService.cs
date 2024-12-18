﻿using FitnessApp.Web.ViewModels.FitnessEventViewModels;

namespace FitnessApp.Services.Data.Contracts;

public interface IFitnessEventService
{
	Task<IEnumerable<AllFitnessEventsViewModel>> GetAllFitnessEventsAsync(string? searchTerm = null);
    Task<FitnessEventViewModel?> GetFitnessEventByIdAsync(int id);
    Task<FitnessEventDetailsViewModel?> GetFitnessEventDetailsAsync(int id);
    Task<IEnumerable<AllFitnessEventsViewModel>> GetMyFitnessEventsAsync(string userId);
    Task AddToMyFitnessEventsAsync(string userId, FitnessEventViewModel? fitnessEventViewModel);
    Task RemoveFromMyFitnessEventsAsync(string userId, FitnessEventViewModel? fitnessEventViewModel);
    Task<AddFitnessEventViewModel> GetFitnessEventForAddAsync();
    Task AddFitnessEventAsync(AddFitnessEventViewModel model, string userId);
    Task EditFitnessEventAsync(FitnessEventViewModel model, string userId);
    Task<DeleteFitnessEventViewModel?> GetFitnessEventForDeleteAsync(int id);
    Task DeleteFitnessEventAsync(int id, string userId);
}