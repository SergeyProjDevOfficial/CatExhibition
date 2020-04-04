using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition.Pages
{
    public class IndexModel : CustomizedPageModel
    {
        public IndexModel(ContentTableContext context) : base(context) { }
    }
}
