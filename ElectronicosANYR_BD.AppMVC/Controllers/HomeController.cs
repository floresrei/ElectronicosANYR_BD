using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElectronicosANYR_BD.Controllers
{
    // Creamos una clase para representar al Cliente
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class HomeController : Controller
    {
        // Esta lista simula nuestra base de datos en memoria
        private static List<Cliente> ListaClientes = new List<Cliente>();

        public IActionResult Index() => View();

        public IActionResult Registro() => View();

        public IActionResult Bienvenido() => View();

        // ACCIÓN PARA REGISTRAR Y ENVIAR A BIENVENIDO
        [HttpPost]
        public IActionResult ProcesarRegistro(string nombre, string correo, string password)
        {
            // 1. Guardamos el nuevo cliente en nuestra lista
            var nuevoCliente = new Cliente
            {
                Nombre = nombre,
                Correo = correo,
                Password = password
            };
            ListaClientes.Add(nuevoCliente);

            // 2. Enviamos el nombre a la vista de bienvenida para personalizarla
            ViewBag.UsuarioNombre = nombre;

            // 3. ¡La magia! Redirigimos directamente a Bienvenido
            return View("Bienvenido");
        }

        [HttpPost]
        public IActionResult Validar(string correo, string password)
        {
            // Buscamos si el correo y contraseña existen en nuestra lista de clientes
            var usuarioEncontrado = ListaClientes.Find(u => u.Correo == correo && u.Password == password);

            if (usuarioEncontrado != null || (correo == "admin@tienda.com" && password == "1234"))
            {
                ViewBag.UsuarioNombre = usuarioEncontrado?.Nombre ?? "Admin";
                return View("Bienvenido");
            }

            ViewBag.Error = "Usuario o contraseña no válidos";
            return View("Index");
        }
    }
}