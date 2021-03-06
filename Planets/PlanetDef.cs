﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets {
	public class PlanetDef {
		#region Variables
		public String name;
		public int id, x, y, z;
		public StarSystemDef parent;

		/// <summary>
		/// Gravity, Temperature, Radiation
		/// </summary>
		public int G, T, R;
		/// <summary>
		/// Surface Ironium, Boranium, Germanium
		/// </summary>
		public int sI, sB, sG;
		/// <summary>
		/// Concentrations of Ironium, Boranium, Germanium
		/// </summary>
		public int cI, cB, cG;

		public EmpireDef owner;
		public ShipDef starbase;
		public int sbadmg, sbsdmg;
		public Dictionary<SpeciesDef, int> pop = new Dictionary<SpeciesDef, int>();
		public int mines, facts, defs, deftype;
		public int scanner;

		#endregion Variables
		public PlanetDef() {
			

		}

	}
}
