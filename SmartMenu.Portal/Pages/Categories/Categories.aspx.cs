using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartMenu.DAL;

namespace SmartMenu.Portal.Pages.Categories
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var DataContext = new smartmenuBEEntities())
                {
                    grdCat.DataSource = DataContext.Categories.ToList();
                    grdCat.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }
    }
}