using System.Collections.Generic;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UnderTheCork.Web.Models.ManageViewModels
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}