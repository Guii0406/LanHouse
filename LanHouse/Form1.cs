using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lanhouse
{
    public partial class Form1 : Form
    {
        public bool cancelar = false;
        public bool logado = false, logado2 = false, logado3 = false, logado4 = false, logado5 = false, logado6 = false, logado7 = false, logado8 = false;
        List<Caixa> listaCaixa = new List<Caixa>();
        List<ClienteEspera> listaEspera = new List<ClienteEspera>();
        List<Cliente> listaClientes = new List<Cliente>();

        Point DragCursor;
        Point DragForm;
        bool Dragging;
        double precoImpressao = 0;
        bool pc1, pc2, pc3, pc4, pc5, pc6, pc7, pc8;
        int segundo, minuto, segundo2, minuto2, segundo3, minuto3, segundo4, minuto4, segundo5, minuto5, segundo6, minuto6, segundo7, minuto7, segundo8, minuto8;
        public Form1()
        {
            InitializeComponent();
        }
        
        //CADASTRO DE CLIENTES
        private void button11_Click(object sender, EventArgs e)
        {
            listaClientes.Add(new Cliente(textBox2.Text, maskedTextBox2.Text, maskedTextBox3.Text, textBox5.Text));
            textBox2.Clear();
            maskedTextBox3.Clear();
            textBox5.Clear();
            maskedTextBox2.Clear();
        }

        //FECHAR, MINIMIZAR E MOVIMENTAR FORM COM PAINEL
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }


        //INICIAR USO
        private void iniciarUso(Label labelStatus, Label labelTimer, Timer timer)
        {
            labelStatus.Text = "•Indisponivel";
            labelStatus.ForeColor = Color.Red;



            labelTimer.Visible = true;

            timer.Start();
        }
        private void iniciarUsoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Label labelStatus = null, labelTimer= null;
            Timer timerr = null;
            bool logadoo = false;
            FormIniciar formIniciar = null;

            //if(logado == true)
            //{
            //    MessageBox.Show("logado");
            //    return;
            //}

            if (pc1)
            {
                //iniciarUso(label1, label9, timer1);
                labelStatus = label1;
                labelTimer = label9;
                timerr = timer1;
                //logadoo = logado;
                 formIniciar = new FormIniciar(listaClientes, this, "logado");

            }
            else if (pc2)
            {
                //iniciarUso(label2, label10, timer2);
                labelStatus = label2;
                labelTimer = label10;
                timerr = timer2;
                //logadoo = logado2;
                formIniciar = new FormIniciar(listaClientes, this, "logado2");

            }
            else if (pc3)
            {
                //iniciarUso(label3, label11, timer3);
                labelStatus = label3;
                labelTimer = label11;
                timerr = timer3;
                formIniciar = new FormIniciar(listaClientes, this, "logado3");
            }
            else if (pc4)
            {
                //iniciarUso(label4, label12, timer4);
                labelStatus = label4;
                labelTimer = label12;
                timerr = timer4;
                formIniciar = new FormIniciar(listaClientes, this, "logado4");

            }
            else if (pc5)
            {
                //iniciarUso(label5, label13, timer5);
                labelStatus = label5;
                labelTimer = label13;
                timerr = timer5;
                formIniciar = new FormIniciar(listaClientes, this, "logado5");
            }
            else if (pc6)
            {
                //iniciarUso(label6, label14, timer6);
                labelStatus = label6;
                labelTimer = label14;
                timerr = timer6;
                formIniciar = new FormIniciar(listaClientes, this, "logado6");
            }
            else if (pc7)
            {
                //iniciarUso(label7, label15, timer7);
                labelStatus = label7;
                labelTimer = label15;
                timerr = timer7;
                formIniciar = new FormIniciar(listaClientes, this, "logado7");
            }
            else if (pc8)
            {
                //iniciarUso(label8, label16, timer8);
                labelStatus = label8;
                labelTimer = label16;
                timerr = timer8;
                formIniciar = new FormIniciar(listaClientes, this, "logado8");
            }
            formIniciar.ShowDialog();
            if (cancelar == true)
            {
                return;
            }

            iniciarUso(labelStatus, labelTimer, timerr);
        }


        //PARAR USO
        private void InterromperUso(Label labelStatus, Label labelTimer, Timer timer, ref int minutoo, ref int segundoo, string logadoo)
        {
            if (minutoo == 0 && segundoo == 0)
            {
                return;
            }

            timer.Stop();
            labelStatus.Text = "•Disponivel";
            labelStatus.ForeColor = Color.Green;
            labelTimer.Visible = false;

            CalcularPreco(minutoo, segundoo, logadoo);
            minutoo = 0;
            segundoo = 0;
            labelTimer.Text = "00:00";
        }
        private void interromperUsoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pc1)
            {
                InterromperUso(label1, label9, timer1, ref minuto, ref segundo, "logado");
            }
            else if (pc2)
            {
                InterromperUso(label2, label10, timer2, ref minuto2, ref segundo2, "logado2");
            }
            else if (pc3)
            {
                InterromperUso(label3, label11, timer3, ref minuto3, ref segundo3, "logado3");
            }
            else if (pc4)
            {
                InterromperUso(label4, label12, timer4, ref minuto4, ref segundo4, "logado4");
            }
            else if (pc5)
            {
                InterromperUso(label5, label13, timer5, ref minuto5, ref segundo5, "logado5");
            }
            else if (pc6)
            {
                InterromperUso(label6, label14, timer6, ref minuto6, ref segundo6, "logado6");
            }
            else if (pc7)
            {
                InterromperUso(label7, label15, timer7, ref minuto7, ref segundo7, "logado7");
            }
            else if (pc8)
            {
                InterromperUso(label8, label16, timer8, ref minuto8, ref segundo8, "logado8");
            }
        }
        private void testarDesconto(ref bool logadoo, int minutoo, int segundoo)
        {
            //if (logadoo == true)
            //{
            //    MessageBox.Show("DESCONTO");
            //}
            //else
            //{
            //    MessageBox.Show("SEM DESCONTO");
            //}

            double preco = 0;
            string tempo;
            if (minutoo == 0)
            {
                preco = 1;
                if(logadoo == true)
                {
                    preco = 0.75;
                }
                tempo = $"{segundoo} segundos";
                MessageBox.Show($"o tempo total foi de {segundoo} segundos, O preço minimo é R${preco}");
            }
            else if (minutoo < 5)
            {
                preco = 1;
                if (logadoo == true)
                {
                    preco = 0.75;
                }
                tempo = $"{minutoo}:{segundoo}";
                MessageBox.Show($"o tempo total foi de {minutoo}:{segundoo} , O preço minimo é R${preco}");
            }
            else
            {
                preco = minutoo / 5;
                if (logadoo == true)
                {
                    //preco = preco - (25.0/100.0);
                    preco -= (preco * (25.0 / 100.0));
                }
                tempo = $"{minutoo}:{segundoo}";
                MessageBox.Show($"o tempo total foi de {minutoo}:{segundoo} , cobre R${preco}");
            }

            InserirNoCaixa($"Uso do computador ({tempo})", preco);
            logadoo = false;
        }

        //CALCULAR PRECO, MOSTRAR E MANDAR PRO CAIXA
        private void CalcularPreco(int minutoo, int segundoo, string logadoo)
        {
            switch (logadoo)
            {
                case "logado":
                    testarDesconto(ref logado, minutoo, segundoo);
                    break;
                case "logado2":
                    testarDesconto(ref logado2, minutoo, segundoo);
                    break;
                case "logado3":
                    testarDesconto(ref logado3, minutoo, segundoo);
                    break;
                case "logado4":
                    testarDesconto(ref logado4, minutoo, segundoo);
                    break;
                case "logado5":
                    testarDesconto(ref logado5, minutoo, segundoo);
                    break;
                case "logado6":
                    testarDesconto(ref logado6, minutoo, segundoo);
                    break;
                case "logado7":
                    testarDesconto(ref logado7, minutoo, segundoo);
                    break;
                case "logado8":
                    testarDesconto(ref logado8, minutoo, segundoo);
                    break;
            }          
        }
        //INSERIR NO CAIXA
        private void InserirNoCaixa(string servico, double total)
        {
            listaCaixa.Add(new Caixa(servico, total));
            AtualizarCaixa(listaCaixa);
        }

        private void AtualizarCaixa(List<Caixa> lista)
        {
            listView1.Items.Clear();
            foreach (Caixa c in lista)
            {
                string[] itemCaixa = new string[2] { c.sevico, c.total.ToString("c2") };
                listView1.Items.Add(new ListViewItem(itemCaixa));

            }
            double totalCaixa = listaCaixa.Sum(x => x.total);
            label22.Text = $"Total: {totalCaixa.ToString("c2")}";
            comboBox1.Text = "Selecione";
        }
        //REMOVER DO CAIXA
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int index = listView1.SelectedIndices[0];
                listaCaixa.RemoveAt(index);
                AtualizarCaixa(listaCaixa);
            }
            catch (Exception erro) { MessageBox.Show("Selecione um item válido"); }
        }
        //ADICIONAR A FILA
        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || maskedTextBox1.Text == "(  )      -")
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            listaEspera.Add(new ClienteEspera(textBox1.Text, maskedTextBox1.Text));
            AtualizarFila(listaEspera);
            textBox1.Clear();
            maskedTextBox1.Clear();
        }
        private void AtualizarFila(List<ClienteEspera> lista)
        {
            listView2.Items.Clear();
            foreach (ClienteEspera c in lista)
            {
                string[] cliente = new string[2] { c.nome, c.celular };
                listView2.Items.Add(new ListViewItem(cliente));
            }
        }
        //REMOVER DA FILA
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView2.SelectedIndices[0];
                listaEspera.RemoveAt(index);
                AtualizarFila(listaEspera);
            }
            catch (Exception erro) { MessageBox.Show("Selecione um item válido"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes(listaClientes);
            formClientes.ShowDialog();
        }

        //IMPRESSÃO
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecoImpressao();
        }

        private void CalcularPrecoImpressao()
        {
            precoImpressao = (double)numericUpDown1.Value;

            if (radioButton1.Checked)
            {
                precoImpressao *= 2;
            }

            label21.Text = $"Total: {precoImpressao.ToString("c2")}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CalcularPrecoImpressao();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CalcularPrecoImpressao();
        }
        //VALIDAR IMPRESSÃO
        private void button9_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Insira um número de folhas");
                return;
            }
            MessageBox.Show($"Impressão no valor de {precoImpressao.ToString("c2")} validada");

            InserirNoCaixa("Impressão", precoImpressao);
        }
        //FILTRAR CAIXA
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Caixa> listaFiltradaCaixa = new List<Caixa>();
            if (comboBox1.Text == "Computadores")
            {
                listaFiltradaCaixa = listaCaixa.FindAll(x => x.sevico[0] == 'U');
            }
            else if (comboBox1.Text == "Impressões")
            {
                listaFiltradaCaixa = listaCaixa.FindAll(x => x.sevico[0] == 'I');
            }
            else
            {
                listaFiltradaCaixa = listaCaixa;
            }
            listView1.Items.Clear();
            AtualizarCaixa(listaFiltradaCaixa);
            label22.Text = $"Total: {listaFiltradaCaixa.Sum(x => x.total).ToString("c2")}";

        }

        


        //PAINEL DINAMICO DO LADO DOS BOTOES
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Top = button2.Top;
            tabControl1.SelectTab(0);
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Top = btn_4.Top;
            tabControl1.SelectTab(1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Top = button5.Top;
            tabControl1.SelectTab(2);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Top = button6.Top;
            tabControl1.SelectTab(3);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Top = button10.Top;
            tabControl1.SelectTab(4);
        }


        //TESTAR PC CLICADO
        private void PcClicado(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h)
        {
            pc1 = a;
            pc2 = b;
            pc3 = c;
            pc4 = d;
            pc5 = e;
            pc6 = f;
            pc7 = g;
            pc8 = h;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PcClicado(true, false, false, false, false, false, false, false);
            }
        }
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PcClicado(false, true, false, false, false, false, false, false);
            }
        }
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, true, false, false, false, false, false);
        }
        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, false, true, false, false, false, false);
        }
        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, false, false, true, false, false, false);
        }
        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, false, false, false, true, false, false);
        }
        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, false, false, false, false, true, false);
        }
        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            PcClicado(false, false, false, false, false, false, false, true);
        }


        //TIMERS
        private void Timer(Label label, ref int minutoo, ref int segundoo)
        {
            segundoo++;
            if (segundoo < 10)
            {
                if (minutoo == 0)
                {
                    label.Text = $"00:0{segundoo}";
                }
                else
                {
                    if (minutoo < 10)
                    {
                        label.Text = $"0{minutoo}:0{segundoo}";
                    }
                    else
                    {
                        label.Text = $"{minutoo}:0{segundoo}";
                    }
                }
            }
            else
            {
                if (minutoo == 0)
                {
                    label.Text = $"00:{segundoo}";
                }
                else
                {
                    if (minutoo < 10)
                    {
                        label.Text = $"0{minutoo}:{segundoo}";
                    }
                    else
                    {
                        label.Text = $"{minutoo}:{segundoo}";
                    }
                }
            }
            if (segundoo == 60)
            {
                minutoo++;
                segundoo = 0;
                if (segundoo < 10)
                {
                    if (minutoo < 10)
                    {
                        label.Text = $"0{minutoo}:0{segundoo}";
                    }
                    else
                    {
                        label.Text = $"{minutoo}:0{segundoo}";
                    }
                }
                else
                {
                    if (minutoo < 10)
                    {
                        label.Text = $"0{minutoo}:{segundoo}";
                    }
                    else
                    {
                        label.Text = $"{minutoo}:{segundoo}";
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer(label9, ref minuto, ref segundo);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Timer(label10, ref minuto2, ref segundo2);
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            Timer(label11, ref minuto3, ref segundo3);
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            Timer(label12, ref minuto4, ref segundo4);
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            Timer(label13, ref minuto5, ref segundo5);
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            Timer(label14, ref minuto6, ref segundo6);
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            Timer(label15, ref minuto7, ref segundo7);
        }
        private void timer8_Tick(object sender, EventArgs e)
        {
            Timer(label16, ref minuto8, ref segundo8);
        }
    }
}
