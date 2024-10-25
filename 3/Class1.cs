namespace Lib_5
{
    public static class Matrix
    {
       
        public static double[] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            // ���������� ������ �����
            int nechetchet = (rows + 1) / 2; 
            double[] averages = new double[nechetchet]; // �������� ������� ��������
            int nechet = 0; // ������� ������ �����
            for (int i = 1; i < rows; i += 2)
            {
                int sum = 0;

                // ��������� �������� ������� ������ ������
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }

                // ������ �������� ���������������
                averages[nechet] = (double)sum / cols;
                nechet++; // ����������� ������� ������ �����
            }

            return averages;
        }
    }
} 