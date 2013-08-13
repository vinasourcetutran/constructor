﻿
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using RLM.Construction;
using RLM.Construction.Web.Data;
using RLM.Construction.Entities;

#endregion

namespace RLM.Construction.Web.UI
{
    /// <summary>
    /// Provides Search Functionality for GridView that uses TypedDataSource. This Composite Control automaticaly builds Fields dropdownlist box
    /// based on the Business Entity class properties collection and GridView Column HeaderText 
    /// and SortExpression properties.
    /// </summary>
    [
        Designer(typeof(System.Web.UI.Design.WebControls.CompositeControlDesigner)),
        ToolboxData("<{0}:GridViewSearchPanel runat=\"server\" GridViewControl=\"GridView1\" BusinessEntityType=\"\" />")
    ]    
    public class GridViewSearchPanel: CompositeControl
    {
        private string _gridViewControlID = string.Empty;
        private string _businessEntityType = string.Empty;
        private string _filter = string.Empty;
        private GridView GridView1;
        private DataSourceControl TypedDataSource;

        /// <summary>
        /// SearchButtonClicked event raised whenever the Search Button Clicked
        /// </summary>
        public event EventHandler SearchButtonClicked;
        
        /// <summary>
        /// ResetButtonClicked event raised whenever the Reset Button Clicked
        /// </summary>
        public event EventHandler ResetButtonClicked;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GridViewSearchPanel class.
		/// </summary>
        public GridViewSearchPanel()
	{

        }
        #endregion

        #region Properties
        /// <summary>
        /// Set / Gets the GridView ControlID
        /// </summary>
        [
        Browsable(true),
        Description("Set / Gets the GridView ControlID"),
        Category("Misc"),
        DefaultValue(""),
        ]
        public string GridViewControlID
        {
            get { return _gridViewControlID; }
            set { _gridViewControlID = value; }
        }

        /// <summary>
        /// Set / Gets the whereClause
        /// </summary>
        private string whereClause
        {
            get
            {
                if (ViewState["_whereClause"] != null)
                {
                    return (string)ViewState["_whereClause"];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                ViewState["_whereClause"] = value;
            }
        }

        /// <summary>
        /// Set / Gets the BusinessEntityType
        /// </summary>
        [
        Browsable(true),
        Description("Set / Gets the BusinessEntityType"),
        Category("Misc"),
        DefaultValue(""),
        ]
        public string BusinessEntityType
        {
            get
            {
                return _businessEntityType;
            }
            set
            {
                _businessEntityType = value;
            }
        }

        ///<summary>
        /// Set / Gets the Filter criteria
        ///</summary>
        [
        Browsable(true),
        Description("Set / Gets the Filter criteria"),
        Category("Misc"),
        DefaultValue(""),
        ]
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }        
        #endregion

        /// <summary>
        /// Make sure that CreateChildControls has been called 
        /// before the control is rendered
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer) 
        { 
            base.EnsureChildControls();
            base.Render(writer);         
        } 

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that 
        /// use composition-based implementation to create any child controls they 
        /// contain in preparation for posting back or rendering. 
        /// </summary>
        protected override void CreateChildControls()
        {
            // Start with a clean form 
            base.Controls.Clear();

            DropDownList cboFieldName = new DropDownList();
            cboFieldName.ID = "cboFieldName";
            cboFieldName.SkinID = "cboFieldName";
            
            if (!base.DesignMode)
            {
                GridView1 = (GridView)this.Parent.FindControl(this.GridViewControlID);
                TypedDataSource = (DataSourceControl)this.Parent.FindControl(GridView1.DataSourceID);

                SetWhereClause(whereClause);

                Type t = EntityUtil.GetType(_businessEntityType);
                System.Reflection.PropertyInfo[] pinfo = t.GetProperties();

                foreach (System.Reflection.PropertyInfo p in pinfo)
                {
                    if (p.PropertyType.ToString() == "System.String")
                    {
                        for (int i = 0; i < GridView1.Columns.Count; i++)
                        {
                            // -- check if property is the same what specified in the sortexpression of the column
                            if (p.Name == GridView1.Columns[i].SortExpression)
                            {
                                ListItem li = new ListItem();
                                li.Text = GridView1.Columns[i].HeaderText;
                                li.Value = GridView1.Columns[i].SortExpression;
                                cboFieldName.Items.Add(li);
                            }
                        }
                    }
                }
            }
            else
            {
                cboFieldName.Items.Add(new ListItem("FieldName", "FieldValue"));
            }

            #region UI implementation
            DropDownList cboOperator = new DropDownList();
            cboOperator.ID = "cboOperator";
            cboOperator.SkinID = "cboOperator";
            cboOperator.Items.Add(new ListItem("contains", "0"));
            cboOperator.Items.Add(new ListItem("starts with", "1"));
            cboOperator.Items.Add(new ListItem("equals", "2"));

            TextBox txtKeyword = new TextBox();
            txtKeyword.ID = "txtKeyword";
            txtKeyword.SkinID = "txtKeyword";

            Label lblLookFor = new Label();
            lblLookFor.ID = "lblLookFor";
            lblLookFor.SkinID = "lblLookFor";
            lblLookFor.Text = "Look For:";

            Label lblWhich = new Label();
            lblWhich.ID = "lblWhich";
            lblWhich.SkinID = "lblWhich";
            lblWhich.Text = "which";

            Button cmdSearch = new Button();
            cmdSearch.ID = "cmdSearch";
            cmdSearch.SkinID = "cmdSearch";
            cmdSearch.Text = "Search";
            cmdSearch.Click += new EventHandler(cmdSearch_Click);

            Button cmdReset = new Button();
            cmdReset.ID = "cmdReset";
            cmdReset.SkinID = "cmdReset";
            cmdReset.Text = "Reset";
            cmdReset.Click += new EventHandler(cmdReset_Click);

            Table tbl = new Table();
            tbl.SkinID = "tblSearchPanel";
            TableRow tr = new TableRow();
            TableCell td;

            td = new TableCell();
            td.Controls.Add(lblLookFor);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(cboFieldName);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(lblWhich);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(cboOperator);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(txtKeyword);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(cmdSearch);
            tr.Cells.Add(td);

            td = new TableCell();
            td.Controls.Add(cmdReset);
            tr.Cells.Add(td);

            tbl.Rows.Add(tr);
            #endregion

            base.Controls.Add(tbl);
            base.ClearChildViewState();
        }

