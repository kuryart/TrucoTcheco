using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class Form1 : Form
    {
        private int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] naipes = new int[] { 1, 2, 3, 4};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            Velocidade();
            Dissonancia2();
            Forca();
            Coragem();
            Seducao();
        }

        private void Velocidade()
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                int velo = numeros[i] * naipes[0];

                lstVelocidade.Items.Add(velo.ToString());

                for (int j = 1; j < naipes.Length; j++)
                {
                    velo = numeros[i] * naipes[j];

                    lstVelocidade.Items[i].SubItems.Add(velo.ToString());
                }
            }
        }

        private void Dissonancia()
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                float disso = 1.0f / numeros[i];

                lstDissonancia.Items.Add((disso * 100).ToString("N0"));

                for (int j = 1; j < naipes.Length; j++)
                {
                    lstDissonancia.Items[i].SubItems.Add((disso * 100).ToString("N0"));
                }
            }
        }

        private void Dissonancia2()
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                float disso = (1.0f / numeros[i]) * 100 * naipes[3];

                lstDissonancia.Items.Add((disso).ToString("N0"));

                for (int j = naipes.Length - 2; j >= 0 ; j--)
                {
                    disso = (1.0f / numeros[i]) * 100 * naipes[j];

                    lstDissonancia.Items[i].SubItems.Add((disso).ToString("N0"));
                }
            }
        }

        private void Forca()
        {
            int vitoriasVelocidade = 0;

            for (int i = 0; i < lstVelocidade.Items.Count; i++)
            {
                lsvForça.Items.Add("");

                for (int j = 0; j < lstVelocidade.Items[i].SubItems.Count; j++)
                {
                    lsvForça.Items[i].SubItems.Add("");
                    vitoriasVelocidade = 0;

                    for (int g = 0; g < lstVelocidade.Items.Count; g++)
                    {
                        for (int h = 0; h < lstVelocidade.Items[g].SubItems.Count; h++)
                        {
                            if (Convert.ToInt32(lstVelocidade.Items[g].SubItems[h].Text.Trim()) < Convert.ToInt32(lstVelocidade.Items[i].SubItems[j].Text.Trim()))
                            {
                                vitoriasVelocidade += 1;
                            }
                        }
                    }

                    lsvForça.Items[i].SubItems[j].Text = vitoriasVelocidade.ToString().Trim();
                }
            }
        }

        private void Coragem()
        {
            int vitoriasDissonancia = 0;

            for (int i = 0; i < lstDissonancia.Items.Count; i++)
            {
                lsvCoragem.Items.Add("");

                for (int j = 0; j < lstDissonancia.Items[i].SubItems.Count; j++)
                {
                    lsvCoragem.Items[i].SubItems.Add("");
                    vitoriasDissonancia = 0;

                    for (int g = 0; g < lstDissonancia.Items.Count; g++)
                    {
                        for (int h = 0; h < lstDissonancia.Items[g].SubItems.Count; h++)
                        {
                            if (Convert.ToDecimal(lstDissonancia.Items[g].SubItems[h].Text.Trim()) < Convert.ToDecimal(lstDissonancia.Items[i].SubItems[j].Text.Trim()))
                            {
                                vitoriasDissonancia += 1;
                            }
                        }
                    }

                    lsvCoragem.Items[i].SubItems[j].Text = vitoriasDissonancia.ToString().Trim();
                }
            }
        }

        private void Seducao()
        {
            int vitoriasTotal = 0;

            for (int i = 0; i < lstDissonancia.Items.Count; i++)
            {
                lsvSeducao.Items.Add("");

                for (int j = 0; j < lstDissonancia.Items[i].SubItems.Count; j++)
                {
                    lsvSeducao.Items[i].SubItems.Add("");

                    vitoriasTotal = Convert.ToInt32(lsvForça.Items[i].SubItems[j].Text.Trim()) + Convert.ToInt32(lsvCoragem.Items[i].SubItems[j].Text.Trim());

                    lsvSeducao.Items[i].SubItems[j].Text = vitoriasTotal.ToString().Trim();
                }
            }
        }
    }
}
