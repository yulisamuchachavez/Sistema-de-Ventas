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
   public class clsCategoria
    {
       private clsManejador M = new clsManejador();

        private Int32 _IdC;
        private Int32 _IdCategoria;
        private string _Descripcion;

        public Int32 IdC {
            get { return _IdC; }
            set { _IdC = value; }
        }
        public Int32 IdCategoria
        {
            get { return _IdCategoria; }
            set { _IdCategoria = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public DataTable Listar() {
            return M.Listado("ListarCategoria",null);
        }

        public string RegistrarCategoria()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@Descripcion",_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("RegistrarCategoria",ref lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }

        public DataTable BuscarCategoria(String objDescripcin) {
            List<clsParametro> lst = new List<clsParametro>();
            DataTable dt = new DataTable();
            try
            {
                lst.Add(new clsParametro("@Datos", objDescripcin));
                return dt = M.Listado("BuscarCategoria",lst);
            }
            catch (Exception ex)
            {    
                throw ex;
            }
        }

        public string ActualizarCategoria()
        { 
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametro("@IdC",_IdC));
                lst.Add(new clsParametro("@Descripcion",_Descripcion));
                lst.Add(new clsParametro("@Mensaje","",SqlDbType.VarChar,ParameterDirection.Output,50));
                M.EjecutarSP("ActualizarCategoria", ref lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return Mensaje;
        }
    }
}
