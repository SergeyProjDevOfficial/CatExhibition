using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class ExhibitionsModel : CustomizedPageModel
    {
        public ExhibitionsModel(ContentTableContext context) : base(context)
        {
        }
    }
}