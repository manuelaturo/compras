using compras.BD;
using compras.BD.Entities;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace compras.File
{
    public class GetFile
    {
        string file = ConfigurationManager.AppSettings["Plantilla"];
        //var file = GetBase64Data();
        public byte[] GetPlantilla()
        {
            string base64 = string.Empty;
            string fileName = "Plantilla.xlsx";
            string fullPath = Path.Combine(file, fileName);
            byte[] data = null;
            FileInfo fileInfo = new FileInfo(fullPath);
            long numBytes = fileInfo.Length;
            FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes((int)numBytes);
            fileStream.Close();
            //base64 = Convert.ToBase64String(data);
            return data;
        }

        public bool SaveUsers(string path)
        {
            bool result = false;
            UsuariosEntity usuariosEntity = new UsuariosEntity();
            SLDocument sl = new SLDocument(path);

            int iRow = 2;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                string numEmpleado = sl.GetCellValueAsString(iRow, 1);
                usuariosEntity.noEmpledo = Convert.ToInt32(numEmpleado);
                string Nombre = sl.GetCellValueAsString(iRow, 2);
                usuariosEntity.nombre = Nombre;
                string ApellidoPaterno = sl.GetCellValueAsString(iRow, 3);
                usuariosEntity.APaterno = ApellidoPaterno;
                string ApellidoMaterno = sl.GetCellValueAsString(iRow, 4);
                usuariosEntity.AMaterno = ApellidoMaterno;
                if (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 5))) {
                    DateTime FechadeNacimiento = sl.GetCellValueAsDateTime(iRow, 5);
                    DateTime dateNacimiento = Convert.ToDateTime(FechadeNacimiento);
                    usuariosEntity.fechaNacimiento = FechadeNacimiento;
                }

                if (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 6)))
                {
                    string Rol = sl.GetCellValueAsString(iRow, 6);
                    usuariosEntity.perfil = Convert.ToInt32(Rol);
                }
                //if (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow,7)))
                //{
                //    string Supervisor = sl.GetCellValueAsString(iRow, 7);
                //    usuariosEntity. = Rol;
                //}
                string Password = sl.GetCellValueAsString(iRow, 8);
                usuariosEntity.password = Password;
                if (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow,9)))
                {
                    string Curp = sl.GetCellValueAsString(iRow, 9);
                    usuariosEntity.curp = Curp;
                }

                string Empresa = sl.GetCellValueAsString(iRow, 10);
                usuariosEntity.compañia = Empresa;
                string Correo = sl.GetCellValueAsString(iRow, 11);
                usuariosEntity.email = Correo;

                //if (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 12)))
                //{
                //    string Ubicacion = sl.GetCellValueAsString(iRow, 12);
                //    usuariosEntity.ubi = Ubicacion;
                //}

                //string Estatus = sl.GetCellValueAsString(iRow, 13);
                UsuariosDAO usuarioDao = new UsuariosDAO();
                usuarioDao.AddUsuario(usuariosEntity);
                iRow++;
                

            }


            return result;
        }
    }
}