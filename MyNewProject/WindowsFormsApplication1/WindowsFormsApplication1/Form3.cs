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
    public partial class Form3 : Form
    {
        public static Form3 SelfRef
        {
            get;
            set;
        }
        //Выполняем грамотное обращение к переменной Select Two
        //для передачи в нее значений для другой формы
        //Инкапсулируем переменную SelectOne
        public static int SelectOne
        {
            get { return select_one; }
            set { select_one = value; }
        }
        public Form3()
        {
            SelfRef = this;
            InitializeComponent();
        }
        //Объявляем переменную SelectOne
        private static int select_one;
        //Инициализируем значение признака, что кнопка 1 была нажата
        //Изначально кнопка не была нажата
        bool SignOne = false;
        //При нажатии на кнопку 1 выполняется запуск метода Одноточечный Оператор Кроссинговера
        private void button1_Click(object sender, EventArgs e)
        {
            //Кнопка 1 была нажата
            SignOne = true;
            //Проверяем истинность логической переменной
            if (SignOne)
            {
                //Присвоение переменной значения
                select_one = 1;
            }
            else { }
            //Form1.SelfRef.SinglePointOK(Form1.A);
            //Скрываем форму 3
            this.Hide();
            //Выполняем вызов формы 1
            Form1.SelfRef.Show();
        }
        //Инициализируем значение признака, что кнопка 2 была нажата
        //Изначально кнопка не была нажата
        bool SignTwo = false;
        //При нажатии на кнопку 2 выполняется запуск метода Двухточечный Оператор Кроссинговера
        private void button2_Click(object sender, EventArgs e)
        {
            //Кнопка 2 была нажата
            SignTwo = true;
            //Проверяем истинность логической переменной
            if (SignTwo)
            {
                //Присвоение переменной значения
                select_one = 2;
            }
            else { }
            //Form1.SelfRef.TwoPointOK(Form1.A);
            //Скрываем форму 3
            this.Hide();
            //Выполняем вызов формы 1
            Form1.SelfRef.Show();
        }
        //Инициализируем значение признака, что кнопка 3 была нажата
        //Изначально кнопка не была нажата
        bool SignTree = false;
        //При нажатии на кнопку 3 выполняется запуск метода Трехточечный Оператор Кроссинговера
        private void button3_Click(object sender, EventArgs e)
        {
            //Кнопка 3 была нажата
            SignTree = true;
            //Проверяем истинность логической переменной
            if (SignTree)
            {
                //Присвоение переменной значения
                select_one = 3;
            }
            else { }
            //Form1.SelfRef.Ordering(Form1.A);
            //Скрываем форму 3
            this.Hide();
            //Выполняем вызов формы 1
            Form1.SelfRef.Show();
        }
    }
}
