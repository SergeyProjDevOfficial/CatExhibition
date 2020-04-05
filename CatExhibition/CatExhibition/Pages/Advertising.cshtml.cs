using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class AdvertisingModel : CustomizedPageModel
    {
        public AdvertisingModel(ContentTableContext context) : base(context)
        {
        }
    }
}