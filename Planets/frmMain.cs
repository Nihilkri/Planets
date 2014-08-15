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
		/// <summary>
		/// Total number of frames elapsed since start
		/// </summary>
		private static ulong _tfr = 0; public static ulong tfr { get { return _tfr; } }

		#endregion Program
		#region Graphics
		public static Bitmap TitleBackground = new Bitmap(@"\\NIHILKRI\Shared\Alien-Planet-In-Nature.jpg");

		#endregion Graphics

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


			for(int q = 0 ; q < 256 ; q++) {
				starsystems.Add(new StarSystemDef() { name = q.ToString(), x = rng.Next(fx), y = rng.Next(fy) });
				starsystems[q].stars.Add(new StarDef());
				starsystems[q].planets.Add(new PlanetDef());
			}

			species.Add(new SpeciesDef() { name = "Hiserati" });
			empires.Add(new EmpireDef() { name = "Serati" });

			int i = rng.Next(starsystems.Count());
			PlanetDef p = empires[0].homeworld = starsystems[i].planets[rng.Next(starsystems[i].planets.Count())];
			p.owner = empires[0];
			p.pop.Add(species.Find(x => x.name == "Hiserati"), 25000);




			tim.Start();
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
		private void frmMain_MouseMove(object sender, MouseEventArgs e) {
			Text = e.Location.ToString(); mp = e.Location;
		}
		private void Form1_Paint(object sender, PaintEventArgs e) { gf.DrawImage(gi, 0, 0); }
		private void tim_Tick(object sender, EventArgs e) { Calc(); Draw(); _tfr++; }

		#endregion Events
		#region Calc
		private void Calc() {
			st = DateTime.Now;
			//gb.Clear(Color.Black);


		}

		#endregion Calc
		#region Draw
		private void Draw() {
			switch(GS) {
				case eGS.Title: DrawTitle(); break;

				default: GS = eGS.Title; break;
			}

			ft = DateTime.Now - st;
			gb.DrawString(ft.TotalMilliseconds.ToString() + "ms", Font, Brushes.White, 0, 0);
			gb.DrawString((1000 / ft.TotalMilliseconds).ToString() + " FPS", Font, Brushes.White, 0, 16);
			gf.DrawImage(gi, 0, 0);
		}
		private Point mp = new Point();
		private Font titlefont = new Font("Razer Header Regular", 72, FontStyle.Italic);
		private Font menufont = new Font("Razer Header Regular", 18, FontStyle.Italic);
		private Button newgame;
		private void DrawTitle() {
			gb.DrawImage(TitleBackground, 0, 0, fx, fy);

			//gb.DrawString("Planets!", new Font("Razer Header Regular", 73, FontStyle.Italic), Brushes.Red, 828, 178);
			//gb.DrawString("Planets!", titlefont, Brushes.White, 1009, 48);//mp);//830, 180);
			gb.DrawString("Planets!", titlefont, Brushes.White, mp);//830, 180);
			tim.Interval = 250;
			//newgame = new Button() { Left = 50, Top = 800 }; newgame.Show();
			gb.DrawString("New Game   " + new string(' ', (int)(4-(tfr % 4))) + " < < <", menufont, Brushes.Gray, 50, 800);
			gb.DrawString("Load Game", menufont, Brushes.Gray, 50, 825);
			gb.DrawString("Options", menufont, Brushes.Gray, 50, 850);
			gb.DrawString("Quit", menufont, Brushes.Gray, 50, 875);

		}
		#endregion Draw
		#region Methods
		#region Data Gathering

		#endregion Data Gathering

		#endregion Methods

	}
}
