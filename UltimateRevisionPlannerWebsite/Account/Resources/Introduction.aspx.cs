using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UltimateRevisionPlannerWebsite;
using System.Data;

namespace UltimateRevisionPlannerWebsite.Account.Resources
{
    public partial class _1Resources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TableHeaderRow headerRow = new TableHeaderRow();
            TableHeaderCell headerTableCell1 = new TableHeaderCell();
            TableHeaderCell headerTableCell2 = new TableHeaderCell();
            TableHeaderCell headerTableCell3 = new TableHeaderCell();
            headerTableCell1.Text = "Resource";
            headerTableCell1.Scope = TableHeaderScope.Column;
            headerTableCell2.Text = "Type";
            headerTableCell2.Scope = TableHeaderScope.Column;
            headerTableCell3.Text = "Length in Minutes";
            headerTableCell3.Scope = TableHeaderScope.Column;
            headerRow.Cells.Add(headerTableCell1);
            headerRow.Cells.Add(headerTableCell2);
            headerRow.Cells.Add(headerTableCell3);
            Table1.Rows.AddAt(0, headerRow);

            List<Resource> lResources = Resource.getResourcesByTopicID(1);
            Label Label1 = new Label();
            Label1.Text = "";
            Label Label2 = new Label();
            Label2.Text = "";

            foreach (Resource newResource in lResources)
            {
                TableRow tableRow = new TableRow();

                TableCell tableCell1 = new TableCell();
                tableCell1.Text = "<a href='";
                tableCell1.Text += newResource._link;
                tableCell1.Text += "' Target=_blank>";
                tableCell1.Text += newResource._description;
                tableCell1.Text += "<a/>";
                tableRow.Cells.Add(tableCell1);

                TableCell tableCell2 = new TableCell();
                tableCell2.Text = "Type-NOT DONE YET";
                tableRow.Cells.Add(tableCell2);

                TableCell tableCell3 = new TableCell();
                tableCell3.Text = "Length - ";
                tableCell3.Text = newResource._lengthMinutes.ToString();
                tableRow.Cells.Add(tableCell3);

                Table1.Rows.Add(tableRow);

            }
        }
    }
}