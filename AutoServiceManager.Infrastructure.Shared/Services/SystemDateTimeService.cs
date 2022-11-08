using AutoServiceManager.Application.Interfaces.Shared;
using System;

namespace AutoServiceManager.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}