        #region Event Methods
        /// <summary>
        /// Displays a Reset button control on the Web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdReset_Click(object sender, EventArgs e)
        {
            DropDownList cboFieldName = (DropDownList)this.FindControl("cboFieldName");
            DropDownList cboOperator = (DropDownList)this.FindControl("cboOperator");
            TextBox txtKeyword = (TextBox)this.FindControl("txtKeyword");

            cboFieldName.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
            txtKeyword.Text = string.Empty;

            whereClause = string.Empty;
            SetWhereClause(string.Empty);
            GridView1.DataBind();
            
            if (ResetButtonClicked != null) ResetButtonClicked(sender, e);
        }

        /// <summary>
        /// Displays a Search button control on the Web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdSearch_Click(object sender, EventArgs e)
        {
            DropDownList cboFieldName = (DropDownList)this.FindControl("cboFieldName");
            DropDownList cboOperator = (DropDownList)this.FindControl("cboOperator");
            TextBox txtKeyword = (TextBox)this.FindControl("txtKeyword");

            switch (cboOperator.SelectedValue)
            {
                case "0":
                    whereClause = string.Format("[{0}] LIKE '%{1}%'", cboFieldName.SelectedValue, txtKeyword.Text);
                    break;

                case "1":
                    whereClause = string.Format("[{0}] LIKE '{1}%'", cboFieldName.SelectedValue, txtKeyword.Text);
                    break;

                case "2":
                    whereClause = string.Format("[{0}] = '{1}'", cboFieldName.SelectedValue, txtKeyword.Text);
                    break;
            }

            SetWhereClause(whereClause);
            GridView1.DataBind();

            if (SearchButtonClicked != null) SearchButtonClicked(sender, e);
        }
        #endregion

        #region Help Methods
        /// <summary>
        /// Sets DataSourceObject Parameter's WhereClause property
        /// </summary>
        /// <param name="whereClause"></param>
        private void SetWhereClause(string whereClause)
        {
            Type t = TypedDataSource.GetType();
            System.Reflection.PropertyInfo prop = t.GetProperty("Parameters");
            ParameterCollection col = (ParameterCollection) prop.GetValue(TypedDataSource, null);

            foreach (Parameter param in col)
            {
                if (param.Name.Equals("WhereClause"))
                {
                    Type pType = param.GetType();                      
                    if (whereClause == string.Empty)
                    {
                        pType.GetProperty("Value").SetValue(param, _filter, null);
                    }
                    else if (_filter == string.Empty)
                    {
                        pType.GetProperty("Value").SetValue(param, whereClause, null);                        
                    }
                    else
                    {
                        pType.GetProperty("Value").SetValue(param, _filter + " AND " + whereClause, null);                        
                    }
                    break;
                }
            }
        }
        #endregion
    }
}

