using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Logica;
using TiendaVirtual.Modelos;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaVitual.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;
        public ProductosController(IWebHostEnvironment environment)
        {
            webHostEnvironment = environment;
        }
        [HttpGet]
        public IActionResult ObtenerListaProductos()
        {
            ProductoServicio servicio= new ProductoServicio();
            List<Producto> listProductos = servicio.ObtenerProductosActivos();
            return Ok(listProductos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerProductoPorId(int id)
        {
            ProductoServicio servicio = new ProductoServicio();
            Producto producto = servicio.ObtenerProductoPorId(id);
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarProducto([FromForm] NuevoProducto nuevoProducto)
        {
            try
            {
                if (nuevoProducto.Imagen == null || nuevoProducto.Imagen.Length == 0)
                {
                    return BadRequest();
                }

                var path = Path.Combine(webHostEnvironment.WebRootPath, "imagenes/", nuevoProducto.Imagen.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await nuevoProducto.Imagen.CopyToAsync(stream);
                    stream.Close();
                }

                var producto = new Producto
                {
                    Nombre = nuevoProducto.Nombre,
                    Descripcion = nuevoProducto.Descripcion,
                    EsActivo = true,
                    Stock = nuevoProducto.Stock,
                    Precio = nuevoProducto.Precio,
                    ImagenUrl = "https://localhost:7028/imagenes/" + nuevoProducto.Imagen.FileName
                };
                ProductoServicio servicio = new ProductoServicio();
                servicio.AgregarProducto(producto);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
