using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Globalization;


namespace Mad_Minute_Monday
{
	public partial class Form1 : MaterialForm
	{
		public Form1()
		{
			InitializeComponent();

			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue200, Primary.Blue400, Primary.Cyan50, Accent.LightBlue200, TextShade.WHITE);
		}
		static Random rd = new Random();
		static int nume = rd.Next(1, 10);
		static int denom = rd.Next(nume, 10);
		static int nume1 = rd.Next(1, 10);
		static int denom1 = rd.Next(nume1, 10);
		void generateNew()
		{
			while (nume==denom)
				denom = rd.Next(1, 10);
			lblnumerator.Text = "" + nume.ToString();
			lbldenominator.Text = "" + denom.ToString();


			
			while (nume1 == denom1)
				denom1 = rd.Next(1, 10);
			lblnume1.Text = "" + nume1.ToString();
			lbldenom1.Text = "" + denom1.ToString();
		}

		static char[] signList = { '+', '-', 'x', '÷' };
		//int index = rd.Next(signList.Length);
		int Sindex = 0;
		private void Form1_Load(object sender, EventArgs e)
		{
			generateNew();

			lblSign.Text = signList[0].ToString();
		}
		static int gcd(int a, int b)
		{
			//find the gcd using the Euclid’s algorithm
			while (a != b)
				if (a < b) b = b - a;
				else a = a - b;
			//since at this point a=b, the gcd can be either of them
			//it is necessary to pass the gcd to the main function
			return (a);
		}
		static int division(int a, int b)
		{
			int remainder = a, quotient = 0;
			while (remainder >= b)
			{
				remainder = remainder - b;
				quotient++;
			}
			return (quotient);
		}
		int aDenom { get; set; }
		int aNume { get; set; }
		void checkAnswer()
		{
			/*switch (lblSign.Text)
			{
				case "+":
					double answer = (nume / denom) + (nume1 / denom1);
					if (doubleans.Text == Math.Round(answer, 1).ToString())
					{
						MessageBox.Show("Correct!");
					}
					if (string.IsNullOrEmpty(doubleans.Text))
					{
						MessageBox.Show("Empty");
					}
					break;
			}*/
			//double firstFraction = Convert.ToDouble(Convert.ToDouble(lblnumerator.Text) / Convert.ToDouble(lbldenominator.Text));
			//double lastFraction = Convert.ToDouble(Convert.ToDouble(lblnume1.Text) / Convert.ToDouble(lbldenom1.Text));
			//double answerB = Convert.ToDouble(firstFraction+lastFraction);
			//string answer = Dec2Frac(Math.Round(answerB,1));
			aDenom = Convert.ToInt32(lbldenominator.Text) * Convert.ToInt32(lbldenom1.Text);
			aNume = (Convert.ToInt32(lblnumerator.Text) * Convert.ToInt32(lbldenom1.Text)) + (Convert.ToInt32(lbldenominator.Text) * Convert.ToInt32(lblnume1.Text));

			int divisor = gcd(aNume, aDenom);
			if (divisor != 1)
			{
				aNume = aNume / divisor;
				aDenom = aDenom / divisor;
			}
			string answer = aNume + "/" + aDenom;

			if (ansnume.Text==aNume.ToString()&&ansdenom.Text==aDenom.ToString())
			{
				MessageBox.Show("Correct!");
				generateNew();
			}
			else
			{
				MessageBox.Show(answer.ToString()) ;
				ansnume.Clear(); ansdenom.Clear();
				generateNew();
			}
		}

		private void ansdenom_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				checkAnswer();
			}
		}

		private void doubleans_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				checkAnswer();
			}
		}

		private void materialFlatButton1_Click(object sender, EventArgs e)
		{
			checkAnswer();
		}
	}
}
