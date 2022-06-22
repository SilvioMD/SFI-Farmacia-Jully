using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;

namespace SFI_Farmacia_Jully.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult RepCompras()
        {
            if (Session["UsuarioLogeado"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
            
        }

        public ActionResult RepVentas()
        {
            if (Session["UsuarioLogeado"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }

        }

        [HttpPost]
        public ActionResult ExportarCompras(string fechainicio, string fechafin)
        {

            using (XLWorkbook libro = new XLWorkbook())
            {
                //Generamos la hoja
                var worksheet = libro.Worksheets.Add("Compras");

                List<CompraE> Compras = ReportesA.ReporteGeneralCompras(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin));

                //Generamos la cabecera
                
                worksheet.Cell(2,2).Value = "Compras entre: ";
                worksheet.Cell(2, 3).Value = fechainicio + " hasta ";
                worksheet.Cell(2, 4).Value = fechafin;
                

                //-----------Genero la tabla de colores-----------
                int fila = 5;
                //cabecera de las tablas
                worksheet.Cell(fila -1, 2).Value = "NoFactura";
                worksheet.Cell(fila - 1, 3).Value = "Proveedor";
                worksheet.Cell(fila - 1, 4).Value = "Total";
                worksheet.Cell(fila - 1, 5).Value = "Fecha";
                

                //LLenado de la tabla
                for (int nRow = 0;nRow <= Compras.Count - 1;nRow++)
                {
                    worksheet.Cell(fila, 2).Value = Compras[nRow].NoFactura;
                    worksheet.Cell(fila, 3).Value = Compras[nRow].Proveedor;
                    worksheet.Cell(fila, 4).Value = Compras[nRow].Total;
                    worksheet.Cell(fila, 5).Value = Compras[nRow].Fecha;
                    fila++;
                }

                //-----------Le damos el formato a la cabecera----------------
                var rango = worksheet.Range("B4:E4"); //Seleccionamos un rango
                rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick); //Generamos las lineas exteriores
                rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Medium); //Generamos las lineas interiores
                rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
                rango.Style.Font.FontSize = 10; //Indicamos el tamaño de la fuente
                rango.Style.Fill.BackgroundColor = XLColor.Blue; //Indicamos el color de background
                rango.Style.Font.FontColor = XLColor.White;

                //-----------Le damos el formato a la tabla----------------
                var rangotitulo = worksheet.Range("B5:E21"); //Seleccionamos un rango
                rangotitulo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
                rangotitulo.Style.Font.FontSize = 10; //Indicamos el tamaño de la fuente
                
                //formato del titulo
                var encabezado = worksheet.Range("B2:D2");
                encabezado.Style.Font.FontSize = 14;
                encabezado.Style.Font.Bold = true;


                worksheet.ColumnsUsed().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    libro.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte Compra" + DateTime.Now.ToString() + ".xlsx");
                }
            }
            

        }

        [HttpPost]
        public ActionResult ExportarVentas(string fechainicio, string fechafin)
        {

            using (XLWorkbook libro = new XLWorkbook())
            {
                
                var hoja = libro.Worksheets.Add(ReportesA.ReporteGeneralVentas(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin)));

                
                hoja.ColumnsUsed().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    
                    libro.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte Venta" + DateTime.Now.ToString() + ".xlsx");
                }
            }


        }


    }
}
