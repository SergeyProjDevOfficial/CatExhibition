using DataBaseWorkingLib.Context;
using DataBaseWorkingLib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CatExhibition.PageModels
{
    public class CustomizedPageModel : PageModel
    {
        private ItemsRepository itemsRepository;
        public string lang = string.Empty;

        public CustomizedPageModel(ContentTableContext context)
        {
            itemsRepository = new ItemsRepository(context);
        }

        [BindProperty(SupportsGet = true)]
        public string Language
        {
            get
            {
                return lang;
            }
            set
            {
                lang = value;
                Response.Cookies.Append(itemsRepository.Language, lang);
                ViewData[itemsRepository.Language] = lang;
            }
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext?.Request?.Cookies[itemsRepository.Language]))
            {
                lang = HttpContext.Request.Cookies[itemsRepository.Language];
                return;
            }

            string currentCulture = System.Globalization.CultureInfo
                .CurrentCulture?.Name ?? string.Empty;

            var languages = GetLanguages();
            if (languages.Contains(currentCulture))
            {
                lang = currentCulture;
            }
            else
            {
                lang = languages.FirstOrDefault();
            }
        }

        public string GetItem(string textId) => itemsRepository.GetItem(textId, lang);

        public IList<string> GetLanguages() => itemsRepository.GetLanguages();
    }
}
