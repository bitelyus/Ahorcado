/*
GIT:
1. SUBIR REPOSITORIO
git remote add origin https://github.com/bitelyus/Ahorcado.git
git push -u origin master

2. BORRAR REPOSITORIO
git rm -rf .git
git init

PREGUNTAS
1. los acentos? -- comprobando con array de vocales acentuadas?
 
*/
using Ahorcado.src.Controler;

namespace Ahorcado
{
    public class Ahorcado
    {
        public static void Main(string[] args)
        {
            ControlerAhorcado.comenzar();
        }
    }
}
