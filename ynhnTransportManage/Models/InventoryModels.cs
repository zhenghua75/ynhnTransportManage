using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class InventoryModels
    {
    }
    public class InventoryGridModel
    {
        public JQGrid InventoryGrid { get; set; }
        public InventoryGridModel()
        {
            InventoryGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="Id",
                        DataType=typeof(Guid),
                        PrimaryKey=true,
                        Visible=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Code",
                        HeaderText="编码",
                        DataType=typeof(string),
                        Editable=true,
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                    },
                    new JQGridColumn()
                    {
                        DataField="Name",
                        HeaderText="名称",
                        DataType=typeof(string),
                        Editable=true,
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitOfMeasure",
                        HeaderText="计量单位",
                        DataType=typeof(string),
                        Editable=true
                    },
                    new JQGridColumn()
                    {
                        DataField="UnitName",
                        HeaderText="计量单位名称",
                        DataType=typeof(string),
                        Editable=false,
                        Visible=false
                    },
                    new JQGridColumn()
                    {
                        DataField="Specs",
                        HeaderText="规格型号",
                        DataType=typeof(string),
                        Editable=true
                    },
                    new JQGridColumn()
                    {
                        DataField="Comment",
                        HeaderText="描述",
                        DataType=typeof(string),
                        Editable=true
                    }
                }
            };
            InventoryGrid.AppearanceSettings.Caption = "存货档案";
            InventoryGrid.ToolBarSettings.ShowSearchButton = true;
            InventoryGrid.ToolBarSettings.ShowAddButton = true;
            //InventoryGrid.ToolBarSettings.ShowDeleteButton = true;
            InventoryGrid.ToolBarSettings.ShowEditButton = true;
            InventoryGrid.ToolBarSettings.ShowRefreshButton = true;
            InventoryGrid.SearchDialogSettings.MultipleSearch = true;
        }
    }
}