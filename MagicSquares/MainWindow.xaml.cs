using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace MagicSquares
{
    public partial class MainWindow : Window
    {
        int[,] magicSquare;
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void encrypt_button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(matrix_n.Text);
            string text = text_box.Text;

            if (text.Length % (n * n) != 0)
            {
                MessageBox.Show("The text length must be a multiple of the matrix size!");
                return;
            }


            StringBuilder encryptedMessage = new StringBuilder();

            for (int k = 0; k < text.Length / (n*n); k++)
            {
                int i = 0;

                for (; i < n; i++)
                {
                    StringBuilder encryptedRow = new StringBuilder();

                    for (int j = 0; j < n; j++)
                    {
                        encryptedRow.Append(text[k * n * n + magicSquare[i, j] - 1]);
                    }
                    encryptedMessage.Append(encryptedRow);
                }
            }
        }

        private void decrypt_button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(matrix_n.Text);
            string text = text_box.Text;

            if (text.Length % (n * n) != 0)
            {
                MessageBox.Show("The text length must be a multiple of the matrix size!");
                return;
            }

            char[] decryptedMessage = new char[text.Length];

            for (int k = 0; k < text.Length / (n * n); k++)
            {
                int i = 0;

                for (; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        decryptedMessage[k * n * n + magicSquare[i, j] - 1] = text[k * n * n + i * n + j];
                    }
                }
            }

            result_text.Text = new string(decryptedMessage);
        }

        private void generate_button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(matrix_n.Text);

            magicSquare = GenerateMatrix(n);
            PrintMatrix(magicSquare, n);
        }

        private int[,] GenerateMatrix(int n)
        {
            Random random = new Random();

            int[,] matrix = new int[n, n];
            int[] numbers = new int[n*n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int temp = numbers[i];
                int randomIndex = random.Next(i, numbers.Length);
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = temp;
            }

            int count = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[count];
                    count++;
                }
            }

            return matrix;
        }

        private void PrintMatrix(int[,] matrix, int n)
        {
            matrix_text.Text = "";
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix_text.Text += matrix[row, col] + " ";
                }
                matrix_text.Text += "\n";
            }
        }
    }
}
