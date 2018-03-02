using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class ParaModels
    {
    }
    public class ParaGridModel
    {
        public JQGrid ParasGrid { get; set; }
        public ParaGridModel()
        {
            ParasGrid = new JQGrid()
            {
                AutoWidth = true,
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="ID",
                        PrimaryKey = true,
                        Visible = false,
                        //Editable=true,
                        DataType=typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Type",
                        HeaderText = "类型",
                        Editable=true,
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                        DataType=typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Code",
                        HeaderText = "编码",
                        Editable=true,
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                        DataType=typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Name",
                        HeaderText="名称",
                        Editable=true,
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                        DataType=typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Value",
                        HeaderText="值",
                        Editable=true,
                        DataType=typeof(string)
                    },
                    new JQGridColumn()
                    {
                        DataField="Comment",
                        HeaderText="描述",
                        Editable=true,
                        DataType=typeof(string)
                    }

                },
                Height = Unit.Percentage(100)
            };
            ParasGrid.ToolBarSettings.ShowAddButton = true;
            ParasGrid.ToolBarSettings.ShowEditButton = true;
            ParasGrid.ToolBarSettings.ShowRefreshButton = true;
            ParasGrid.ToolBarSettings.ShowSearchButton = true;
            ParasGrid.AppearanceSettings.Caption = "参数设置";
            ParasGrid.SearchDialogSettings.MultipleSearch = true;
            ParasGrid.SortSettings.InitialSortColumn = "Type,Code";
        }
    }
}