using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ynhnTransportManage.Models;
using Trirand.Web.Mvc;

namespace ynhnTransportManage.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        private DXInfo.Models.ynhnTransportManage db = new DXInfo.Models.ynhnTransportManage();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report1()
        {
            var gridModel = new Report1Grid();
            SetupReport1Grid(gridModel.ReportGrid);
            return View(gridModel);
        }
        private void SetupReport1Grid(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Report1_RequestData");
        }
        private IQueryable GetReport1Data()
        {
            var tp = (from t in db.Transports
                      join c in db.Cards on t.Card equals c.Id into tc
                      from tcs in tc.DefaultIfEmpty()

                      join v in db.Vehicles on tcs.Vehicle equals v.Id into tcsv
                      from tcsvs in tcsv.DefaultIfEmpty()

                      join d in db.Drivers on t.Driver equals d.Id into td
                      from tds in td.DefaultIfEmpty()

                      join d1 in db.Depts on t.Load_DeptId equals d1.DeptId into td1
                      from td1s in td1.DefaultIfEmpty()

                      join u1 in db.aspnet_CustomProfile on t.Load_UserId equals u1.UserId into tu1
                      from tu1s in tu1.DefaultIfEmpty()

                      join i in db.Inventory on t.Load_Inventory equals i.Id into ti
                      from tis in ti.DefaultIfEmpty()

                      join um in db.UnitOfMeasures on tis.UnitOfMeasure equals um.Id into ium
                      from iums in ium.DefaultIfEmpty()

                      select new
                      {
                          tcs.CardNo,
                          t.Status,
                          tcsvs.PlateNo,
                          tcsvs.OwnerName,
                          DriverName = tds.Name,
                          Load_Dept = td1s.DeptName,
                          t.Load_Date,
                          Load_Oper = tu1s.FullName,
                          Load_Inventory = tis.Name,
                          UnitName = iums.Name,
                          tis.Specs,
                          t.Load_Quantity
                      }).ToList();
            var tps = tp.Select(s => new
            {
                s.CardNo,
                Status = s.Status == 0 ? "进厂" : s.Status == 1 ? "装车" : s.Status == 2 ? "卸货" : "出厂",
                s.PlateNo,
                s.OwnerName,
                s.DriverName,
                s.Load_Dept,
                s.Load_Date,
                s.Load_Oper,
                s.Load_Inventory,
                s.UnitName,
                s.Specs,
                s.Load_Quantity
            }).ToList().AsQueryable();
            return tps;
        }
        public ActionResult Report1_RequestData()
        {
            var gridModel = new Report1Grid();
            SetupReport1Grid(gridModel.ReportGrid);
            JQGridState gridState = gridModel.ReportGrid.GetState(false);
            Session["Report1GridState"] = gridState;
            return gridModel.ReportGrid.DataBind(GetReport1Data());
        }
        public ActionResult Report1ExportToExcel()
        {
            var gridModel = new Report1Grid();
            SetupReport1Grid(gridModel.ReportGrid);
            JQGridState gridState = Session["Report1GridState"] as JQGridState;
            gridModel.ReportGrid.ExportToExcel(GetReport1Data(), "车辆装货报表.xls", gridState);
            return View();
        }
        public ActionResult Report2()
        {
            var gridModel = new Report2Grid();
            SetupReport2Grid(gridModel.ReportGrid);
            return View(gridModel);
        }
        private void SetupReport2Grid(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Report2_RequestData");
        }
        private IQueryable GetReport2Data()
        {
            var tp = (from t in db.Transports
                      join c in db.Cards on t.Card equals c.Id into tc
                      from tcs in tc.DefaultIfEmpty()

                      join v in db.Vehicles on tcs.Vehicle equals v.Id into tcsv
                      from tcsvs in tcsv.DefaultIfEmpty()

                      join d in db.Drivers on t.Driver equals d.Id into td
                      from tds in td.DefaultIfEmpty()

                      join d1 in db.Depts on t.Load_DeptId equals d1.DeptId into td1
                      from td1s in td1.DefaultIfEmpty()

                      join u1 in db.aspnet_CustomProfile on t.Load_UserId equals u1.UserId into tu1
                      from tu1s in tu1.DefaultIfEmpty()

                      join i in db.Inventory on t.Load_Inventory equals i.Id into ti
                      from tis in ti.DefaultIfEmpty()

                      join um in db.UnitOfMeasures on tis.UnitOfMeasure equals um.Id into ium
                      from iums in ium.DefaultIfEmpty()

                      join d2 in db.Depts on t.InFactory_DeptId equals d2.DeptId into td2
                      from td2s in td2.DefaultIfEmpty()

                      join u2 in db.aspnet_CustomProfile on t.InFactory_UserId equals u2.UserId into tu2
                      from tu2s in tu2.DefaultIfEmpty()

                      select new
                      {
                          tcs.CardNo,
                          t.Status,
                          tcsvs.PlateNo,
                          tcsvs.OwnerName,
                          DriverName = tds.Name,
                          InFactory_Dept=td2s.DeptName,
                          t.InFactory_Date,
                          InFactory_Oper=tu2s.FullName,
                          Load_Dept = td1s.DeptName,
                          t.Load_Date,
                          Load_Oper = tu1s.FullName,
                          Load_Inventory = tis.Name,
                          UnitName = iums.Name,
                          tis.Specs,
                          t.Load_Quantity
                      }).ToList();
            var tps = tp.Select(s => new
            {
                s.CardNo,
                Status = s.Status == 0 ? "进厂" : s.Status == 1 ? "装车" : s.Status == 2 ? "卸货" : "出厂",
                s.PlateNo,
                s.OwnerName,
                s.DriverName,
                s.InFactory_Dept,
                s.InFactory_Date,
                s.InFactory_Oper,
                s.Load_Dept,
                s.Load_Date,
                s.Load_Oper,
                s.Load_Inventory,
                s.UnitName,
                s.Specs,
                s.Load_Quantity
            }).ToList().AsQueryable();
            return tps;
        }
        public ActionResult Report2_RequestData()
        {
            var gridModel = new Report2Grid();
            SetupReport2Grid(gridModel.ReportGrid);
            JQGridState gridState = gridModel.ReportGrid.GetState(false);
            Session["Report2GridState"] = gridState;
            return gridModel.ReportGrid.DataBind(GetReport2Data());
        }
        public ActionResult Report2ExportToExcel()
        {
            var gridModel = new Report2Grid();
            SetupReport2Grid(gridModel.ReportGrid);
            JQGridState gridState = Session["Report2GridState"] as JQGridState;
            gridModel.ReportGrid.ExportToExcel(GetReport2Data(), "车辆装货进出场报表.xls", gridState);
            return View();
        }
        public ActionResult Report3()
        {
            var gridModel = new Report3Grid();
            SetupReport3Grid(gridModel.ReportGrid);
            return View(gridModel);
        }
        private void SetupReport3Grid(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Report3_RequestData");
        }
        private IQueryable GetReport3Data()
        {
            var tp = (from t in db.Transports
                      join c in db.Cards on t.Card equals c.Id into tc
                      from tcs in tc.DefaultIfEmpty()

                      join v in db.Vehicles on tcs.Vehicle equals v.Id into tcsv
                      from tcsvs in tcsv.DefaultIfEmpty()

                      join d in db.Drivers on t.Driver equals d.Id into td
                      from tds in td.DefaultIfEmpty()

                      join d1 in db.Depts on t.OutFactory_DeptId equals d1.DeptId into td1
                      from td1s in td1.DefaultIfEmpty()

                      join u1 in db.aspnet_CustomProfile on t.OutFactory_UserId equals u1.UserId into tu1
                      from tu1s in tu1.DefaultIfEmpty()

                      join i in db.Inventory on t.Load_Inventory equals i.Id into ti
                      from tis in ti.DefaultIfEmpty()

                      join um in db.UnitOfMeasures on tis.UnitOfMeasure equals um.Id into ium
                      from iums in ium.DefaultIfEmpty()

                      join d2 in db.Depts on t.Shipment_DeptId equals d2.DeptId into td2
                      from td2s in td2.DefaultIfEmpty()

                      join u2 in db.aspnet_CustomProfile on t.Shipment_UserId equals u2.UserId into tu2
                      from tu2s in tu2.DefaultIfEmpty()

                      select new
                      {
                          tcs.CardNo,
                          t.Status,
                          tcsvs.PlateNo,
                          tcsvs.OwnerName,
                          DriverName = tds.Name,
                          Shipment_Dept = td2s.DeptName,
                          t.Shipment_Date,
                          Shipment_Oper = tu2s.FullName,
                          OutFactory_Dept = td1s.DeptName,
                          t.OutFactory_Date,
                          OutFactory_Oper = tu1s.FullName,
                          Load_Inventory = tis.Name,
                          UnitName = iums.Name,
                          tis.Specs,
                          t.Shipment_Quantity
                      }).ToList();
            var tps = tp.Select(s => new
            {
                s.CardNo,
                Status = s.Status == 0 ? "进厂" : s.Status == 1 ? "装车" : s.Status == 2 ? "卸货" : "出厂",
                s.PlateNo,
                s.OwnerName,
                s.DriverName,
                s.Shipment_Dept,
                s.Shipment_Date,
                s.Shipment_Oper,
                s.OutFactory_Dept,
                s.OutFactory_Date,
                s.OutFactory_Oper,
                s.Load_Inventory,
                s.UnitName,
                s.Specs,
                s.Shipment_Quantity
            }).ToList().AsQueryable();
            return tps;
        }
        public ActionResult Report3_RequestData()
        {
            var gridModel = new Report3Grid();
            SetupReport3Grid(gridModel.ReportGrid);
            JQGridState gridState = gridModel.ReportGrid.GetState(false);
            Session["Report3GridState"] = gridState;
            return gridModel.ReportGrid.DataBind(GetReport3Data());
        }
        public ActionResult Report3ExportToExcel()
        {
            var gridModel = new Report3Grid();
            SetupReport3Grid(gridModel.ReportGrid);
            JQGridState gridState = Session["Report3GridState"] as JQGridState;
            gridModel.ReportGrid.ExportToExcel(GetReport3Data(), "车辆卸货进出场报表.xls", gridState);
            return View();
        }
        public ActionResult Report4()
        {
            var gridModel = new Report4Grid();
            SetupReport4Grid(gridModel.ReportGrid);
            return View(gridModel);
        }
        private void SetupReport4Grid(JQGrid grid)
        {
            grid.DataUrl = Url.Action("Report4_RequestData");
        }
        private IQueryable GetReport4Data()
        {
            var tp = (from t in db.Transports
                      join c in db.Cards on t.Card equals c.Id into tc
                      from tcs in tc.DefaultIfEmpty()

                      join v in db.Vehicles on tcs.Vehicle equals v.Id into tcsv
                      from tcsvs in tcsv.DefaultIfEmpty()

                      join d in db.Drivers on t.Driver equals d.Id into td
                      from tds in td.DefaultIfEmpty()

                      //join d1 in db.Depts on t.OutFactory_DeptId equals d1.DeptId into td1
                      //from td1s in td1.DefaultIfEmpty()

                      //join u1 in db.aspnet_CustomProfile on t.OutFactory_UserId equals u1.UserId into tu1
                      //from tu1s in tu1.DefaultIfEmpty()

                      join i in db.Inventory on t.Load_Inventory equals i.Id into ti
                      from tis in ti.DefaultIfEmpty()

                      join um in db.UnitOfMeasures on tis.UnitOfMeasure equals um.Id into ium
                      from iums in ium.DefaultIfEmpty()

                      join d2 in db.Depts on t.Shipment_DeptId equals d2.DeptId into td2
                      from td2s in td2.DefaultIfEmpty()

                      join u2 in db.aspnet_CustomProfile on t.Shipment_UserId equals u2.UserId into tu2
                      from tu2s in tu2.DefaultIfEmpty()

                      select new
                      {
                          tcs.CardNo,
                          t.Status,
                          tcsvs.PlateNo,
                          tcsvs.OwnerName,
                          DriverName = tds.Name,
                          Shipment_Dept = td2s.DeptName,
                          t.Shipment_Date,
                          Shipment_Oper = tu2s.FullName,
                          //OutFactory_Dept = td1s.DeptName,
                          //t.OutFactory_Date,
                          //OutFactory_Oper = tu1s.FullName,
                          Load_Inventory = tis.Name,
                          UnitName = iums.Name,
                          tis.Specs,
                          t.Shipment_Quantity,
                          t.Shipment_CheckUser
                      }).ToList();
            var tps = tp.Select(s => new
            {
                s.CardNo,
                Status = s.Status == 0 ? "进厂" : s.Status == 1 ? "装车" : s.Status == 2 ? "卸货" : "出厂",
                s.PlateNo,
                s.OwnerName,
                s.DriverName,
                s.Shipment_Dept,
                s.Shipment_Date,
                s.Shipment_Oper,
                //s.OutFactory_Dept,
                //s.OutFactory_Date,
                //s.OutFactory_Oper,
                s.Load_Inventory,
                s.UnitName,
                s.Specs,
                s.Shipment_Quantity,
                s.Shipment_CheckUser
            }).ToList().AsQueryable();
            return tps;
        }
        public ActionResult Report4_RequestData()
        {
            var gridModel = new Report4Grid();
            SetupReport4Grid(gridModel.ReportGrid);
            JQGridState gridState = gridModel.ReportGrid.GetState(false);
            Session["Report4GridState"] = gridState;
            return gridModel.ReportGrid.DataBind(GetReport4Data());
        }
        public ActionResult Report4ExportToExcel()
        {
            var gridModel = new Report4Grid();
            SetupReport4Grid(gridModel.ReportGrid);
            JQGridState gridState = Session["Report4GridState"] as JQGridState;
            gridModel.ReportGrid.ExportToExcel(GetReport4Data(), "验收货物情况报表.xls", gridState);
            return View();
        }
    }
}
