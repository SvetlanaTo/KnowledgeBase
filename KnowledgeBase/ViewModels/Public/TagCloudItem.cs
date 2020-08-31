using KnowledgeBase.DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels.Public
{
    public class TagCloudItem
    {
        public TagCloudItem(TopTagItem tagItem)
        {
            Ratio = tagItem.Ratio;
            Name = tagItem.Name;
            Id = tagItem.Id;
            FontSize = tagItem.FontSize;
        }

        public int? Ratio { get; set; }
        public string Name { get; set; }
        public long? Id { get; set; }
        public int FontSize { get; set; }
    }
}
