using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class CategoriesModel : CustomizedPageModel
    {
        public CategoriesModel(ContentTableContext context) : base(context) { }
    }
}