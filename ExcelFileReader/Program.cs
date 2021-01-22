using SpreadsheetLight;
using System;

namespace ExcelFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\dev\PDF Generator\MVCPDFGenerator\wwwroot\images\Catalogo.xlsx";
            //string path = @"../images/Catalogo.xlsx";

            SLDocument sl = new SLDocument(path);

            //CODIGO	TIPO	DESCRIPCION	CANTIDAD	UNIDAD	VARIEDAD


            int iRow = 2;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                string codigo = sl.GetCellValueAsString(iRow, 1);
                string tipo = sl.GetCellValueAsString(iRow, 2);
                string descripcion = sl.GetCellValueAsString(iRow, 3);
                string cantidad = sl.GetCellValueAsString(iRow, 4);
                string unidad = sl.GetCellValueAsString(iRow, 5);
                string variedad = sl.GetCellValueAsString(iRow, 6);

                iRow++;

                Console.WriteLine(codigo + ", " + tipo + ", " + descripcion + ", " + cantidad + ", " + unidad + ", " + variedad);
            }

        }
    }
}
