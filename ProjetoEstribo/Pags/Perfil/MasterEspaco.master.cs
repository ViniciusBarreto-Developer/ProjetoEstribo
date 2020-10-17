using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pags_Perfil_MasterEspaco : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnSair_Click(object sender, EventArgs e)
    {
        Session.Remove("usuario");
        Response.Redirect("../Principal.aspx");
    }
}
