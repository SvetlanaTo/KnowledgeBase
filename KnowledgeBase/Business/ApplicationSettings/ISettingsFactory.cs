using KnowledgeBase.Models;
using KnowledgeBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Business.ApplicationSettings
{
    public interface ISettingsFactory
    {
        SettingsViewModel CreateViewModel(Settings settings);
        Settings CreateModel(SettingsViewModel settings);
    }
}
