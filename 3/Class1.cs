namespace Lib_5
{
    public static class Matrix
    {
        // Расчет средних значений для строк с нечетными номерами
        public static double[] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] averages = new double[rows / 2];
            for (int i = 1; i < rows; i += 2)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }
                averages[i / 2] = (double)sum / cols;
            }
            return averages;
        }
    }
}