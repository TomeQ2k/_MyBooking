using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Stats.Pages
{
    [Authorize(Policy = Constants.AdminPolicy)]
    public class StatsModel : BasePageModel
    {
        private readonly IServiceProvider services;

        public StatsWrapper StatsWrapper { get; private set; }

        public StatsType StatsType { get; private set; }

        public StatsModel(IServiceProvider services)
        {
            this.services = services;

            Title = "Stats";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] StatsType statsType = StatsType.Annual)
        {
            StatsType = statsType;

            IStatsService statsService = StatsType switch
            {
                StatsType.Annual => services.GetRequiredService<IAnnualStatsService>(),
                StatsType.Monthly => services.GetRequiredService<IMonthlyStatsService>(),
                _ => services.GetRequiredService<IAnnualStatsService>()
            };

            StatsWrapper = await new StatsWrapper(statsService).Build();

            return Page();
        }
    }
}