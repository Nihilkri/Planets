using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets {
	public class FleetDef {
		#region Variables
		public String name;
		public int id, x, y, z;

		public EmpireDef owner;
		List<ShipDef> ships = new List<ShipDef>();

		#endregion Variables
		public FleetDef() {


		}

	}
}
