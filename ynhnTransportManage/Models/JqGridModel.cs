using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace ynhnTransportManage.Models
{
    public class JqGridModel
    {
        public JqGridModel(List<JQGridColumn> columns, int width = 1024, double percentage = 100,
            bool showRefreshButton = true,
            bool showAddButton = true,
            bool showDeleteButton = true,
            bool showEditButton = true,
            bool showSearchButton = true,
            bool showSearchToolBar = true,
            bool showViewRowDetailsButton = true,
            bool closeAfterEditing = true,
            bool closeAfterAdding = true,
            string customButtonClicked = "customButtonClicked"
            )
        {
            this.Grid = new JQGrid()
            {
                Columns = columns,
                Width = Unit.Pixel(width),
                Height = Unit.Percentage(percentage)
            };
            Grid.ToolBarSettings.ShowRefreshButton = showRefreshButton;
            Grid.ToolBarSettings.ShowAddButton = showAddButton;
            Grid.ToolBarSettings.ShowDeleteButton = showDeleteButton;
            Grid.ToolBarSettings.ShowEditButton = showEditButton;
            Grid.ToolBarSettings.ShowSearchButton = showSearchButton;
            Grid.ToolBarSettings.ShowSearchToolBar = showSearchToolBar;
            Grid.ToolBarSettings.ShowViewRowDetailsButton = showViewRowDetailsButton;
            Grid.EditDialogSettings.CloseAfterEditing = closeAfterEditing;
            Grid.AddDialogSettings.CloseAfterAdding = closeAfterAdding;
            //if (Grid.ToolBarSettings.CustomButtons.Count == 0)
            //{
            //    Grid.ToolBarSettings.CustomButtons.Add(
            //       new JQGridToolBarButton
            //       {
            //           Text = "导出EXCEL",
            //           ToolTip = "导出EXCEL",
            //           ButtonIcon = "ui-icon-extlink",
            //           Position = ToolBarButtonPosition.Last,
            //           OnClick = customButtonClicked
            //       }
            //   );
            //}            
        }
        public JQGrid Grid { get; set; }

        
    }
}