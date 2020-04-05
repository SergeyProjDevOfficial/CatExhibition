using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class ConditionsModel : CustomizedPageModel
    {
        public ConditionsModel(ContentTableContext context) : base(context)
        {
        }
    }
}