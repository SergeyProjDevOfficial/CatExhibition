using CatExhibition.PageModels;
using DataBaseWorkingLib.Context;

namespace CatExhibition
{
    public class ContactsModel : CustomizedPageModel
    {
        public ContactsModel(ContentTableContext context) : base(context)
        {
        }
    }
}