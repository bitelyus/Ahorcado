namespace Ahorcado.src.Model
{

    /// <summary>
    /// Clase modelo para albergar la estructura de datos 
    /// con todas las palabras leidas del fichero de texto diccionario.txt
    /// </summary>
    class Diccionario {

        // ZONA DE ATRIBUTOS

        private string[] _palabras; // NUESTRO ARRAY DINÁMICO DE DATOS PARA LAS PALABRAS

        // Getters & Setters
        public string[] palabras {
            get {
                return _palabras;
            }
        }

        // ZONA DE CONSTRUCTORES    
        public Diccionario() {
            this._palabras=null;
        }

        // ZONA DE MÉTODOS

        /// <summary>
        /// Función para agregar una palabra a la estructura dinámica de datos
        /// </summary>        
        public bool agregarPalabra(string palabra) {
            bool agregada;

            agregada = false;

            string[] copiapalabras = null;
            if (palabras == null)
            {
                this._palabras = new string[1];
            }
            else
            {
                copiapalabras = new string[this._palabras.Length];
                this._palabras.CopyTo(copiapalabras, 0);
                this._palabras = new string[this._palabras.Length + 1];
                copiapalabras.CopyTo(this._palabras, 0);
                copiapalabras = null;
            }
            this._palabras[this._palabras.Length - 1] = palabra;
            return agregada;
        }
        
        
        // SOBREESCRITURA MÉTODO TOSTRING

        override
        public string ToString() {
            string salida;
            salida="\nPALABRAS EN EL DICCIONARIO\n";
            salida+="==========================\n\n";
            if (palabras!=null) {
                foreach (string p in palabras ) {
                    salida +=p+"\n";
                }
                
            } else {
                salida += "¡¡NO HAY PALABRAS EN EL DICCIONARIO!!";
            }

            return salida;
        }

    }
}