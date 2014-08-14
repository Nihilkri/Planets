using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planets {
	public partial class frmMain : Form {
		#region Variables
		#region Program
		/// <summary>
		/// Random Number Generator
		/// </summary>
		public static Random rng = new Random();
		/// <summary>
		/// fx,fy is the size of the form; fx2,fy2 is half that;
		/// so that (fx2, fy2) is the center of the form
		/// </summary>
		public static int fx, fy, fx2, fy2;
		/// <summary>
		/// the canvas that holds the back buffer
		/// </summary>
		private Bitmap gi;
		/// <summary>
		/// The graphics for the back buffer that draws on gi
		/// </summary>
		private Graphics gb;
		/// <summary>
		/// The graphics for the front buffer that draws on the form
		/// </summary>
		private Graphics gf;
		/// <summary>
		/// The timer object for setting the heartbeat
		/// </summary>
		private Timer tim = new Timer() { Interval = 1000 / 60 };
		/// <summary>
		/// The start time for frame timings
		/// </summary>
		private DateTime st;
		/// <summary>
		/// The finish time for frame timings
		/// </summary>
		private TimeSpan ft;
		#endregion Program
		#region Game
		public enum eGS { Title }
		public static eGS GS = eGS.Title;

		public static List<SpeciesDef> species = new List<SpeciesDef>();
		public static List<EmpireDef> empires = new List<EmpireDef>();
		public static List<StarSystemDef> starsystems = new List<StarSystemDef>();
		public static List<FleetDef> fleets = new List<FleetDef>();

		#endregion Game

		#endregion Variables
		#region Events
		public frmMain() { InitializeComponent(); }
		private void Form1_Load(object sender, EventArgs e) {
			fx = Width; fy = Height; fx2 = fx / 2; fy2 = fy / 2;
			gi = new Bitmap(fx, fy); gb = Graphics.FromImage(gi);
			gf = CreateGraphics(); tim.Tick += tim_Tick;

			empires.Add(new EmpireDef() { name = "Serati" });
			//empires[0].fleets.Add(new FleetDef());
			fleets.Add(new FleetDef() { owner = empires[0] });
			empires[0].name = "Hiserat'na";
			MessageBox.Show(fleets[0].owner.name);


			//tim.Start();
			Calc(); Draw();
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); return;

				default: break;
			}
		}
		private void Form1_MouseClick(object sender, MouseEventArgs e) {

		}
		private void Form1_Paint(object sender, PaintEventArgs e) { gf.DrawImage(gi, 0, 0); }
		void tim_Tick(object sender, EventArgs e) { Calc(); Draw(); }

		#endregion Events
		#region Calc
		public void Calc() {
			st = DateTime.Now;
			gb.Clear(Color.Black);


		}

		#endregion Calc
		#region Draw
		public void Draw() {


			ft = DateTime.Now - st;
			gb.DrawString(ft.TotalMilliseconds.ToString() + "ms", Font, Brushes.White, 0, 0);
			gb.DrawString((1000 / ft.TotalMilliseconds).ToString() + " FPS", Font, Brushes.White, 0, 16);
			gf.DrawImage(gi, 0, 0);
		}

		#endregion Draw
		#region Methods

		#endregion Methods

	}
}
