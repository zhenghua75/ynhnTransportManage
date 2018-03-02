using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ynhnTransportManage.Models;
using Trirand.Web.Mvc;
using System.Web.Security;

namespace ynhnTransportManage.Controllers
{
    public class BaseInfoController : Controller
    {
        //
        // GET: /BaseInfo/
        private DXInfo.Models.ynhnTransportManage db = new DXInfo.Models.ynhnTransportManage();
        public ActionResult Index()
        {
            return View();
        }
        #region 参数设置
        public ActionResult Para()
        {
            var gridModel = new ParaGridModel();
            SetupParaGridModel(gridModel.ParasGrid);
            return View(gridModel);
        }
        private void SetupParaGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Para_RequestData");
            grid.EditUrl = Url.Action("Para_EditData");
            grid.SearchDialogSettings.MultipleSearch = true;
            JQGridColumn typeColumn = grid.Columns.Find(c => c.DataField == "Type");

            //typeColumn.Formatter = new CheckBoxFormatter();
            typeColumn.SearchType = SearchType.DropDown;
            if (grid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            {
                List<SelectListItem> litem = new List<SelectListItem>()
                        {
                             new SelectListItem { Text = "所有", Value = "" },
                            new SelectListItem{Text="部门编码长度",Value="DeptCodeLength"},//DeptCodeLength
                            new SelectListItem{Text="结算方式",Value="BalanceType"}//BalanceType
                        };
                typeColumn.EditList = litem;
                //litem.Insert(0, new SelectListItem { Text = "所有", Value = "" });
                typeColumn.SearchList = litem;
                
            }
            typeColumn.EditType = EditType.DropDown;
        }
        public ActionResult Para_RequestData(Guid? id)
        {
            List<DXInfo.Models.NameCode> ncs=null;
            if (id.HasValue)
            {
                ncs = db.NameCode.Where(w => w.ID == id).ToList();
            }
            else
            {
                ncs = db.NameCode.ToList();
            }
            var gridModel = new ParaGridModel();
            SetupParaGridModel(gridModel.ParasGrid);
            return gridModel.ParasGrid.DataBind(ncs.AsQueryable());
        }
        public ActionResult Para_EditData(DXInfo.Models.NameCode nc)
        {
            var gridModel = new ParaGridModel();
            SetupParaGridModel(gridModel.ParasGrid);
            if (gridModel.ParasGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                using (var context = db)
                {
                    nc.ID = Guid.NewGuid();

                    if (nc.Type == "DeptCodeLength")
                    {
                        //DeptCodeLength
                        var n = context.NameCode.Where(w => w.Type == "DeptCodeLength").FirstOrDefault();
                        if(n!=null)
                        {
                            return gridModel.ParasGrid.ShowEditValidationMessage("部门编码长度记录只能有一条");
                        }
                    }
                    context.NameCode.Add(nc);
                    context.SaveChanges();
                }
            }
            if (gridModel.ParasGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldnc = context.NameCode.Where(w => w.ID == nc.ID).FirstOrDefault();
                    oldnc.Code = nc.Code;
                    oldnc.Name = nc.Name;
                    oldnc.Value = nc.Value;
                    oldnc.Comment = nc.Comment;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Para");
        }
        #endregion
        #region 组织机构
        [Authorize]
        public ActionResult Dept()
        {
            var deptModel = new DeptJqGridModel();
            SetupDeptJqGridModel(deptModel.DeptsGrid);
            return View(deptModel);
        }
        private void SetupDeptJqGridModel(JQGrid grid)
        {
            grid.SortSettings.InitialSortColumn = "DeptCode";
            grid.SortSettings.InitialSortDirection = SortDirection.Asc;
            grid.DataUrl = Url.Action("Dept_RequestData");
            grid.EditUrl = Url.Action("Dept_EditData");
            grid.SearchDialogSettings.MultipleSearch = true;
            
        }
        private List<DXInfo.Models.Dept> GetDept(Guid? deptId)
        {
            if (deptId.HasValue)
            {
                return db.Depts.Where(s => s.ParentDeptId == deptId.Value).OrderBy(o => o.DeptCode).ToList();
            }
            else
            {
                return db.Depts.OrderBy(o=>o.DeptCode).ToList();
                             //select new
                             //{
                             //    d.DeptId,
                             //    //ParentDeptId?=(d.ParentDeptId==null)?Guid.Empty:d.ParentDeptId, 
                             //    d.ParentDeptId,
                             //    d.DeptCode,
                             //    d.DeptName,
                             //    d.Address,
                             //    d.Comment
                             //    //level=(d.ParentDeptId==null)?0:1,
                             //    //isLeaf=(d.ParentDeptId==null)?false:true,
                             //    //expanded=false,
                             //    //icon=""
                             //}).ToList();
            }
        }
        [Authorize]
        public ActionResult Dept_RequestData(Guid? nodeid, int? n_level)
        {
            //Guid? deptID = nodeid;
            int level = n_level.HasValue ? (int)n_level + 1 : 0;

            //获取叶节点
            var leaf = (from d in db.Depts
                       join dd in db.Depts on d.DeptId equals dd.ParentDeptId into temp
                       from dleaf in temp.DefaultIfEmpty()     
                       where dleaf.DeptId==null
                       select d.DeptId).ToList();
            List<DXInfo.Models.Dept> depts = null;
            if (nodeid.HasValue)
            {
                depts = db.Depts.Where(w => w.ParentDeptId == nodeid.Value).OrderBy(o=>o.DeptCode).ToList();
            }
            else
            {
                depts = db.Depts.OrderBy(o => o.DeptCode).ToList();
            }

            var nc = db.NameCode.Where(w => w.Type == "DeptCodeLength").FirstOrDefault();
            int deptCodeLength = 3;
            if (nc != null)
            {
                deptCodeLength = Convert.ToInt32(nc.Value);
            }

            var ldepts = from d in depts
                         select new
                         {
                             d.DeptId,d.ParentDeptId,d.DeptCode,d.DeptName,d.Address,d.Comment,
                             level=d.DeptCode.Length /deptCodeLength-1,
                             parent_id=(d.ParentDeptId.HasValue)?d.ParentDeptId.Value.ToString():"",
                             isLeaf=leaf.Contains(d.DeptId)?"true":"false",
                             expanded="false"                             
                         };
            var deptModel = new DeptJqGridModel();
            SetupDeptJqGridModel(deptModel.DeptsGrid);
            
            //var depts = GetDept(nodeid);
            //JsonResult json = new JsonResult();
            //json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            
            //json.Data = new
            //{
            //    page = 1,
            //    total = 1,
            //    records = depts.Count,
            //    rows = (from dept in depts 
            //            select new
            //            {
            //                cell = new string[] {
            //                dept.DeptId.ToString(),
            //                dept.ParentDeptId != null ? dept.ParentDeptId.ToString() : "",
            //                dept.DeptCode,
            //                dept.DeptName,
            //                dept.Address,
            //                dept.Comment,
            //               (dept.DeptCode.Length/3-1).ToString(),//level
            //                (dept.ParentDeptId.HasValue)?dept.ParentDeptId.Value.ToString():"null",//parent_id
            //                (dept.ParentDeptId==null)?"false":"true",//isLeaf
            //                "false"//expanded
            //            }
            //            })
            //};

            //return json;

            //List<JQTreeNode> ltn = new List<JQTreeNode>();
            //foreach(DXInfo.Models.Dept d in depts)
            //{
            //    JQTreeNode tn = new JQTreeNode();
            //    tn.Text = d.DeptName;
            //    tn.Value = d.DeptId.ToString();
            //}
            //deptModel.DeptsGrid.PagerSettings.PageSize = ldepts.Count();                
            return deptModel.DeptsGrid.DataBind(ldepts.OrderBy(o=>o.level).OrderBy(o=>o.DeptCode).ToList().AsQueryable());

        }        
        public ActionResult Dept_EditData(Guid? nodeid, int? n_level, Guid? parent_id, DXInfo.Models.Dept dept)
        {
            var deptModel = new DeptJqGridModel();
            SetupDeptJqGridModel(deptModel.DeptsGrid);
            //部门编码长度
            var nc = db.NameCode.Where(w => w.Type == "DeptCodeLength").FirstOrDefault();
            int deptCodeLength = 3;
            if (nc != null)
            {
                deptCodeLength = Convert.ToInt32(nc.Value);
            }
            if (dept.DeptCode.Length % deptCodeLength != 0)
            {
                return deptModel.DeptsGrid.ShowEditValidationMessage("部门编码长度不正确！");
            }
            
            if (deptModel.DeptsGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var contex = db)
                {
                    var olddept = contex.Depts.Where(w => w.DeptId == dept.DeptId).FirstOrDefault();
                    if (olddept.DeptCode != dept.DeptCode) return deptModel.DeptsGrid.ShowEditValidationMessage("部门编码不能修改！");
                    //olddept.DeptCode = dept.DeptCode;
                    olddept.DeptName = dept.DeptName;
                    olddept.Comment = dept.Comment;
                    olddept.Address = dept.Address;
                    contex.SaveChanges();
                }
            }
            if (deptModel.DeptsGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                var d = db.Depts.Where(w => w.DeptCode == dept.DeptCode).FirstOrDefault();
                if (d != null)
                {
                    return deptModel.DeptsGrid.ShowEditValidationMessage("部门编码已存在！");
                }
                //if (dept.DeptCode.Length == deptCodeLength)
                //{
                //    var d3 = db.Depts.Where(w => w.ParentDeptId == null).FirstOrDefault();
                //    if (d3 != null)
                //    {
                //        return deptModel.DeptsGrid.ShowEditValidationMessage("顶级部门已存在！");
                //    }
                //}
                if (dept.DeptCode.Length > deptCodeLength)
                {
                    string strParentDeptCode = dept.DeptCode.Substring(0, dept.DeptCode.Length - deptCodeLength);
                    var d2 = db.Depts.Where(w => w.DeptCode == strParentDeptCode).FirstOrDefault();
                    if (d2 == null) return deptModel.DeptsGrid.ShowEditValidationMessage("上级部门编码"+strParentDeptCode+"不存在！");
                    parent_id = d2.DeptId;
                }
                using (var context = db)
                {

                    DXInfo.Models.Dept newdept = new DXInfo.Models.Dept();
                    newdept.DeptId = Guid.NewGuid();
                    newdept.ParentDeptId = parent_id;
                    newdept.DeptCode = dept.DeptCode;
                    newdept.DeptName = dept.DeptName;
                    newdept.Address = dept.Address;
                    newdept.Comment = dept.Comment;
                    context.Depts.Add(newdept);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Dept");
        }
        #endregion
        #region 车辆信息
        private void SetupVehicleGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Vehicle_RequestData");
            grid.EditUrl = Url.Action("Vehicle_EditData");
            

            //JQGridColumn driverColumn = grid.Columns.Find(c => c.DataField == "Driver");

            //driverColumn.Formatter = new CustomFormatter()
            //{
            //    FormatFunction = "ShowName",
            //    UnFormatFunction = "UnShowName"
            //};
            //driverColumn.EditType = EditType.DropDown;
            //driverColumn.SearchType = SearchType.DropDown;
            //if (grid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            //{
            //    var editList = (from u in db.Drivers
            //                    select new
            //                    {
            //                        u.Id,
            //                        u.Name
            //                    }).ToList();
            //    var list = editList.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            //    driverColumn.EditList = list.ToList<SelectListItem>();
            //    driverColumn.SearchList = list.ToList<SelectListItem>();
            //    driverColumn.SearchList.Insert(0, new SelectListItem { Text = "所有", Value = "" });
            //}
        }
        public ActionResult Vehicle()
        {
            var gridModel = new VehicleGridModel();
            SetupVehicleGridModel(gridModel.VehicleGrid);
            return View(gridModel);
        }
        public ActionResult Vehicle_RequestData()
        {
            var gridModel = new VehicleGridModel();
            SetupVehicleGridModel(gridModel.VehicleGrid);
            var vehicles =
                (from v in db.Vehicles
                //join d in db.Drivers on v.Driver equals d.Id into vd
                //from veh in vd.DefaultIfEmpty()
                select new
                {
                    v.Id,
                    v.PlateNo,
                    v.MotorNo,
                    v.BrandModel,
                    v.Comment,
                    v.OwnerName
                }).ToList();
            var veh2 = vehicles.Select(s => new { s.Id, s.PlateNo, s.BrandModel, s.MotorNo, s.OwnerName,s.Comment });
            return gridModel.VehicleGrid.DataBind(veh2.ToList().AsQueryable());
        }
        public ActionResult Vehicle_EditData(DXInfo.Models.Vehicle vehicle)
        {
            var gridModel = new VehicleGridModel();
            if (gridModel.VehicleGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                var v = db.Vehicles.Where(w => w.PlateNo == vehicle.PlateNo).FirstOrDefault();
                if (v != null)
                    return gridModel.VehicleGrid.ShowEditValidationMessage("车牌号已存在");
                using (var context = db)
                {
                    vehicle.Id = Guid.NewGuid();
                    context.Vehicles.Add(vehicle);
                    context.SaveChanges();
                }
            }
            if (gridModel.VehicleGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldvehicle = context.Vehicles.Where(w => w.Id == vehicle.Id).FirstOrDefault();
                    if (oldvehicle.PlateNo != vehicle.PlateNo)
                    {
                        var v = db.Vehicles.Where(w => w.PlateNo == vehicle.PlateNo).FirstOrDefault();
                        if (v != null)
                            return gridModel.VehicleGrid.ShowEditValidationMessage("车牌号已存在");
                    }
                    oldvehicle.PlateNo = vehicle.PlateNo;
                    oldvehicle.BrandModel = vehicle.BrandModel;
                    oldvehicle.MotorNo = vehicle.MotorNo;
                    oldvehicle.Comment = vehicle.Comment;
                    //oldvehicle.OwnerName = vehicle.OwnerName;
                    //oldvehicle.OwnerIdCardNo = vehicle.OwnerIdCardNo;
                    //oldvehicle.OwnerDriverNo = vehicle.OwnerDriverNo;
                    oldvehicle.OwnerName = vehicle.OwnerName;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Vehicle");
        }
        #endregion
        #region 车主信息
        private void SetupDriversGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Driver_RequestData");
            grid.EditUrl = Url.Action("Driver_EditData");
        }
        public ActionResult Driver()
        {
            var gridModel = new DriversGridModel();
            SetupDriversGridModel(gridModel.DriversGrid);
            return View(gridModel);
        }
        public ActionResult Driver_RequestData()
        {
            var gridModel = new DriversGridModel();
            SetupDriversGridModel(gridModel.DriversGrid);

            var drivers = db.Drivers.ToList();
            return gridModel.DriversGrid.DataBind(drivers.AsQueryable());
        }
        public ActionResult Driver_EditData(DXInfo.Models.Driver driver)
        {
            var gridModel = new DriversGridModel();
            SetupDriversGridModel(gridModel.DriversGrid);

            if (gridModel.DriversGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                using (var contex = db)
                {
                    driver.Id = Guid.NewGuid();
                    contex.Drivers.Add(driver);
                    contex.SaveChanges();
                }
            }
            if (gridModel.DriversGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var contex = db)
                {
                    var olddriver = contex.Drivers.Where(w => w.Id == driver.Id).FirstOrDefault();
                    olddriver.Code = driver.Code;
                    olddriver.Name = driver.Name;
                    olddriver.DriverNo = driver.DriverNo;
                    olddriver.Telephone = driver.Telephone;
                    olddriver.Address = driver.Address;
                    olddriver.IdCardNo = driver.IdCardNo;
                    olddriver.Comment = driver.Comment;
                    contex.SaveChanges();
                }
            }
            return RedirectToAction("Driver");
        }
        #endregion
        #region 计量单位
        private void SetupUnitsGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Unit_RequestData");
            grid.EditUrl = Url.Action("Unit_EditData");
        }
        public ActionResult UnitOfMeasure()
        {
            var gridModel = new UnitOfMeasuresGridModel();
            SetupUnitsGridModel(gridModel.UnitOfMeasuresGrid);
            return View(gridModel);
        }
        public ActionResult Unit_RequestData()
        {
            var gridModel = new UnitOfMeasuresGridModel();
            SetupUnitsGridModel(gridModel.UnitOfMeasuresGrid);

            var units = db.UnitOfMeasures.ToList();
            return gridModel.UnitOfMeasuresGrid.DataBind(units.AsQueryable());
        }
        public ActionResult Unit_EditData(DXInfo.Models.UnitOfMeasure unit)
        {
            var gridModel = new UnitOfMeasuresGridModel();
            SetupUnitsGridModel(gridModel.UnitOfMeasuresGrid);

            if (gridModel.UnitOfMeasuresGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                using (var context = db)
                {
                    unit.Id = Guid.NewGuid();
                    context.UnitOfMeasures.Add(unit);
                    context.SaveChanges();
                }
            }
            if (gridModel.UnitOfMeasuresGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldunit = context.UnitOfMeasures.Where(w => w.Id == unit.Id).FirstOrDefault();
                    oldunit.Code = unit.Code;
                    oldunit.Name = unit.Name;
                    oldunit.Comment = unit.Comment;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("UnitOfMeasure");
        }
        #endregion
        #region 存货档案
        private void SetupInventoryGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Inventory_RequestData");
            grid.EditUrl = Url.Action("Inventory_EditData");

            JQGridColumn unitsColumn = grid.Columns.Find(c => c.DataField == "UnitOfMeasure");

            unitsColumn.Formatter = new CustomFormatter()
            {
                FormatFunction = "ShowName",
                UnFormatFunction = "UnShowName"
            };
            unitsColumn.EditType = EditType.DropDown;
            unitsColumn.SearchType = SearchType.DropDown;
            if (grid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            {
                var editList = (from u in db.UnitOfMeasures
                                select new
                                {
                                    u.Id,
                                    u.Name
                                }).ToList();
                var list = editList.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
                unitsColumn.EditList = list.ToList<SelectListItem>();
                unitsColumn.SearchList = list.ToList<SelectListItem>();
                unitsColumn.SearchList.Insert(0, new SelectListItem { Text = "所有", Value = "" });
            }

        }
        public ActionResult Inventory()
        {
            var gridModel = new InventoryGridModel();
            SetupInventoryGridModel(gridModel.InventoryGrid);
            return View(gridModel);
        }
        public ActionResult Inventory_RequestData()
        {
            var gridModel = new InventoryGridModel();
            SetupInventoryGridModel(gridModel.InventoryGrid);

            var invs = (from inv in db.Inventory
                       join unit in db.UnitOfMeasures on inv.UnitOfMeasure equals unit.Id into invunit
                       from iu in invunit.DefaultIfEmpty()
                       select new
                       {
                           inv.Id,
                           inv.Code,
                           inv.Name,
                           inv.Comment,
                           inv.UnitOfMeasure,
                           inv.Specs,
                           UnitName=iu.Name
                       }).ToList();
            var invs2 = invs.Select(s => new
            {
                s.Id,
                s.Code,
                s.Name,
                s.Comment,
                UnitOfMeasure = s.UnitOfMeasure.HasValue ? s.UnitOfMeasure.ToString() : "",
                s.Specs,
                s.UnitName
            }).ToList();
            return gridModel.InventoryGrid.DataBind(invs2.ToList().AsQueryable());
        }

        public ActionResult Inventory_EditData(DXInfo.Models.Inventory inv)
        {
            var gridModel = new InventoryGridModel();
            SetupInventoryGridModel(gridModel.InventoryGrid);

            if (gridModel.InventoryGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                using (var context = db)
                {
                    inv.Id = Guid.NewGuid();
                    context.Inventory.Add(inv);
                    context.SaveChanges();
                }
            }
            if (gridModel.InventoryGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldinv = context.Inventory.Where(w => w.Id == inv.Id).FirstOrDefault();
                    oldinv.Code = inv.Code;
                    oldinv.Name = inv.Name;
                    oldinv.Comment = inv.Comment;
                    oldinv.UnitOfMeasure = inv.UnitOfMeasure;
                    oldinv.Specs = inv.Specs;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Inventory");
        }
        #endregion

        #region 运输路线
        private void SetupLinesGridModel(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Lines_RequestData");
            grid.EditUrl = Url.Action("Lines_EditData");
        }
        public ActionResult Lines()
        {
            var gridModel = new LinesGridModel();
            SetupLinesGridModel(gridModel.LinesGrid);
            return View(gridModel);
        }
        public ActionResult Lines_RequestData()
        {
            var gridModel = new LinesGridModel();
            SetupLinesGridModel(gridModel.LinesGrid);

            var lines = db.Lines.ToList();
            return gridModel.LinesGrid.DataBind(lines.AsQueryable());
        }
        public ActionResult Lines_EditData(DXInfo.Models.Line line)
        {
            var gridModel = new LinesGridModel();
            SetupLinesGridModel(gridModel.LinesGrid);
            if (gridModel.LinesGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                using (var context = db)
                {
                    line.Id = Guid.NewGuid();
                    context.Lines.Add(line);
                    context.SaveChanges();
                }
            }
            if (gridModel.LinesGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldline = context.Lines.Where(w => w.Id == line.Id).FirstOrDefault();
                    oldline.Code = line.Code;
                    oldline.Name = line.Name;
                    oldline.Comment = line.Comment;
                    oldline.Mileage = line.Mileage;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Lines");
        }
        #endregion

        private void SetupkeyMangeGrid(JQGrid grid)
        {
            grid.DataUrl = Url.Action("KeyManage_RequestData");
            grid.EditUrl = Url.Action("KeyManage_EditData");

            JQGridColumn userColumn = grid.Columns.Find(c => c.DataField == "UserId");
            
            if (grid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
            {
                var us = db.aspnet_CustomProfile.ToList();
                var lus = us.Select(u=>new SelectListItem { Text = u.FullName, Value = u.UserId.ToString() }
                         ).ToList();

                userColumn.EditList = lus;
            }
            userColumn.EditType = EditType.DropDown;

            userColumn.Formatter = new CustomFormatter()
            {
                FormatFunction = "ShowName",
                UnFormatFunction = "UnShowName"
            };
        }
        public ActionResult KeyManage()
        {
            var gridModel = new KeyManageGridModel();
            SetupkeyMangeGrid(gridModel.KeyManageGrid);
            return View(gridModel);
        }
        public ActionResult KeyManage_RequestData()
        {
            var gridModel = new KeyManageGridModel();
            SetupkeyMangeGrid(gridModel.KeyManageGrid);
            var keys = (from e in db.ekey                       
                       join u in db.aspnet_CustomProfile on e.UserId equals u.UserId into eu
                       from eus in eu.DefaultIfEmpty()
                       select new { e.HardwareID, e.CardNo, e.CreateDate, e.IsUse,e.UserId, eus.FullName }).ToList();
            var lkeys = keys.Select(s=>new{s.HardwareID,s.CardNo,s.CreateDate,s.IsUse,UserId=s.UserId.ToString(),s.FullName});
            return gridModel.KeyManageGrid.DataBind(lkeys.ToList().AsQueryable());
        }
        public ActionResult KeyManage_EditData(DXInfo.Models.ekey key)
        {
            var gridModel = new KeyManageGridModel();
            SetupkeyMangeGrid(gridModel.KeyManageGrid);
            if (gridModel.KeyManageGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                using (var context = db)
                {
                    var oldkey = context.ekey.Where(w => w.HardwareID == key.HardwareID).FirstOrDefault();
                    if (oldkey != null)
                    {
                        oldkey.IsUse = key.IsUse;
                        oldkey.UserId = key.UserId;
                        context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("KeyManage");
        }
    }
}
