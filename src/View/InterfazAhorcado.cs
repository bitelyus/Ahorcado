using System;

namespace Ahorcado.src.View
{
    public static class InterfazAhorcado {

        public static void mostrarMenu() {
            
            string salida;
            
            CH.cls();
            salida = "\n";
            Console.ForegroundColor = ConsoleColor.Cyan;
            salida += "+===================================+\n";
            salida += "|   EL JUEGO DEL AHORCADO - V 1.0   |\n";
            salida += "|    - - - - - - - - - - - - - -    |\n";
            salida += "|      By MiK - 2º D.A.M. CENEC     |\n";
            salida += "+===================================+\n";
            Console.WriteLine(salida);
            Console.ForegroundColor = ConsoleColor.White;
            salida = "1. INICIAR NUEVA PARTIDA\n";
            salida += "2. INCLUIR NUEVAS PALABRAS\n\n";
            salida += "3. LISTAR PALABRAS DICCIONARIO\n\n";
            salida += "0. SALIR\n\n";
            Console.Write(salida);


        }

        public static void lifesLeft(int vidas) {
            string salida;

            salida = "";
            switch (vidas) {
                case 10:
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="         :)\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    break;
                case 9:
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="__________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 8:
                    salida+="\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 7:
                    salida+="_____________\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 6:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 5:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|    /\n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 4:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|    / \\     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 3:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|    /\n";
                    salida+="|    / \\     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 2:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|    /|\n";
                    salida+="|    / \\     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 1:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|    /|\\     \n";
                    salida+="|    / \\     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 0:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|     O      \n";
                    salida+="|    /|\\    \n";
                    salida+="|    / \\    \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
            }
            CH.lcdColor(salida,ConsoleColor.Red);
        }

        public static void mostrarLetras(char[] letras) {
            string salida;

            salida="HAS DICHO: ";
            foreach (char c in letras) {
                salida+= c.ToString() + " - ";
            }
            salida+="\n";

            CH.lcdColor(salida,ConsoleColor.Cyan);
        }

    }
}

/*

                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|     O      \n";
                    salida+="|    /|\     \n";
                    salida+="|    / \     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n";
*/