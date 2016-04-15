using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrees
{
    public class SPL
    {
        public int cont;
        public TreeNode raiz;
        public TreeNode auxp;
        public TreeNode auxh;
        public bool bandera = true;

        public SPL()
        {
            raiz = null;
        }

        /*INSERTAR*/
        public TreeNode Insertar(int codl)
        {
            Console.WriteLine("\nElemento: " + codl);
            if (raiz == null)
                raiz = new TreeNode(codl);
            else
            {
                auxp = null;
                auxh = raiz;
                while (auxh != null)
                {
                    if (codl <= auxh.dat)
                    {
                        auxp = auxh;
                        auxh = auxh.iz;
                    }
                    else
                    {
                        auxp = auxh;
                        auxh = auxh.de;
                    }
                }
                TreeNode nuevo = new TreeNode(codl);
                if (auxp.dat < codl)
                {
                    auxp.de = nuevo;
                    Subir(auxp, nuevo);
                }
                else
                {
                    auxp.iz = nuevo;
                    Subir(auxp, nuevo);
                }
            }

            return raiz;
        }

        /*ZAG ZAG*/
        public void zagzag(TreeNode abuelo)
        {

            if (cont < 2)
            {
                Console.WriteLine("zag zag");
                cont++;
                TreeNode nuevo = new TreeNode(abuelo.dat);
                nuevo.iz = abuelo.iz;
                nuevo.de = abuelo.de;
                nuevo.de = auxp.iz;
                abuelo.iz = nuevo;
                abuelo.de = auxp.de;
                abuelo.dat = auxp.dat;
                if (abuelo == raiz)
                    bandera = false;
                auxp = abuelo;
            }
            else
            {
                Console.WriteLine("");
                cont = 0;
            }
        }

        /*ZAG ZIG*/
        public void zagzig(TreeNode abuelo)
        {

            if (cont == 1 || cont == 2)
                Console.WriteLine("");
            Console.WriteLine("zag zig");
            cont = 0;
            TreeNode nuevo = new TreeNode(abuelo.dat);
            nuevo.iz = abuelo.iz;
            nuevo.de = abuelo.de;
            abuelo.dat = auxh.dat;
            nuevo.de = auxh.iz;
            abuelo.iz = nuevo;
            auxp.iz = auxh.de;
            abuelo.de = auxp;
            if (abuelo == raiz)
            {
                raiz = abuelo;
                bandera = false;
            }
            auxh = abuelo;
            auxp = TieneAbuelo(auxh);
        }

        /*ZIG ZIG*/
        public void zigzig(TreeNode abuelo)
        {

            if (cont < 2)
            {
                Console.WriteLine("zig ");
                cont++;
                TreeNode nuevo = new TreeNode(abuelo.dat);
                nuevo.iz = abuelo.iz;
                nuevo.de = abuelo.de;
                nuevo.iz = auxp.de;
                abuelo.de = nuevo;
                abuelo.iz = auxp.iz;
                abuelo.dat = auxp.dat;
                if (abuelo == raiz)
                    bandera = false;
                auxp = abuelo;
            }
            else
            {
                Console.WriteLine("");
                cont = 0;
            }
        }

        /*ZIG ZAG*/
        public void zigzag(TreeNode abuelo)
        {
            if (cont == 1 || cont == 2)
                Console.WriteLine("");
                Console.WriteLine("zig zag");
            cont = 0;
            TreeNode nuevo = new TreeNode(abuelo.dat);
            nuevo.iz = abuelo.iz;
            nuevo.de = abuelo.de;
            abuelo.dat = auxh.dat;
            nuevo.iz = auxh.de;
            abuelo.de = nuevo;
            auxp.de = auxh.iz;
            abuelo.iz = auxp;
            if (abuelo == raiz)
            {
                raiz = abuelo;
                bandera = false;
            }
            auxh = abuelo;
            auxp = TieneAbuelo(auxh);
        }

        /*ZIG*/
        public void zig()
        {
            if (cont == 2)
                Console.WriteLine("");
                Console.WriteLine("zig ");
            raiz.iz = auxh.de;
            auxh.de = raiz;
            raiz = auxh;
            cont = 0;
        }

        /*ZAG*/
        public void zag()
        {
            if (cont == 2)
                Console.WriteLine("");
            Console.WriteLine("zag");
            raiz.de = auxh.iz;
            auxh.iz = raiz;
            raiz = auxh;
            cont = 0;
        }

        /*SUBIR EL VALOR INSERTADO A LA RAIZ*/
        public void Subir(TreeNode padre, TreeNode hijo)
        {
            bandera = true;
            auxp = padre;
            auxh = hijo;
            while ((bandera == true) && (TieneAbuelo(auxp) != null))
            {
                TreeNode abuelo = TieneAbuelo(auxp);
                //zag zag
                if ((abuelo.de == auxp) && (auxp.de == auxh))
                {
                    zagzag(abuelo);
                }
                else
                {
                    //zag zig
                    if ((abuelo.de == auxp) && (auxp.iz == auxh))
                    {
                        zagzig(abuelo);
                    }
                    else
                    {
                        //zig zig
                        if ((abuelo.iz == auxp) && (auxp.iz == auxh))
                        {
                            zigzig(abuelo);
                        }
                        //zig zag
                        else
                        {
                            zigzag(abuelo);
                        }
                    }
                }
            }
            if (auxh != raiz)
            {
                //zag
                if (raiz.de == auxh)
                {
                    zag();
                }
                //zig
                else
                {
                    zig();
                }
            }
        }

        /*DEVUELVE EL ABUELO DE UN NIETO*/
        public TreeNode TieneAbuelo(TreeNode nodo)
        {
            if (nodo == raiz)
                return null;
            else
            {
                TreeNode padre = null;
                TreeNode hijo = raiz;
                while (hijo != nodo)
                {
                    if (nodo.dat <= hijo.dat)
                    {
                        padre = hijo;
                        hijo = hijo.iz;
                    }
                    else
                    {
                        padre = hijo;
                        hijo = hijo.de;
                    }
                }
                return padre;
            }
        }

        /*RECORRIDOS*/
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
            else
            {
                AyudaInOrden(nodo.iz);
                Console.Write(nodo.dat + " ");
                AyudaInOrden(nodo.de);
            }
        }

        /*elimina un elemento de un arbol splay y coloca su antecesor en la raiz*/
        public TreeNode Eliminar(int codl)
        {
            if (codl == raiz.dat)
            {
                TreeNode borrado = raiz;
                if ((raiz.iz == null) && (raiz.de == null))
                {
                    raiz = null;
                    return borrado;
                }
                else
                {
                    if ((raiz.iz != null) && (raiz.de != null))
                    {
                        TreeNode aux = raiz;
                        raiz = MayordeMenores(raiz);
                        raiz.iz = aux.iz;
                        raiz.de = aux.de;
                        return borrado;
                    }
                    else
                    {
                        if (raiz.de != null)
                        {
                            raiz = raiz.de;
                            return borrado;
                        }
                        else
                        {
                            raiz = raiz.iz;
                            return borrado;
                        }
                    }
                }
            }
            else
            {
                TreeNode padre = null;
                TreeNode hijo = raiz;
                while (hijo.dat != codl)
                {
                    if (codl <= hijo.dat)
                    {
                        padre = hijo;
                        hijo = hijo.iz;
                    }
                    else
                    {
                        padre = hijo;
                        hijo = hijo.de;
                    }
                }
                Subir(padre, hijo);
                TreeNode rai = raiz;
                Eliminar(raiz.dat);
                return rai;
            }
        }

        /*buscar el mayor de los menores*/
        public TreeNode MayordeMenores(TreeNode nodo)
        {
            TreeNode padre = nodo;
            TreeNode aux = nodo.iz;
            while (aux.de != null)
            {
                padre = aux;
                aux = aux.de;
            }
            padre.de = aux.iz;
            return aux;
        }

        /*buscar un elemento y lo sube a la raiz*/
        public TreeNode Buscar(int codl, TreeNode rai, int codtema, String nomb)
        {
            raiz = rai;
            if (codl == raiz.dat)
            {
                Console.WriteLine("Rotacion para busqueda: ");
                Console.WriteLine("Sin rotacion");
                Console.WriteLine("Elemento encontrado. Raiz: " + raiz.dat);
            }
            else
            {
                TreeNode padre = null;
                TreeNode hijo = raiz;
                Console.WriteLine("Rotacion para busqueda: ");
                while ((hijo != null) && (hijo.dat != codl))
                {
                    if (codl <= hijo.dat)
                    {
                        padre = hijo;
                        hijo = hijo.iz;
                    }
                    else
                    {
                        padre = hijo;
                        hijo = hijo.de;
                    }
                }
                if (hijo == null)
                {
                    TreeNode aux = TieneAbuelo(padre);
                    if (padre != raiz)
                        Subir(aux, padre);                 
                    Console.WriteLine("El elemento no se encuentra. Raiz: " + raiz.dat);
                }
                else
                {
                    Subir(padre, hijo);
                    Console.WriteLine("Elemento encontrado. Raiz: " + raiz.dat);
                }
            }
            return raiz;
        }

        /*retorna si es miembro un elemento*/
        public bool Miembro(int dat, TreeNode rai)
        {
            raiz = rai;
            TreeNode hijo = raiz;
            while ((hijo != null) && (hijo.dat != dat))
            {
                if (dat <= hijo.dat)
                {
                    hijo = hijo.iz;
                }
                else
                {
                    hijo = hijo.de;
                }
            }
            if (hijo == null)
                return false;
            else
                return true;
        }

    }
}