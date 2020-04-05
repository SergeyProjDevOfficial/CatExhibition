using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class AboutUsModel : CustomizedPageModel
    {
        public AboutUsModel(ContentTableContext context) : base(context)
        {
        }
    }
}