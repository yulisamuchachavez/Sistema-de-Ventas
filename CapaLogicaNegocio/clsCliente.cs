using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaEnlaceDatos;

namespace CapaLogicaNegocio
{
    public class clsCliente
    {
        private clsManejador M = new clsManejador();

        private string _Dni;
        private string _Apellidos;
        private string _Nombres;
        private string _Direccion;
        private string _Telefono;


        public string Dni
        {
            get { return _Dni; }
            set { _Dni = value; }
        }
        
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public String Direccion{
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public DataTable Listado() {
           return M.Listado("ListarClientes", null);
        }

        public DataTable BuscarCliente(String objDatos) {
            DataTable dt = new DataTable();
            List<clsParametro> lst = new List<clsParametro>();
            lst.Add(new clsParametro("@Datos",objDatos));
            return dt=M.Listado("FiltrarDatosCliente",lst);
        }

        public String RegistrarCliente() {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@DNI",_Dni));
                lst.Add(new clsParametro("@Apellidos",_Apellidos));
                lst.Add(new clsParametro("@Nombres",_Nombres));
                lst.Add(new clsParametro("@Direccion",_Direccion));
                lst.Add(new clsParametro("@Telefono",_Telefono));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCliente", ref lst);
                Mensaje=lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarCliente()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@DNI", _Dni));
                lst.Add(new clsParametro("@Apellidos", _Apellidos));
                lst.Add(new clsParametro("@Nombres", _Nombres));
                lst.Add(new clsParametro("@Direccion", _Direccion));
                lst.Add(new clsParametro("@Telefono", _Telefono));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarCliente", ref lst);
                Mensaje = lst[5].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}
