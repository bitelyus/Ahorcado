using System;
using System.IO;
using Ahorcado.src.View;
using Ahorcado.src.Model;

namespace Ahorcado.src.Controler
{
    public static class ControlerAhorcado
    {
        // ZONA DE VARIABLES GLOBALES NECESARIAS PARA EL FUNCIONAMIENTO DEL JUEGO
        private static Diccionario diccionario = new Diccionario();         // MI DICCIONARIO QUE CONTENDRÁ TODAS LAS PALABRAS
        private static string ruta_carpeta = "Data";                        // LA CARPETA PARA EL FICHERO diccionario.txt
        private static string ruta_diccionario = "Data/diccionario.txt";    // LA RUTA COMPLETA DEL diccionario.txt
        private static string palabra = null;                               // LA PALABRA QUE HABRÁ QUE ACERTAR
        public static char[] letras = null;                                 // LETRAS QUE YA HE DICHO
        private static int nivel;                                           // EL NIVEL DEL JUEGO
        private static int vidas;                                           // NUMERO DE VIDAS DEPENDIENDO DEL NIVEL

        /// <sumary>
        /// FUNCIÓN PÚBLICA PARA QUE COMIENZE LA FUNCIÓN!! ES LLAMADA DESDE EL MAIN
        /// </sumary>
        public static void comenzar()
        {

            // 1. Mostrar Menú
            // 2. Pedir Opción
            // 3. Evaluar Opción
            // 4. Actuar en consecuencia

            // DECLARACIÓN DE VARIALBES
            bool salir;     // CONTROL DE SALIDA 
            int opcion;     // OPCIÓN ELEGIDA

            // ENTRADA

            salir = false;
            nivel = 1;
            vidas = 10;

            // PROCESO
            comprobarFicheros();                            // COMPROBAMOS LA EXISTENCIA LA ESTRUCTURA DE DATOS PARA EL diccionario.txt


            do
            {                                            // PRESENTAR EL MENU HASTA QUE LA OPCIÓN SEA SALIR
                InterfazAhorcado.mostrarMenu(nivel);             // MOSTRAMOS EL MENÚ
                opcion = CH.leerOpcion(4);                  // PEDIMOS LA OPCIÓN

                switch (opcion)
                {                           // EVALUAMOS LA OPCIÓN
                    case 1:                                 // 1. INICIAR NUEVA PARTIDA
                        ControlerAhorcado.iniciarPartida();
                        break;
                    case 2:                                 // 2. CAMBIAR DE NIVEL
                        ControlerAhorcado.cambiarNivel();
                        break;
                    case 3:                                 // 3. INCLUIR NUEVAS PALABRAS
                        ControlerAhorcado.agregarPalabra();
                        break;
                    case 4:                                 // 4. SALIR DEL PROGRAMA
                        CH.lcd(diccionario.ToString());
                        CH.pausa();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            } while (!salir);

            // SALIDA
            CH.lcdColor("\nBYE BYE, MiK.... Vuelve pronto!! >:)\n ", ConsoleColor.Cyan);

        }

        /// <sumary>
        /// PROCEDIMIENTO PARA COMENZAR UNA NUEVA PARTIDA
        /// </sumary>
        public static void iniciarPartida()
        {

            // 1. Comprobar existencia de palabras en el diccionario
            // 2. Elegir una palabra al azar
            // 3. Comenzar a pedir letras o palabra resolver

            char letra;
            char[] palabra_char;
            char[] resultado;
            string salida;

            Random random;
            int opcion, palabras, contador, i, j, aciertos, fallos, intentos, posicion;
            bool encontrada, salir;

            // SÓLO SI EL DICCIONARIO DE PALABRAS NO ESTÁ VACIO, COMENZAMOS EL JUEVO
            if (diccionario.palabras != null)
            {

                // SETEAMOS NUESTRAS VARIABLES
                letras = null;
                palabras = diccionario.palabras.Length;
                random = new Random();

                // EVALUAMOS EL NIVEL DE JUEGO PARA ELEGIR PALABRAS DE MAS DE 8 CARACTERES...

                switch (nivel)
                {
                    case 1:
                        opcion = random.Next(palabras);
                        palabra = diccionario.palabras[opcion];
                        break;
                    case 2:
                        do
                        {
                            opcion = random.Next(palabras);
                            palabra = diccionario.palabras[opcion];
                        } while (palabra.Length < 8);
                        break;
                }

                // CONVERTIMOS LA PALABRA A ARRAY DE CHARSSS PARA PODER REALIZAR COMPROBACION UNA A UNA
                palabra_char = palabra.ToCharArray();

                // SETEAMOS EL RESULTADO CON LAS RALLITAS VACIAS... 
                resultado = new char[palabra_char.Length];
                for (j = 0; j < resultado.Length; j++)
                {
                    resultado[j] = '_';
                }

                // INICIALIZAMOS EL RESTO DE VARIALES QUE VAMOS A USAR DURANTE EL JUEGO

                palabras = palabra.Length;
                encontrada = false;
                salir = false;
                aciertos = 0;
                fallos = 0;
                intentos = 0;
                i = 0;
                salida = "";

                // MOSTRAMOS INFORMACION DEL COMIENZO DEL JUEVO POR LA PANTALLA

                //CH.lcd("l> PALABRA A ACERTAR: " + palabra);
                CH.lcdColor("\ni> OK, MiK.. VAMOS A JUGAR UN POCO\ni> INTRODUCE [RESOLVER] PARA RESOLVER\ni> YO YA TENGO LA PALABRA\n", ConsoleColor.Cyan);
                for (j = 0; j < palabras; j++)
                {
                    salida += "_ ";
                }
                CH.lcdColor("i> PALABRA: " + salida + "\n", ConsoleColor.Cyan);

                // Y COMENZAMOS A PEDIR PALABRAS ....

                do
                {
                    contador = 0;
                    posicion = 0;
                    encontrada = false;
                    letra = CH.leerChar("INTRODUCE UNA LETRA");
                    if (letra == '0')
                    {
                        if (resolver((vidas - fallos)))
                        {
                            salir = true;
                        }
                        else
                        {
                            intentos++;
                        }
                    }
                    if (!salir && letra != '0')
                    {
                        //CH.lcd("l> LETRA: " + letra);
                        intentos++;

                        // COMPROBAMOS SI YA HAS DICHO LA LETRA INTRODUCIDA
                        if (!estaLetra(letra))
                        {
                            // Y SI NO ESTA DICHA, LA AGREGAMOS A LAS DICHAS, 
                            agregarLetra(letra);

                            // Y COMENZAMOS A VER SI ESTA EN LA PALABRA UNA POR UNA
                            foreach (char c in palabra)
                            {
                                //CH.lcd("c: " + c + " | l: " + letra + " | pos: " + posicion);
                                if (c.Equals(letra))
                                {
                                    // SI LA ENCONTRAMOS.. LA CAMBIAMOS EN EL RESULTADO Y SETEAMOS ENCONTRADA A  TRUE
                                    encontrada = true;
                                    contador++;
                                    resultado[posicion] = letra;
                                    //break;
                                }
                                posicion++;
                            }

                            CH.cls();

                            // MOSTRAMOS EL RESULTADO POR PANTALLA
                            InterfazAhorcado.mostrarResultado(resultado);

                            // SI NO ESTA, AÑADIMOS FALLOS Y MOSTRAMOS MENSAJE
                            if (!encontrada)
                            {
                                fallos++;
                                CH.lcdColor("\ni> LA LETRA '" + letra + "' NO ESTA! | INTENTOS: " + intentos + " | ACIERTOS: " + aciertos + " | VIDAS: " + (vidas - fallos), ConsoleColor.Red);
                            }
                            else // SI ESTA, AÑADIMOS ACIERTOS Y MOSTRAMOS MENSAJE
                            {
                                aciertos += contador;
                                i++;
                                CH.lcdColor("\ni> PALABRA ENCONTRADA " + contador + " VECES | INTENTOS: " + intentos + " | ACIERTOS: " + aciertos + " | VIDAS: " + (vidas - fallos), ConsoleColor.Yellow);
                            }

                            // COMPROBAMOS SI HEMOS ACERTADO LA PALABRA
                            if (aciertos == palabras)
                            {
                                // MOSTRAMOS RESULTADO Y MENSAJE Y SE ACABO
                                switch (nivel) {
                                    case 1:
                                        InterfazAhorcado.lifesLeft(vidas - fallos);
                                        break;
                                    case 2:
                                        InterfazAhorcado.lifesLeftDificult(vidas - fallos);
                                        break;
                                }

                                CH.lcdColor("\n!> ENHORABUENA MAAAKINA!!! HAS GANADO | PUNTOS:" + (vidas - fallos), ConsoleColor.DarkGreen);
                                salir = true;
                            }
                            else
                            {
                                // SI NO HEMOS ACERTADO, MOSTRAMOS PANEL DE VIDAS Y COMPRAMOS FALLOS PARA FIN DE PARTIDA
                                switch (nivel) {
                                    case 1:
                                        InterfazAhorcado.lifesLeft(vidas - fallos);
                                        break;
                                    case 2:
                                        InterfazAhorcado.lifesLeftDificult(vidas - fallos);
                                        break;
                                }
                                InterfazAhorcado.mostrarLetras(letras);
                                if (fallos == vidas)
                                {
                                    salir = true;
                                    CH.lcdColor("\n!> WOUNNN WOUNNN WOUNNN.... HAZ MUERTO, XAVAL!!!", ConsoleColor.Red);
                                    CH.lcdColor("\ni> LA PALABRA ERA: " + palabra, ConsoleColor.Red);
                                }
                            }
                        }
                        else
                        {
                            CH.lcdColor("!> YA HAS DICHO ESA LETRA, WEBON!! ... INTENTOS +1", ConsoleColor.Red);
                            //CH.pausa();
                        }
                    }
                } while (!salir);
            }
            else
            {
                CH.lcdColor("!> NO HAY PALABRAS EN EL DICCIONARIO!!", ConsoleColor.Red);
            }
            CH.pausa();
        }

        /// <summary>
        /// Función para comprobar la existencia del fichiro de datos diccionario.txt
        /// Si no existe, lo creamos.
        /// </summary>
        public static void comprobarFicheros()
        {

            string mensaje;

            mensaje = "";

            CH.cls();
            try
            {

                if (!Directory.Exists(ruta_carpeta))
                {
                    Directory.CreateDirectory(ruta_carpeta);
                    File.CreateText(ruta_diccionario);
                    mensaje = "i> SE HA CREADO LA CARPETA 'Data' PARA EL DICCIONARIO Y EL FICHERO 'diccionario.txt'";
                }
                else
                {
                    mensaje = "i> DIRECTORIO DE TRABAJO LOCALIZADO : CARGANDO PALABRAS AL DICCIONARIO A CONTINUACION...'";
                    cargarPalabras();
                }
            }
            catch (IOException ex)
            {
                CH.lcdColor("!> ERROR E/S:" + ex.Message, ConsoleColor.Red);
            }

            CH.lcdColor("\n" + mensaje, ConsoleColor.Green);
            CH.pausa();
        }

        /// <summary>
        /// Función para cambiar el nivel de la partida a dificial
        /// </summary>
        public static void cambiarNivel()
        {
            switch (nivel)
            {

                case 1:
                    nivel = 2;
                    vidas = 5;
                    CH.lcdColor("\ni> HAS CAMBIADO A NIVEL DIFICIL!!\ni> PALABRAS DE MAS DE 8 LETRAS Y SÓLO 5 INTENTOS", ConsoleColor.Green);
                    CH.pausa();
                    break;
                case 2:
                    nivel = 1;
                    vidas = 10;
                    CH.lcdColor("\ni> HAS CAMBIADO A NIVEL DIFICIL!!\ni> PALABRAS DE MAS DE 8 LETRAS Y SÓLO 5 INTENTOS", ConsoleColor.Green);
                    CH.pausa();
                    break;

            }
        }

        /// <summary>
        /// MÉTODO PARA LEER UN FICHERO DE TEXTO Y AGREGAR PALABRAS A UN ARRAY DE PALABRAS
        /// </summary>
        public static void cargarPalabras()
        {
            // DECLARACION VARIABLES
            StreamReader sr;
            string linea;

            // ASIGNACION VARIABLES: ENTRADA
            sr = File.OpenText(ruta_diccionario);

            linea = "";

            // PROCESO
            while (!sr.EndOfStream)
            {
                linea = sr.ReadLine();
                diccionario.agregarPalabra(linea);
            }

            // SALIDA
            sr.Dispose();
            //CH.lcdColor("i> SE HAN CARGADO LAS PALABRAS DEL 'diccionario.txt'",ConsoleColor.Green);
        }

        ///<summary>
        /// Método para grabar una palabra en el fichero de texto 'diccionario.txt'
        ///</summary>
        public static bool grabarPalabra(string palabra)
        {

            bool grabada;
            StreamWriter sw;
            grabada = false;

            try
            {

                sw = File.AppendText(ruta_diccionario);
                sw.WriteLine(palabra);
                sw.Flush();
                sw.Dispose();

            }
            catch (IOException ex)
            {
                throw new Exception("!> ERROR E/S: " + ex.Message);
            }

            return grabada;
        }

        /// <summary>
        /// Método para agregar una palabra la diccionario de palabras. 
        /// </summary>

        public static bool agregarPalabra()
        {
            bool salir;
            string palabra;

            palabra = "";
            salir = false;
            try
            {
                do
                {
                    palabra = CH.leerPalabra("INTRODUCE UNA PALABRA");
                    if (!estaPalabra(palabra))
                    {
                        diccionario.agregarPalabra(palabra);
                        ControlerAhorcado.grabarPalabra(palabra);
                    }
                    else
                    {
                        CH.lcdColor("!> ERROR!! .. LA PALABRA YA ESTÁ EN EL DICCIONARIO!", ConsoleColor.Red);
                    }
                    salir = CH.seguir("¿QUIERES AGREGAR OTRA PALABRA? [S/N]");
                } while (!salir);
            }
            catch (Exception ex)
            {
                CH.lcdColor(ex.Message, ConsoleColor.Red);
                CH.pausa();
            }

            return true;
        }

        /// <summary>
        /// Procedimiento para agregar una letra al diccionario
        /// </summary>
        public static void agregarLetra(char letra)
        {
            char[] copialetras;
            copialetras = null;
            if (letras == null)
            {
                letras = new char[1];
            }
            else
            {
                copialetras = new char[letras.Length];
                letras.CopyTo(copialetras, 0);
                letras = new char[letras.Length + 1];
                copialetras.CopyTo(letras, 0);
                copialetras = null;
            }
            letras[letras.Length - 1] = letra;
        }


        /// <summary>
        /// Función para comprar si una letra está o no está 
        /// </summary>
        public static bool estaLetra(char letra)
        {
            bool encontrada;
            encontrada = false;
            if (letras != null)
            {
                foreach (char c in letras)
                {
                    if (c.Equals(letra))
                    {
                        encontrada = true;
                        break;
                    }
                }
            }
            return encontrada;
        }

        /// <summary>
        /// Función para comprobar si una palabra está o no en el diccionario de palabras
        /// <param name="palabra">La palabra a comprobar si esta</param>
        /// </summary>        
        public static bool estaPalabra(string palabra)
        {
            bool esta;

            esta = false;

            if (diccionario.palabras != null)
            {
                foreach (string p in diccionario.palabras)
                {
                    if (p.ToLower().Equals(palabra))
                    {
                        esta = true;
                        break;
                    }
                }
            }

            return esta;

        }

        /// <summary>
        /// Función para resolvar la palabra
        /// <paramref name="puntos">Los puntos del jugador para mostrarlos si acierta</param>
        /// </summary>
        public static bool resolver(int puntos)
        {
            bool resuelto;
            string solucion;
            string mensaje;

            resuelto = false;
            solucion = CH.leerString("DÍME LA PALABRA QUE HAS PENSADO");
            if (solucion.Equals(palabra))
            {
                mensaje = "\n!> ENHORABUENA MÁKINA!!! HAS ACERTADO LA PALABRA! | PUNTOS: " + puntos;
                resuelto = true;
            }
            else
            {
                mensaje = "\n!> SORRY :( - TRY AGAIN!! ... INTENTOS +1";
            }

            CH.lcdColor(mensaje, ConsoleColor.Cyan);
            if (!resuelto) { CH.pausa(); }
            return resuelto;
        }
    }
}


/*

UN CARACTER UNICODE (UTF-8) OCUPA 2 BYTES + 1 EXTRA
PARA FICHEROS BINARIOS USAREMOS EL BINARYWRITER Y BINARYREADER

*/
