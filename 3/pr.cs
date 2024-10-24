using System.IO;

namespace Libmas
{
    public static class masHelp
    {
        // Заполнение массива числами от 1 до 10
        public static void zapolneniemas(int[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 11);
                }
            }
        }

        // Очистка массива
        public static void ochistkamas(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = 0;
                }
            }
        }

        // Сохранение массива 
        public static void Savemas(int[] mas, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (int num in mas)
                {
                    writer.WriteLine(num);
                }
            }
        }

        // Загрузка массива 
        public static int[] Loadmas(string file)
        {
            if (!File.Exists(file))
            {
                return new int[0];
            }

            int[] mas = new int[File.ReadAllLines(file).Length];
            int i = 0;
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    mas[i++] = int.Parse(reader.ReadLine());
                }
            }
            return mas;
        }
    }
}
