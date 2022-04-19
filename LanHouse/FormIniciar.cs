using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanhouse
{
    public partial class FormIniciar : Form
    {
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        List<Cliente> listaClientes;
        Form1 form1;
        string logado;
        
        public FormIniciar(List<Cliente> listaClientes, Form1 form1, string logado)
        {
            InitializeComponent();
            this.listaClientes = listaClientes;
            this.form1 = form1;
            form1.cancelar = false;
            this.logado = logado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (logado)
            {
                case "logado":
                    TestarLogin(ref form1.logado);
                    break;
                case "logado2":
                    TestarLogin(ref form1.logado2);
                    break;
                case "logado3":
                    TestarLogin(ref form1.logado3);
                    break;
                case "logado4":
                    TestarLogin(ref form1.logado4);
                    break;
                case "logado5":
                    TestarLogin(ref form1.logado5);
                    break;
                case "logado6":
                    TestarLogin(ref form1.logado6);
                    break;
                case "logado7":
                    TestarLogin(ref form1.logado7);
                    break;
                case "logado8":
                    TestarLogin(ref form1.logado8);
                    break;
            }
        }
        private void TestarLogin(ref bool logado)
        {
            logado = false;
            foreach (Cliente c in listaClientes)
            {
                if (c.Cpf == maskedTextBox2.Text)
                {
                    logado = true;
                    //MessageBox.Show("logado");
                    this.Close();
                    break;
                }
            }
            if (logado == false)
            {
                MessageBox.Show("nenhum usuario com esse cpf foi encontrado");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            form1.cancelar = true;
            this.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
    }
}
