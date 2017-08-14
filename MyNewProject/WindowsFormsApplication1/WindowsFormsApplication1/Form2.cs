using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Устанавливаем нечеткие флаги для НЛК1
            label9.Text = Form1.S1;
            label10.Text = Form1.Str1;
            label11.Text = Form1.S2;
            //Устанавливаем нечеткие флаги для НЛК2
            label12.Text = Form1.S1;
            label13.Text = Form1.Str2;
            label14.Text = Form1.S2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Закрываем окно формы 2
            this.Close();
            //Выполняем переход к окну главного меню, формы 1
            //Скрываем форму 2
            Hide();
            Form1 Главное_меню = new Form1();
            Главное_меню.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Выполняем возврат на форму 1
            //Скрываем форму 2
            Hide();
            Form1 Главное_меню = new Form1();
            Главное_меню.ShowDialog();
        }
    }
}
