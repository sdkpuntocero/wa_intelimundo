using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wa_intelimundo
{
	public class cn
	{
		static string con_sql = @"Data Source=localhost;Initial Catalog=db_im;User ID=u_im;Password=dev_.0";
		public static string CadenaConexion
		{
			get
			{
				return con_sql;

			}
		}
	}
}