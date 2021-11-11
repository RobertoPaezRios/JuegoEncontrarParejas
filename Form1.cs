using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoJugadoresFutbol
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        int contClicks = 0, intentos = 5, idBoton1 = 9, idBoton2 = 9, puntos = 0;
        bool victoria = false, pareja = false;
        cBoton[] botones = {
                new cBoton("boton1", ""),
                new cBoton("boton2", ""),
                new cBoton("boton3", ""),
                new cBoton("boton4", ""),
                new cBoton("boton5", ""),
                new cBoton("boton6", ""),
                new cBoton("boton7", ""),
                new cBoton("boton8", ""),
            };


        public Form1()
        {
            InitializeComponent();
        }

        public class cBoton
        {
            int numero = 0;
            string texto = "", idBoton = "";
            bool volteado;

            public cBoton(string idBoton, string texto)
            {
                this.idBoton = idBoton;
                this.texto = texto;
                this.volteado = false;
            }

            public void setNumero(int numero) { this.numero = numero; }
            public void setTexto(string texto) { this.texto = texto; }
            public void setidBoton(string idBoton) { this.idBoton = idBoton; }
            public void setVolteado(bool volteado) { this.volteado = volteado; }

            public int getNumero() { return this.numero; }
            public string getTexto() { return this.texto; }
            public string getidBoton() { return this.idBoton; }
            public bool getVolteado() { return this.volteado; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] numeros = { 1, 1, 2, 2, 3, 3, 4, 4 };
            int aleatorioPri = 0, aleatorioSec = 0, auxCamb = 0;

            //ESTABLECER UN NUMERO A CADA BOTON//
            for (int i = 0; i <= 7; i++) {
                botones[i].setNumero(numeros[i]);
                botones[i].setTexto(botones[i].getNumero().ToString());
            }
            button1.Text = botones[0].getTexto();
            button2.Text = botones[1].getTexto();
            button3.Text = botones[2].getTexto();
            button4.Text = botones[3].getTexto();
            button5.Text = botones[4].getTexto();
            button6.Text = botones[5].getTexto();
            button7.Text = botones[6].getTexto();
            button8.Text = botones[7].getTexto();
            ////////////////////////////////////////

            // CAMBIAR LAS POSICIONES DE LOS NUMEROS//
            for (int i = 0; i <= 50; i++) {
                aleatorioPri = rand.Next(0, 7);
                aleatorioSec = rand.Next(0, 7);
                auxCamb = botones[aleatorioPri].getNumero();
                botones[aleatorioPri].setNumero(botones[aleatorioSec].getNumero());
                botones[aleatorioSec].setNumero(auxCamb);
            }
            //CAMBIAR EL TEXTO CON LOS NUEVOS NUMEROS//
            for (int i = 0; i <= 7; i++) {
                botones[i].setTexto(botones[i].getNumero().ToString());
            }
            button1.Text = botones[0].getTexto();
            button2.Text = botones[1].getTexto();
            button3.Text = botones[2].getTexto();
            button4.Text = botones[3].getTexto();
            button5.Text = botones[4].getTexto();
            button6.Text = botones[5].getTexto();
            button7.Text = botones[6].getTexto();
            button8.Text = botones[7].getTexto();
            ////////////////////////////////////////////

            //OCULTAR TODOS LOS NUMEROS//

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            ///////////////////////////////
        }

        public void buscarPareja ()
        {
            int cont = 0;

            if (intentos == 0) {
                MessageBox.Show("Has perdido", "Derrota",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
                this.Close(); 
            } 
            for (int i = 0; i <= 7; i++)
            {
                if (botones[i].getVolteado() == true)
                {
                    cont++;        
                    
                }
            }
            if (cont == 8)
            {
                MessageBox.Show("Has ganado!", "Victoria",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
                
            if (botones[idBoton1].getNumero() == botones[idBoton2].getNumero())
            {
                if (idBoton1 == 0) { button1.Enabled = false; }
                if (idBoton1 == 1) { button2.Enabled = false; }
                if (idBoton1 == 2) { button3.Enabled = false; }
                if (idBoton1 == 3) { button4.Enabled = false; }
                if (idBoton1 == 4) { button5.Enabled = false; }
                if (idBoton1 == 5) { button6.Enabled = false; }
                if (idBoton1 == 6) { button7.Enabled = false; }
                if (idBoton1 == 7) { button8.Enabled = false; }
                ///////////////////////////////////////////////
                if (idBoton2 == 0) { button1.Enabled = false; }
                if (idBoton2 == 1) { button2.Enabled = false; }
                if (idBoton2 == 2) { button3.Enabled = false; }
                if (idBoton2 == 3) { button4.Enabled = false; }
                if (idBoton2 == 4) { button5.Enabled = false; }
                if (idBoton2 == 5) { button6.Enabled = false; }
                if (idBoton2 == 6) { button7.Enabled = false; }
                if (idBoton2 == 7) { button8.Enabled = false; }
                puntos += 2;
                pareja = true;
                botones[idBoton1].setVolteado(true);
                botones[idBoton2].setVolteado(true);
                contClicks = 0;
                idBoton1 = 9;
                idBoton2 = 9;
            } else
            {
                pareja = false;
                botones[idBoton1].setVolteado(false);
                botones[idBoton2].setVolteado(false);
                System.Threading.Thread.Sleep(1000);
                if (idBoton1 == 0) { button1.Text = ""; }
                if (idBoton1 == 1) { button2.Text = ""; }
                if (idBoton1 == 2) { button3.Text = ""; }
                if (idBoton1 == 3) { button4.Text = ""; }
                if (idBoton1 == 4) { button5.Text = ""; }
                if (idBoton1 == 5) { button6.Text = ""; }
                if (idBoton1 == 6) { button7.Text = ""; }
                if (idBoton1 == 7) { button8.Text = ""; }
                ///////////////////////////////////////////////
                if (idBoton2 == 0) { button1.Text = ""; }
                if (idBoton2 == 1) { button2.Text = ""; }
                if (idBoton2 == 2) { button3.Text = ""; }
                if (idBoton2 == 3) { button4.Text = ""; }
                if (idBoton2 == 4) { button5.Text = ""; }
                if (idBoton2 == 5) { button6.Text = ""; }
                if (idBoton2 == 6) { button7.Text = ""; }
                if (idBoton2 == 7) { button8.Text = ""; }
                idBoton1 = 9; idBoton2 = 9;
                contClicks = 0;
                intentos--;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = botones[0].getTexto();
            contClicks++;
            botones[0].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 0; }
            if (idBoton1 == 9) { idBoton1 = 0; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = botones[1].getTexto();
            contClicks++;
            botones[1].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 1; }
            if (idBoton1 == 9) { idBoton1 = 1; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = botones[2].getTexto();
            contClicks++;
            botones[2].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 2; }
            if (idBoton1 == 9) { idBoton1 = 2; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = botones[3].getTexto();
            contClicks++;
            botones[3].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 3; }
            if (idBoton1 == 9) { idBoton1 = 3; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = botones[4].getTexto();
            contClicks++;
            botones[4].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 4; }
            if (idBoton1 == 9) { idBoton1 = 4; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = botones[5].getTexto();
            contClicks++;
            botones[5].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 5; }
            if (idBoton1 == 9) { idBoton1 = 5; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = botones[6].getTexto();
            contClicks++;
            botones[6].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 6; }
            if (idBoton1 == 9) { idBoton1 = 6; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = botones[7].getTexto();
            contClicks++;
            botones[7].setVolteado(true);
            if (idBoton1 != 9 && idBoton2 == 9) { idBoton2 = 7; }
            if (idBoton1 == 9) { idBoton1 = 7; }
            if (contClicks == 2) { buscarPareja(); contClicks = 0; }            
            
        }
    }
}
