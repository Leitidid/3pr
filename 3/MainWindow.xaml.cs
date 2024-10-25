using Lib_5;
using Libmas;
using Microsoft.Win32;
using System.Data;
using System.Windows;

namespace _3
{
    public partial class MainWindow : Window
    {
        // Матрица
        private int[,] matrix;

        //  открытие файла
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        //сохранение файла
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        // "Сохранить"
        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            // матрица не пустая
            if (matrix != null)
            {
                // сохранение файла
                if (saveFileDialog.ShowDialog() == true)
                {
                    MessageBox.Show("Матрица сохранена");
                }
            }
        }

        //  "Загрузить"
        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show("Матрица загружена.");
            }
        }

        //  "О программе"
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string developer = "Дудина Екатерина";
            int job = 3;
            string task = "Дана матрица размера M × N. Для каждой строки матрицы с четным номером найти среднее арифметическое ее элементов. Условный оператор не \r\nиспользовать.";
            MessageBox.Show($"Разработчик: {developer}\nНомер работы: {job}\nЗадание: {task}", "О программе");
        }

        // "Выход"
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // переход матрицы в DataView для DataGrid
        private DataView GetDataTableFromMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            DataTable dt = new DataTable(); // Добавление столбцов 
            for (int i = 0; i < cols; i++)
            {
                dt.Columns.Add("колонки" + (i + 1));
            }
 // Добавление строк
            for (int i = 0; i < rows; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    dr[j] = matrix[i, j];
                }
                dt.Rows.Add(dr);
            }
           // Возвращение DataView
            return dt.DefaultView;
        }

        // "Заполнить"
        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int M = int.Parse(tb1.Text);
                int N = int.Parse(tb2.Text);

                // Создание матрицы
                matrix = new int[M, N];

                // Заполнение матрицы 
                masHelp.zapolneniemas(matrix);

                // Отображение матрицы в DataGrid
                dataGridMatrix.ItemsSource = GetDataTableFromMatrix(matrix);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // "Расчитать"
        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (matrix != null)
                {
                    // Расчет средних значений для строк с четными номерами
                    double[] averages = Matrix.Calculate(matrix);
                    tb3.Text = string.Join(", ", averages);
                }
                else
                {
                    MessageBox.Show("Сначала заполните матрицу!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        //"Очистить"
        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            // Очистка матрицы
            masHelp.ochistkamas(matrix);

            // Обновление DataGrid
            dataGridMatrix.ItemsSource = GetDataTableFromMatrix(matrix);

            // Очистка TextBox
            tb3.Text = "";
        }
    }
}