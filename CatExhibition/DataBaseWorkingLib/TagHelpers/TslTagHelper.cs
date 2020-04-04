using DataBaseWorkingLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseWorkingLib.Context;
using System.Linq;

namespace DataBaseWorkingLib.TagHelpers
{
    [HtmlTargetElement(Attributes = "tsl-content")]
    public class TslTagHelper : TagHelper
    {
        public string TslContent { get; set; }

        protected string language;
        protected ItemsRepository itemsRepository;

        [ViewContext]
        public ViewContext ViewContext { get; set; }
        protected HttpRequest Request => ViewContext.HttpContext.Request;

        public TslTagHelper(ContentTableContext context) =>  itemsRepository = new ItemsRepository(context);



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            language = GetCurrentLanguage();
            var outputData = itemsRepository.GetItem(TslContent, language) ?? "";
            output.Content.SetHtmlContent(outputData);
        }



        protected string GetCurrentLanguage()
        {
            string lang = ViewContext?.ViewData[itemsRepository.Language]?.ToString();

            if (!string.IsNullOrEmpty(lang))
            {
                return lang;
            }

            if (!string.IsNullOrEmpty(Request.Cookies[itemsRepository.Language]))
            {
                return Request.Cookies[itemsRepository.Language];
            }

            string currentCulture = System.Globalization.CultureInfo
                .CurrentCulture?.Name ?? string.Empty;

            if (itemsRepository.GetLanguages().Contains(currentCulture))
            {
                return currentCulture;
            }

            return itemsRepository.GetLanguages().FirstOrDefault();
        }
    }
}
