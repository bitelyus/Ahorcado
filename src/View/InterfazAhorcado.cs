using System;

namespace Ahorcado.src.View
{

    public static class InterfazAhorcado {

        /// <summary>
        /// Procedimiento para mostrar el menu de opciones principal
        /// </summary>
        public static void mostrarMenu(int nivel) {
            
            string salida;
            
            CH.cls();
            salida = "\n";
            Console.ForegroundColor = ConsoleColor.Cyan;
            salida += "+===================================+\n";
            salida += "|   EL JUEGO DEL AHORCADO - V 1.0   |\n";
            salida += "|    - - - - - - - - - - - - - -    |\n";
            salida += "|      By MiK - 2º D.A.M. CENEC     |\n";
            salida += "+===================================+\n";
            switch (nivel) {
                case 1:
                    salida += "       + -  NIVEL: FÁCIL  - +\n";
                    break;
                case 2:
                    salida += "       + -  NIVEL: DIFICIL - +\n";
                    break;
            }
            Console.WriteLine(salida);
            Console.ForegroundColor = ConsoleColor.White;
            salida = "1. INICIAR NUEVA PARTIDA\n";
            salida +="2. CAMBIAR DE NIVEL\n\n";
            salida += "3. INCLUIR NUEVAS PALABRAS\n\n";
            salida += "4. LISTAR PALABRAS DICCIONARIO\n\n";
            salida += "0. SALIR\n\n";
            Console.Write(salida);


        }

        /// <summary>
        /// Procedimiento para mostrar el dibujito del ahorcado segun el número de vidas que queden
        /// </summary>
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

        /// <summary>
        /// Procedimiento para mostrar el dibujito del ahorcado segun el número de vidas que queden
        /// </summary>
        public static void lifesLeftDificult(int vidas) {
            string salida;

            salida = "";
            switch (vidas) {
                case 5:
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="         :)\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    salida+="\n";
                    break;
                case 4:
                    salida+="\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 3:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 2:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|\n";
                    salida+="|    / \\     \n";
                    salida+="|            \n";
                    salida+="|_________________\n";
                    salida+="|________________|\n"; 
                    break;
                case 1:
                    salida+="_____________\n";
                    salida+="|     |      \n";
                    salida+="|\n";
                    salida+="|    /|\n";
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

        /// <summary>
        /// Procedimiento para mostrar el resultado de la palabra con los aciertos
        /// </summary>

        public static void mostrarResultado(char[] resultado) {
            string salida;

            salida="";
            foreach (char c in resultado) {
                
                    salida+=c.ToString() + " ";   
                  
            }
            CH.lcd("\nI> RESOLUCION: " + salida); 
        }


        /// <summary>
        /// Función para mostrar las letras que ya se han dicho por pantalla
        /// </summary>
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