using DataBaseWorkingLib.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseWorkingLib.Repository
{
    public class ItemsRepository
    {
        public string Language { get => "Language"; }

        private ContentTableContext _context;
        public ItemsRepository(ContentTableContext context)
        {
            _context = context;
        }

        public string GetItem(string textId, string language)
        {
            return
                _context.Translations
                .Where(i => i.Language.Equals(language)
                    && i.TextId.Equals(textId))
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        public IList<string> GetLanguages()
        {
            return
                _context.Translations
                .Select(item => item.Language)
                .Distinct()
                .ToList();
        }
    }
}
