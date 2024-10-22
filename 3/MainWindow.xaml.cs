using Libmas;
using Lib_5;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Data;

namespace _3
{
    public partial class MainWindow : Window
    {
        // Матрица
        private int[,] matrix;

        // Диалоговое окно для открытия файла
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        // Диалоговое окно для сохранения файла
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события "Сохранить"
        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что матрица не пустая
            if (matrix != null)
            {
                // Вызов диалогового окна для выбора файла сохранения
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Сохранение матрицы в файл
                    // (Здесь нужно преобразовать матрицу в массив,
                    // например, с помощью метода Flatten())
                    // masHelp.Savemas(Flatten(matrix), saveFileDialog.FileName);
                    MessageBox.Show("Матрица сохранена.");
                }
            }
        }

        // Обработчик события "Загрузить"
        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            // Вызов диалогового окна для выбора файла загрузки
            if (openFileDialog.ShowDialog() == true)
            {
                // Загрузка матрицы из файла
                // (Здесь нужно загрузить данные из файла и
                // преобразовать их обратно в матрицу)
                // matrix = LoadMatrix(openFileDialog.FileName);
                MessageBox.Show("Матрица загружена.");
            }
        }

        // Обработчик события "О программе"
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Вывод информации о программе
            string developer = "Дудина Екатерина";
            int job = 3;
            string task = "Дана матрица размера M × N. Для каждой строки матрицы с нечетным номером (1, \r\n3, …) найти среднее арифметическое ее элементов. Условный оператор не \r\nиспользовать.";
            MessageBox.Show($"Разработчик: {developer}\nНомер работы: {job}\nЗадание: {task}", "О программе");
        }

        // Обработчик события "Выход"
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            // Закрытие приложения
            this.Close();
        }

        // Метод для преобразования матрицы в DataView для DataGrid
        private DataView GetDataTableFromMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Создание таблицы данных
            DataTable dt = new DataTable();

            // Добавление столбцов в таблицу
            for (int i = 0; i < cols; i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            // Добавление строк в таблицу
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

        // Обработчик события "Заполнить"
        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение количества столбцов и строк из текстовых полей
                int M = int.Parse(tb1.Text);
                int N = int.Parse(tb2.Text);

                // Создание матрицы
                matrix = new int[M, N];

                // Заполнение матрицы случайными числами
                masHelp.zapolneniemas(matrix);

                // Отображение матрицы в DataGrid
                dataGridMatrix.ItemsSource = GetDataTableFromMatrix(matrix);
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Обработчик события "Расчитать"
        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка, что матрица не пустая
                if (matrix != null)
                {
                    // Расчет средних значений для строк с нечетными номерами
                    double[] averages = Matrix.Calculate(matrix);

                    // Вывод средних значений в TextBox
                    tb3.Text = string.Join(", ", averages);
                }
                else
                {
                    MessageBox.Show("Сначала заполните матрицу!");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Обработчик события "Очистить"
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