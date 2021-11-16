using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.Write("Ingrese la cantidad de filas:");
                //int cantidadFilas = int.Parse(Console.ReadLine());
                //Console.Write("Ingrese la cantidad de columna:");
                //int cantidadColumnas = int.Parse(Console.ReadLine());
                //string[,] matrizA = CargarMatriz(cantidadFilas, cantidadColumnas);
                //string[,] matrizB = CargarMatriz(cantidadFilas, cantidadColumnas);
                //MostrarMatriz(matrixA);
                var matrizA = new string[,]
                {
                    {"ASD", "QWE", "ZXC", "QAZ"},
                    {"RTY", "FGH", "VBN", "WSX"},
                    {"UIO", "JKL", "NMÑ", "EDC"},
                };

                var matrizB = new string[,]
                {
                    {"QQQ", "WWW", "EEE", "PLM"},
                    {"AAA", "SSS", "DDD", "OKN"},
                    {"ZZZ", "NNN", "CCC", "IJB"},
                    //{"ZZZ", "NNN", "CCC", "IJB"}
                };

                var nuevaMatriz = IntercalarMatrices(matrizA, matrizB);
                MostrarMatriz(nuevaMatriz);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }
            Console.ReadLine();
        }

        private static string[,] IntercalarMatrices(string[,] matrixA, string[,] matrixB)
        {

            if (matrixA.Rank != matrixB.Rank)
            {
                throw new InvalidOperationException("Matrices con dimensiones diferentes!!!");
            }

            if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixB.GetLength(1) != matrixB.GetLength(1))
            {
                throw new InvalidOperationException("Matrices con cantidad de filas y/o columnas diferentes!!!");
            }

            var nuevaMatrix = new string[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int fila = 0; fila < matrixA.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matrixA.GetLength(1); columna++)
                {
                    if (columna % 2 == 0)
                    {
                        nuevaMatrix[fila, columna] = matrixA[fila, columna];
                    }
                    else
                    {
                        nuevaMatrix[fila, columna] = matrixB[fila, columna];
                    }
                }
            }

            return nuevaMatrix;
        }

        private static void MostrarMatriz(string[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("Mostrando elementos de la Matriz");
            for (int fila = 0; fila < matrix.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matrix.GetLength(1); columna++)
                {
                    Console.Write($"{matrix[fila, columna]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        private static string[,] CargarMatriz(int cantidadFilas, int cantidadColumnas)
        {
            string[,] matrix = new string[cantidadFilas, cantidadColumnas];
            for (int fila = 0; fila < cantidadFilas; fila++)
            {
                for (int columna = 0; columna < cantidadColumnas; columna++)
                {
                    Console.Write($"Ingrese el contenido del elemento [{fila},{columna}]:");
                    matrix[fila, columna] = Console.ReadLine();
                }
            }

            return matrix;
        }
    }
}
