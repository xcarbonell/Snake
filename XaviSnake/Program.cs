using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XaviSnake
{
    class Program
    {
        public static int[] columnasUsadas;
        public static int[] filasUsadas;
        public static int indexUsadas = 0;
        static void Main(string[] args)
        {
            //int[,] tablero = new int[8, 8];
            int columna = 0;
            int fila = 0;
            //columnasUsadas[indexUsadas] = 0;
            //filasUsadas[indexUsadas] = 0;
            actualizarTablero(columna, fila);

            ConsoleKey move;
            move = Console.ReadKey(true).Key;
            bool validMove = checkMove(move, columna, fila);

            while (true)
            {
                //if checkmove == true hacer movimiento, sino repreguntar
                //checkMove(columna, fila);
                if (validMove)
                {
                    int[] a = moveSnake(move, columna, fila);
                    Console.WriteLine("fila: " + a[0].ToString());
                    Console.WriteLine("columna: " + a[1].ToString());
                    columna = a[0];
                    fila = a[1];
                    actualizarTablero(columna, fila);
                }
                else
                {
                    //Console.WriteLine("Salida del tablero");
                    break;
                }
                move = Console.ReadKey(true).Key;
                validMove = checkMove(move, columna, fila);
                Console.WriteLine(validMove);
            }


            Console.WriteLine("Te has chocado contra la pared. Has perdido.");
            Console.ReadLine();
        }

        static bool checkMove(ConsoleKey move, int columna, int fila)
        {
            if (move == ConsoleKey.DownArrow || move == ConsoleKey.UpArrow || move == ConsoleKey.RightArrow || move == ConsoleKey.LeftArrow)
            {
                switch (move)
                {
                    case ConsoleKey.UpArrow:
                        //arriba
                        if (columna-- < 1)
                        {
                            return false;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        //izq
                        if (fila-- < 1)
                        {
                            return false;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        //abajo
                        if (columna++ > 6)
                        {
                            return false;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //der
                        if (fila++ > 6)
                        {
                            return false;
                        }
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] moveSnake(ConsoleKey movimiento, int columna, int fila)
        {
            int[] posicion = new int[2];
            switch (movimiento)
            {
                case ConsoleKey.UpArrow:
                    //arriba
                    columna--;
                    break;
                case ConsoleKey.LeftArrow:
                    fila--;
                    break;
                case ConsoleKey.DownArrow:
                    //abajo
                    columna++;
                    break;
                case ConsoleKey.RightArrow:
                    //der
                    fila++;
                    break;
            }
            //Console.WriteLine(columnasUsadas[indexUsadas] + " " + filasUsadas[indexUsadas] + " " + indexUsadas);
            posicion[0] = columna;
            posicion[1] = fila;
            return posicion;
        }

        static void actualizarTablero(int fila, int columna)
        {
            Console.WriteLine();
            Console.WriteLine("─────────────────");
            bool filaEncontrada = false;
            for (int i = 0; i < 8; i++)
            {
                if(i == fila)
                {
                    filaEncontrada = true;
                }
                Console.Write("│");
                for (int j = 0; j < 8; j++)
                {
                    if (filaEncontrada)
                    {
                        if (j == columna)
                        {
                            /*indexUsadas++;
                            columnasUsadas[indexUsadas] = j;
                            filasUsadas[indexUsadas] = i;*/
                            Console.Write("█│");
                        }
                        else
                        {
                            Console.Write(" │");
                        }
                    }
                    else
                    {
                       Console.Write(" │");
                    }
                }
                filaEncontrada = false;
                Console.WriteLine();
                Console.WriteLine("─────────────────");
            }
        }
    }
}
