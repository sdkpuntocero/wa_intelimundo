using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace wa_intelimundo
{
	public class search_cs : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string prefixText = context.Request.QueryString["q"];

			using (db_imEntities edm_servicios = new db_imEntities())
			{
				var i_servicios = (from i_u in edm_servicios.inf_inventario
								   join i_g in edm_servicios.fact_grado_escolar on i_u.id_grado_escolar equals i_g.id_grado_escolar
								   join i_n in edm_servicios.fact_nivel_escolar on i_g.id_nivel_escolar equals i_n.id_nivel_escolar
								   where i_u.caracteristica.Contains(prefixText)

								   select new
								   {
									   i_u.id_codigo_inventario,
									   i_n.desc_nivel_escolar,
									   i_g.desc_grado_escolar,
									   i_u.categoria,
									   i_u.caracteristica,
									   i_u.costo

								   }).ToList();

				StringBuilder sb = new StringBuilder();
				//foreach (sdr.Read())
				//{
				//	sb.Append(sdr["ContactName"])
				//		.Append(Environment.NewLine);
				//}
				context.Response.Write(sb.ToString());
			}

		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}