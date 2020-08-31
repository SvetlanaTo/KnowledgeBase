using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.DAL.Repo
{
    public class SettingsRepository : ISettingsRepository
    {

        private KnowledgeBaseContext _context;

        public SettingsRepository(KnowledgeBaseContext context)
        {
            _context = context;
        }

        public Settings Get()
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
                return _context.Settings.FirstOrDefault();
            //}
        }

        public List<Settings> GetSettingsAsNoTracking()
        {
            return _context.Settings.AsNoTracking().ToList();
        }

        public void Save(Settings settings)
        {
            //using (var db = new KnowledgeBaseContext(_config))
            //{
                var set = _context.Settings.FirstOrDefault();
                if (set != null)
                {
                _context.Settings.Remove(set);
                }

            _context.Settings.Add(settings);
            _context.SaveChanges();
            //}
        }
    }
}
