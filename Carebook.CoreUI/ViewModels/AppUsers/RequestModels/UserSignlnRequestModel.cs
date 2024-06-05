namespace Carebook.CoreUI.ViewModels.AppUsers.RequestModels
{
    public class UserSignlnRequestModel:IRegisterSignlnSpec
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
