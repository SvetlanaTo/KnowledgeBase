﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class BackupListViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime FileDate { get; set; }
    }
}
