using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CCUS
{
    class MethodCreate : Form
    {
        public void SelectMethod(Array array, string sprint, string folder, bool type)
        {
            //True = Crear documento
            //False = Crear archivo
            if (type == true)
            {
                CreateFolder(array, sprint, folder);
            }
            else
            {
                CreateTxt(array, sprint, folder);
            }
        }
        public void CreateFolder(Array array, string sprint, string folder)
        {
            string ruta = Path.Combine(folder, sprint);

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine($"Se creo la carpeta '{sprint}' exitosamente.");
                CreateFolderUs(array, ruta);
            }
            else
            {
                MessageBox.Show($"La carpeta {sprint} ya se encuentra creada, en lugar de crear debería Actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CreateFolderUs (Array array, string ruta)
        {
            int carpetasCreadasExitosamente = 0;
            foreach (string nombreCarpeta in array)
            {
                string nombreCorregido = Regex.Replace(nombreCarpeta, "[\\/:*?\"<>|]", " ");

                string rutaCarpeta = Path.Combine(ruta, nombreCorregido);

                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                    Console.WriteLine($"Se creó la carpeta '{nombreCorregido}' exitosamente.");
                    carpetasCreadasExitosamente++;
                }
                else
                {
                    Console.WriteLine($"La carpeta '{nombreCorregido}' ya existe en la ruta especificada.");
                }
            }
            MessageBox.Show($"Se crearon {carpetasCreadasExitosamente} carpetas exitosamente", "Carpetas creadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void CreateTxt(Array array, string sprint, string folder)
        {
            string nombreArchivo = sprint; 
            string ruta = folder; 

            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (!File.Exists(rutaCompleta))
            {

                using (StreamWriter sw = File.AppendText(rutaCompleta))
                {
                    foreach (string elemento in array)
                    {
                        sw.WriteLine(elemento); 
                    }
                }
                MessageBox.Show($"Se escribieron los elementos en el archivo '{nombreArchivo}' exitosamente.", "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine($"El archivo '{nombreArchivo}' no existe en la ruta especificada.");
            }
        }
    }
}
