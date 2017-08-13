using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_1
{
    /// <summary>
    /// Основной класс формы
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Контракт на рисование
        /// </summary>
        Graphics g;

        /// <summary>
        /// Множество точек - вершин
        /// </summary>
        List<Point> p = new List<Point>();

        /// <summary>
        /// Затравочная точка
        /// </summary>
        Point FloodPoint;

        /// <summary>
        ///  Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сравнение цветов для двух точек
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool ColorMatch(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        /// <summary>
        /// Закраска многоугольника "затравкой"
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="pt"></param>
        /// <param name="targetColor"></param>
        /// <param name="replacementColor"></param>
        static void FloodFill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            // Стэк точек матрицы изображения
            Queue<Point> q = new Queue<Point>();

            // Помещаем затравочную точку в стэк
            
            q.Enqueue(pt);
            // Пока стэк не пуст
            while (q.Count > 0)
            {
                // Вытаскиваем точку из сиэка
                Point n = q.Dequeue();

                // Сравниваем с цветом закраски
                if (!ColorMatch(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;

                // Берем соседнюю точку
                Point w = n, e = new Point(n.X + 1, n.Y);

                // Проверяем на цвета границ, фона и заполнения
                while ((w.X >= 0) && ColorMatch(bmp.GetPixel(w.X, w.Y), targetColor))
                {
                    bmp.SetPixel(w.X, w.Y, replacementColor);
                    if ((w.Y > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y - 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y - 1));
                    if ((w.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(w.X, w.Y + 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y + 1));
                    w.X--;
                }

                // Проверяем на цвета границ, фона и заполнения
                while ((e.X <= bmp.Width - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y), targetColor))
                {
                    bmp.SetPixel(e.X, e.Y, replacementColor);
                    if ((e.Y > 0) && ColorMatch(bmp.GetPixel(e.X, e.Y - 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y - 1));
                    if ((e.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y + 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y + 1));
                    e.X++;
                }
            }
        }

        /// <summary>
        /// Вызов закраски
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void FloodFillColorize(int x, int y)
        {
            // Получение изображения для обработки
            Bitmap b = new Bitmap(pictureBox1.Image);
            // Затравка
            FloodFill(b, new Point(x, y), Color.White, Color.Blue);
            // Выгрузка результата на форму
            pictureBox1.Image = b;
            pictureBox1.Invalidate();
            MessageBox.Show("Готово!");
        }

        void SimpleColorize()
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            GraphicsPath gp;
            gp = new GraphicsPath();
            gp.AddPolygon(p.ToArray());
            Region region = new Region(gp);
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width - 1; j++)
                {
                    Point pp = new Point(j, i);
                    if (region.IsVisible(pp))
                    {
                        b.SetPixel(j, i, Color.Blue);
                    }
                    else
                    {
                        b.SetPixel(j, i, Color.White);
                    }
                }
            }
            pictureBox1.Image = b;
            pictureBox1.Invalidate();
            MessageBox.Show("Готово!");
        }

        /// <summary>
        /// Перерисовка сцены
        /// </summary>
        private void Redraw()
        {
            // Очистка холста
            ClearPic();
            g = Graphics.FromImage(pictureBox1.Image);
            // Обход всех точек вершин
            foreach(var i in p)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Black)
                    , i.X - 5
                    , i.Y - 5
                    , 10
                    , 10
                    );
            }
            // Первая линия (когда точек всего две)
            if (p.Count == 2)
                g.DrawLine(
                    new Pen(Color.Black, 3)
                    , new Point(p[0].X, p[0].Y)
                    , new Point(p[1].X, p[1].Y)
                    );
            // Остальные точки (когда их больше двух)
            if (p.Count > 2)
                g.DrawPolygon(
                    new Pen(Color.Black, 3)
                    , p.ToArray()
                    );
            pictureBox1.Invalidate();            
        }

        // Полная очистка холста
        private void ClearPic()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);

            gr.Clear(Color.White);
            gr.Dispose();

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание инструментов
            g = CreateGraphics();
            // Сглаживание рисунка
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Создание изображения
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // Вывод очищенного на форму
            pictureBox1.Image = b;
            pictureBox1.Invalidate();
            // Обнуление всего
            ClearPic();
            FloodPoint.X = 0;
            FloodPoint.Y = 0;

            // 2
            floodFillToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Не используется пока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик события нажатия на кнопку мыши (правая рисует, левая закрашивает)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Левая кропка
            if (e.Button == MouseButtons.Left)
            {
                // Добавляем точку
                p.Add(new Point(e.X, e.Y));
                // Перерисовываем сцену
                Redraw();
            }
            // Правая кновка
            if (e.Button == MouseButtons.Right)
            {
                //2
                floodFillToolStripMenuItem.Enabled = true;


                FloodPoint = new Point(e.X, e.Y);
                string msg = "Затравочная точка поставлена в координатах : "
                    + "X = "
                    + FloodPoint.X.ToString()
                    + ", Y = "
                    + FloodPoint.Y.ToString();
                MessageBox.Show(msg);
                Redraw();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1
            //if ((FloodPoint.X == 0) && (FloodPoint.Y == 0))
            //{
            //    MessageBox.Show("Поставьте затравочную точку правой кнопкой мышки!");
            //}
            //else
            //{
            //    FloodFillColorize(FloodPoint.X, FloodPoint.Y);
            //}
            // 2
            FloodFillColorize(FloodPoint.X, FloodPoint.Y);
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleColorize();
        }
    }
}
