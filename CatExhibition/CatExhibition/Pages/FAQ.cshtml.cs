using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class FAQModel : CustomizedPageModel
    {
        public FAQModel(ContentTableContext context) : base(context)
        {
        }
    }
}