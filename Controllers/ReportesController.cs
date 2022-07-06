using ClosedXML.Excel;
using SFI_Farmacia_Jully.Models.Action;
using SFI_Farmacia_Jully.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

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

        public ActionResult RepControlados()
        {
            if (Session["UsuarioLogeado"] != null)
            {
                return View(ReportesA.ReporteControlados());
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

                worksheet.Cell(2, 2).Value = "Compras entre: ";
                worksheet.Cell(2, 3).Value = fechainicio + " hasta ";
                worksheet.Cell(2, 4).Value = fechafin;


                //-----------Genero la tabla de colores-----------
                int fila = 5;
                //cabecera de las tablas
                worksheet.Cell(fila - 1, 2).Value = "NoFactura";
                worksheet.Cell(fila - 1, 3).Value = "Proveedor";
                worksheet.Cell(fila - 1, 4).Value = "Total";
                worksheet.Cell(fila - 1, 5).Value = "Fecha";


                //LLenado de la tabla
                for (int nRow = 0; nRow <= Compras.Count - 1; nRow++)
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


        [HttpPost]
        public ActionResult ExportarControlados()
        {

            using (XLWorkbook libro = new XLWorkbook())
            {
                //Generamos la hoja
                var worksheet = libro.Worksheets.Add("Compras");

                List<ProductoE> Productos = ReportesA.ReporteControlados();

                //Generamos la cabecera
                worksheet.Cell(1, 4).Value = "MINISTERIO DE SALUD";
                worksheet.Cell(2, 4).Value = "SILAIS MANAGUA"; 
                 worksheet.Cell(4, 4).Value = "INFORME MENSUAL DE SUSTANCIAS PSICOTROPICAS - ANEXO";
                //datos de la farmacia
                worksheet.Cell(6, 1).Value = "FARMACIA:"; worksheet.Cell(6, 2).Value = "FARMAJULLY"; worksheet.Cell(6, 8).Value = "MES: "; worksheet.Cell(6, 9).Value = DateTime.Now.ToString();
                worksheet.Cell(7, 1).Value = "Dirección:"; worksheet.Cell(7, 2).Value = "Colonia Miguel Bonilla,"; worksheet.Cell(7, 3).Value = "Comedor UNAN 3 cuadras abajo 5 1/2"; worksheet.Cell(7, 4).Value = " cuadra al sur, casa 227.";
                worksheet.Cell(9, 1).Value = "MUNICIPIO:"; worksheet.Cell(9, 2).Value = "Managua";

                //-----------Genero la tabla de colores-----------
                int fila = 14;
                //cabecera de las tablas
                worksheet.Cell(fila - 2, 2).Value = "NOMBRE GENÉRICO"; worksheet.Cell(fila - 1, 2).Value = "Y CONCENTRACIÓN";
                worksheet.Cell(fila - 2, 3).Value = "FORM."; worksheet.Cell(fila - 1, 3).Value = "FARM.";
                worksheet.Cell(fila - 2, 4).Value = "LABORAT."; worksheet.Cell(fila - 2, 4).Value = "FABRIC.";
                worksheet.Cell(fila - 2, 5).Value = "ENTRADAS";
                worksheet.Cell(fila - 2, 6).Value = "SALIDAS";
                worksheet.Cell(fila - 2, 7).Value = "EXISTENCIA"; worksheet.Cell(fila - 1, 7).Value = "ACTUAL";
               
                //LLenado de la tabla
                for (int nRow = 0; nRow <= Productos.Count - 1; nRow++)
                {
                    worksheet.Cell(fila, 2).Value = Productos[nRow].Nombre;
                    worksheet.Cell(fila, 3).Value = Productos[nRow].Presentacion;
                    worksheet.Cell(fila, 4).Value = Productos[nRow].Laboratorio;
                    worksheet.Cell(fila, 5).Value = Productos[nRow].Entrada;
                    worksheet.Cell(fila, 6).Value = Productos[nRow].Salida;
                    worksheet.Cell(fila, 7).Value = Productos[nRow].CantidadDisponible;
                    fila++;
                }
                //pie de pagina
                worksheet.Cell(fila + 2, 1).Value = "Arlen S."; worksheet.Cell(fila + 2, 8).Value = "Arlen S.";
                worksheet.Cell(fila + 2, 2).Value = "Centeno O."; worksheet.Cell(fila + 2, 9).Value = "Centeno O.";
                worksheet.Cell(fila + 3, 1).Value = "PROPIETARIO:"; worksheet.Cell(fila + 3, 8).Value = "REGENTE "; worksheet.Cell(fila + 3, 9).Value = "FARMACEÚTICO:";


                //formato del titulo
                var encabezado = worksheet.Range("D1:H11");
                encabezado.Style.Font.FontSize = 12;
                encabezado.Style.Font.Bold = true;

                //Editar el encabezado de la tabla
                var encabezadotabla = worksheet.Range("B12:G13");
                encabezadotabla.Style.Font.FontSize = 12;
                encabezadotabla.Style.Font.Bold = true;
                encabezadotabla.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
                encabezadotabla.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick); //Generamos las lineas exteriore

                //Editar el encabezado de la tabla
                var tabla = worksheet.Range("B12:G13");
                tabla.Style.Font.FontSize = 12;
                tabla.Style.Font.Bold = true;
                tabla.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
                tabla.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick); //Generamos las lineas exteriore

                worksheet.ColumnsUsed().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    libro.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte Minsa" + DateTime.Now.ToString() + ".xlsx");
                }
            }

        }
    }
}
