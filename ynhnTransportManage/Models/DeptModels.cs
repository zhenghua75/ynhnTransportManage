using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class DeptJqTreeModel
    {
        public JQTree DeptsTree { get; set; }
        public DeptJqTreeModel()
        {
            DeptsTree = new JQTree()
            {                
            };
        }
    }
    public class DeptModels
    {
    }

    public class DeptJqGridModel
    {
        public JQGrid DeptsGrid { get; set; }
        public DeptJqGridModel()
        {
            DeptsGrid = new JQGrid()
            {
                TreeGrid = true,
                ExpandColumn = "DeptCode",
                ParentIdField="ParentDeptId",
                
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="DeptId",
                        PrimaryKey=true,
                        Visible=false
                    },
                    new JQGridColumn()
                    {
                        DataField = "ParentDeptId",                        
                        Visible=false
                    },
                    new JQGridColumn()
                    {
                        HeaderText="编码",
                        DataField="DeptCode",
                        Editable=true,
                        Sortable=false,
                        Searchable=true,
                        DataType=typeof(string),
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                    },
                    new JQGridColumn()
                    {
                        HeaderText="名称",
                        DataField="DeptName",
                        Editable=true,
                        Searchable=true,
                        Sortable=false,
                        DataType=typeof(string),
                        EditDialogFieldSuffix="(*)",
                        EditClientSideValidators = new List<JQGridEditClientSideValidator>()
                        {
                            new RequiredValidator()                            
                        },
                    },
                    new JQGridColumn()
                    {
                        HeaderText="地址",
                        DataField="Address",
                        Searchable=true,
                        Sortable=false,
                        DataType=typeof(string),
                        Editable=true
                    },
                    new JQGridColumn()
                    {
                        HeaderText="描述",
                        DataField="Comment",
                        Searchable=true,
                        Sortable=false,
                        DataType=typeof(string),
                        Editable=true
                    },
                    new JQGridColumn()
                    {
                        DataField="level"
                    },
                    new JQGridColumn()
                    {
                        DataField="parent_id"
                    },
                    new JQGridColumn()
                    {
                        DataField="isLeaf"
                    },
                    new JQGridColumn()
                    {
                        DataField="expanded"
                    }
                }
            };
            DeptsGrid.AppearanceSettings.Caption = "组织机构";
            DeptsGrid.ToolBarSettings.ShowAddButton = true;
            DeptsGrid.ToolBarSettings.ShowEditButton = true;
            DeptsGrid.ToolBarSettings.ShowRefreshButton = true;
            DeptsGrid.ToolBarSettings.ShowSearchButton = true;

            DeptsGrid.EditDialogSettings.ReloadAfterSubmit = true;
            DeptsGrid.EditDialogSettings.CloseAfterEditing = true;
            DeptsGrid.AddDialogSettings.CloseAfterAdding = true;
            DeptsGrid.AutoWidth = true;
            DeptsGrid.Height = Unit.Percentage(100);
            //DeptsGrid.AppearanceSettings.ShowRowNumbers = false;
            
            
        }

    }
}