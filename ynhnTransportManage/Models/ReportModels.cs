using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class ReportModels
    {
    }
    public class Report1Grid
    {
        public JQGrid ReportGrid { get; set; }
        public Report1Grid()
        {
            ReportGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="CardNo",
                        HeaderText="卡号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Status",
                        HeaderText="状态",
                        DataType = typeof(string),     
                    },
                    new JQGridColumn()
                    {
                        DataField="PlateNo",
                        HeaderText="车牌号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="OwnerName",
                        HeaderText="车主",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="DriverName",
                        HeaderText="驾驶员",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Dept",
                        HeaderText="装车部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Date",
                        HeaderText="装车时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Oper",
                        HeaderText="装车操作员",
                        DataType = typeof(string)
                    },

                    new JQGridColumn()
                    {
                        DataField="Load_Inventory",
                        HeaderText="存货",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitName",
                        HeaderText="计量单位",
                        DataType = typeof(string),                        
                        Editable=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Specs",
                        HeaderText="规格型号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Quantity",
                        HeaderText="装车数量",
                        DataType = typeof(decimal)     
                    }
                }
            };
            ReportGrid.ToolBarSettings.ShowSearchButton = true;
            ReportGrid.SearchDialogSettings.MultipleSearch = true;
            ReportGrid.AppearanceSettings.Caption = "车辆装货报表";
            ReportGrid.ToolBarSettings.CustomButtons = new List<JQGridToolBarButton>()
            {
                new JQGridToolBarButton()
                {
                    Position = ToolBarButtonPosition.Last,
                    ToolTip="导出EXCEL",
                    Text="导出",
                    OnClick="customButtonClicked",
                    ButtonIcon="ui-icon-extlink"
                }
            };
        }
    }

    public class Report2Grid
    {
        public JQGrid ReportGrid { get; set; }
        public Report2Grid()
        {
            ReportGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="CardNo",
                        HeaderText="卡号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Status",
                        HeaderText="状态",
                        DataType = typeof(string),     
                    },
                    new JQGridColumn()
                    {
                        DataField="PlateNo",
                        HeaderText="车牌号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="OwnerName",
                        HeaderText="车主",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="DriverName",
                        HeaderText="驾驶员",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="InFactory_Dept",
                        HeaderText="进厂部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="InFactory_Date",
                        HeaderText="进厂时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="InFactory_Oper",
                        HeaderText="进厂操作员",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Dept",
                        HeaderText="装车部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Date",
                        HeaderText="装车时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Oper",
                        HeaderText="装车操作员",
                        DataType = typeof(string)
                    },

                    new JQGridColumn()
                    {
                        DataField="Load_Inventory",
                        HeaderText="存货",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitName",
                        HeaderText="计量单位",
                        DataType = typeof(string),                        
                        Editable=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Specs",
                        HeaderText="规格型号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Load_Quantity",
                        HeaderText="装车数量",
                        DataType = typeof(decimal)     
                    },
                }
            };
            ReportGrid.ToolBarSettings.ShowSearchButton = true;
            ReportGrid.SearchDialogSettings.MultipleSearch = true;
            ReportGrid.AppearanceSettings.Caption = "车辆装货进出场报表";
            ReportGrid.ToolBarSettings.CustomButtons = new List<JQGridToolBarButton>()
            {
                new JQGridToolBarButton()
                {
                    Position = ToolBarButtonPosition.Last,
                    ToolTip="导出EXCEL",
                    Text="导出",
                    OnClick="customButtonClicked",
                    ButtonIcon="ui-icon-extlink"
                }
            };
        }
    }

    public class Report3Grid
    {
        public JQGrid ReportGrid { get; set; }
        public Report3Grid()
        {
            ReportGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="CardNo",
                        HeaderText="卡号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Status",
                        HeaderText="状态",
                        DataType = typeof(string),     
                    },
                    new JQGridColumn()
                    {
                        DataField="PlateNo",
                        HeaderText="车牌号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="OwnerName",
                        HeaderText="车主",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="DriverName",
                        HeaderText="驾驶员",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Dept",
                        HeaderText="卸货部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Date",
                        HeaderText="卸货时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Oper",
                        HeaderText="卸货操作员",
                        DataType = typeof(string)
                    },

                    new JQGridColumn()
                    {
                        DataField="Load_Inventory",
                        HeaderText="存货",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitName",
                        HeaderText="计量单位",
                        DataType = typeof(string),                        
                        Editable=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Specs",
                        HeaderText="规格型号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Quantity",
                        HeaderText="卸货数量",
                        DataType = typeof(decimal)     
                    },
                    new JQGridColumn()
                    {
                        DataField="OutFactory_Dept",
                        HeaderText="出厂部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="OutFactory_Date",
                        HeaderText="出厂时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="OutFactory_Oper",
                        HeaderText="出厂操作员",
                        DataType = typeof(string)
                    },
                }
            };
            ReportGrid.ToolBarSettings.ShowSearchButton = true;
            ReportGrid.SearchDialogSettings.MultipleSearch = true;
            ReportGrid.AppearanceSettings.Caption = "车辆卸货进出场报表";
            ReportGrid.ToolBarSettings.CustomButtons = new List<JQGridToolBarButton>()
            {
                new JQGridToolBarButton()
                {
                    Position = ToolBarButtonPosition.Last,
                    ToolTip="导出EXCEL",
                    Text="导出",
                    OnClick="customButtonClicked",
                    ButtonIcon="ui-icon-extlink"
                }
            };
        }
    }


    public class Report4Grid
    {
        public JQGrid ReportGrid { get; set; }
        public Report4Grid()
        {
            ReportGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="CardNo",
                        HeaderText="卡号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Status",
                        HeaderText="状态",
                        DataType = typeof(string),     
                    },
                    new JQGridColumn()
                    {
                        DataField="PlateNo",
                        HeaderText="车牌号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="OwnerName",
                        HeaderText="车主",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="DriverName",
                        HeaderText="驾驶员",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Dept",
                        HeaderText="卸货部门",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Date",
                        HeaderText="卸货时间",
                        DataType = typeof(DateTime)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Oper",
                        HeaderText="卸货操作员",
                        DataType = typeof(string)
                    },

                    new JQGridColumn()
                    {
                        DataField="Load_Inventory",
                        HeaderText="存货",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitName",
                        HeaderText="计量单位",
                        DataType = typeof(string),                        
                        Editable=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Specs",
                        HeaderText="规格型号",
                        DataType = typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_Quantity",
                        HeaderText="卸货数量",
                        DataType = typeof(decimal)     
                    },
                    new JQGridColumn()
                    {
                        DataField="Shipment_CheckUser",
                        HeaderText="验收",
                        DataType = typeof(string)
                    },
                }
            };
            ReportGrid.ToolBarSettings.ShowSearchButton = true;
            ReportGrid.SearchDialogSettings.MultipleSearch = true;
            ReportGrid.AppearanceSettings.Caption = "验收货物情况报表";
            ReportGrid.ToolBarSettings.CustomButtons = new List<JQGridToolBarButton>()
            {
                new JQGridToolBarButton()
                {
                    Position = ToolBarButtonPosition.Last,
                    ToolTip="导出EXCEL",
                    Text="导出",
                    OnClick="customButtonClicked",
                    ButtonIcon="ui-icon-extlink"
                }
            };
        }
    }
}