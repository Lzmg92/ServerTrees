using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ServerTrees
{
    public class TreeNode
    {
        String strDot = "";
        #region variables   
        public TreeNode iz;
        public int dat;
        public TreeNode de;
        #endregion
        public TreeNode(int dat)
        {
            this.dat = dat;
            de = iz = null;
        }

        //Metodo completo para graficar
        public void graph()
        {
            dotGraph(this);
            generarBatPNG();
            verImagen();
        }

        // generar el archivo dot para graficar el arbol
        public void dotGraph(TreeNode nod)
        {
            strDot = "";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tree.dot";
            String encabezado = "digraph spl {\r\n node [shape=oval]; \r\n graph [bgcolor=\"#003366\"]; \r\n edge [color=white]; \r\n";
            StreamWriter sw = new StreamWriter(ruta, false);
            contDot(nod);
            sw.WriteLine(encabezado);
            sw.WriteLine(strDot);
            sw.WriteLine("}");
            sw.Close();

        }

        // generar el string q conforma el contenido del dot
        public void contDot(TreeNode nod)
        {

            strDot = strDot + "nodo" + nod.dat.ToString()
                    + " [style=filled, "
                    + "color = \"#00CC00\", "
                    + "label =\"Id: " + nod.dat.ToString()
                    + "\" ];\n";


            if (nod.iz != null)
            {
                strDot = strDot + "nodo" + nod.dat.ToString() + "-> nodo" + nod.iz.dat.ToString() + ";\n";
                contDot(nod.iz);
            }

            if (nod.de != null)
            {
                strDot = strDot + "nodo" + nod.dat.ToString() + "-> nodo" + nod.de.dat.ToString() + ";\n";
                contDot(nod.de);
            }

        }

        // generar bat para mandar a crear la imagen
        public void generarBatPNG()
        {
            String bat = "";
            String rutabat = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Tree.bat";
            String dsk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            bat = "cd " + dsk + "\\Graphviz2.38\\bin \n";
            bat = bat + "dot.exe -Tpng " + dsk + "\\Tree.dot" + " -o " + dsk + "\\Tree.png" + "\n ";
            bat = bat + "exit";

            System.IO.File.WriteAllText(rutabat, bat);
            try
            {
                System.Diagnostics.Process.Start(dsk + "\\Tree.bat");
            }
            catch (Exception ex)
            {
            }
        }

        //despeglegar imagen
        public void verImagen()
        {
            String dsk = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            try
            {
                System.Diagnostics.Process.Start(dsk + "\\Tree.png");
            }
            catch (Exception ex)
            { }
        }
    }

}
}