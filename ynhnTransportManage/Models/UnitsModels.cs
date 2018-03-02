using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class UnitOfMeasuresGridModel
    {
        public JQGrid UnitOfMeasuresGrid { get; set; }
        public UnitOfMeasuresGridModel()
        {
            UnitOfMeasuresGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="Id",
                        DataType=typeof(Guid),
                        PrimaryKey = true,
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
                        DataField="Comment",
                        HeaderText="描述",
                        DataType=typeof(string),
                        Editable=true
                    }
                }
            };
            UnitOfMeasuresGrid.AppearanceSettings.Caption = "计量单位";
            UnitOfMeasuresGrid.ToolBarSettings.ShowSearchButton = true;
            UnitOfMeasuresGrid.ToolBarSettings.ShowAddButton = true;
            //UnitOfMeasuresGrid.ToolBarSettings.ShowDeleteButton = true;
            UnitOfMeasuresGrid.ToolBarSettings.ShowEditButton = true;
            UnitOfMeasuresGrid.ToolBarSettings.ShowRefreshButton = true;
        }
    }
}