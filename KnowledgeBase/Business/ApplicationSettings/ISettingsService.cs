using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.ApplicationSettings
{
    public interface ISettingsService
    {
        Settings GetSettings();
        void ReloadSettings();
    }
}
