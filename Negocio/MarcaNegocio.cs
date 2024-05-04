using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDataBase;
using dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        private AccesoDatos Datos;

        public MarcaNegocio()
        {
            Datos = new AccesoDatos();
        }

        public List<Marca> ListarMarcas()
        {
            List<Marca> Lista = new List<Marca>();
            try
            {
                Datos.SetearConsulta("select Id, Descripcion FROM MARCAS");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = Datos.Lector.GetInt32(0);
                    aux.NombreMarca = (string)Datos.Lector["Descripcion"];

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }   

        public void agregarMarca(Marca nuevaMarca)
        {
            try
            {
               Datos.SetearConsulta("insert into MARCAS (Descripcion) values (@Descripcion)");
               Datos.SetearParametro("@Descripcion", nuevaMarca.NombreMarca);
               Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }  
        
        public void modificarMarca(Marca marca)
        {
            try
            {
                Datos.SetearConsulta("update MARCAS set Descripcion = @Descripcion where Id = @Id");
                Datos.SetearParametro("@Descripcion", marca.NombreMarca);
                Datos.SetearParametro("@Id", marca.IDMarca);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        public void eliminarMarca(Marca marca)
        {
            try
            {
                Datos.SetearConsulta("delete from MARCAS where Id = @Id");
                Datos.SetearParametro("@Id", marca.IDMarca);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }
    }
}
