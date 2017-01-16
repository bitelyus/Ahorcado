namespace Ahorcado.src.Model
{
    class Diccionario {

        private string[] _palabras;

        public string[] palabras {
            get {
                return _palabras;
            }
        }

        public Diccionario() {
            this._palabras=null;
        }

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