using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class KeyManageModels
    {
    }
    public class KeyManageGridModel
    {
        public JQGrid KeyManageGrid { get; set; }
        public KeyManageGridModel()
        {
            KeyManageGrid = new JQGrid()
            {
                AutoWidth = true,
                Height = Unit.Percentage(100),
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn()
                    {
                        DataField="HardwareID",
                        HeaderText = "硬件序列号",
                        DataType = typeof(string),
                        Editable = false
                    },
                    new JQGridColumn()
                    {
                        DataField = "CardNo",
                        HeaderText = "ekey编号",
                        DataType = typeof(string),
                        Editable = false
                    },
                    new JQGridColumn()
                    {
                        DataField = "CreateDate",
                        HeaderText = "启用日期",
                        DataType = typeof(string),
                        Editable=false
                    },
                    new JQGridColumn()
                    {
                        DataField = "IsUse",
                        HeaderText = "是否启用",
                        DataType = typeof(bool),
                        Editable = true,
                        EditType = EditType.CheckBox,
                        Formatter = new CheckBoxFormatter()
                    },
                    new JQGridColumn()
                    {
                        DataField = "UserId",
                        HeaderText = "用户",
                        DataType = typeof(Guid),
                        Editable=true,
                        EditType = EditType.DropDown
                    },
                    new JQGridColumn()
                    {
                        DataField = "FullName",
                        HeaderText = "用户",
                        DataType = typeof(string),
                        Editable=false,
                        Visible = false
                    }
                }
            };
            KeyManageGrid.ToolBarSettings.ShowEditButton = true;
            KeyManageGrid.AppearanceSettings.Caption = "ekey管理";
        }
    }
}