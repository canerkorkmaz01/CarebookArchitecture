using Carebook.CoreUI.Areas.Admin.Models.AppRoles.ResponseModel;

namespace Carebook.CoreUI.Areas.Admin.Models.AppRoles.PageVms
{
    public class AssignRolePageVM
    {
        public int UserID { get; set; }
        public List<AppRoleResponseModel> Roles { get; set; }
    }
}
