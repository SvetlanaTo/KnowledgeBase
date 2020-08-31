using KnowledgeBase.DAL.Repo;
using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.ApplicationSettings
{
    public class SettingsService : ISettingsService 
    {
        private const string SettingsSessionKey = "SettingsSessionKey";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ISettingsRepository _settingsRepository { get; set; }

        public SettingsService(IHttpContextAccessor httpContextAccessor, ISettingsRepository settingsRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _settingsRepository = settingsRepository;
        }


        public Settings GetSettings()
        {          
            //todo VRATI SE.. SREDI SESSION ... Session CompanyName
            return _settingsRepository.Get();

            //if (_httpContextAccessor.HttpContext.Session.GetString(SettingsSessionKey) == null)
            //{
            //    ReloadSettings();
            //}
            //return HttpContext.Current.Session[SettingsSessionKey] as Settings;         


            //KbVaultPublicController -> OnActionExecuted 
            //return (_httpContextAccessor.HttpContext.Session.GetString(SettingsSessionKey) as object) as Settings;
        }

        public void ReloadSettings()
        {
            ////HttpContext.Current.Session[SettingsSessionKey] = SettingsRepository.Get();

            //ovo sad nema smisla
            //var sessionkey = _httpContextAccessor.HttpContext.Session.GetString(SettingsSessionKey);
            //sessionkey = _settingsRepository.Get().ToString();

            //uzima prvu torku iz baze koju pronadje
            //_context.Settings.FirstOrDefault();
            //_httpContextAccessor.HttpContext.Session.SetString("CalculationType", tableName);

            var settings = _settingsRepository.GetSettingsAsNoTracking();


        }
    }
}
