using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AccesoDataBase;
using dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        private AccesoDatos datos;
        public CategoriaNegocio() { datos = new AccesoDatos(); }
        public List<Categoria> listarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                datos.SetearConsulta("select id, descripcion from CATEGORIAS");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IDCategoria = (int)datos.Lector["Id"];
                    aux.NombreCategoria = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch ( Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }
        }

        public void agregarCategoria(Categoria newCat)
        {
            try
            {
                datos.SetearConsulta("insert into CATEGORIAS (Descripcion) values (@Descripcion)");
                datos.SetearParametro("@Descripcion", newCat.NombreCategoria);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }
        public void modificarCategoria(Categoria cat)
        {
            try
            {
                datos.SetearConsulta("update CATEGORIAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetearParametro("@Descripcion", cat.NombreCategoria);
                datos.SetearParametro("@Id", cat.IDCategoria);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.CerrarConexion();
            }
            
            
        }
        public void eliminarCategoria(Categoria cat)
        {
            try
            {
                datos.SetearConsulta("delete from CATEGORIAS where Id = @Id");
                datos.SetearParametro("@Id", cat.IDCategoria);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            
        }
    }
}
