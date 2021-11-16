using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hackaton
{
    public partial class Form1 : Form
    {
        public int t = 0;

        public Form1()
        {
            InitializeComponent();
        }

        bool[,] estados = new bool[8, 16] // rojo, amarillo, verde, flecha
            {   {false, false, true, false,  true, false, false, false,  true, false, false, true,   true, false, false, false},
                {false, true,  true, false,  true, false, false, false,  true, false, false, true,   true, false, false, false},
                {true, false, false, true,   false, false, true, false,  true, false, false, false,  true, false, false, false},
                {true, false, false, true,   false, true,  true, false,  true, false, false, false,  true, false, false, false},
                {true, false, false, false,  true, false, false, false,  false, false, true, false,  true, false, false, true},
                {true, false, false, false,  true, false, false, false,  false, true,  true, false,  true, false, false, true},
                {true, false, false, false,  true, false, false, true,   true, false, false, false,  false, false, true, false},
                {true, false, false, false,  true, false, false, true,   true, false, false, false,  false, true,  true, false}
            };

        int[] tiempos = new int[8]
        {
            9000,
            1000,
            9000,
            1000,
            9000,
            1000,
            9000,
            1000
        };


        public void SetSemaforo1(bool rojo, bool amarillo, bool verde, bool flecha)
        {
            SVerde1.Visible = verde;
            SAmarillo1.Visible = amarillo;
            SRojo1.Visible = rojo;
            SFlechaA1.Visible = !flecha;
        }

        public void SetSemaforo2(bool rojo, bool amarillo, bool verde, bool flecha)
        {
            SVerde2.Visible = verde;
            SAmarillo2.Visible = amarillo;
            SRojo2.Visible = rojo;
            SFlechaA2.Visible = !flecha;
        }

        public void SetSemaforo3(bool rojo, bool amarillo, bool verde, bool flecha)
        {
            SVerde3.Visible = verde;
            SAmarillo3.Visible = amarillo;
            SRojo3.Visible = rojo;
            SFlechaA3.Visible = !flecha;
        }

        public void SetSemaforo4(bool rojo, bool amarillo, bool verde, bool flecha)
        {
            SVerde4.Visible = verde;
            SAmarillo4.Visible = amarillo;
            SRojo4.Visible = rojo;
            SFlechaA4.Visible = !flecha;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSemaforo1(false, false, false, false);
            SetSemaforo2(false, false, false, false);
            SetSemaforo3(false, false, false, false);
            SetSemaforo4(false, false, false, false);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetSemaforo1(estados[t, 0], estados[t, 1], estados[t, 2], estados[t, 3]);
            SetSemaforo2(estados[t, 4], estados[t, 5], estados[t, 6], estados[t, 7]);
            SetSemaforo3(estados[t, 8], estados[t, 9], estados[t, 10], estados[t, 11]);
            SetSemaforo4(estados[t, 12], estados[t, 13], estados[t, 14], estados[t, 15]);
            timer1.Interval = tiempos[t];

            t++;

            if (t >= 8) t = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            if (timer1.Enabled) button2.Text = "Pausar";
            else button2.Text = "Reiniciar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = 0;
            timer1.Interval = 100;
            timer1.Enabled = true;
        }
    }
}
