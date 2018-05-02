using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
	public partial class Vendedor : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Panel0.Visible = true;
			Panel1.Visible = false;
			Panel2.Visible = false;
			Panel3.Visible = false;
			Panel4.Visible = false;
			Panel5.Visible = false;
		}

		protected void lkb_resumen_Click(object sender, EventArgs e)
		{
			Panel0.Visible = false;
			Panel1.Visible = true;
			Panel2.Visible = false;
			Panel3.Visible = false;
			Panel4.Visible = false;
			Panel5.Visible = false;
		}

		protected void a_contacto_Click(object sender, EventArgs e)
		{
			Panel0.Visible = false;
			Panel1.Visible = false;
			Panel2.Visible = true;
			Panel3.Visible = false;
			Panel4.Visible = false;
			Panel5.Visible = false;
		}

		protected void a_gastos_Click(object sender, EventArgs e)
		{
			Panel0.Visible = false;
			Panel1.Visible = false;
			Panel2.Visible = false;
			Panel3.Visible = true;
			Panel4.Visible = false;
			Panel5.Visible = false;
		}

		protected void a_recepcion_Click(object sender, EventArgs e)
		{
			Panel0.Visible = false;
			Panel1.Visible = false;
			Panel2.Visible = false;
			Panel3.Visible = false;
			Panel4.Visible = true;
			Panel5.Visible = false;
		}

		protected void lKbIENVENIDO_Click(object sender, EventArgs e)
		{
			Panel0.Visible = false;
			Panel1.Visible = false;
			Panel2.Visible = false;
			Panel3.Visible = false;
			Panel4.Visible = false;
			Panel5.Visible = true;
		}
	}
}