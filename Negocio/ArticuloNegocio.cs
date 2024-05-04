using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoDataBase;

namespace Negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos Datos;
        private ImagenNegocio Imagenes;

        public ArticuloNegocio()
        {
            Datos = new AccesoDatos();
            Imagenes = new ImagenNegocio();
        }

        public List<Articulo> ListarArticulos(string consulta = null)
        {
            List<Articulo> Lista = new List<Articulo>();
            try
            {
                if (consulta!= null)
                {
                    Datos.SetearConsulta(consulta);

                }
                else
                {
                    Datos.SetearConsulta("select  a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.ID IdCategoria, c.Descripcion as 'Categoria', m.Descripcion as 'Marca', m.ID IdMarca FROM ARTICULOS a, Categorias c, Marcas m where a.IdCategoria= c.Id and a.IdMarca = m.Id");
                }
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IDArticulo = Datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)Datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)Datos.Lector["Nombre"];
                    aux.DescripcionArticulo = (string)Datos.Lector["Descripcion"];
                    aux.PrecioArticulo = (decimal)Datos.Lector["Precio"];
                    aux.MarcaArticulo = new Marca();
                    aux.MarcaArticulo.IDMarca = (int)Datos.Lector["IdMarca"];
                    aux.MarcaArticulo.NombreMarca= (string)Datos.Lector["Marca"];
                    aux.CategoriaArticulo = new Categoria();
                    aux.CategoriaArticulo.IDCategoria = (int)Datos.Lector["IdCategoria"];
                    aux.CategoriaArticulo.NombreCategoria = (string)Datos.Lector["Categoria"];
                    
                    
                    Lista.Add(aux);
                }   

                foreach (var articulo in Lista)
                {
                    
                    articulo.Imagenes = Imagenes.Listarimagenes(articulo.IDArticulo);
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

        public void AgregarArticulo(Articulo Nuevo)
        {
            try
            {
                try
                {
                    Datos.SetearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,Precio,IdCategoria,IdMarca) values(@Codigo,@Nombre,@Descripcion,@Precio,@IdCategoria,@IdMarca)");
                    Datos.SetearParametro("@Codigo", Nuevo.CodigoArticulo);
                    Datos.SetearParametro("@Nombre", Nuevo.NombreArticulo);
                    Datos.SetearParametro("@Descripcion", Nuevo.DescripcionArticulo);
                    Datos.SetearParametro("@IdCategoria", Nuevo.CategoriaArticulo.IDCategoria);
                    Datos.SetearParametro("@IdMarca", Nuevo.MarcaArticulo.IDMarca);
                    Datos.SetearParametro("@Precio", Nuevo.PrecioArticulo);
                    Datos.EjecutarAccion();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { Datos.CerrarConexion(); }
                int ID = ObtenerUltimoID();
                Imagenes.AgregarImagen(ID, Nuevo.Imagenes[0].URLImagen);
                
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { Datos.CerrarConexion();}
        }

        public void ModificarArticulo(Articulo Modificado)
        {
            try
            {
                Datos.SetearConsulta("update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre,Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria,Precio=@Precio where id=@Id ");
                Datos.SetearParametro("@Codigo", Modificado.CodigoArticulo);
                Datos.SetearParametro("@Nombre", Modificado.NombreArticulo); ;
                Datos.SetearParametro("@Descripcion", Modificado.DescripcionArticulo);
                Datos.SetearParametro("@IdCategoria", Modificado.CategoriaArticulo.IDCategoria);
                Datos.SetearParametro("@IdMarca", Modificado.MarcaArticulo.IDMarca);
                Datos.SetearParametro("@Precio", Modificado.PrecioArticulo);
                Datos.SetearParametro("@Id", Modificado.IDArticulo);
                Datos.EjecutarAccion();
                Datos.CerrarConexion();
                Datos.SetearConsulta("insert into IMAGENES (IdArticulo,ImagenUrl) values (@IdArticulo,@URL)");
                Datos.SetearParametro("@IdArticulo", Modificado.IDArticulo);
                Datos.SetearParametro("@URL", Modificado.Imagenes[0].URLImagen);
                Datos.EjecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EliminarArticulo(int ID)
        {
            try
            {
                Datos.SetearConsulta("DELETE FROM ARTICULOS WHERE Id ="+ID);
                Datos.EjecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                Datos.CerrarConexion(); 
            }
        }

        public int ObtenerUltimoID()
        {
            try
            {
                Datos.SetearConsulta("SELECT MAX(Id) FROM ARTICULOS");
                Datos.EjecutarLectura();
                Datos.Lector.Read();
                return Datos.Lector.GetInt32(0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { Datos.CerrarConexion(); }
        }

        public void ModificarArticuloImagen(Articulo Modificado)
        {
            try
            {
                Datos.SetearConsulta("update IMAGENES set ImagenUrl = @URL where IdArticulo = @IdArticulo");
                Datos.SetearParametro("@IdArticulo", Modificado.IDArticulo);
                Datos.SetearParametro("@URL", "https://i0.wp.com/static.vecteezy.com/system/resources/previews/005/337/799/original/icon-image-not-found-free-vector.jpg?ssl=1");
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { Datos.CerrarConexion(); }
        }
    }
}
