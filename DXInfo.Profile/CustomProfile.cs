using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.Security;
using DXInfo.Models;

namespace DXInfo.Profile
{
    public class CustomProfile : ProfileBase
    {
        [SettingsAllowAnonymous(false)]
        [CustomProviderData("DeptId;uniqueidentifier")]
        public Guid DeptId
        {
            get { return (Guid)this.GetPropertyValue("DeptId"); }
            set { this.SetPropertyValue("DeptId", value); }
        }

        [SettingsAllowAnonymous(false)]        
        public string DeptCode
        {
            get { return (string)this.GetPropertyValue("DeptCode"); }
            set { this.SetPropertyValue("DeptCode", value); }
        }

        [SettingsAllowAnonymous(false)]
        public string DeptName
        {
            get { return (string)this.GetPropertyValue("DeptName"); }
            set { this.SetPropertyValue("DeptName", value); }
        }

        [SettingsAllowAnonymous(false)]
        [CustomProviderData("FullName;nvarchar")]
        public string FullName
        {
            get { return (string)this.GetPropertyValue("FullName"); }
            set { this.SetPropertyValue("FullName", value); }
        }

        public static CustomProfile GetUserProfile(string username)
        {
            CustomProfile customProfile = Create(username) as CustomProfile;
            ynhnTransportManage contex = new ynhnTransportManage();
            if(customProfile.DeptId!=Guid.Empty)
            {
                Dept dept = contex.Depts.FirstOrDefault<Dept>(d => d.DeptId == customProfile.DeptId);
                if (dept != null)
                {
                    customProfile.DeptCode = dept.DeptCode;
                    customProfile.DeptName = dept.DeptName;
                }
            }
            return customProfile;
        }
        
        public static CustomProfile GetUserProfile()
        {
            MembershipUser u = Membership.GetUser();
            string username = "";
            if(u!=null)
            {
                username = u.UserName;
            }
            CustomProfile customProfile = Create(username) as CustomProfile;
            ynhnTransportManage contex = new ynhnTransportManage();
            if(customProfile.DeptId!=Guid.Empty)
            {
                Dept dept = contex.Depts.FirstOrDefault<Dept>(d => d.DeptId == customProfile.DeptId);
                if (dept != null)
                {
                    customProfile.DeptCode = dept.DeptCode;
                    customProfile.DeptName = dept.DeptName;
                }
            }
            return customProfile;
        }

    }
}
