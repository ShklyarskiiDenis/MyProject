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
    public partial class Form4 : Form
    {
        public static Form4 SelfRef
        {
            get;
            set;
        }
        //Выполняем грамотное обращение к переменной SelectTwo
        //для передачи в нее значений для другой формы
        //Инкапсулируем переменную SelectTwo
        public static int SelectTwo
        {
            get { return select_two; }
            set { select_two = value; }
        }
        public Form4()
        {
            SelfRef = this;
            InitializeComponent();
        }
        //Объявляем переменную select_two
        private static int select_two;
        //Инициализируем значение признака, что кнопка 1 была нажата
        //Изначально кнопка не была нажата
        bool SignOne = false;
        //При нажатии на кнопку 1 выполняется запуск метода Одноточечный Оператор Мутации
        private void button1_Click(object sender, EventArgs e)
        {
            //Кнопка 1 была нажата
            SignOne = true;
            //Проверяем истинность логической переменной
            if (SignOne)
            {
                //Присвоение переменной значения
                select_two = 1;
            }
            else { }
            //Вызываем метод Одноточечный Оператор Мутации
            //Внутри скобок доступен массив из модуля (формы) 1
            //Form1.SelfRef.SinglePointOM(Form1.A);
            //Скрываем форму 4
            this.Hide();
            //Вызов формы 1
            Form1.SelfRef.Show();
        }
        //Инициализируем значение признака, что кнопка 2 была нажата
        //Изначально кнопка не была нажата
        bool SignTwo = false;
        //При нажатии на кнопку 2 выполняется запуск метода Двухточечный Оператор Мутации
        private void button2_Click(object sender, EventArgs e)
        {
            //Кнопка 2 была нажата
            SignTwo = true;
            //Проверяем истинность логической переменной
            if (SignTwo)
            {
                //Присвоение переменной значения
                select_two = 2;
            }
            else { }
            //Вызываем метод Двухточечный Оператор Мутации
            //Внутри скобок доступен массив из модуля (формы) 2
            //Form1.SelfRef.TwoPointOM(Form1.A);
            //Скрываем форму 4
            this.Hide();
            //Вызов формы 1
            Form1.SelfRef.Show();
        }
        //Инициализируем значение признака, что кнопка 3 была нажата
        //Изначально кнопка не была нажата
        bool SignTree = false;
        //При нажатии на кнопку 3 выполняется запуск метода Трехточечный Оператор Мутации
        private void button3_Click(object sender, EventArgs e)
        {
            //Кнопка 3 была нажата
            SignTree = true;
            //Проверяем истинность логической переменной
            if (SignTree)
            {
                //Присвоение переменной значения
                select_two = 3;
            }
            else { }
            //Вызываем метод Трехточечный Оператор Кроссинговера
            //Внутри скобок доступен массив из модуля (формы) 1
            //Form1.SelfRef.ThreePointOM(Form1.A);
            //Скрываем форму 4
            this.Hide();
            //Вызов формы 1
            Form1.SelfRef.Show();
        }
        //Инициализируем значение признака, что кнопка 4 была нажата
        //Изначально кнопка не была нажата
        private bool SignFour = false;
        //При нажатии на кнопку 4 выполняется запуск метода 
        private void button4_Click(object sender, EventArgs e)
        {
            //Кнопка 4 была нажата
            SignFour = true;
            //Проверяем истинность логической переменной
            if (SignFour)
            {
                //Присвоение переменной значения
                select_two = 4;
            }
            else { }
            //Скрываем форму 4
            this.Hide();
            //Вызов формы 1
            Form1.SelfRef.Show();
        }
    }
}
