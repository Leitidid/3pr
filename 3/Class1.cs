namespace Lib_5
{
    public static class Matrix
    {
       
        public static double[] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            // Количество нечетных строк
            int nechetchet = (rows + 1) / 2; 
            double[] averages = new double[nechetchet]; // хранение средних значений
            int nechet = 0; // Счетчик нечетных строк

            // Идем по строкам в матрице с шагом 2, начиная с 1 (т.е. нечетные индексы)
            for (int i = 1; i < rows; i += 2)
            {
                int sum = 0;

                // Суммируем элементы текущей нечетной строки
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }

                // Расчет среднего арифметического
                averages[nechet] = (double)sum / cols;
                nechet++; // Увеличиваем счетчик нечетных строк
            }

            return averages;
        }
    }
}