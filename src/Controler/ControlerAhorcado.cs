using System;
using System.IO;
using Ahorcado.src.View;
using Ahorcado.src.Model;

namespace Ahorcado.src.Controler
{
    public static class ControlerAhorcado {
        
        private static Diccionario diccionario = new Diccionario();         // MI DICCIONARIO QUE CONTENDRÁ TODAS LAS PALABRAS
        private static string ruta_carpeta = "Data";                        // LA CARPETA PARA EL FICHERO diccionario.txt
        private static string ruta_diccionario = "Data/diccionario.txt";    // LA RUTA COMPLETA DEL diccionario.txt
        private static string palabra = null;                               // LA PALABRA QUE HABRÁ QUE ACERTAR
        public static char[] letras = null;                                 // LETRAS QUE YA HE DICHO!

        /// <sumary>
        /// FUNCIÓN PÚBLICA PARA QUE COMIENZE LA FUNCIÓN!!
        /// </sumary>
        public static void comenzar () {

            // 1. Mostrar Menú
            // 2. Pedir Opción
            // 3. Evaluar Opción
            // 4. Actuar en consecuencia
            
            // DECLARACIÓN DE VARIALBES
            bool salir;     // CONTROL DE SALIDA 
            int opcion;     // OPCIÓN ELEGIDA

            // ENTRADA

            salir = false;  
            
            // PROCESO
            comprobarFicheros();                            // COMPROBAMOS LA EXISTENCIA LA ESTRUCTURA DE DATOS PARA EL diccionario.txt
            

            do {                                            // PRESENTAR EL MENU HASTA QUE LA OPCIÓN SEA SALIR
                InterfazAhorcado.mostrarMenu();             // MOSTRAMOS EL MENÚ
                opcion = CH.leerOpcion(3);                  // PEDIMOS LA OPCIÓN

                switch (opcion) {                           // EVALUAMOS LA OPCIÓN
                    case 1:                                 // 1. INICIAR NUEVA PARTIDA
                        ControlerAhorcado.iniciarPartida();
                        break;
                    case 2:                                 // 2. INCLUIR NUEVAS PALABRAS
                        ControlerAhorcado.agregarPalabra();
                        break;
                    case 3:                                 // 3. SALIR DEL PROGRAMA
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
        public static void iniciarPartida() {

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


            if (diccionario.palabras!=null) {
                
                letras = null;
                palabras = diccionario.palabras.Length;
                random = new Random();
                opcion = random.Next(palabras);
                palabra = diccionario.palabras[opcion];
                palabra_char = palabra.ToCharArray();
                resultado = new char[palabra_char.Length];
                for (j=0;j<resultado.Length;j++) {
                    resultado[j]='_';
                }
                palabras = palabra.Length;
                encontrada = false;
                salir = false;
                aciertos = 0;
                fallos = 0;
                intentos = 0;
                i = 0;
                salida ="";
                //CH.lcd("l> PALABRA A ACERTAR: " + palabra);
                CH.lcdColor("\ni> OK, MiK.. VAMOS A JUGAR UN POCO\ni> INTRODUCE [RESOLVER] PARA RESOLVER\ni> YO YA TENGO LA PALABRA\n",ConsoleColor.Cyan);                
                for (j=0;j<palabras;j++) {
                    salida+="_ ";
                }
                CH.lcdColor("i> PALABRA: " + salida + "\n",ConsoleColor.Cyan);

                do {
                    contador = 0;
                    posicion = 0;
                    encontrada = false;
                    letra = CH.leerChar("INTRODUCE UNA LETRA");
                    if (letra=='0') {
                        if (resolver((10-fallos))) {
                            salir = true;
                        } else {
                           intentos++;
                        }
                    }
                    if (!salir && letra!='0') {
                        //CH.lcd("l> LETRA: " + letra);
                        intentos++;
                        if (!estaLetra(letra)) {
                            agregarLetra(letra);
                            foreach (char c in palabra) {
                                //CH.lcd("c: " + c + " | l: " + letra + " | pos: " + posicion);
                                if (c.Equals(letra)) { 
                                    encontrada=true;
                                    contador++;
                                    resultado[posicion] = letra;
                                    //break;
                                }
                                posicion++;
                            }
                            CH.cls();
                            InterfazAhorcado.mostrarResultado(resultado);
                            if (!encontrada) {
                                fallos++;
                                CH.lcdColor("\ni> LA LETRA '"+ letra +"' NO ESTA! | INTENTOS: " + intentos + " | ACIERTOS: " + aciertos + " | VIDAS: " + (10-fallos),ConsoleColor.Red);
                            } else {
                                    aciertos+=contador;
                                    i++;
                                    CH.lcdColor("\ni> PALABRA ENCONTRADA " + contador + " VECES | INTENTOS: " + intentos + " | ACIERTOS: " + aciertos + " | VIDAS: " + (10-fallos),ConsoleColor.Yellow);
                            }
                            if (aciertos==palabras) {
                                InterfazAhorcado.lifesLeft(10-fallos);
                                CH.lcdColor("\n!> ENHORABUENA MAAAKINA!!! HAS GANADO | PUNTOS:" + (10-fallos),ConsoleColor.DarkGreen);
                                salir = true;
                            } else {
                                InterfazAhorcado.lifesLeft(10-fallos);
                                InterfazAhorcado.mostrarLetras(letras);
                                if (fallos==10) {
                                    salir=true;
                                    CH.lcdColor("\n!> WOUNNN WOUNNN WOUNNN.... HAZ MUERTO, XAVAL!!!",ConsoleColor.Red);
                                    CH.lcdColor("\ni> LA PALABRA ERA: " + palabra,ConsoleColor.Red);
                                }
                            }
                        } else {
                            CH.lcdColor("!> YA HAS DICHO ESA LETRA, WEBON!! ... INTENTOS +1",ConsoleColor.Red);
                            //CH.pausa();
                        }
                    }
                } while (!salir);
            } else {
                CH.lcdColor("!> NO HAY PALABRAS EN EL DICCIONARIO!!",ConsoleColor.Red);
            }            
            CH.pausa();
        }

        public static void comprobarFicheros() {
 
            string mensaje;

            mensaje = "";
            
            CH.cls();
            try {

                if (!Directory.Exists(ruta_carpeta)) {
                    Directory.CreateDirectory(ruta_carpeta);
                    File.CreateText(ruta_diccionario);
                    mensaje = "i> SE HA CREADO LA CARPETA 'Data' PARA EL DICCIONARIO Y EL FICHERO 'diccionario.txt'";
                } else {
                    mensaje = "i> DIRECTORIO DE TRABAJO LOCALIZADO : CARGANDO PALABRAS AL DICCIONARIO A CONTINUACION...'";
                    cargarPalabras();
                }
            } catch (IOException ex) {
                CH.lcdColor("!> ERROR E/S:"+ex.Message,ConsoleColor.Red);
            }
            
            CH.lcdColor("\n"+mensaje,ConsoleColor.Green);
            CH.pausa();
        }

        /// <summary>
        /// MÉTODO PARA LEER UN FICHERO DE TEXTO Y AGREGAR PALABRAS A UN ARRAY DE PALABRAS
        /// </summary>
        public static void cargarPalabras() {
            // DECLARACION VARIABLES
            StreamReader sr;
            string linea;

            // ASIGNACION VARIABLES: ENTRADA
            sr = File.OpenText(ruta_diccionario);
            
            linea = "";

            // PROCESO
            while (!sr.EndOfStream) {
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
        public static bool grabarPalabra(string palabra) {
            
            bool grabada;
            StreamWriter sw;
            grabada = false;
            
            try {
                
                sw = File.AppendText(ruta_diccionario);
                sw.WriteLine(palabra);
                sw.Flush();
                sw.Dispose();
                
            } catch (IOException ex) {
                throw new Exception("!> ERROR E/S: " + ex.Message);
            }

            return grabada;
        }

        /// <summary>
        /// Método para agregar una palabra la diccionario de palabras. 
        /// </summary>
    
        public static bool agregarPalabra() {
            bool salir;
            string palabra;

            palabra = "";
            salir = false;
            try {
                do {
                    palabra = CH.leerPalabra("INTRODUCE UNA PALABRA" );
                    if (!estaPalabra(palabra)) {
                        diccionario.agregarPalabra(palabra);
                        ControlerAhorcado.grabarPalabra(palabra);
                    } else {
                        CH.lcdColor("!> ERROR!! .. LA PALABRA YA ESTÁ EN EL DICCIONARIO!",ConsoleColor.Red);
                    }
                    salir = CH.seguir("¿QUIERES AGREGAR OTRA PALABRA? [S/N]");
                } while (!salir);
            } catch (Exception ex) {
                CH.lcdColor(ex.Message,ConsoleColor.Red);
                CH.pausa();
            }

            return true;
        }


        public static void agregarLetra(char letra) {
            char[] copialetras;
            copialetras = null;
            if (letras==null) {
                letras = new char[1];
            } else {
                copialetras = new char[letras.Length];
                letras.CopyTo(copialetras, 0);
                letras = new char[letras.Length + 1];
                copialetras.CopyTo(letras, 0);
                copialetras = null;
            }
            letras[letras.Length - 1] = letra;
        }

        public static bool estaLetra(char letra) {
            bool encontrada;
            encontrada = false;
            if (letras!=null) {
                foreach(char c in letras) {
                    if (c.Equals(letra)) {
                        encontrada=true;
                        break;
                    }
                }
            }
            return encontrada;
        }

        public static bool estaPalabra(string palabra) {
            bool esta;
            
            esta = false;

            if (diccionario.palabras!=null) {
                foreach (string p in diccionario.palabras) {
                    if (p.ToLower().Equals(palabra)) {
                        esta = true;
                        break;
                    }
                }
            }
            
            return esta;

        }

        public static bool resolver(int puntos) {
            bool resuelto;
            string solucion;
            string mensaje;

            resuelto=false;
            solucion=CH.leerString("DÍME LA PALABRA QUE HAS PENSADO");
            if (solucion.Equals(palabra)) {
                mensaje="\n!> ENHORABUENA MÁKINA!!! HAS ACERTADO LA PALABRA! | PUNTOS: "+ puntos;
                resuelto=true;
            } else {
                mensaje="\n!> SORRY :( - TRY AGAIN!! ... INTENTOS +1";
            }

            CH.lcdColor(mensaje,ConsoleColor.Cyan);
            if (!resuelto) {CH.pausa();}
            return resuelto;
        }
    }
}


/*

UN CARACTER UNICODE (UTF-8) OCUPA 2 BYTES + 1 EXTRA
PARA FICHEROS BINARIOS USAREMOS EL BINARYWRITER Y BINARYREADER

*/