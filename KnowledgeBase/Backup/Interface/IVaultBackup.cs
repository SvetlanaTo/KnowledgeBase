using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Backup.Interface
{
    public interface IVaultBackup
    {
        void Connect(string connectionString);
        bool Backup(string databaseName, string physicalPath);
        bool Restore(string databaseName, string physicalPath);
    }
}
