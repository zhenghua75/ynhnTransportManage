using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ynhnTransportManage.Models;
using DXInfo.Profile;
using System.Data.Entity;
using DXInfo.Models;
using System.Web.Profile;
using System.Web.Helpers;
using System.Security.Permissions;
using Trirand.Web.Mvc;
using System.Data.Objects.SqlClient;
using System.Data;
namespace ynhnTransportManage.Controllers
{
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public IRolesService RoleService { get; set; }
        public UsersJqGridModel GridModel
        {
            get
            {
                return new UsersJqGridModel(GetUsersColumns());
            }
        }
        public DXInfo.Models.ynhnTransportManage db
        {
            get
            {
                return new DXInfo.Models.ynhnTransportManage();
            }
        }
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
            if (RoleService == null) { RoleService = new AccountRoleService(); }
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Logon");
        }
        #region Users
        private List<JQGridColumn> GetUsersColumns()
        {
            return new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "UserId", 
                                                        PrimaryKey = true,
                                                        Editable = false, Visible=false,
                                                        Width = 100 },
                                     new JQGridColumn { DataField="UserName",
                                                        Editable = false,Width=100, HeaderText="用户名",DataType=typeof(string),Searchable=true,
                                                        EditDialogFieldSuffix="(*)",
                                                        SearchType=SearchType.TextBox,
                                                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                                                        {
                                                            new RequiredValidator()                            
                                                        }
                                     },
                                     new JQGridColumn {DataField="FullName",Editable=true,Width=50, HeaderText="姓名",DataType=typeof(string),Searchable=true,
                                                        SearchType=SearchType.TextBox,
                                                        EditDialogFieldSuffix="(*)",
                                                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                                                        {
                                                            new RequiredValidator()                            
                                                        }
                                     },
                                    new JQGridColumn { DataField = "DeptId", DataType=typeof(string),SearchType=SearchType.DropDown,
                                                        EditType=EditType.DropDown,Searchable=true,
                                                        EditDialogFieldSuffix="(*)",
                                                        Editable = true,HeaderText="部门", Formatter=new CustomFormatter(){     
                                                            FormatFunction="ShowName", UnFormatFunction="UnShowName"},
                                                        Width = 100 ,SearchToolBarOperation=SearchOperation.IsEqualTo,
                                                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                                                        {
                                                            new RequiredValidator()                            
                                                        }
                                    },                                    
                                     new JQGridColumn {DataField="DeptName",Editable=false,Width=50, HeaderText="部门",DataType=typeof(string),
                                         Visible=false
                                     },
                                     new JQGridColumn { DataField = "LastActivityDate", 
                                         HeaderText="最近活动日期",
                                                        Editable = false,
                                                        Width = 100, 
                                                        DataFormatString = "{0:yyyy/MM/dd}",
                                                        Searchable = true,
                                                        DataType = typeof(DateTime),
                                                        SearchType = SearchType.DatePicker,
                                                        SearchControlID = "DatePicker",EditType=EditType.DatePicker,
                                                        
                                                        EditorControlID="DatePicker",SearchToolBarOperation=SearchOperation.IsEqualTo
                                     },
                                     new JQGridColumn {DataField="IsApproved",Editable=true,Width=100, HeaderText="是否启用",
                                                        Formatter=new CheckBoxFormatter(),DataType=typeof(bool),Searchable=true,
                                                        SearchType=SearchType.DropDown,
                                                        EditType=EditType.CheckBox,
                                                        SearchToolBarOperation=SearchOperation.IsEqualTo,
                                                        SearchList=new List<SelectListItem>()
                                                        {
                                                            new SelectListItem { Text = "所有", Value = "" },
                                                            new SelectListItem{Text="启用",Value="true"},
                                                            new SelectListItem{Text="禁用",Value="false"}
                                                        }
                                     },
                                     new JQGridColumn { DataField = "LastLoginDate", 
                                                        Editable = false,
                                                        Width = 100, 
                                                        DataFormatString = "{0:yyyy/MM/dd}", HeaderText="最近的登录日期",
                                                        DataType=typeof(DateTime),SearchType=SearchType.DatePicker,Searchable=true,
                                                        SearchControlID="DatePicker",EditType=EditType.DatePicker,
                                                        EditorControlID="DatePicker",SearchToolBarOperation=SearchOperation.IsEqualTo},
                                    new JQGridColumn { DataField = "CreateDate", 
                                                        Editable = false,
                                                        Width = 100, 
                                                        DataFormatString = "{0:yyyy/MM/dd}", HeaderText="创建日期",DataType=typeof(DateTime),SearchType=SearchType.DatePicker,Searchable=true,
                                                        SearchControlID="DatePicker",EditType=EditType.DatePicker,
                                                        EditorControlID="DatePicker",SearchToolBarOperation=SearchOperation.IsEqualTo
                                                      }                                     
                                 };
        }
        [Authorize]
        public ActionResult Users()
        {
            var gridModel = GridModel;
            var usersGrid = gridModel.Grid;
            SetUpGrid(usersGrid);
            SetUpDeptDropDown(usersGrid);
            return View(gridModel);
            
        }
        [Authorize]
        public JsonResult GridData()
        {
            var contex = db;                    
            var users = (from user in contex.aspnet_Users
                        join memberships in contex.aspnet_Membership on user.UserId equals memberships.UserId into um
                        from ms in um.DefaultIfEmpty()
                        join profile in contex.aspnet_CustomProfile on ms.UserId equals profile.UserId into uc
                        from cp in uc.DefaultIfEmpty()
                        join depts in contex.Depts on cp.DeptId equals depts.DeptId into dc
                        from d in dc.DefaultIfEmpty()
                        select new
                        {
                            user.UserId,
                            user.UserName,
                            FullName = (cp == null ? string.Empty : cp.FullName),
                            DeptId = (d==null?Guid.Empty:d.DeptId),
                            //DeptCode =(d==null?string.Empty:d.DeptCode),
                            DeptName = (d == null ? string.Empty : d.DeptName),
                            LastActivityDate=user.LastActivityDate,
                            ms.IsApproved,
                            LastLoginDate = ms.LastLoginDate,
                            CreateDate = ms.CreateDate
                        }).ToList();
            var users2 = users.Select(s=>new {s.UserId,s.UserName,s.FullName,DeptId=s.DeptId.ToString(),s.DeptName,
                LastActivityDate=Convert.ToDateTime(s.LastActivityDate.ToString("yyyy/MM/dd")),s.IsApproved
                ,LastLoginDate=Convert.ToDateTime(s.LastLoginDate.ToString("yyyy/MM/dd")),
                CreateDate=Convert.ToDateTime(s.CreateDate.ToString("yyyy/MM/dd"))});
            return GridModel.Grid.DataBind(users2.ToList().AsQueryable());
        }
        [Authorize]
        public ActionResult EditRows(UserInfoModel editedUser)
        {
            var gridModel = GridModel;
            //var context = db;
            if (gridModel.Grid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                MembershipService.UpdateUser(editedUser.UserId, editedUser.FullName, editedUser.DeptId);
                //editedUser.IsApproved = this.Request.Form["IsApproved"].Contains("true");
                MembershipService.ChangeApproval(editedUser.UserId, editedUser.IsApproved);
            }
            if (gridModel.Grid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                MembershipService.DeleteUser(editedUser.UserId);
                using(DXInfo.Models.ynhnTransportManage context = new DXInfo.Models.ynhnTransportManage())
                {
                    var cus = context.aspnet_CustomProfile.Where(w => w.UserId == editedUser.UserId);
                    if (cus.Count() > 0)
                    {
                        foreach (DXInfo.Models.aspnet_CustomProfile oldcus in cus)
                        {
                            context.aspnet_CustomProfile.Remove(oldcus);
                        }
                        context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Users","Account");
        }

        private void SetUpDeptDropDown(JQGrid ordersGrid)
        {
            // setup the grid search criteria for the columns
            JQGridColumn deptsColumn = ordersGrid.Columns.Find(c => c.DataField == "DeptId");
            
            if (ordersGrid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            {
                var context = new DXInfo.Models.ynhnTransportManage();  
                var editList = (from d in context.Depts
                               select new
                               {
                                   d.DeptName,
                                   d.DeptId
                               }).ToList();
                var list = editList.Select(s => new SelectListItem {Text=s.DeptName,Value=s.DeptId.ToString() });
                deptsColumn.EditList = list.ToList<SelectListItem>();
                deptsColumn.SearchList = list.ToList<SelectListItem>();
                deptsColumn.SearchList.Insert(0, new SelectListItem { Text = "所有", Value = "" });
            }
        }        
        private void SetUpGrid(JQGrid usersGrid)
        {
            usersGrid.DataUrl = Url.Action("GridData");
            usersGrid.EditUrl = Url.Action("EditRows");
            usersGrid.AutoWidth = true;
            usersGrid.AppearanceSettings.Caption = "管理用户";
            usersGrid.SearchDialogSettings.MultipleSearch = true;
        }
        [Authorize]
        public ActionResult ExportToExcel()
        {
            var gridModel = GridModel;
            var contex = db;
            var users = from user in contex.aspnet_Users
                        join memberships in contex.aspnet_Membership on user.UserId equals memberships.UserId into um
                        from ms in um.DefaultIfEmpty()
                        join profile in contex.aspnet_CustomProfile on ms.UserId equals profile.UserId into uc
                        from cp in uc.DefaultIfEmpty()
                        join depts in contex.Depts on cp.DeptId equals depts.DeptId into dc
                        from d in dc.DefaultIfEmpty()
                        select new
                        {
                            //user.UserId,
                            user.UserName,
                            FullName = (cp == null ? string.Empty : cp.FullName),
                            //DeptId = (d == null ? Guid.Empty : d.DeptId),
                            DeptName = (d == null ? string.Empty : d.DeptName),
                            user.LastActivityDate,
                            ms.IsApproved,
                            ms.LastLoginDate,
                            ms.CreateDate
                        };
            var grid = gridModel.Grid;
            DataTable dt = Helpers.LinqToDataTable(users);
            grid.ExportToExcel(dt);
            return View();
        }
        #endregion

        //[Authorize]
        //public ActionResult UserDetails(Guid id)
        //{
        //    MembershipUser user = MembershipService.GetUser(id);
        //    if (user == null)
        //        return RedirectToAction("Users");
        //    DXInfo.Profile.CustomProfile profile = DXInfo.Profile.CustomProfile.GetUserProfile(user.UserName);

        //    Dept dept = MembershipService.GetDept(profile.DeptId);

        //    DetailsUserModel model = new DetailsUserModel();
        //    model.Dept = dept;
        //    model.User = user;
        //    model.Profle = profile;

        //    return View(model);
        //}
        //[Authorize]
        //public ActionResult EditUser(Guid id)
        //{

        //    MembershipUser user = MembershipService.GetUser(id);
        //    if (user == null)
        //        return RedirectToAction("Users");
        //    DXInfo.Profile.CustomProfile profile = DXInfo.Profile.CustomProfile.GetUserProfile(user.UserName);

        //    EditUserModel model = new EditUserModel();
        //    model.DeptId = profile.DeptId;
        //    model.FullName = profile.FullName;
        //    model.UserName = user.UserName;

        //    return View(model);
        //}
        //[Authorize]
        //[HttpPost]
        //public ActionResult EditUser(EditUserModel model)
        //{
        //    MembershipService.UpdateUser(model.UserId, model.FullName, model.DeptId);

        //    return RedirectToAction("UserDetails", new { id = model.UserId });

        //    //return View(model);
        //}

        //public ActionResult DeleteUser(Guid id)
        //{
        //    //DXInfo.Profile.CustomProfile profile = DXInfo.Profile.CustomProfile.GetUserProfile(id);
        //    //ProfileManager.DeleteProfile(id);
        //    MembershipService.DeleteUser(id);
        //    return RedirectToAction("Users");
        //}
        // **************************************
        // URL: /Account/LogOn
        // **************************************

        #region 登录
        public ActionResult LogOn()
        {
            //if (Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                int icount = db.aspnet_Users.Count();
                if (icount == 0)
                {
                    MembershipCreateStatus createStatus = MembershipService.CreateUser("admin", "123456", "系统管理员", Guid.Empty);
                    model.UserName = "admin";
                    model.Password = "123456";
                }
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    //DXInfo.Models.ekey tk = null;
                    if (!string.IsNullOrEmpty(model.HardwareID))
                    {
                        using (DXInfo.Models.ynhnTransportManage context = new DXInfo.Models.ynhnTransportManage())
                        {
                            var key = context.ekey.Where(w => w.HardwareID == model.HardwareID).FirstOrDefault();
                            var us = context.aspnet_Users.Where(w => w.UserName == model.UserName).FirstOrDefault();
                            if (key == null)
                            {
                                DXInfo.Models.ekey tk = new ekey();
                                tk.HardwareID = model.HardwareID;
                                tk.CardNo = model.CardNo;
                                tk.CreateDate = DateTime.Now;
                                tk.IsUse = true;
                                tk.UserId = us != null ? us.UserId : Guid.Empty;
                                context.ekey.Add(tk);
                                context.SaveChanges();
                            }
                            else
                            {
                                if (!key.IsUse)
                                {
                                    ModelState.AddModelError("", "提供的用户名或密码不正确。");
                                    return View(model);
                                }
                            }
                        }
                    }
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "提供的用户名或密码不正确。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("LogOn");
        }
        #endregion

        #region 注册
        // **************************************
        // URL: /Account/Register
        // **************************************
        [Authorize]
        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.FullName,model.DeptId);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    //FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    //return RedirectToAction("Index", "Home");
                    ViewBag.PasswordLength = MembershipService.MinPasswordLength;
                    //Response.Write("<script>alert('注册用户成功');</script>");
                    //Response.Write("<script>window.location.href='" + Url.Action("Register") + "';</script>");
                    //return PartialView(model);
                    return RedirectToAction("RegisterSucess", "Account");
                    //return Json(new { Success = false, Message = "创建帐户失败：用户名或密码在错误！" },JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
            //return Json(new { Success = false, Message = "创建帐户失败：提交的数据存在错误！" });
        }
        public ActionResult RegisterSucess()
        {
            return View();
        }
        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "当前密码不正确或新密码无效。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        //public ActionResult Approved(Guid Id)
        //{
        //    MembershipService.ChangeApproval(Id, true);
        //    return RedirectToAction("Users");
        //}
        //public ActionResult NoApproved(Guid Id)
        //{
        //    MembershipService.ChangeApproval(Id, false);
        //    return RedirectToAction("Users");
        //}
        #endregion

        #region 角色
        private List<JQGridColumn> GetRolesColumns()
        {
            return new List<JQGridColumn>()
            {
                new JQGridColumn()
                {
                    DataField="RoleId",
                    Visible=false,
                    PrimaryKey=true                    
                },
                new JQGridColumn()
                {
                    DataField="RoleName",
                    HeaderText="角色名",
                    DataType=typeof(string),
                    Editable = true,
                    //EditFieldAttributes=new List<JQGridEditFieldAttribute>()
                    //{
                    //    new JQGridEditFieldAttribute()
                    //    {
                    //        Name="readonly",
                    //        Value="true"
                    //    }
                    //},
                    EditDialogFieldSuffix="(*)",
                    EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                    {
                        new RequiredValidator()                            
                    }
                },
                new JQGridColumn()
                {
                    DataField="Description",
                    HeaderText="描述",
                    DataType=typeof(string),
                    Editable=true,
                    EditDialogFieldSuffix="(*)",
                    EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                    {
                        new RequiredValidator()                            
                    }
                }
            };
        }
        [Authorize]
        public ActionResult Roles()
        {
            var rolesGridModel = new RolesJqGridModel(GetRolesColumns());
            var rolesGrid = rolesGridModel.Grid;
            SetupRolesGrid(rolesGrid);
            //var contex = db;
            //string sql = "select * from aspnet_roles";
            //var roles = contex.aspnet_Roles;
           
            return View(rolesGridModel);
        }
        public void SetupRolesGrid(JQGrid rolesGrid)
        {
            rolesGrid.DataUrl = Url.Action("RolesGridData");
            rolesGrid.EditUrl = Url.Action("EditRole");
            rolesGrid.AppearanceSettings.Caption = "管理角色";
            rolesGrid.SearchDialogSettings.MultipleSearch = true;
        }
        [Authorize]
        public JsonResult RolesGridData()
        {
            var contex = db;
            var rolesGridModel = new RolesJqGridModel(GetRolesColumns());
            SetupRolesGrid(rolesGridModel.Grid);
            //var rolesGrid = rolesGridModel.Grid;
            var roles = contex.aspnet_Roles;
            return rolesGridModel.Grid.DataBind(roles);
        }
        [Authorize]
        public ActionResult EditRole(aspnet_Role role)
        {
            var rolesGridModel = new RolesJqGridModel(GetRolesColumns());
            if (rolesGridModel.Grid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                RoleService.Create(role.RoleName, role.Description);
                
            }
            if (rolesGridModel.Grid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {                
                using (var contex = db)
                {
                    aspnet_Role roleold = contex.aspnet_Roles.FirstOrDefault(r => r.RoleId == role.RoleId);
                    //roleold.RoleName = role.RoleName;
                    roleold.Description = role.Description;
                    //roleold.LoweredRoleName = role.RoleName.ToLower();
                    contex.SaveChanges();
                }
            }
            if (rolesGridModel.Grid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                RoleService.Delete(role.RoleId);
            }
            return RedirectToAction("Roles", "Account");
        }
        [Authorize]
        public ActionResult RolesExportToExcel()
        {
            var rolesGridModel = new RolesJqGridModel(GetRolesColumns());
            var contex = db;
            var roles = contex.aspnet_Roles.Select(s => new {s.RoleName,s.Description });
            DataTable dt = Helpers.LinqToDataTable(roles);
            rolesGridModel.Grid.ExportToExcel(dt);
            return View();
        }
        //[Authorize]
        //public ActionResult EditRole(Guid Id)
        //{
        //    DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
        //    var role = contex.aspnet_Roles.FirstOrDefault(r=>r.RoleId==Id);
        //    RoleInfoModel rinfo = new RoleInfoModel();
        //    rinfo.RoleId = role.RoleId;
        //    rinfo.RoleName = role.RoleName;
        //    rinfo.Description = role.Description;
        //    return View(rinfo);
        //}
        //[Authorize]
        //[HttpPost]
        //public ActionResult EditRole(RoleInfoModel model)
        //{
        //    using (DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage())
        //    {
        //        aspnet_Role role = contex.aspnet_Roles.FirstOrDefault(r => r.RoleId == model.RoleId);
        //        role.RoleName = model.RoleName;
        //        role.Description = model.Description;
        //        role.LoweredRoleName = model.RoleName.ToLower();
        //        contex.SaveChanges();
        //    }
        //    return RedirectToAction("Roles");
        //}
        //public ActionResult DeleteRole(Guid id)
        //{
        //    //using (DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage())
        //    //{
        //    //    aspnet_Role role = contex.aspnet_Roles.FirstOrDefault(r => r.RoleId == RoleId);
        //    //    contex.aspnet_Roles.Remove(role);

        //    //    contex.SaveChanges();
        //    //}
        //    RoleService.Delete(id);
        //    return RedirectToAction("Roles");
        //}
        [Authorize]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddRole(RoleInfoModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                RoleService.Create(model.RoleName, model.Description);
                return RedirectToAction("Roles", "Account");
            }
            return View(model);
        }
        #endregion


        private ActionResult DisplayRolesOfUser(Guid id)
        {
            MembershipUser user = MembershipService.GetUser(id);
            if (user == null)
            {
                ModelState.AddModelError("", "未能找到用户信息");
                return View();
            }
            DXInfo.Profile.CustomProfile profile = DXInfo.Profile.CustomProfile.GetUserProfile(user.UserName);
            if (profile == null)
            {
                ModelState.AddModelError("", "未能找到配置信息");
                return View();
            }
            Dept dept = MembershipService.GetDept(profile.DeptId);
            if (dept == null)
            {
                ModelState.AddModelError("", "未能找到部门信息");
                return View();
            }

            AddUserToRolesModel model = new AddUserToRolesModel();
            model.UserId = Guid.Parse(user.ProviderUserKey.ToString());
            model.UserName = user.UserName;
            model.FullName = profile.FullName;
            model.DeptName = profile.DeptName;

            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            string sql = string.Format(@"select a.RoleId,a.RoleName,a.Description,case when b.UserId is null then CONVERT(bit,0) else CONVERT(bit,1) end as IsInRole from aspnet_Roles a
left join (select * from aspnet_UsersInRoles where UserId='{0}') b on a.RoleId=b.RoleId", id.ToString());

            var roles = contex.Database.SqlQuery<RolesInfoModel>(sql).ToList();

            model.Roles = roles.AsEnumerable<RolesInfoModel>();
            return View("AddUserToRole",model);
        }
        
        [Authorize]
        public ActionResult AddToRole(Guid userId, string roleName)
        {
            //foreach (string roleName in model.Roles2)
            //{
            //    if (!RoleService.IsInRole(model.UserName, roleName))
            //    {
            //        RoleService.AddToRole(model.UserName, roleName);
            //        //RoleService.AddToRole(model.UserName, model.Roles2.ToArray());
            //    }
            //}
            //RoleService.RemoveFromRole
            MembershipUser user = MembershipService.GetUser(userId);
            RoleService.AddToRole(user, roleName);
            //return View("AddUserToRole",);      
            //return DisplayRolesOfUser(userId);
            return RedirectToAction("AddUserToRole", new { id = userId });

        }
        [Authorize]
        public ActionResult DeleteUserFromRole(Guid userId, string roleName)
        {
            MembershipUser user = MembershipService.GetUser(userId);
            RoleService.RemoveFromRole(user, roleName);
            //return View("AddUserToRole");
            //return DisplayRolesOfUser(userId);
            return RedirectToAction("AddUserToRole", new { id = userId });
        }

        [Authorize]
        public ActionResult ForRoleAddUser(Guid roleId)
        {
            return DisplayUsersOfRole(roleId);
        }

        private ActionResult DisplayUsersOfRole(Guid roleId)
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            //string sql = "select * from aspnet_roles where roleId='"+roleId.ToString()+"'";
            //var roles = contex.Database.SqlQuery<RoleInfoModel>(sql).ToList();
            var role = contex.aspnet_Roles.FirstOrDefault<aspnet_Role>(r => r.RoleId == roleId);
            string sql = string.Format(@"select a.UserId,a.UserName,b.FullName,c.DeptName ,a.LastActivityDate,d.IsApproved,d.LastLoginDate,d.CreateDate,
case when e.RoleId is null then CONVERT(bit,0) else CONVERT(bit,1) end as IsInRole
from aspnet_Users a
left join aspnet_Membership d on a.UserId=d.UserId
left join aspnet_CustomProfile b on a.UserId=b.UserId
left join Depts c on b.DeptId=c.DeptId
left join (select * from aspnet_UsersInRoles where RoleId='{0}') e on a.UserId=e.UserId
left join aspnet_Roles f on e.RoleId=f.RoleId
order by a.LastActivityDate desc",roleId.ToString());

            var users = contex.Database.SqlQuery<UserInfoForRoleModel>(sql).ToList();

            ForRoleAddUserModel ru = new ForRoleAddUserModel();
            ru.RoleId = role.RoleId;
            ru.RoleName = role.RoleName;
            ru.Description = role.Description;

            ru.Users = users;
            
            return View("ForRoleAddUser",ru);
        }

        [Authorize]
        public ActionResult AddToRole2(Guid userId,Guid roleId, string roleName)
        {
            MembershipUser user = MembershipService.GetUser(userId);
            RoleService.AddToRole(user, roleName);
            return RedirectToAction("ForRoleAddUser", new { roleId = roleId });
            //return DisplayUsersOfRole(roleId);

        }
        [Authorize]        
        public ActionResult DeleteUserFromRole2(Guid userId,Guid roleId, string roleName)
        {
            MembershipUser user = MembershipService.GetUser(userId);
            RoleService.RemoveFromRole(user, roleName);
            //return DisplayUsersOfRole(roleId);
            return RedirectToAction("ForRoleAddUser", new { roleId = roleId });
        }
        public ActionResult RolesList()
        {
            DXInfo.Models.ynhnTransportManage db = new DXInfo.Models.ynhnTransportManage();
            var roles = from r in db.aspnet_Roles select r;
            return PartialView(roles);
        }
        public ActionResult SitemapsList()
        {
            
            DXInfo.Models.ynhnTransportManage db = new DXInfo.Models.ynhnTransportManage();
            var sitemaps = from r in db.aspnet_Sitemaps where r.IsAuthorize==true select r;
            return PartialView(sitemaps);
        }
        #region 权限
        [Authorize]
        public ActionResult AuthorizationRule()
        {
            var authGridModel = new AuthorizationGridModel();
            SetUpAuthGridModel(authGridModel);
            return View(authGridModel);
        }
        private void SetUpAuthGridModel(AuthorizationGridModel authorizationGridModel)
        {
            var authorizationGrid = authorizationGridModel.AuthorizationGrid;
            var roleGrid = authorizationGridModel.RolesGrid;

            authorizationGrid.DataUrl = Url.Action("AuthorizationRuleOfAuth_RequestData");
            authorizationGrid.EditUrl = Url.Action("AuthorizationRuleOfAuth_EditData");
            authorizationGrid.SearchDialogSettings.MultipleSearch = true;
            //authorizationGrid.Columns.Insert(0, new JQGridColumn
            //{
            //    Sortable=false,
            //    Fixed = true,
            //    EditActionIconsColumn = true
            //});
            authorizationGrid.ToolBarSettings.ShowEditButton = true;
            JQGridColumn isInRoleColumn = authorizationGrid.Columns.Find(c => c.DataField == "IsInRole");

            isInRoleColumn.Formatter = new CheckBoxFormatter();
            isInRoleColumn.SearchType = SearchType.DropDown;
            if (authorizationGrid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            {
                isInRoleColumn.SearchList = new List<SelectListItem>()
                        {
                            new SelectListItem { Text = "所有", Value = "" },
                            new SelectListItem{Text="选择",Value="true"},
                            new SelectListItem{Text="未选择",Value="false"}
                        };
            }
            isInRoleColumn.EditType = EditType.CheckBox;

            roleGrid.DataUrl = Url.Action("AuthorizationRuleOfRole_RequestData");
            roleGrid.ID = "RolesGrid";
            roleGrid.HierarchySettings.HierarchyMode = HierarchyMode.Parent;
            roleGrid.AppearanceSettings.Caption = "权限";
            roleGrid.ClientSideEvents.SubGridRowExpanded = "showAuthsSubGrid";
            roleGrid.SearchDialogSettings.MultipleSearch = true;
            authorizationGrid.HierarchySettings.HierarchyMode = HierarchyMode.Child;
            
            authorizationGrid.ID = "AuthorizationGrid";

        }
        private void SetUpRoleAssignGridModel(RoleAssignGridModel gridModel)
        {
            var usersGrid = gridModel.UsersGrid;
            var rolesGrid = gridModel.RolesGrid;

            rolesGrid.AppearanceSettings.Caption = "角色分配";
            usersGrid.DataUrl = Url.Action("RoleAssignOfUser_RequestData");
            usersGrid.EditUrl = Url.Action("RoleAssignOfUser_EditData");
            usersGrid.SearchDialogSettings.MultipleSearch = true;

            rolesGrid.DataUrl = Url.Action("RoleAssignOfRole_RequestData");
            rolesGrid.SearchDialogSettings.MultipleSearch = true;
        }
        public JsonResult AuthorizationRuleOfRole_RequestData()
        {
            var authGridModel = new AuthorizationGridModel();
            SetUpAuthGridModel(authGridModel);
            var context = db;
            var roles = context.aspnet_Roles;
            return authGridModel.RolesGrid.DataBind(roles);
        }
        #endregion
        public ActionResult RoleAssign()
        {
            var gridModel = new RoleAssignGridModel();
            SetUpRoleAssignGridModel(gridModel);
            return View(gridModel);
        }
        public JsonResult RoleAssignOfRole_RequestData()
        {
            var gridModel = new RoleAssignGridModel();
            SetUpRoleAssignGridModel(gridModel);
            var context = db;
            var roles = context.aspnet_Roles;
            return gridModel.RolesGrid.DataBind(roles);
        }
        public JsonResult RoleAssignOfUser_RequestData(string ParentRowId)
        {
            //ParentRowId=HttpUtility.HtmlDecode(ParentRowId);
            var gridModel = new RoleAssignGridModel();
            SetUpRoleAssignGridModel(gridModel);
            var contex = db;
            //if (!ParentRowId.HasValue)
            //{
            //    var users = from user in contex.aspnet_Users
            //                join memberships in contex.aspnet_Membership on user.UserId equals memberships.UserId into um
            //                from ms in um.DefaultIfEmpty()
            //                join profile in contex.aspnet_CustomProfile on ms.UserId equals profile.UserId into uc
            //                from cp in uc.DefaultIfEmpty()
            //                join depts in contex.Depts on cp.DeptId equals depts.DeptId into dc
            //                from d in dc.DefaultIfEmpty()
            //                select new
            //                {
            //                    IsInRole = false,
            //                    user.UserId,
            //                    user.UserName,
            //                    FullName = (cp == null ? string.Empty : cp.FullName),
            //                    DeptName = (d == null ? string.Empty : d.DeptName),
            //                };
            //    return gridModel.UsersGrid.DataBind(users);
            //}
            //else
            //{
            Guid rid = Guid.Parse(ParentRowId);
            var oldrole = contex.aspnet_Roles.Where(w => w.RoleId == rid).FirstOrDefault();
                var users = from user in contex.aspnet_Users
                            //join memberships in contex.aspnet_Membership on user.UserId equals memberships.UserId into um
                            //from ms in um.DefaultIfEmpty()
                            join profile in contex.aspnet_CustomProfile on user.UserId equals profile.UserId into uc
                            from cp in uc.DefaultIfEmpty()
                            join depts in contex.Depts on cp.DeptId equals depts.DeptId into dc
                            from d in dc.DefaultIfEmpty()
                            join auth in contex.aspnet_UsersInRoles.Where(s=>s.RoleId==oldrole.RoleId) on user.UserId equals auth.UserId into ua
                            from a in ua.DefaultIfEmpty()
                            join role in contex.aspnet_Roles on a.RoleId equals role.RoleId into ra
                            from ras in ra.DefaultIfEmpty()
                            select new
                            {
                                IsInRole = (ras== null ? false : true),
                                user.UserId,
                                user.UserName,
                                FullName = (cp == null ? string.Empty : cp.FullName),
                                DeptName = (d == null ? string.Empty : d.DeptName),
                            };

                return gridModel.UsersGrid.DataBind(users);
           // }
        }

        public ActionResult RoleAssignOfUser_EditData(string ParentRowId,Guid UserId,bool? IsInRole)
        {
            bool isInRole = IsInRole.HasValue?IsInRole.Value:true;
            Guid rid = Guid.Parse(ParentRowId);

            var r = db.aspnet_Roles.Where(w => w.RoleId == rid).FirstOrDefault();
            if (isInRole)
            {
                MembershipUser user = MembershipService.GetUser(UserId);
                RoleService.AddToRole(user, r.RoleName);
                
            }
            else
            {
                MembershipUser user = MembershipService.GetUser(UserId);
                RoleService.RemoveFromRole(user, r.RoleName);
            }
            return RedirectToAction("RoleAssign");
        }
        public JsonResult AuthorizationRuleOfAuth_RequestData(Guid parentRowID)
        {

            var authGridModel = new AuthorizationGridModel();
            SetUpAuthGridModel(authGridModel);
            //SetupRoelGridModel(authGridModel.RolesGrid);
            var context = db;
            //if (!string.IsNullOrEmpty(parentRowID))
            //{
                var auths = from s in context.aspnet_Sitemaps.Where(w => w.Code != "000" && w.IsAuthorize==true)
                            join a in context.aspnet_AuthorizationRules.Where(w => w.RoleId == parentRowID) on s.Code equals a.SiteMapKey into sa
                            from auth in sa.DefaultIfEmpty()
                            //where auth.RoleName == RoleName
                            select new
                            {
                                //EditActions=false,
                                IsInRole = (auth == null ? false : true),
                                Code=s.Code,
                                s.Title
                                //RoleName = parentRowID
                            };
                return authGridModel.AuthorizationGrid.DataBind(auths);
            //}
            //else
            //{
            //    var auths = context.aspnet_Sitemaps.Select(s => new { IsInRole = false, Code = s.Code, Title = s.Title, RoleName = "" })
            //   .Where(w => w.Code != "000");
            //    return authGridModel.AuthorizationGrid.DataBind(auths);
            //}
        }
        //
        public ActionResult AuthorizationRuleOfAuth_EditData(Guid ParentRowId,string Code,bool? IsInRole)
        {
            //if (sitemap.RoleName == "") return View();
            bool isInRole =IsInRole.HasValue?IsInRole.Value:true;
            using (var context = db)
            {
                var ruleold = context.aspnet_AuthorizationRules.Where(s=>s.RoleId==ParentRowId && s.SiteMapKey==Code).FirstOrDefault();
                if (ruleold != null)
                {
                    if (!isInRole) context.aspnet_AuthorizationRules.Remove(ruleold);
                }
                else
                {
                    if (isInRole)
                    {
                        aspnet_AuthorizationRule rule = new aspnet_AuthorizationRule();
                        rule.RuleId = Guid.NewGuid();
                        rule.RoleId = ParentRowId;//sitemap.RoleName;
                        rule.SiteMapKey = Code;//sitemap.Code;

                        context.aspnet_AuthorizationRules.Add(rule);
                    }
                }
                context.SaveChanges();
            }
            return RedirectToAction("AuthorizationRule");
        }
        //[Authorize]
        //public ActionResult AddAuthorizationRule()
        //{
        //    return View();
        //}
        //[Authorize]
        //public ActionResult DeleteAuthorizationRule()
        //{
        //    return View();
        //}
    }
}
