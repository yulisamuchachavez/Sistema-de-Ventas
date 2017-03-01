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
    public class clsProducto
    {
        private clsManejador M = new clsManejador();

        private Int32 _IdP;
        private Int32 _IdCategoria;
        private string _Producto;
        private string _Marca;
        private Int32 _Stock;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private DateTime _FechaVencimiento;

        public Int32 IdP{
            get { return _IdP; }
            set{_IdP=value;}
        }

        public Int32 IdCategoria
        {
            get { return _IdCategoria; }
            set { _IdCategoria = value; }
        }

        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public Int32 Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

        public decimal PrecioCompra
        {
            get { return _PrecioCompra; }
            set { _PrecioCompra = value; }
        }

        public decimal PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _FechaVencimiento; }
            set { _FechaVencimiento = value; }
        }

        public DataTable Listar()
        {
            return M.Listado("ListadoProductos", null);
        }

        public DataTable BusquedaProductos(String objDatos) {
            DataTable dt = new DataTable();
            List<clsParametro> lst = new List<clsParametro>();
            try
            {
                lst.Add(new clsParametro("@Datos", objDatos));
                dt = M.Listado("FiltrarDatosProducto", lst);
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            return dt;
        }

        public string RegistrarProductos()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new clsParametro("@IdCategoria", _IdCategoria));
                lst.Add(new clsParametro("@Nombre", _Producto));
                lst.Add(new clsParametro("@Marca", _Marca));
                lst.Add(new clsParametro("@Stock", _Stock));
                lst.Add(new clsParametro("@PrecioCompra", _PrecioCompra));
                lst.Add(new clsParametro("@PrecioVenta", _PrecioVenta));
                lst.Add(new clsParametro("@FechaVencimiento", _FechaVencimiento));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarProducto", ref lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

        public String ActualizarProductos()
        {
            List<clsParametro> lst = new List<clsParametro>();
            String Mensaje = "";

            try
            {
                lst.Add(new clsParametro("@IdProducto",_IdP));
                lst.Add(new clsParametro("@IdCategoria", _IdCategoria));
                lst.Add(new clsParametro("@Nombre", _Producto));
                lst.Add(new clsParametro("@Marca", _Marca));
                lst.Add(new clsParametro("@Stock", _Stock));
                lst.Add(new clsParametro("@PrecioCompra", _PrecioCompra));
                lst.Add(new clsParametro("@PrecioVenta", _PrecioVenta));
                lst.Add(new clsParametro("@FechaVencimiento", _FechaVencimiento));
                lst.Add(new clsParametro("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("ActualizarProducto", ref lst);
                Mensaje = lst[8].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }
    }
}