using Microsoft.AspNetCore.Identity;

namespace Carebook.Business.Sys
{
    public class MvcStoreIdentityErrorDescriber: IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "TooShort", Description = $"Parolanız en az {length} karakter olmalıdır!" };
        }
    }
}
