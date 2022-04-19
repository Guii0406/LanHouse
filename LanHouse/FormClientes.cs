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
    public partial class FormClientes : Form
    {
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        List<Cliente> listaClientes;
        public FormClientes(List<Cliente> listaClientes)
        {
            InitializeComponent();
            this.listaClientes = listaClientes;
            MontarListView();
        }

        void MontarListView()
        {
            listView2.Items.Clear();
            foreach (Cliente c in listaClientes)
            {
                string[] item = new string[4] { c.Nome, c.Cpf, c.Telefone, c.Email };
                listView2.Items.Add(new ListViewItem(item));
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //foreach(Cliente c in listaClientes)
            //{
            //    if(c.Cpf == maskedTextBox2.Text)
            //    {
            //        string[] item = new string[4] {c.Nome, c.Cpf, c.Telefone, c.Email };
            //        listView2.Items.Add(new ListViewItem(item));
            //    }
            //}
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = listView2.SelectedItems[0].Index;
                textBox2.Text = listaClientes[index].Nome;
                maskedTextBox3.Text = listaClientes[index].Telefone;
                textBox5.Text = listaClientes[index].Email;
            }
            catch (Exception erro) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView2.SelectedItems[0].Index;
                listaClientes[index].Nome = textBox2.Text;
                listaClientes[index].Telefone = maskedTextBox3.Text;
                listaClientes[index].Email = textBox5.Text;
                MontarListView();
            }
            catch (Exception erro) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView2.SelectedItems[0].Index;
                listaClientes.RemoveAt(index);
                MontarListView();
                textBox2.Clear();
                textBox5.Clear();
                maskedTextBox3.Clear();
            }
            catch (Exception erro) { }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
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


    }
}
