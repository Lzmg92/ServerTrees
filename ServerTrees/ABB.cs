using System;
using System.Windows.Forms;

namespace PruebaTrees
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
            int comp = string.Compare(nw.disp, raiz.disp);
            if (comp == -1)
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
            else if (comp == 1)
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

        public void insert(string disp, string date, Double drating, Double trating)
        {
            TreeNode nw = new TreeNode(disp, date, drating, trating);

            if (vacio())
            {
                raiz = nw;
            }
            else
            {
                insertNABB(nw, raiz);
            }
        }

        /*BUSCAR*/
        public TreeNode Search(string disp, TreeNode r)
        {
            if (r == null)
            {
                return new TreeNode("","",-1,-1);
            }
            else
            {
                int comp = string.Compare(disp,r.disp);
                if (comp == 0)
                {
                }
                else if (comp == -1)
                {
                    return Search(disp, r.iz);
                }
                else if (comp == 1)
                {
                    return Search(disp, r.de);
                }
            }
            return null;
        }


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

        public bool eliminar(string disp)
        {
            TreeNode aux = raiz;
            TreeNode padre = raiz;
            bool hijoIquierdo = true;

            int comp = string.Compare(disp, aux.disp);
            while (comp !=0)
            {
                if (comp == -1 )
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
                comp = string.Compare(disp, aux.disp);
            } //fin del while
            if (esHoja(aux))
            {
                if (aux == raiz)
                {
                    raiz = null;
                }
                else if (hijoIquierdo)
                {
                    padre.iz= null;
                }
                else
                {
                    padre.de = null;
                }
            }
            else if (aux.de== null)
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
            Console.WriteLine("se reemplaza nodo " + reemplazo.disp);
            return reemplazo;
        }

    }
}