using System;
using System.Windows.Forms;

namespace ServerTrees
{
    public class ABB
    {
        public TreeNode raiz;

        public ABB()
        {
            raiz = null;
        }

        /*------------------------- Metodos de verificacion ----------------------------------*/
        public bool vacio()
        {
            if (raiz == null)
                return true;
            else
                return false;
        }

        public bool esHoja(TreeNode nod)
        {
            if (nod.iz == null && nod.de == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*----------------------------------------------------------------------------------------------------------*/
        /*------------------------------------ Metodos de gestion del abb ----------------------------------------*/
        /*----------------------------------------------------------------------------------------------------------*/

        /*INSERTAR*/
        public void insertNABB(TreeNode nw, TreeNode raiz)
        {
            if (nw.dat < raiz.dat)
            {
                if (raiz.iz == null)
                {
                    raiz.iz = nw;
                }
                else
                {
                    insertNABB(nw, raiz.iz);
                }

            }
            else if (nw.dat > raiz.dat)
            {
                if (raiz.de == null)
                {
                    raiz.de = nw;
                }
                else
                {
                    insertNABB(nw, raiz.de);
                }
            }
        }

        public void insertABB(int dat)
        {
            TreeNode nw = new TreeNode(dat);

            if (vacio())
            {
                raiz = nw;
            }
            else
            {
                insertNABB(nw, raiz);
            }
        }
        
         /*RECORRIDOS*/
        public void PreOrdenABB()
        {
            Console.Write("\n");
            if (raiz != null)
                AyudaPreOrden(raiz);
        }

        private void AyudaPreOrden(TreeNode nodo)
        {
            if (nodo == null)
            {
                return;
            }
            Console.Write(nodo.dat + " ");
            AyudaPreOrden(nodo.iz);
            AyudaPreOrden(nodo.de);
        }

        public void InOrden()
        {
            Console.Write("\n");
            if (raiz != null)
                AyudaInOrden(raiz);
        }

        private void AyudaInOrden(TreeNode nodo)
        {
            if (nodo == null)
            {
                return;
            }

            AyudaPreOrden(nodo.iz);
            Console.Write(nodo.dat + " ");
            AyudaPreOrden(nodo.de);
        }

        public void PostOrden()
        {
            Console.Write("\n");
            if (raiz != null)
                AyudaPostOrden(raiz);
        }

        private void AyudaPostOrden(TreeNode nodo)
        {
            if (nodo == null)
            {
                return;
            }

            AyudaPreOrden(nodo.iz);
            AyudaPreOrden(nodo.de);
            Console.Write(nodo.dat + " ");
        }
        
          /*BUSCAR*/
        public TreeNode Search(int id, TreeNode r)
        {
            if (r == null)
            {
                return new TreeNode(-1);
            }
            else
            {
                if (id == r.dat)
                {
                }
                else if (id < r.dat)
                {
                    return Search(id, r.iz);
                }
                else if (id > r.dat)
                {
                    return Search(id, r.de);
                }
            }
            return null;
        }

      /*  public void eliminar(int id)
        {
            TreeNode r = Search(id, raiz);
            if (esHoja(r))
            {
                r = null;
            }
            else
            {

            }

        } */

      /*      public TreeNode obtenerPadre(int id)
        {
            TreeNode n = new TreeNode(-1);
            if (!vacio())
            {
                n = raiz;
                TreeNode temporal2;
                if ()
                    while (n.)
                    {

                    }
            }
            return n;
        } */

        /*OBTENER EL MENOR VALOR*/
        public void menorValor()
        {
            if (raiz != null)
            {
                TreeNode reco = raiz;
                while (reco.iz != null)
                {
                    reco = reco.iz;
                }

            }
        }

        /*OBTENER EL MAYOR VALOR*/
        public void mayorValor()
        {
            if (raiz != null)
            {
                TreeNode reco = raiz;
                while (reco.de != null)
                {
                    reco = reco.de;
                }
            }
        }

        public bool eliminarABB(int id)
        {
            TreeNode aux = raiz;
            TreeNode padre = raiz;
            bool hijoIquierdo = true;

            while (aux.dat != id)
            {
                if (id < aux.dat)
                {
                    hijoIquierdo = true;
                    aux = aux.iz;
                }
                else
                {
                    hijoIquierdo = false;
                    aux = aux.de;
                }
                if (aux == null)
                {
                    return false;
                }
            } //fin del while
            if (esHoja(aux))
            {
                if (aux == raiz)
                {
                    raiz = null;
                }
                else if (hijoIquierdo)
                {
                    padre.iz = null;
                }
                else
                {
                    padre.de = null;
                }
            }
            else if (aux.de == null)
            {
                if (aux == raiz)
                {
                    raiz = aux.iz;
                }
                else if (hijoIquierdo)
                {
                    padre.iz = aux.iz;
                }
                else
                {
                    padre.de = aux.iz;
                }
            }
            else if (aux.iz == null)
            {
                if (aux == raiz)
                {
                    raiz = aux.de;
                }
                else if (hijoIquierdo)
                {
                    padre.iz = aux.de;
                }
                else
                {
                    padre.de = aux.iz;
                }
            }
            else
            {
                TreeNode reemplazo = obtenerNodoReemplazo(aux);
                if (aux == raiz)
                {
                    raiz = reemplazo;
                }
                else if (hijoIquierdo)
                {
                    padre.iz = reemplazo;
                }
                else
                {
                    padre.de = reemplazo;
                }
                reemplazo.iz = aux.iz;
            }

            return true;
        }

        public TreeNode obtenerNodoReemplazo(TreeNode nodoReemp)
        {
            TreeNode reemplazarPadre = nodoReemp;
            TreeNode reemplazo = nodoReemp;
            TreeNode aux = nodoReemp.de;
            while (aux != null)
            {
                reemplazarPadre = reemplazo;
                reemplazo = aux;
                aux = aux.iz;
            }
            if (reemplazo != nodoReemp.de)
            {
                reemplazarPadre.iz = reemplazo.de;
                reemplazo.de = nodoReemp.de;
            }
            Console.WriteLine("se reemplaza nodo " + reemplazo.dat);
            return reemplazo;
        }

    }
}