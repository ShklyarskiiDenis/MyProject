using System;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static Form1 SelfRef { get; set; }
        //Выполняем грамотное обращение к строковым переменным
        //Инкапсулируем переменную S1
        public static string S1
        {
            get { return s1; }
            set { s1 = value; }
        }
        //Инкапсулируем переменную S2
        public static string S2
        {
            get { return s2; }
            set { s2 = value; }
        }
        //Инкапсулируем переменную Str1
        public static string Str1
        {
            get { return str1; }
            set { str1 = value; }
        }
        //Инкапсулируем переменную Str2
        public static string Str2
        {
            get { return str2; }
            set { str2 = value; }
        }
        //Задаем матрицу назначений
        int[,] a = new int[10000, 10000];
        private static string s1;
        private static string s2;
        private static string str1;
        private static string str2;
        //Задаем вектор эффективностей
        double[] b = new double[10000];
        //Задаем вектор коэффициентов модуля
        double[] c = new double[10000];
        //Задаем вектор для переопределения номеров команд
        int[] J = new int[10000]; 
  
        public Form1()
        {
            SelfRef = this;
            InitializeComponent();
        }
        //Событие, происходящее при нажатии на кнопку Получить Решение
        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем вещественную константу, используется в Алгоритме Лягушек
            double C = 0;
            //Проверка на неправильный ввод
            try
            {
                //Вводим константу с клавиатуры
                C = Convert.ToDouble(textBox7.Text);
            }
            //Блок, в котором отлавливаются исключения при помощи ключ. слова Exception
            catch (Exception)
            {
                //Вывод предупреждающего сообщения
                MessageBox.Show("Повторите ввод числовой контсанты С, будет выставлено значение по умолчанию!");
            }
            finally
            {
                //Логическая переменная для входа в цикл
                bool flag = true;
                //Цикл выполняется, пока условие истинно
                while (flag)
                {
                    //Если ввод удался, то присваиваем переменной введенное с клавиатуры число
                    if (Convert.ToBoolean(C))
                    {
                        //С лежит в пределах от 0 до 1, проверяем попадание в этот промежуток
                        if ((C > 0) && (C < 1))
                        {
                            //Присваиваем переменной значение, которое будет вводиться с клавиатуры
                            C = Convert.ToDouble(textBox7.Text);
                        }
                        //Проверяем больше ли С единице
                        else if (C >= 1)
                        {
                            MessageBox.Show("Значение С не должно быть больше, либо равным 1, будет выставлено близкое к единице значение.");
                            //Присваиваем ему близкое к единице число
                            C = 0.99999;
                            //Выводим значение С в поле textBox7
                            textBox7.Text = Convert.ToString(C);
                        }

                        //Если введено С, меньше 1
                        else if (C < 0)
                        {
                            //С помощью модуля делаем С положительным
                            C = Math.Abs(C);
                            //Если С получилось больше 1, то меняем его на значение, близкое к единице
                            if (C >= 1)
                            {
                                //Присваиваем С значение, близкое к единице
                                C = 0.99999;
                                //Выводим значение С в поле textBox7
                                textBox7.Text = Convert.ToString(C);
                            }
                            else if ((C > 0) && (C < 1))
                            {
                                //Присваиваем первоначальное значение
                                C = Math.Abs(C);
                                //Выводим это значение в поле textBox7
                                textBox7.Text = Convert.ToString(C);
                            }
                            else { }
                        }
                        else if (C == 0)
                        {
                            C = 0.11111;
                            //Выводим это значение в поле textBox7
                            textBox7.Text = Convert.ToString(C);
                        }
                        else { }
                        //Флаг равен ложь
                        flag = false;
                    }
                    //Если ввод не удался, то выводим сообщение о повторном вводе
                    else if (!(Convert.ToBoolean(C)))
                    {
                        //Выводим сообщение об ошибке
                        MessageBox.Show("Повторите ввод вещественного числа снова!");
                        MessageBox.Show("Автоматически выставлено значение по умолчанию, равное 0.125");
                        //Выставляем значение по умолчанию
                        C = 0.125;
                        //Выводим это значение по умолчанию в поле ввода textBox7
                        textBox7.Text = Convert.ToString(C);
                        //Выполняем прерывание цикла 
                        break;
                    }
                    else { }
                }
            }
            //Объявляем переменную, в которой будем хранить число команд работников
            int dimension = 0;
            //Проверка на неправильный ввод
            try
            {
                //Присваиваем переменной значение, которое будет вводиться пользователем
                dimension = Convert.ToInt32(textBox5.Text);
            }
            //Блок, в котором отлавливаются исключения при помощи ключ слова Exeception
            catch (Exception)
            {
                //Вывод предупреждающего сообщения
                MessageBox.Show("Повторите ввод числа команд снова,будет выставлено значение по умолчанию!");
            }
            //Блок, выполняющийся в любом случае
            finally
            {
                //Объявляем логическую переменную для входа в цикл
                bool flag = true;
                //Цикл выполняется, пока условие истинно
                while (flag)
                {
                    //Если ввод удался, то присваиваем переменной введенное с клавиатуры число
                    if (Convert.ToBoolean(dimension))
                    {
                        //Присваиваем переменной значение, которое будет вводиться пользователем
                        dimension = Convert.ToInt32(textBox5.Text);
                        //Если размерность двумерного массива является отрицательным числом
                        if (dimension < 0)
                        {
                            //С помощью модуля размерность массива становится положительной
                            dimension = Math.Abs(dimension);
                            //Выводим это значение в поле ввода textBox3
                            textBox5.Text = Convert.ToString(dimension);
                        }
                        else { }
                        //Флаг равен ложь, выходим из цикла
                        flag = false;
                    }
                    //Если ввод не удался, то выводим сообщение о повторном вводе
                    else if (!(Convert.ToBoolean(dimension)))
                    {
                        //Выводим сообщение
                        MessageBox.Show("Повторите ввод числа снова!");
                        MessageBox.Show("Автоматически выставлено значение по умолчанию, равное 10.");
                        //Выставляем значение по умолчанию
                        dimension = 10;
                        //Выводим это значение по умолчанию в поле ввода textBox5
                        textBox5.Text = Convert.ToString(dimension);
                        //Выполняем команду прерывания цикла
                        break;
                    }
                    else { }
                }
            }
            double clock1 = 0;
            //Объявляем генератор псевдослучайных чисел для создания матрицы Назначений
            Random rnd = new Random();
            //Инициализируем матрицу Назначений
            for (int i = 0; i < (dimension); i++)
            {
                for (int j = 0; j < (dimension); j++)
                {
                    //Генерируем элементы матрицы Назначений
                    a[i, j] = rnd.Next(1001, 9999);
                    clock1 = Timing();
                }
            }
            double clock2 = 0;
            //Задаем строки таблицы для матрицы
            dataGridView3.RowCount = (dimension); 
            //Задаем столбцы таблицы для матрицы
            dataGridView3.ColumnCount = (dimension);
            //объявляем биты
            int Left = 0, Right = 0, LeftCenterZero = 0, RightCenterZero = 0, Sigma = 0;
            //Целая часть числа
            double Number = 0;
            //Строковые типы-заменители битов
            string left = " ", right = " ", leftCenter = " ", rightCenter = " " , sigma=" ";
            //Выполняем преобразование самого числа, зануляем средние разряды числа
            for (int i = 0; i < (dimension); i++)
            {
                for (int j = 0; j < (dimension); j++)
                {
                    //Вычисляем остаток, бит Right
                    Math.DivRem(a[i, j], 10, out Right);
                    //Если крайний правый бит равен нулю
                    if (Right == 0)
                    {
                        //Генерируем бит при помощи генератора псевдослучайных чисел
                        Right = rnd.Next(1, 9);
                    }
                    else { }
                    //Переводим крайний правый бит в строковое значение
                    right = Convert.ToString(Right);
                    //Вычисляем оставшуюся целую часть
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(a[i, j] / 10)));
                    //Вычисляем остаток, бит RightCenterZero
                    Math.DivRem(Convert.ToInt32(Number), 10, out RightCenterZero);
                    //Если центральный правый бит не равен нулю, то выполняем его зануление
                    if (RightCenterZero != 0)
                    {
                        //Выполняем зануление центрального правого бита
                        RightCenterZero = 0;
                    }
                    else { }
                    //Переводим центральный крайний правый бит в строковый тип
                    rightCenter = Convert.ToString(RightCenterZero);
                    //Вычисляем оставшуюся целую часть
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(Number / 10)));
                    //Вычисляем следующий остаток, бит LeftCenterZero
                    Math.DivRem(Convert.ToInt32(Number), 10, out LeftCenterZero);
                    //Если центральный левый бит не равен нулю, то выполняем его зануление
                    if (LeftCenterZero != 0)
                    {
                        //Выполняем зануление центрального левого бита
                        LeftCenterZero = 0;
                    }
                    else { }
                    //Переводим центральный крайний левый бит в строковый тип
                    leftCenter = Convert.ToString(LeftCenterZero);
                    //Вычисляем оставшуюся целую часть
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(Number / 10)));
                    //Вычисляем последний остаток, бит Left
                    Math.DivRem(Convert.ToInt32(Number), 10, out Left);
                    //Переводим крайний левый бит в строковое значение
                    left = Convert.ToString(Left);
                    //Выполняем склеивание всех полученных битов
                    sigma = left + leftCenter + rightCenter + right;
                    //Выполняем преобразование строки в число
                    Sigma = Convert.ToInt32(sigma);
                    //Выполняем замену элемента массива на полученное число
                    a[i, j] = Sigma;
                    clock2 = Timing();
                }
            }
            //Помечаем (Подписываем) строки и столбцы в матрице
            for (int i = 0; i < dimension; i++)
            {
                //Помечаем строки в матрице
                dataGridView3.Rows[i].HeaderCell.Value = "rows " + Convert.ToString(i + 1);
                for (int j = 0; j < dimension; j++)
                {
                    //Помечаем столбцы в матрице
                    dataGridView3.Columns[j].HeaderCell.Value = "column " + Convert.ToString(j + 1);
                }
            }
            for (int i = 0; i < (dimension); i++)
            {
                for (int j = 0; j < (dimension); j++)
                {
                    //Выводим двумерный массив в таблицу
                    dataGridView3.Rows[i].Cells[j].Value = a[i, j].ToString();
                }
            }
            //Объявлением переменную, в которой хранится количество итераций алгоритма
            int k = 0;
            //Проверка на неправильный ввод
            try
            {
                //Вводим значение k из вне с помощью элемента TextBox
                k = Convert.ToInt32(textBox3.Text);
            }
            //Генерируем исключение (Exception,выполняется обработка любых исключений)
            catch (Exception)
            {
                //Выводим предупредительное сообщение
                MessageBox.Show("Выполните повторный ввод количества итераций алгоритма!");
            }
            //Блок действий, который выполнится в любом случае
            finally
            {
               //Объявляем флаг и он равен правда
                bool flag = true;
                while (flag)
                {
                    //Если ввод удался, то в переменной к находится значение, введеннон с клавиатуры
                    if (Convert.ToBoolean(k))
                    {
                        //Вводим значение k из вне с помощью элемента TextBox
                        k = Convert.ToInt32(textBox3.Text);
                        //Проверяем, является ли число итераций отрицательным числом
                        if (k < 0)
                        {
                            //С помощью модуля делаем k положительным числом
                            k = Math.Abs(k);
                            //Выводим это значение в поле ввода textBox3
                            textBox3.Text = Convert.ToString(k);
                        }
                        else { }
                        //Меняем значение флага на ложь
                        flag = false;
                    }
                    //Если ввод не удался, то выводим сообщение о повторном вводе
                    else if (!(Convert.ToBoolean(k)))
                    {
                        //Выводим сообщение
                        MessageBox.Show("Повторите ввод числа еше раз!");
                        MessageBox.Show("Автоматически выставлено значение по умолчанию, равное 50!");
                        //Выставляем значение по умолчанию
                        k = 50;
                        //Выводим это значение по умолчанию в поле ввода textBox3
                        textBox3.Text = Convert.ToString(k);
                       //Выполняем команду прерывания цикла
                        break;
                    }
                    else { }
                }
            }
            //Объявляем переменную, в которой будет храниться число Лягушек в популяции
            int Frogs = 0;
            //Проверка на неправильный ввод
            try
            {
                //Вводим число Лягушек в популяции с клавиатуры
                Frogs = Convert.ToInt32(textBox6.Text);
            }
            //Блок, в котором отлавливаются исключения при помощи ключ. слова Exception
            catch (Exception)
            {
                //Вывод предупреждающего сообщения
                MessageBox.Show("Повторите ввод количества лягушек еще раз, будет выставлено значение по умолчанию!");
            }
            finally
            {
                //Логическая переменная для входа в цикл
                bool flag = true;
                //Цикл выполняется, пока услрвие истинно
                while (flag)
                {
                    //Если ввод удался, то присваиваем переменной введенное с клавиатуры число
                    if (Convert.ToBoolean(Frogs))
                    {
                        //Присваиваем переменной значение, которое будет вводиться пользователем
                        Frogs = Convert.ToInt32(textBox6.Text);
                        //Если количество Лягушек отрицательно, то меняем знак числа
                        if (Frogs < 0)
                        {
                            //При помощи модуля Frogs становится положительным
                            Frogs = Math.Abs(Frogs);
                            //Выводим число в поле вводе textBox6
                            textBox6.Text = Convert.ToString(Frogs);
                        }
                        else { }
                        //Флаг равен ложь, выходим из цикла
                        flag = false;
                    }
                    //Если ввод не удался, то выводим сообщение о повторном вводе
                    else if (!(Convert.ToBoolean(Frogs)))
                    {
                        //Выводим сообщение
                        MessageBox.Show("Повторите ввод числа снова!");
                        MessageBox.Show("Автоматически выставлено значение по умолчанию, равное 10.");
                        //Выставляем значение по умолчанию
                        Frogs = 10;
                        //Выводим это значение по умолчанию в поле ввода textBox6
                        textBox6.Text = Convert.ToString(Frogs);
                        break;
                    }
                    else { }
                }
            }
            //Инициализируем число прогонов в алгоритме
            int t = 1;
            //Вычисляем начальное значение ЦФ
            double NewF =Math.Abs(InitialObjectiveNewFunction(b, c, dimension));
            //Выводим на экран начальное значение ЦФ
            label7.Text = Convert.ToString(NewF);
            //Вызов формы 3 для выбора одного из Операторов Кроссинговера
            Form3 Оператор_Кроссинговера = new Form3();
            Оператор_Кроссинговера.ShowDialog();
            //Вызов формы 4 для выбора одного из Операторов Мутации
            Form4 Оператор_Мутации = new Form4();
            Оператор_Мутации.ShowDialog();
            //Передаем значение Селектора для Кроссинговера (Селектора 1) из формы 3 в форму 1
            int OneSelect = Form3.SelectOne;
            //Передаем значение Селектора для Мутации (Селектора 2) из формы 4 в форму 1
            int TwoSelect = Form4.SelectTwo;
            //Инициализируем последующее значение ЦФ
            double F = 0;
            //Инициализируем последующее среднее значение ЦФ
            double aveF = 0;
            //Инициализируем лучшее значение ЦФ
            double bestF = 0;
            //Объявляем переменную, играющую роль Таймера
            double clock = 0.0;
            //Запускаем Главный цикл алгоритма
            while (t <= k)
            {
                //Зависимость времени работы алгоритма от числа работников
                textBox7.Text = Convert.ToString(clock1 + clock2 + clock) + " c";
                //Выводим cоответствующую надпись с помощью элемента label
                label20.Text = "TimeOfWorkers";
                //Вычисляем предыдущее значение F
                double prevF = (NewF) / 2;
                //Реализуем выбор между тремя используемыми Операторами Кроссинговера
                switch (OneSelect)
                {
                    //Если OneSelect=1, то выполняем Одноточечный Оператор Кроссинговера
                    case 1:
                        //Вызываем Одноточечный ОК
                        SinglePointOK(a, dimension);
                        //C помощью break выполняем прерывание, чтобы дальше не выполнялось
                        break;
                    //Если OneSelect=2, то выполняем Двухточечный Оператор Кроссинговера
                    case 2:
                        //Вызываем Двухточечный ОК
                        TwoPointOK(a, dimension);
                        //С помощью break выполняем прерывание
                        break;
                    //Если OneSelect=3, то выполняем прерывание, чтобы дальше не выполнялось
                    case 3:
                        //Вызываем Упорядочивающий ОК
                        Ordering(a, dimension);
                        //С помощью break выполняем прерывание
                        break;
                }
              //Реализуем выбор между тремя разновидностями Мутации и Алгоритмом Поведения Лягушек
                switch (TwoSelect)
                {
                    //Если TwoSelect=1, то выполняем Одноточечный Оператор Мутации
                    case 1:
                        //Вызываем Одноточечный Ом
                        SinglePointOM(a, dimension);
                        //С помощью break выполянем прерывание
                        break;
                    //Если TwoSelect=2, то выполняем Двухточечный Оператор Мутации
                    case 2:
                        //Вызываем Двухточечный ОМ
                        TwoPointOM(a, dimension);
                        //С помощью break выполяем прерывание
                        break;
                    //Если TwoSelect=3, то выполняем Трехточечный Оператор Мутации
                    case 3:
                        //Вызываем Трехточечный ОМ
                        ThreePointOM(a, dimension);
                        //С помощью break выполянем прерывание
                        break;
                    //Если TwoSelect=4, то выполняем Алгоритм Поведения Лягушек
                    case 4:
                        //Блок на основе поведения Лягушек
                        FrogBehaviourUnit(a, dimension, Frogs, C);
                        //C помощью break выполняем прерывание
                        break;
                } 
                //Вычисляем последующее значение ЦФ
                 F = InitialObjectiveFunction(b, c, dimension);
                //Выводим на экран последующее значение ЦФ
                label8.Text = Convert.ToString(F);
                //Вычисляем наилучшее значение ЦФ среди двух найденных
                if (F > NewF)
                {
                    //Лучшим является следующее значение ЦФ
                    bestF = F;
                    //На первой итерации в алгоритме Среднее значение ЦФ равно 0
                    if (t == 1)
                    {
                        aveF = 0;
                    }
                    else { }
                    //На второй итерации aveF не равно 0
                    if (t >= 2)
                    {
                        //Выполняем расчет 
                        aveF = AverageCalculation(F, NewF);
                    }
                    else { }
                    //Выводим на экран лучшее значение ЦФ
                    label17.Text = Convert.ToString(bestF);
                }
                else { }
                //Вычисляем лучшее значение ЦФ среди двух найденных
                if (NewF > F)
                {
                    //Лучшим является предыдущее значение ЦФ
                    bestF = NewF;
                    //На первой итерации в алгоритме Среднее значение ЦФ равно 0
                    if (t == 1)
                    {
                        aveF = 0;
                    }
                    else { }
                    //На второй итерации aveF не равно 0
                    if (t >= 2)
                    {
                        //Выполняем расчет 
                        aveF = AverageCalculation(F, NewF);
                    }
                    else { }
                    //Выводим на экран лучшее значение ЦФ
                    label17.Text = Convert.ToString(bestF);
                }
                else { }
                //Вычисляем вероятность выполнения Оператора Кроссинговера
                double Kp = FuzzyLogicControllerOne(aveF, bestF, prevF);
                //Вычисляем вероятность выполнения Оператора Мутации
                double Mp = FuzzyLogicControllerTwo(aveF, bestF, prevF);
                //Осуществляем вывод вероятности ОК
                label13.Text = Convert.ToString(Kp);
                //Осуществляем вывод вероятности ОМ
                label15.Text = Convert.ToString(Mp);
                if (Kp > Mp)
                {
                    //Реализуем выбор между тремя используемыми Операторами Кроссинговера
                    switch (OneSelect)
                    {
                        //Если OneSelect=1, то выполняем Одноточечный Оператор Кроссинговера
                        case 1:
                            //Вызываем Одноточечный ОК
                            SinglePointOK(a, dimension);
                            //C помощью break выполняем прерывание, чтобы дальше не выполнялось
                            break;
                        //Если OneSelect=2, то выполняем Двухточечный Оператор Кроссинговера
                        case 2:
                            //Вызываем Двухточечный ОК
                            TwoPointOK(a, dimension);
                            //С помощью break выполняем прерывание
                            break;
                        //Если OneSelect=3, то выполняем прерывание, чтобы дальше не выполнялось
                        case 3:
                            //Вызываем Упорядочивающий ОК
                            Ordering(a, dimension);
                            //С помощью break выполняем прерывание
                            break;
                    }
                }
                else { }
                if (Mp > Kp)
                {
                    //Реализуем выбор между тремя разновидностями Мутации и Алгоритмом Поведения Лягушек
                    switch (TwoSelect)
                    {
                        //Если TwoSelect=1, то выполняем Одноточечный Оператор Мутации
                        case 1:
                            //Вызываем Одноточечный ОМ
                            SinglePointOM(a, dimension);
                            //С помощью break выполянем прерывание
                            break;
                        //Если TwoSelect=2, то выполняем Двухточечный Оператор Мутации
                        case 2:
                            //Вызываем Двухточечный ОМ
                            TwoPointOM(a, dimension);
                            //С помощью break выполяем прерывание
                            break;
                        //Если TwoSelect=3, то выполняем Трехточечный Оператор Мутации
                        case 3:
                            //Вызываем Трехточечный ОМ
                            ThreePointOM(a, dimension);
                            //С помощью break выполянем прерывание
                            break;
                        //Если TwoSelect=4, то выполняем Алгоритм Поведения Лягушек
                        case 4:
                            //Блок на основе поведения Лягушек
                            FrogBehaviourUnit(a, dimension, Frogs, C);
                            label14.Text = "Вероятность Лягушек";
                            //С помощью break выполняем прерывание
                            break;
                    }
                }
                else { }
                //Старое значение заменяем на новое
                NewF = F;
                //Увеличиваем счетчик числа итераций алгоритма
                t++;
                //Увеличиваем значение таймера
                clock = clock + 0.001;
                //Выводим время работы НГА с помощью элемента textBox4
                textBox4.Text = "Время работы алгоритма = " + Convert.ToString(clock) + " cек";
                //Если t больше k
                if (t > k)
                {
                    //Зануляем значения "Таймеров"
                    clock = 0;
                    clock1 = 0;
                    clock2 = 0;
                }
                else { }
            }
            //Объявляем переменную счетчик и инициализатор массива J
            int inc = 1;
            //Запускаем цикл for
            for (int i = 0; i < dimension; i++)
            {
                //Инициализируем массив J
                J[i] = inc;
                //Наращиваем (инкрементируем) переменную j
                inc++;
                //Выполняем проверку на ревенство j десяти
                if (inc == 10)
                {
                    //"Сбрасываем" j в единицу
                    inc = 1;
                }
                else { }
            }          
           //Выполняем переопределение номеров команд
            for (int j = 0; j < (dimension); j++)
            {
                for (int i = 0; i < (dimension); i++)
                {
                    //Получаем первый бит Right
                    Math.DivRem(a[i, j], 10, out Right);
                    //Переводим Right в строковый тип
                    right = Convert.ToString(Right);
                    //Получаем первое целое от исходного числа
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(a[i, j] / 10)));
                    //Целую часть делим на 10 и получаем бит RightCenterZero
                    Math.DivRem(Convert.ToInt32(Number), 10, out RightCenterZero);
                    //Переводим RightCenterZero в строковый тип
                    rightCenter = Convert.ToString(RightCenterZero);
                    //Получаем второе целое от исходного числа
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(Number / 10)));
                    //Получаем бит LeftCenterZero
                    Math.DivRem(Convert.ToInt32(Number), 10, out LeftCenterZero);
                    //Переводим LeftCenterZero в строковый тип
                    leftCenter = Convert.ToString(LeftCenterZero);
                    //Получаем третье целое от исходного числа
                    Number = Convert.ToDouble(Math.Truncate(Convert.ToDouble(Number / 10)));
                    //Получаем бит Left
                    Math.DivRem(Convert.ToInt32(Number), 10, out Left);
                    //Выполняем переназначение
                    Left = J[j];
                    //Переводим Left в строковый тип
                    left = Convert.ToString(Left);
                    //Выполняем склеивание битов в строковом типе
                    sigma = left + leftCenter + rightCenter + right;
                    //Выполняем преобразование строковой суммы в числовую
                    Sigma = Convert.ToInt32(sigma);
                    //Заменяем старый элемент массива на новый
                    a[i, j] = Sigma;

                }
            }
        }
        //Метод, реализующий БлокПоведенияЛягушек
        public void FrogBehaviourUnit(int[,] a, int dim, int frogs, double Dc)
        {
            //Объявляем переменные, отвечающие за разряды лучшего и худшего положений
            int Right1 = 0, Right2 = 0;
            //Инициализируем массив для хранения значений ЦФ в Алгоритме Поведения Лягушек
            int[,] CF = new int[dim, dim];
            //инициализируем разряды
            int Right = 0, Left = 0;
            //Формируем матрицу специальных ЦФ для Алгоритма Лягушек
            for (int i = 0; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    //Получаем бит Right
                    Math.DivRem(a[i, j], 10, out Right);
                    //Получаем бит Left
                    Left = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(a[i, j] / 1000)));
                    //Формируем матрицу, элементами которой являются значения Целевых Функций
                    CF[i, j] = Left + Right;
                }
            }
            //Постепенно для ЦФ ищется минимальное и максимальное значения
            //Инициализируем лучшее и худшее значение ЦФ
            int BestFrogCf = 0, WorstFrogCf = CF[0, 0];
            //Инициализируем константу в Алгоритме поведения Лягушек (сделать, чтобы она вводилась с клавитатуры)
            //Инициализируем значения индексов
            int Wi = 0, Wj = 0, Bi = 0, Bj = 0;
            //Инициализируем генератор случайных чисел rnd
            Random rnd= new Random();
            //Объявляем переменную, в которую необходимо поместить псевдослучайное число
            int rand = rnd.Next(1, (dim + 1));
            //Объявляем строковые аналоги переменных Right1 и Right2
            string right1 = " ", right2 = " ";
            //Объявляем переменные, в которых будут хранить оставшиеся части чисел
            int Number1 = 0, Number2 = 0;
            //Объявляем аналоги этих переменных
            string number1 = " ", number2 = " ";
            //Объявляем строковые переменные для обмена местами битов Right1 и Right2
            string StrSwap1 = " ", StrSwap2 = " ";
            //Объявляем переменные для изменения элементов массива
            int Swap1 = 0, Swap2 = 0;
            //Код Алгоритма поведения Лягушек
            for (int i = 0; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    //Ищем наименьшее значение Целевой Функции
                    if (CF[i, j] < WorstFrogCf)
                    {
                        //Выполняем изменение худшего значения Целевой Функции
                        WorstFrogCf = CF[i, j];
                        //Инициализируем худшее положение Лягушки в строке матрицы
                        Wi = i;
                        //Инициализируем худшее положение Лягушки в столбце матрицы
                        Wj = j;
                    }
                    //Иначе, задаем положение Лягушки самостоятельно с помощью Генератора псевдослучаных чисел
                    else
                    {
                        //Инициализируем худшее положение Лягушки в строке матрицы с помощью Генератора псевдослучайных чисел
                        Wi = rnd.Next(1, 9);
                        //Инициализируем худшее положение Лягушки в столбце матрицы с помощью Генератора псевдослучайных чисел
                        Wj = rnd.Next(1, 9);
                    }
                    //Ищем наибольшее значение Целевой Функции
                    if (CF[i, j] > BestFrogCf)
                    {
                        //Выполняем изменение лучшего значения Целевой Функции
                        BestFrogCf = CF[i, j];
                        //Инициализируем лучшее положение Лягушки в строке матрицы
                        Bi = i;
                        //Инициализируем лучшее положение Лягушки в столбце матрицы
                        Bj = j;
                    }
                    else
                    {
                        //Инициализируем худшее положение Лягушки в строке матрицы с помощью Генератора псевдослучайных чисел
                        Bi = rnd.Next(1, 9);
                        //Инициализируем худшее положение Лягушки в столбце матрицы с помощью Генератора псевдослучайных чисел
                        Bj = rnd.Next(1, 9);
                    }
                    //Популяция Лягушек, вводится пользователем с клавиатуры
                    //Вводить коэффициент С с клавиатуры
                    for (int c = 0; c < frogs; c++)
                    {
                        //Если строки худшего и лучшего положения Лягушки равны, высчитываем расположение в столбце
                        if (Wi == Bi)
                        {
                            Wj = Convert.ToInt32(Math.Round(Convert.ToDecimal(Wj + Dc * rand * Math.Abs(Bj - Wj))));
                        }
                        else { }
                        //Если столбцы худшего и лучшего положения Лягушки равны, высчитываем расположение в строке
                        if (Wj == Bj)
                        {
                            Wi = Convert.ToInt32(Math.Round(Convert.ToDecimal(Wi + Dc * rand * Math.Abs(Bi - Wi))));
                        }
                        else { }
                        //Если ни строки, ни столбцы положений Лягушки в матрице не равны
                        if ((Wi != Bi) && (Wj != Bj))
                        {
                            //Вычисляем положение Лягушки в строке матрицы
                            Wi = Convert.ToInt32(Math.Round(Convert.ToDecimal(Wi + Dc * rand * Math.Abs(Bi - Wi))));
                            //Вычисляем положение Лягушки в столбце матрицы
                            Wj = Convert.ToInt32(Math.Round(Convert.ToDecimal(Wj + Dc * rand * Math.Abs(Bj - Wj))));
                        }
                        else { }
                        //Если получилось так, что строки и столбцы худшего и лучшего решений равны
                        if ((Wi == Bi) && (Wj == Bj))
                        {
                            //Инициализируем номер строки худшего положения в матрице
                            Wi = rnd.Next(1, 10);
                            //Инициализируем номер столбца худшего положения в матрице
                            Wj = rnd.Next(1, 10);
                            //Инициализируем номер строки лучшего положения в матрице
                            Bi = Math.Abs(Wi - Convert.ToInt32(Math.Truncate(Convert.ToDecimal(Wi / (Dc * rand)))));
                            //Инициализируем номер столбца лучшего положения в матрице
                            Bj = Math.Abs(Wj - Convert.ToInt32(Math.Truncate(Convert.ToDecimal(Wj / (Dc * rand)))));
                        }
                        else { }
                        //Если номер строки худшего решения вышел за пределы матрицы
                        if (Wi > dim)
                        {
                            //Номер строки худшего решения равен граничному значению в матрице
                            Wi = dim;
                        }
                        else { }
                        //Если номер столбца худшего решения вышел за пределы матрицы
                        if (Wj > dim)
                        {
                            //Номер столбца худшего решения равен граничному значению в матрице
                            Wj = dim;
                        }
                        else { }
                        //Если номер строки лучшего решения вышел за пределы матрицы
                        if (Bi > dim)
                        {
                            //Номер столбца лучшего решения равен граничному значению в матрице
                            Bi = dim;
                        }
                        else { }
                        //Если номер столбца лучшего решения вышел за пределы матрицы
                        if (Bj > dim)
                        {
                            //Номер столбца лучшего решения равен граничному значению в матрице
                            Bj = dim;
                        }
                        else { }
                        //Выполним обмен людьми между в двух командах (реально выполняется обмен крайними правыми разрядами)
                        //Обмен выполняется между лучшим и худшим положениями
                        //Получаем бит худшей позиции
                        Math.DivRem(a[Wi, Wj], 10, out Right1);
                        //Проверяем, равен ли бит Right1 нулю, если это так, то переходим дальше
                        if (Right1 == 0)
                        {
                            //Пропускаем шаг, когда Right1=0
                            continue;
                        }
                        else { }
                        //Получаем оставшееся число
                        Number1 = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(a[Wi, Wj] / 10)));
                        //Преобразовываем разряд Right1 в строковый тип
                        right1 = Convert.ToString(Right1);
                        //Преобразовываем Number1 в строковый тип
                        number1 = Convert.ToString(Number1);
                        //Получаем бит лучшей позиции
                        Math.DivRem(a[Bi, Bj], 10, out Right2);
                        //Проверяем, равен ли бит Right 2 нулю, если это так, то переходим дальше
                        if (Right2 == 0)
                        {
                            //Пропускаем шаг, когда Right2=0
                            continue;
                        }
                        //Получаем оставшееся число
                        Number2 = Convert.ToInt32(Math.Truncate(Convert.ToDecimal(a[Bi, Bj] / 10)));
                        //Преобразовываем разряд Right2 в строковый тип
                        right2 = Convert.ToString(Right2);
                        //Преобразовываем Number2 в строковый тип
                        number2 = Convert.ToString(Number2);
                        //Получаем новое число, соответствующее худшей позиции Лягушки в матрице
                        StrSwap1 = number1 + right2;
                        //Получаем новое число, соответствующее лучшей позиции Лягушки в матрице
                        StrSwap2 = number2 + right1;
                        //Выполняем преобразование строки StrSwap1 в число Swap1
                        Swap1 = Convert.ToInt32(StrSwap1);
                        //Выполняем преобразование строки StrSwap2 в число Swap2
                        Swap2 = Convert.ToInt32(StrSwap2);
                        //Формируем элемент массива с худшим положением в матрице
                        a[Wi, Wj] = Swap1;
                        //Формируем элемент массива с лучшим положением в матрице
                        a[Bi, Bj] = Swap2;
                    }
                }
            }
        }
        //Выполняем расчет одного значения ЦФ
        public double InitialObjectiveFunction(double[] b, double[] c, int dim)
    {
        //Объявляем генератор псевдослучайных чисел
        Random rna = new Random();
        //Инициализируем вектор эффективностей работников
        for (int i = 0; i < (dim); i++)
        {
            b[i] = Convert.ToDouble(rna.Next(1, 10));
        }
        //Объявляем вспомогательные переменные
        double p = 1, mul = 1, add = 0, sum = 0;
        //Инициализируем вектор произвольного модуля
        for (int i = 0; i < (dim); i++)
        {
            c[i] = Convert.ToDouble(rna.Next(1, 20));
            c[i] = c[i] / 10000;
        }
        //Выполняем расчет начального значения целевой функции
        for (int i = 0; i < (dim); i++)
        {
            p = p * c[i];
            sum = sum + b[i];
            mul = mul * sum * p;
            add = add + mul;
        }
        //Инициализируем значение F
        double F = add;
        //Выполняем возврат значения F
        return F;
    }
        //Выполняем расчет другого значения ЦФ
        public double InitialObjectiveNewFunction(double[] b, double[] c, int dim)
        {
            //Инициализируем генератор псевдослучайных чисел для генерации векторов
            Random randOne = new Random();
            //Инициализируем генератор псевдослучайных чисел для генерации конца промежутка
            Random randTwo = new Random();
            //Объявляем дополнительную переменную
            int addition = randTwo.Next(1, 30);
            //Инициализируем вектор эффективностей работников
            for (int i = 0; i < (dim); i++)
            {
                b[i] = Convert.ToDouble(randOne.Next(1, addition));
            }
            //Объявляем вспомогательные переменные
            double p = 1, mul = 1, add = 0, sum = 0;
            //Инициализируем вектор произвольного модуля
            for (int i = 0; i < (dim); i++)
            {
                c[i] = Convert.ToDouble(randOne.Next(1, addition));
                c[i] = c[i] / 10000;
            }
            //Выполняем расчет начального значения целевой функции
            for (int i = 0; i < (dim); i++)
            {
                p = p * c[i];
                sum = sum + b[i];
                mul = mul * sum * p;
                add = add + mul;
            }
            //Инициализируем значение F
            double NewF = add;
            //Выполняем возврат значения F
            return NewF;
        }
        //Реализация селекции(отбора)
        //Отбор выполняется между двумя строками матрицы
        //Метод, в котором рассчитывается среднее значение в матрице
        //Среднее значение в матрице-сумма средних по строкам деленная на их количество
        public int AverageMatrix(int[,] a, int dim)
        {
            //Инициализируем сумму элементов строк матрицы
            int sum = 0;
            //Инициализируем вспомогательные параметры-среднее по строкам и столбцам
            double aveStr = 0, aveCol = 0;
            //Инициализируем сумму средних по строкам
            double aveS = 0;
            //Инициализируем итоговое возвращаемое значение
            int Total = 0;
            //Вычисляем сумму элементов строк в матрице
            for (int i = 0; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    //Вычисляем сумму элементов строки в матрице
                    sum = sum + a[i, j];
                    //Вычисляем среднее значение в строке матрице
                    aveStr = sum / 21;
                }
                //Зануляем сумму элементов строк, чтобы она не накапливалась
                sum = 0;
                //Вычисляем сумму средних значений для всех строк в матрице
                aveS = aveS + aveStr;
                //Среднее значение среди средних по строкам матрицы-среднее значени в матрице
                aveCol = aveS / 21;
                //Вычисляем итоговое возвращаемое значение для матрицы
                Total = Convert.ToInt32(Math.Round(aveCol));
            }

            return Total;
        }
        //Метод, в котором рассчитывается Хеммингово расстояние для определения
        //кандидатов, необходимых для выполнения скрещивания
        //Значения n и k определяются при помощи генератора случайных чисел
        //и являются номерами строк
        public int HemmingDistance(int[,] a, int n, int k, int dim)
        {
            //Наибольшее и наименьшее значение среди двух чисел
            int max = 0, min = 0;
            //Инициализируем Хеммингово расстояние
            int dist = 0;
            //Инициализируем разность, между рассматриваемыми элементами матрицы
            int devide = 0;
            //Проверяем, какое из чисел больше
            if (n > k)
            {
                max = n;//Наибольшее число
                min = k;//Наименьшее число
            }
            else { }
            //Проверяем, какое из чисел меньше
            if (n < k)
            {
                max = k;//Наибольшее число
                min = n;//Наименьшее число
            }
            for (int i = min; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    //Вычисляем разность между двумя элементами матрицы
                    devide = Math.Abs(a[max, j] - a[min, j]);
                    //Вычиялем Хеммингово расстояние
                    dist = dist + devide;
                }
            }
            return dist;
        }
        //Метод, реализующий одноточечный оператор кроссинговера
        public void SinglePointOK(int[,] a, int dim)
        {
            //Инициализируем первый генератор случайных чисел
            Random rnd = new Random();
            //Инициализируем второй генератор случайных чисел
            Random rna = new Random();
            //Значение для первой произвольно выбранной строки
            int n = rnd.Next(0, (dim));
            //Значение для второй произвольно выбранной строки
            int k = rna.Next(0, (dim));
            //Используем Хеммингово расстояние для дальнейших вычислений
            int Distance = HemmingDistance(a, n, k, dim);
            //Используем среднее значение в матрице для дальнейших вычислений
            int R = AverageMatrix(a, dim);
            //Признак
            bool sign = true;
            //Инициализируем дополнительную переменную для обмена элементов между строками
            int swap = 0;
            //Реализуем бесконечный цикл для выбора хромосом (строк в матрице),
            //готовых к скрещиванию
            while (sign)
            {
                //Генерируем номер случайного столбца
                int m = rnd.Next(0, (dim));
                //Сравниваем два значения, если выполняется, то делаем обмен
                if (Distance > R)
                {
                    //Устанавливаем начальное значение для столбца, с которого 
                    //будет выполняться обмен
                    int j = m;
                    while (j < (dim))
                    {
                        //Выполняем одноточечный оператор кроссинговера
                        //Меняем местами часть элементов выбранных строк в матрице межде собой
                        swap = a[n, j];
                        a[n, j] = a[k, j];
                        a[k, j] = swap;
                        //Увеличиваем номер столба матрицы
                        j++;
                    }
                    //Меняем значение признака для выхода из цикла
                    sign = false;
                }
                else { }
                if (Distance <= R)
                {
                    //Значение для первой произвольно выбранной строки
                    n = rnd.Next(0, (dim));
                    //Значение для второй произвольно выбранной строки
                    k = rna.Next(0, (dim));
                    //Используем Хеммингово расстояние для дальнейших вычислений
                    Distance = HemmingDistance(a, n, k, dim);
                    //Используем среднее значение в матрице для дальнейших вычислений
                    R = AverageMatrix(a, dim);
                    //Дублируем признак
                    sign = true;
                }
                else { }
            }
        }
        //Метод, реализующий двухточечный оператор кроссинговера
        public void TwoPointOK(int[,] a, int dim)
        {
            //Инициализируем максимальное и минимальное значения
            int max = a[0, 0], min = a[0, 0];
            //Инициализируем значения строк максимального и минимального элементов
            int max_i = 0, min_i = 0;
            //Инициализируем значения столбцов максимального и минимального элементов
            int max_j = 0, min_j = 0;
            //Выполняем поиск максимального и минимального элементов в матрице
            for (int i = 0; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    //Сравниваем текущее значение матрицы со значением максимального элемента
                    if (a[i, j] > max)
                    {
                        max = a[i, j];//Находим максимальный элемент в матрице
                        max_i = i;//Находим индекс строки максимального элемента в матрице
                        max_j = j;//Находим индекс столбца максимального элемента в матрице
                    }
                    else { }
                    //Сравниваем текущее значение матрицы со значением минимального элемента
                    if (a[i, j] < min)
                    {
                        min = a[i, j];//Находим минимальный элемент в матрице
                        min_i = i;//Находим индекс строки минимального элемента в матрице
                        min_j = j;//Находим индекс столбца минимального элемента в матрице
                    }
                }
            }
            //Инициализация переменной для обмена элементов
            int swap = 0;
            //Сравниваем индексы строк максимального и минимального элементов и менем их местами
            if (min_i > max_i)
            {
                //Выполняем обмен между индексами строк элементов
                swap = max_i;
                max_i = min_i;
                min_i = swap;
            }
            else { }
            //Сравниваем индексы столбцов максимального и минимального элементов и меняем их местами
            if (min_j > max_j)
            {
                //Выполняем обмен между индексами столбцов элементов
                swap = max_j;
                max_j = min_j;
                min_j = swap;
            }
            else { }
            //Реализуем обмен между двумя точками-двухточечный ОК
            //Выбираем два произвольных индекса столбцов и срок, фиксируем строки
            //Выполняем обмен элементов строк в пределах индексов выбранных столбцов
            for (int j = min_j; j < max_j; j++)
            {
                //Выполняем сам обмен между двумя точками
                swap = a[min_i, j];
                a[min_i, j] = a[max_i, j];
                a[max_i, j] = swap;
            }
        }
        //Метод, реализующий трехточечный оператор кроссинговера
        public void Ordering(int[,] a, int dim)
        {
            //Инициализируем первый генератор случайных чисел
            Random rnd = new Random();
            //Инициализируем второй генератор случайных чисел
            Random rna = new Random();
            //Инициализируем первый индекс строки, заданный случайным числом
            int n = rnd.Next(0, dim);
            //Инициализируем второй индекс строки, заданный случайным числом
            int k = rna.Next(0, dim);
            //Проверяем на равенство строки, заданные генератором
            if (n == k)
            {
                //Проверяем, равно ли n и k граничному значению
                if ((n == (dim)) && (k == (dim)))
                {
                    //Меняем параметры произвольным образом на свое усмотрение
                    n = n - 1;
                    k = k - n;
                }
                else { }
                //Проверяем, равно ли n и k нулю
                if ((n == 0) && (k == 0))
                {
                    //Увеличиваем параметры произвольным образом
                    n = n + 1;
                    k = k + n;
                }
                else { }
                if (((n != 0) && (k != 0)) || ((n != (dim)) && (k != (dim))))
                {
                    n = n + 1;
                }
                else { }
                if ((n == (dim)) || (k == (dim)))
                {
                    n = n - 1;
                    k = k - 1;
                }
                else { }
            }
            else { }
            //Инициализируем переменную для обмена значениями между строками
            int swap = 0;
            //Инициализируем максимальное и минимальное значения строк
            int IndexMax_i = 0, IndexMin_i = 0;
            //Сравниваем два числа и кладем в соответствующие переменные
            if (k > n)
            {
                //Получением индекс большей строки
                IndexMax_i = k;
                //Получаем индекс меньшей строки
                IndexMin_i = n;

            }
            else { }
            //Выполняем сравнение, аналогичное предыдущему
            if (n > k)
            {
                //Получаем индекс большей строки
                IndexMax_i = n;
                //Получаем индекс меньшей строки
                IndexMin_i = k;
            }
            else { }
            //Значение двух строк задается случайным образом
            //Выполняем обмен произвольной части элементов двух строк с левой стороны
            for (int j = 0; j < IndexMax_i; j++)
            {
                //Выполняем обмен двух элементов между собой в заданных строках
                swap = a[IndexMin_i, j];
                a[IndexMin_i, j] = a[IndexMax_i, j];
                a[IndexMax_i, j] = swap;
            }
            //Выполняем упорядочивание элементов заданных строк произвольным образом
            //Упорядочивание выполняется при помощи сортировки Методом Выбора
            //Упорядочиваем элементы строки с минимальным индексом
            for (int j = 0; j < ((dim)-1); j++)
            {
                int nMin = j;
                for (int l = j + 1; l < (dim); l++)
                {
                    if (a[IndexMin_i, l] < a[IndexMin_i, nMin])
                    {
                        nMin = l;

                    }
                    else { }
                    if (nMin != j)
                    {
                        swap = a[IndexMin_i, j];
                        a[IndexMin_i, j] = a[IndexMin_i, nMin];
                        a[IndexMin_i, nMin] = swap;
                    }
                    else { }
                }
            }
            //Упорядочиваем элементы строки с максимальным индексом
            for (int j = 0; j < ((dim)-1); j++)
            {
                int nMin = j;
                for (int l = j + 1; l < (dim); l++)
                {
                    if (a[IndexMax_i, l] < a[IndexMax_i, nMin])
                    {
                        nMin = l;

                    }
                    else { }
                    if (nMin != j)
                    {
                        swap = a[IndexMax_i, j];
                        a[IndexMax_i, j] = a[IndexMax_i, nMin];
                        a[IndexMax_i, nMin] = swap;
                    }
                    else { }
                }
            }
        }
        //Метод выполнения одноточечного оператора мутации
        // (меняем местами два элемента в столбце)
        public void SinglePointOM(int[,] a, int dim)
        {
            Random rna = new Random();

            int cups = 0;

            int Gener = rna.Next(0, (dim));

            for (int i = Gener; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    if ((i + 1) < (dim))
                    {
                        cups = a[i, j];
                        a[i, j] = a[i + 1, j];
                        a[i + 1, j] = cups;
                    }
                    else { }
                    if ((i + 1) > (dim))
                    {
                        cups = a[i - 1, j];
                        a[i - 1, j] = a[i, j];
                        a[i, j] = cups;
                    }
                    else { }
                }
            }
        }
        //Метод выполнения двухточечного оператора мутации
        //(меняем местами две пары элементов в столбце)
        public void TwoPointOM(int[,] a, int dim)
        {
            //Инициализация начальных значений элементов
            //max, min - первоначальные значения максимальных и минимальных элементов
            //maxOne, minOne - значения первого максимального и первого минимального элементов
            //maxTwo, minTwo - значения второго максимального и второго максимального элементов
            int swap = 0, max = a[0, 0], min = a[0, 0], maxTwo = max, minTwo = min;
            //Инициалируем первые значения максимальных и минимальных элементов
            int maxOne = 0, minOne = 0;
            //Инициализируем индексы максимальных и минимальных элементов
            int indexMax_i = 0, indexMax_j = 0, indexMin_i = 0, indexMin_j = 0;

            for (int j = 0; j < (dim); j++)
            {
                for (int i = 0; i < (dim); i++)
                {
                    //Выполняем поиск первой пары максимального и минимального значений
                    if (a[i, j] > max)
                    {
                        max = a[i, j];//присваиваем начальному максимальному элементу 
                        //значения большего элемента, чем максимальный, в матрице
                        indexMax_i = i;//получение индекса строки максимального элемента
                        indexMax_j = j;//получение индекса столбца максимального элемента
                        maxOne = max;//первоначальный максимальный элемент найден
                    }
                    else { }

                    if (a[i, j] < min)
                    {
                        min = a[i, j];//присваиваем начальному минимальному элементу
                        //значения меньшего элемента, чем минимальный, в матрице
                        indexMin_i = i;//получение индекса строки минимального элемента
                        indexMin_j = j;//полчение индекса столбца минимального элемента
                        minOne = min;//первоначальный минимальный элемент найден
                    }
                    else { }
                    //Выполняем обмен первой пары элементов в столбце
                    swap = a[indexMax_i, indexMax_j];
                    a[indexMax_i, indexMax_j] = a[indexMin_i, indexMin_j];
                    a[indexMin_i, indexMin_j] = swap;
                    //Выполняем поиска второй пары максимального и минимального значений
                    if (a[i, j] > maxTwo)
                    {
                        if (a[i, j] != maxOne)
                        {
                            maxTwo = a[i, j]; //Находим второй максимальный элемент
                            indexMax_i = i; //получение индекса строки второго максимального элемента
                            indexMax_j = j; //получение индекса столбца второго максимального элемента
                        }
                        else { }
                    }
                    else { }
                    if (a[i, j] < minTwo)
                    {
                        if (a[i, j] != minOne)
                        {
                            minTwo = a[i, j]; //Находим второй минимальный элемент
                            indexMin_i = i; //получение индекса строки второго минимального элемента
                            indexMin_j = j; //получение индекса столбца второго минимального элемента
                        }
                        else { }
                    }
                    else { }
                    //Выполняем обмен второй пары максимального и минимального значений
                    swap = a[indexMax_i, indexMax_j];
                    a[indexMax_i, indexMax_j] = a[indexMin_i, indexMin_j];
                    a[indexMin_i, indexMin_j] = swap;
                }
            }
        }
        //Метод выполнения трехточечного оператора мутации
        //(меняем местами три пары элементов в столбце)
        public void ThreePointOM(int[,] a, int dim)
        {
            //Инициализация начальных значений параметров
            int swap = 0, max = a[0, 0], min = a[0, 0], maxTwo = max, minTwo = min;
            //инициализация третьей пары из максимального и минимального значений
            int maxThree = max, minThree = min;
            //инициализация первой пары из максимального и минимальног значений
            int maxOne = 0, minOne = 0;
            //maxTwo,minTwo-вторая пара из максимального и минимального значений
            //Инициализируем индексы максимального и минимального элементов
            int indexMax_i = 0, indexMax_j = 0, indexMin_i = 0, indexMin_j = 0;
            for (int j = 0; j < (dim); j++)
            {
                for (int i = 0; i < (dim); i++)
                {
                    //Сравниваем текущий элемент матрицы с максимальным
                    if (a[i, j] > max)
                    {
                        //Находим максимальный элемент в матрице
                        max = a[i, j];
                        maxOne = max;
                        //получение индекса строки максмального элемента
                        indexMax_i = i;
                        //получение индекса столбца максимального элемента
                        indexMax_j = j;
                    }
                    else { }
                    //Сравниваем текущий элемент матрицы с минимальным
                    if (a[i, j] < min)
                    {
                        //Находим минимальный элемент в матрице
                        min = a[i, j];
                        minOne = min;
                        //получение индекса строки минимального элемента
                        indexMin_i = i;
                        //получение индекса столбца минимального элемента
                        indexMin_j = j;
                    }
                    else { }
                    //Выполняем обмен первой пары максимального и минимального элементов
                    swap = a[indexMax_i, indexMax_j];
                    a[indexMax_i, indexMax_j] = a[indexMin_i, indexMin_j];
                    a[indexMin_i, indexMin_j] = swap;
                    //Выполняем поиск второго максимального элемента
                    if (a[i, j] > maxTwo)
                    {
                        //Выполняем сравнение текущего элемента матрицы с максимальным элементом первой пары
                        if (a[i, j] != maxOne)
                        {
                            //Находим максимальный элемент из второй пары
                            maxTwo = a[i, j];
                            //Находим индекс строки второго максимального элемента
                            indexMax_i = i;
                            //Находим индекс столбца второго максимального элемента
                            indexMax_j = j;
                        }
                        else { }

                    }
                    else { }
                    //Выполняем поиск второго минимального элемента
                    if (a[i, j] < minTwo)
                    {
                        //Выполняем сравнение текущего элемента матрицы с минимальным элементом первой пары
                        if (a[i, j] != minOne)
                        {
                            //Находим минимальный элемент из второй пары
                            minTwo = a[i, j];
                            //Находим индекс строки второго минимального элемента
                            indexMin_i = i;
                            //Находим индекс столбца второго минимального элемента
                            indexMin_j = j;
                        }
                        else { }
                    }
                    else { }
                    //Выполняем обмен второй пары максимального и минимального элементов
                    swap = a[indexMax_i, indexMax_j];
                    a[indexMax_i, indexMax_j] = a[indexMin_i, indexMin_j];
                    a[indexMin_i, indexMin_j] = swap;
                    //Выполняем поиск третьего максимального элемента
                    if (a[i, j] > maxThree)
                    {
                        //Сравниваем текущий элемент матрицы с максимальным из первой пары
                        if (a[i, j] != maxOne)
                        {
                            //Сравниваем текущий элемент матрицы с максимальным из второй пары
                            if (a[i, j] != maxTwo)
                            {
                                //Получаем максимальный элемент из третьей пары
                                maxThree = a[i, j];
                                //Находим индекс строки третьего максимального элемента
                                indexMax_i = i;
                                //Находим индекс столбца третьего максимального элемента
                                indexMax_j = j;
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }
                    //Выполняем поиск третьего минимального элемента
                    if (a[i, j] < minThree)
                    {
                        //Сравниваем текущий элемент матрицы с минимальным элементом из первой пары
                        if (a[i, j] != minOne)
                        {
                            //Сравниваем текущий элемент матрицы с минимальным из второй пары
                            if (a[i, j] != minTwo)
                            {
                                //Получаем минимальный элемент из третьей пары
                                minThree = a[i, j];
                                //Находим индекс строки третьего минимального элемента
                                indexMin_i = i;
                                //Находим индекс столбца третьего минимального элемента
                                indexMin_j = j;
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }
                    //Выполняем обмен третьей пары максимального и минимального элементов
                    swap = a[indexMax_i, indexMax_j];
                    a[indexMax_i, indexMax_j] = a[indexMin_i, indexMin_j];
                    a[indexMin_i, indexMin_j] = swap;
                }
            }
        }
        //Метод, в котором вычисляется среднее значение ЦФ
        public double AverageCalculation(double F, double NewF)
        {
            //Инициализируем среднее значение ЦФ 
            double AveF = 0;
            //Вычисляем среднее значение ЦФ по результатам имеющих двух значений
            AveF = (F + NewF) / 2;
            return AveF;
        }
        //Метод, в котором НЛК1 выполняет расчет вероятности для ОК
        public double FuzzyLogicControllerOne(double aveF, double bestF, double prevF)
        {
            //Инициализируем управляющие воздействия НЛК
            double e1 = 0, e2 = 0;
            //Выполяняем инициализацию генератора случайных чисел
            Random rand = new Random();
            //Инициализируем Селектор НЛК1 для e1
            int FuzzySelectE1 = rand.Next(1, 3);
            //Инициализируем Селектор НЛК2 для e2
            int FuzzySelectE2 = rand.Next(1, 3);
            e1 = Math.Abs(1 - (bestF / aveF));
            //Реализуем выбор для e1
            switch (FuzzySelectE1)
            {
                //Если FuzzySelect=1
                case 1:
                    //Если в этом случае, e1 не попало в этот промежуток
                    if ((e1 < 0) || (e1 > 0.06))
                    {
                        //Корректируем значение e1
                        e1 = e1 / 10;
                    }
                    else { }
                    //Выполняем прерывание при помощи break
                    break;
                //Если FuzzySelect=2
                case 2:
                    //e1 остается без изменений
                    break;
            }
            //Выполняем расчет второго управляющего воздействия НЛК
            e2 = (aveF - prevF) / bestF;
            //Реализуем выбор для e2
            switch (FuzzySelectE2)
            {
                //Если FuzzySelect=1
                case 1:
                    //Проверяем, e2 больше нуля
                    if (e2 > 0)
                    {
                        //Инвертируем значение e2
                        e2 = e2 * (-1);
                        //Проверяем, больше ли e2 единице
                        if (e2 < (-1))
                        {
                            //Корректируем e2
                            e2 = e2 / 10;
                        }
                        else { }
                    }
                    else { }
                    //Выполняем прерывание при помощи break
                    break;
                //Если FuzzySelect=2
                case 2:
                    //Проверяем, e2 больше нуля
                    if (e2 < 0)
                    {
                        //Инвертируем значение e2
                        e2 = e2 * (-1);
                        //Проверяем, больше ли e2 единице
                        if (e2 > 1)
                        {
                            //Корректируем значение t2
                            e2 = e2 / 10;
                        }
                        else { }
                    }
                    else { }
                    //Выполняем прерывание при помощи break
                    break;
            }
            //Инициализируем вероятность Мутации
            double Prok = 0;
            //Инициализируем новую вероятность Мутации
            double Pk = 0;
            //Инициализируем изменение вероятность Мутации, 
            //рассчитанную с помощью НЛК
            double dPk = 0;
            //Вычисляем предварительную вероятность для Мутации
            //С помощью Генератора псевдослучайных числе задаем предварительную вероятность для Мутации
            Prok = rand.Next(0, 4);
            //Полчучаем вероятность мутации
            //Инициализируем строковые переменные
            s1 = " ";
            s2 = " ";
            str1 = " ";
            //Вычисляем изменения вероятностей кроссинговера и мутации и вырабатываем сигнал
            //Комбинация PL и NL для кроссинговера
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= (-1)) && (e2 <= (-0.4))))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //negative large-значительное ухудшение
                s2 = "NL";
                //negative small-незначительное ухудшение
                str1 = "NS";
                //Находим изменения вероятности кроссинговера
                dPk = -0.6;
            }
            else { }
            //Комбинация PL и NS для кроссинговера
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= -0.6) && (e2 <= 0)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //negative small-незначительное ухудшение
                s2 = "NS";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим изменение вероятности кроссинговера
                dPk = 0.6;
            }
            else { }
            //Комбинация PL И ZE для кроссинговера
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= (-0.4)) && (e2 <= 0.4)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //zero-частичное изменение
                s2 = "ZE";
                //positive small-незначительное улучшение
                str1 = "PS";
                //Находим изменение вероятности кроссинговера
                dPk = 0.54;
            }
            else { }
            //Комбинация PL и PS для кроссинговера
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= 0) && (e2 <= 0.6)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //positive small-незначительное улучшение
                s2 = "PS";
                //positive small-незначительное улучшение
                str1 = "PS";
                //Находим изменение вероятности кроссинговера
                dPk = 0.95;
            }
            else { }
            //Комбинация PL и PL для кроссинговера
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= 0.4) && (e2 <= 1)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //positive large-значительное улучшение
                s2 = "PL";
                //positive large-значительное улучшение
                str1 = "PL";
                //Находим изменение вероятности кроссинговера
                dPk = 1.3;
            }
            else { }
            //Комбинация PS и NL для кроссинговера
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-1)) && (e2 <= (-0.4))))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //negative large-значительное ухудшение
                s2 = "NL";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим изменение вероятности кроссинговера
                dPk = 0.86;
            }
            else { }
            //Комбинация PS и NS для кроссинговера
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-0.6)) && (e2 <= 0)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //negative small-незначительное ухудшение
                s2 = "NS";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим изменение вероятности кроссинговера
                dPk = 0.8;
            }
            else { }
            //Комбинация PS и ZE
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-0.4)) && (e2 <= 0.4)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //zero-частичное изменение
                s2 = "ZE";
                //zer0-частичное изменение
                str1 = "ZE";
                //Находим изменение вероятности кроссинговера
                dPk = 0.74;
            }
            else { }
            //Комбинация PS и PS
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= 0) && (e2 <= 0.6)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //positive small-незначительное улучшение
                s2 = "PS";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим изменение веротяности кроссинговера
                dPk = 0.45;
            }
            else { }
            //Комбинация PS и PL
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= 0.4) && (e2 <= 1)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //positive large-значительное улучшение
                s2 = "PL";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим изменение вероятности кроссинговера
                dPk = 1.5;
            }
            else { }
            //Комбинация ZE и NL
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-1)) && (e2 <= (-0.4))))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //negative large-значительное ухудшение
                s2 = "NL";
                //negative small-незначительное улучшение
                str1 = "NS";
                //Находим частичное изменение вероятности кроссинговера
                dPk = 0.66;
            }
            else { }
            //Комбинация ZE и NS
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-0.6)) && (e2 <= 0)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //negative small-незначительное ухудшение
                s2 = "NS";
                //negative large-значительное ухудшение
                str1 = "NL";
                //Находим частичное изменение вероятности кроссинговера
                dPk = 0.12;
            }
            else { }
            //Комбинация ZE и ZE
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-0.4)) && (e2 <= 0.4)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //zero-частичное изменение 
                s2 = "ZE";
                //zero-частичное изменение
                str1 = "ZE";
                //Находим частичное изменение вероятности кроссинговера
                dPk = -0.74;
            }
            else { }
            //Комбинация ZE и PS
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= 0) && (e2 <= 0.6)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //positive small-незначительное улучшение
                s2 = "PS";
                //negative large-значительное ухудшение
                str1 = "NL";
                //Находим частичное изменение вероятности кроссинговера
                dPk = -0.54;
            }
            else { }
            //Комбинация ZE и PL
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= 0.4) && (e2 <= 1)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //positive large-значительное улучшение
                s2 = "PL";
                //positive small-незначительное улучшение
                str1 = "PS";
                //Находим частичное изменение вероятности кроссинговера
                dPk = 0.25;
            }
            else { }
            //Выполняем расчет вероятности по формуле
            Pk = Math.Abs(Prok + dPk);
            //Выполняем возврат полученного значения для вероятности Кроссинговера
            return Pk;
        }
        //Метод, в котором НЛК2 выполняет расчет вероятности для ОМ
        public double FuzzyLogicControllerTwo(double aveF, double bestF, double prevF)
        {
            //Инициализируем управляющие воздействия НЛК
            double e1 = 0, e2 = 0;
            //Выполяняем инициализацию генератора случайных чисел
            Random rand1 = new Random();
            Random rand2 = new Random();
            //Инициализируем Селектор НЛК1 для e1
            int FuzzySelectE1 = rand1.Next(1, 3);
            //Иницализируем Селектор НЛК2 для e2
            int FuzzySelectE2 = rand2.Next(1, 3);
            e1 = Math.Abs(1 - (bestF / aveF));
            //Реализуем выбор для e1
            switch (FuzzySelectE1)
            {
                //Если FuzzySelect=1
                case 1:
                    //Если в этом случае, e1 не попало в этот промежуток
                    if ((e1 < 0) || (e1 > 0.06))
                    {
                        //Корректируем значение e1
                        e1 = e1 / 10;
                    }
                    else { }
                    //Выполняем прерывание при помощи break
                    break;
                //Если FuzzySelect=2
                case 2:
                    //e1 остается без изменений
                    break;
            }
            //Выполняем расчет второго управляющего воздействия НЛК
            e2 = (aveF - prevF) / bestF;
            //Реализуем выбор для e2
            switch (FuzzySelectE2)
            {
                //Если FuzzySelect=1
                case 1:
                    //Проверяем, положительное e2 или нет
                    if (e2 > 0)
                    {
                        //Инвертируем значение e2
                        e2 = e2 * (-1);
                        //Коррекктируем значение e2
                        if (e2 < (-0.06))
                        {
                            e2 = e2 / 10;
                        }
                        else { }
                    }
                    else { }
                    //Выполяем прерывание при помощи break
                    break;
                //Если FuzzySelect=2
                case 2:
                    //Проверяем, положительное e2 или нет
                    if (e2 > 0)
                    {
                        //Корректируем значение e2
                        if (e2 > 0.1)
                        {
                            e2 = e2 / 10;
                        }
                        else { }
                    }
                    else
                    {
                        e2 = e2 * (-1);
                    }
                    //Выполняем прерывание при помощи break
                    break;
            }
            //Инициализируем вероятность Мутации
            double Prom = 0;
            //Инициализируем новую вероятность Мутации
            double Pm = 0;
            //Инициализируем изменение вероятность Мутации, 
            //рассчитанную с помощью НЛК
            double dPm = 0;
            //Вычисляем предварительную вероятность для Мутации
            //С помощью Генератора псевдослучайных числе задаем предварительную вероятность для Мутации
            Prom = rand1.Next(0, 4);
            //Полчучаем вероятность мутации
            //Инициализируем строковые переменные
            s1 = " ";
            s2 = " ";
            str2 = " ";
            //Вычисляем изменения вероятностей кроссинговера и мутации и вырабатываем сигнал
            //Выполняем вычисление вероятности для оператора мутации
            //Комбинация PL и NL для мутации
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= (-0.1))) && (e2 <= (-0.04)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //negative large-значительное улучшение
                s2 = "NL";
                //positive small-незначительное улучшение
                str2 = "PS";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.06;
            }
            else { }
            //Комбинация PL и NS для мутации
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= (-0.06)) && (e2 <= 0)))
            {

                //positive large-значительное улучшение
                s1 = "PL";
                //negative small-незначительное ухудшение
                s2 = "NS";
                //zero-частичное изменение
                str2 = "ZE";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.72;
            }
            else { }
            //Комбинация PL и ZE
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= (-0.04)) && (e2 <= 0.04)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //zero-частичное изменение
                s2 = "ZE";
                //positive small-незначительное улучшение
                str2 = "PS";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.14;
            }
            else { }
            //Комбинация PL и PS
            if ((((e1 >= 0.3) && (e1 <= 1))) && ((e2 >= 0) && (e2 <= 0.06)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //positive small-незначительное улучшение
                s2 = "PS";
                //negative small-незначительное ухудшение
                str2 = "NS";
                //Находим частичное изменение вероятности для мутации
                dPm = -0.12;
            }
            else { }
            //Комбинация PL и PL
            if (((e1 >= 0.3) && (e1 <= 1)) && ((e2 >= 0.04) && (e2 <= 0.1)))
            {
                //positive large-значительное улучшение
                s1 = "PL";
                //positive large-значительное улучшение
                s2 = "PL";
                //negative large-значительное ухудшение
                str2 = "NL";
                //Находим частичное изменение вероятности для мутации
                dPm = -0.26;
            }
            else { }
            //Комбинация PS и NL
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-0.1)) && (e1 <= (-0.04))))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //negative small-значительное ухудшение
                s2 = "NL";
                //zero-частичное изменение
                str2 = "ZE";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.26;
            }
            else { }
            //Комбинация PS и NS
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-0.06)) && (e2 <= 0)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //negative small-значительное ухудшение
                s2 = "NS";
                //zero-частичное изменение
                str2 = "ZE";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.02;
            }
            else { }
            //Комбинация PS и ZE
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= (-0.04)) && (e2 <= 0.04)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //zero-частичное изменение
                s2 = "ZE";
                //negative small-значительное ухудшение
                str2 = "NS";
                //Находим частичное изменение вероятности для мутации
                dPm = -0.33;
            }
            else { }
            //Комбинация PS и PS
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= 0) && (e2 <= 0.06)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //positive small-незначительное улучшение
                s2 = "PS";
                //zero-частичное изменение
                str2 = "ZE";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.21;
            }
            else { }
            //Комбинация PS и PL
            if (((e1 >= 0.05) && (e1 <= 0.4)) && ((e2 >= 0.04) && (e2 <= 0.1)))
            {
                //positive small-незначительное улучшение
                s1 = "PS";
                //positive large-значительное улучшение
                s2 = "PL";
                //negative small-незначительное ухудшение
                str2 = "NS";
                //Находим частичное изменение вероятности для мутации
                dPm = -0.02;
            }
            else { }
            //Комбинация ZE и NL
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-0.1)) && (e2 <= (-0.04))))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //negative large-значительное улучшение
                s2 = "NL";
                //positive small-незначительное улучшение
                str2 = "PS";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.6;
            }
            else { }
            //Комбинация ZE и NS
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-0.06)) && (e2 <= 0)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //negative small-незначительное улучшение
                s2 = "NS";
                //positive large-значительное улучшение
                str2 = "PL";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.14;
            }
            else { }
            //Комбинация ZE и ZE
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= (-0.04)) && (e2 <= 0.04)))
            {
                //zero-частичное изменение 
                s1 = "ZE";
                //zero-частичное изменение
                s2 = "ZE";
                //zero-частичное изменение
                str2 = "ZE";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.06;
            }
            else { }
            //Комбинация ZE и PS
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= 0) && (e2 <= 0.06)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //positive small-незначительное улучшение
                s2 = "PS";
                //positive large-значительное улучшение
                str2 = "PL";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.22;
            }
            else { }
            //Комбинация ZE и PL
            if (((e1 >= 0) && (e1 <= 0.06)) && ((e2 >= 0.04) && (e2 <= 0.1)))
            {
                //zero-частичное изменение
                s1 = "ZE";
                //positive large-значительное улучшение
                s2 = "PL";
                //positive small-незначительное улучшение
                str2 = "PS";
                //Находим частичное изменение вероятности для мутации
                dPm = 0.2;
            }
            else { }
            //Выполняем расчет вероятности по формуле
            Pm = Math.Abs(Prom + dPm);
            //Выполняем возврат полученного значения для вероятности мутации
            return Pm;
        }
        //Расчет зависимости времени работы алгоритма от числа работников
        //Глобальная переменная, счетчик "Таймера"
        private double Clk = 0;
        public double Timing()
        {
            //Объявляем интервал времени работы "Таймера"
            double clk = 0.001;
            //Наращиваем значение "Таймера"
            Clk = Clk + clk;
            //Выполняем возврат значения времени
            return Clk;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Скрываем первоначальную форму
            this.Hide();
            Form2 Параметры_НГА = new Form2();
            Параметры_НГА.ShowDialog();
        }
        //Реализация кнопки "Получить размещение"
        private void button3_Click(object sender, EventArgs e)
        {
            //Объявляем глобальную переменную, число команд работников
            int dimension = 0;
            //Локальная переменная, объявляем число работников
            try
            {
                dimension = Convert.ToInt32(textBox5.Text);
            }
            catch (Exception)
            {

            }
            finally
            {
                //Если ввод неудался, то в качестве размерность массива выставляем определенное значение по умолчанию
                if (!(Convert.ToBoolean(dimension)))
                {
                    //Присваиваем переменной dimension, значение по умолчанию, равное 10
                    dimension = 10;
                }
                else { }
            }
            //Получаем новую матрицу назначений и вывод туда измененный двумерный массив
            for (int i = 0; i < (dimension); i++)
            {
                for (int j = 0; j < (dimension); j++)
                {
                    //Выполняем вывод измененой матрицы назначений
                    dataGridView3.Rows[i].Cells[j].Value = a[i, j].ToString();
                }
            }
        }
        //Реализация кнопки "Очистить"
        private void button4_Click(object sender, EventArgs e)
        {
            //Число работников
            int dimension = 0;
            //Локальная переменная, объявляем число работников
            try
            {
                dimension = Convert.ToInt32(textBox5.Text);
            }
            catch (Exception)
            {

            }
            finally
            {
                //Если ввод неудался, то в качестве размерность массива выставляем определенное значение по умолчанию
                if (!(Convert.ToBoolean(dimension)))
                {
                    //Присваиваем переменной dimension, значение по умолчанию, равное 10
                    dimension = 10;
                }
                else { }
            }
            //Выполняем очищение сгенерированной матрицы
            for (int i = 0; i < (dimension); i++)
            {
                for (int j = 0; j < (dimension); j++)
                {
                    //Выполняем очищение сгенерированной матрицы
                    a[i, j] = 0;
                    //Выполняем вывод матрицы нулей
                    dataGridView3.Rows[i].Cells[j].Value = a[i, j].ToString();
                }
            }
            //Выполняем очищение поля ввода элемента textBox3
            textBox3.Text = " ";
            //Выполняем очищение поля ввода textBox4
            textBox4.Text = " ";
            //Выполняем очищение поля ввода textBox5
            textBox5.Text = " ";
            //Выполняем очищение поля ввода textBox6
            textBox6.Text = " ";
            //Выполняем очищение поля ввода textBox7
            textBox7.Text = " ";
            //Очищаем поле вывода данных для элемента label7
            label7.Text = " ";
            //Очищаем поле вывода данных для элемента label8
            label8.Text = " ";
            //Очищаем поле вывода данных для элемента label13
            label13.Text = " ";
            //Возвращаем в поле вывода данных для элемента label14 прежнюю надпись
            label14.Text = "Вероятность Мутации";
            //Очищаем поле вывода данных для элемента label15
            label15.Text = " ";
            //Очищаем поле вывода данных для элемента label17
            label17.Text = " ";
            //Возврашаем исходную надпись над полем для ввода константы С
            label20.Text = "Ввод C = const";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Выполняем закрытие самой формы 1, а не окна этой формы
            Application.Exit();
        }
    }
}


