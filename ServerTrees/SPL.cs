using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTrees
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
        public TreeNode insert(string disp, string date, Double drating, Double trating)
        {
            Console.WriteLine("\nElemento: " + disp);
            if (raiz == null)
                raiz = new TreeNode(disp, date, drating, trating);
            else
            {
                auxp = null;
                auxh = raiz;
                while (auxh != null)
                {
                    int comp = string.Compare(disp,  auxh.disp);
                    if (comp == -1)
                    {
                        auxp = auxh;
                        auxh = auxh.iz;
                    }
                    else if (comp == 1)
                    {
                        auxp = auxh;
                        auxh = auxh.de;
                    } else {
                        Console.WriteLine("iguales");
                        promDat(auxh, drating, trating);
                        return null;
                    }
                }
                TreeNode nuevo = new TreeNode(disp, date, drating ,trating);
                int comp2 = string.Compare(auxp.disp , disp);
                if (comp2 == -1)
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

        /*PROMEDIAR*/
        public void promDat(TreeNode n1, Double dra, Double tra) {
            Double N1 = n1.drating;
            Double N2 = dra;
            n1.drating = (N1+N2) / 2;
            N1 = n1.trating;
            N2 = tra;
            n1.trating = (N1+N2) / 2;
        }

        /*ZAG ZAG*/
        public void zagzag(TreeNode abuelo)
        {

            if (cont < 2)
            {
                Console.WriteLine("zag zag");
                cont++;
                TreeNode nuevo = new TreeNode(abuelo.disp, abuelo.date, abuelo.drating, abuelo.trating);
                nuevo.iz = abuelo.iz;
                nuevo.de = abuelo.de;
                nuevo.de = auxp.iz;
                abuelo.iz = nuevo;
                abuelo.de = auxp.de;
                pasarDatos(abuelo,auxp);
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
            TreeNode nuevo = new TreeNode(abuelo.disp, abuelo.date, abuelo.drating, abuelo.trating);
            nuevo.iz = abuelo.iz;
            nuevo.de = abuelo.de;
            pasarDatos(abuelo,auxh);
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
                TreeNode nuevo = new TreeNode(abuelo.disp, abuelo.date, abuelo.drating, abuelo.trating);
                nuevo.iz = abuelo.iz;
                nuevo.de = abuelo.de;
                nuevo.iz = auxp.de;
                abuelo.de = nuevo;
                abuelo.iz = auxp.iz;
                pasarDatos(abuelo, auxp);
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
            TreeNode nuevo = new TreeNode(abuelo.disp, abuelo.date, abuelo.drating, abuelo.trating);
            nuevo.iz = abuelo.iz;
            nuevo.de = abuelo.de;
            pasarDatos(abuelo,auxh);
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

        /*pasar datos */
        public void pasarDatos(TreeNode recibe, TreeNode envia) {
            recibe.disp = envia.disp;
            recibe.date = envia.date;
            recibe.drating = envia.drating;
            recibe.trating = envia.trating;
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
                    int comp = string.Compare(nodo.disp , hijo.disp);
                    if (comp == -1 || comp ==0)
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

        /*elimina un elemento de un arbol splay y coloca su antecesor en la raiz*/
        public TreeNode Eliminar(string disp)
        {
            int compr = string.Compare(disp, raiz.disp);
            if (compr == 0)
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
                int comp = string.Compare(disp , hijo.disp );
                while (comp != 0)
                {
                    if (comp == -1)
                    {
                        padre = hijo;
                        hijo = hijo.iz;
                    }
                    else
                    {
                        padre = hijo;
                        hijo = hijo.de;
                    }
                    comp = string.Compare(disp, hijo.disp);
                }
                Subir(padre, hijo);
                TreeNode rai = raiz;
                Eliminar(raiz.disp);
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
        public TreeNode Buscar(string disp, TreeNode rai, int codtema, String nomb)
        {
            raiz = rai;
            int comp = string.Compare(disp , raiz.disp );
            if (comp == 0)
            {
                Console.WriteLine("Rotacion para busqueda: ");
                Console.WriteLine("Sin rotacion");
                Console.WriteLine("Elemento encontrado. Raiz: " + raiz.disp);
            }
            else
            {
                TreeNode padre = null;
                TreeNode hijo = raiz;
                Console.WriteLine("Rotacion para busqueda: ");
                int com = string.Compare(hijo.disp , disp);
                while ((hijo != null) && com != 0)
                {
                    if (com == -1)
                    {
                        padre = hijo;
                        hijo = hijo.iz;
                    }
                    else
                    {
                        padre = hijo;
                        hijo = hijo.de;
                    }
                    com = string.Compare(hijo.disp, disp);
                }
                if (hijo == null)
                {
                    TreeNode aux = TieneAbuelo(padre);
                    if (padre != raiz)
                        Subir(aux, padre);                 
                    Console.WriteLine("El elemento no se encuentra. Raiz: " + raiz.disp);
                }
                else
                {
                    Subir(padre, hijo);
                    Console.WriteLine("Elemento encontrado. Raiz: " + raiz.disp);
                }
            }
            return raiz;
        }

        /*retorna si es miembro un elemento*/
        public bool Miembro(string disp, TreeNode rai)
        {
            raiz = rai;
            TreeNode hijo = raiz;
            int comp = string.Compare(hijo.disp, disp);
            while ((hijo != null) && (comp != 0))
            {
                if (comp == -1)
                {
                    hijo = hijo.iz;
                }
                else
                {
                    hijo = hijo.de;
                }
                comp = string.Compare(hijo.disp, disp);
            }
            if (hijo == null)
                return false;
            else
                return true;
        }

    }
}