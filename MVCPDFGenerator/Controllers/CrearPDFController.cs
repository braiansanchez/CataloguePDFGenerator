using Microsoft.AspNetCore.Mvc;
using MVCPDFGenerator.Models;
using Rotativa.AspNetCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MVCPDFGenerator.Controllers
{
    public class CrearPDFController : Controller
    {
        //**REEMPLAZAR path para apuntar a carpeta de proyecto --PENDIENTE
        string pathExcel = @"D:\dev\PDF Generator\MVCPDFGenerator\wwwroot\images\ALFAJORES\PIE IMAGENES.xlsx";

        public IActionResult Index()
        {
            Catalogo catalogo = getProducts();

            

            //return View(catalogo);
            return new ViewAsPdf("Index", catalogo)
            {
                //Ver opciones de Rotativa y como usar bootstrap para el estilo
                /*Usando CSS puro el estilo se puede adaptar bien*/

            };

        }

        private void resizeImages(string imageCode)
        {
            string resizePath = @"D:\dev\PDF Generator\MVCPDFGenerator\wwwroot\images\Resize\" + imageCode + ".jpg";
            string originalPath = @"D:\dev\PDF Generator\MVCPDFGenerator\wwwroot\images\ALFAJORES\" + imageCode;
            //System.IO.Directory.CreateDirectory(pathOutput);

            try
            {
                using (Image image = Image.Load(originalPath + ".jpg"))
                {
                    image.Mutate(x => x.Resize(200, 200));

                    image.Save(resizePath);
                }
            }
            catch (Exception)
            {
                using (Image image = Image.Load(originalPath + ".png"))
                {
                    image.Mutate(x => x.Resize(200, 200));

                    image.Save(resizePath);
                }
            }

            

        }


        private Catalogo getProducts()
        {
            SLDocument sl = new SLDocument(pathExcel);

            //Valido columnas
            //**USAR TRY CATCH para manejar excepciones --- PENDIENTE

            Catalogo ListaProductos = new Catalogo();
            List<Producto> productos = new List<Producto>();
            int iRow = 2;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                //Guardo imagen con tamaño modificado
                resizeImages(sl.GetCellValueAsString(iRow, 1));


                productos.Add(new Producto()
                {
                    Codigo = sl.GetCellValueAsString(iRow, 1),
                    Tipo = sl.GetCellValueAsString(iRow, 2),
                    Descripcion = sl.GetCellValueAsString(iRow, 3),
                    Cantidad = sl.GetCellValueAsString(iRow, 4),
                    Unidad = sl.GetCellValueAsString(iRow, 5),
                    Variedad = sl.GetCellValueAsString(iRow, 6),
                    ImageSource = "/images/Resize/" + sl.GetCellValueAsString(iRow, 1) + ".jpg"
                });

                iRow++;

            }

            ListaProductos.Productos = productos;

            return ListaProductos;
        }
    }
}
