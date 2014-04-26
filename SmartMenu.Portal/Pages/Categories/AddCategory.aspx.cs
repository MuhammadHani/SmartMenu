using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartMenu.DAL;

namespace SmartMenu.Portal.Pages.Categories
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Category objCategory = new Category()
            { BinaryContent = FileUpload1.FileBytes,
                DateCreated= DateTime.Now,
                NameAR = txtNameAR.Text,
                NameEN = txtNameEN.Text,
            CreatedBy =1};

            using (var DataContext = new smartmenuBEEntities())
            {
                DataContext.AddToCategories(objCategory);
                DataContext.SaveChanges();
            }

            Response.Redirect("Categories.aspx");
        }
    }
}