using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets {
	public class StarSystemDef {
		#region Variables
		public String name;
		public int id, x, y, z;

		List<StarDef> stars = new List<StarDef>();


		#endregion Variables
		public StarSystemDef() {


		}

	}
}
