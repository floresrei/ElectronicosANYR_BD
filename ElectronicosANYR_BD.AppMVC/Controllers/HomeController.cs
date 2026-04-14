using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ElectronicosANYR_BD.AppMVC.Models;
namespace ElectronicosANYR_BD.Controllers
{
    // Creamos una clase para representar al Cliente


    public class HomeController : Controller
    {
        private readonly ElectronicosAnyrBdContext _context;

        public HomeController(ElectronicosAnyrBdContext context)
        {
            _context = context;
        }
        // Esta lista simula nuestra base de datos en memoria
        private static List<Cliente> ListaClientes = new List<Cliente>();

        public IActionResult Index() => View();

        public IActionResult Registro() => View();

        public IActionResult Bienvenido() => View();

        // ACCIÓN PARA REGISTRAR Y ENVIAR A BIENVENIDO
        [HttpPost]
        public async Task<IActionResult> ProcesarRegistro(string nombre,string apellido,string correo, string password)
        {
            // 1. Guardamos el nuevo cliente en nuestra lista
            /*  var nuevoCliente = new Cliente
              {
                  Nombre = nombre,
                  Correo = correo,
                  Password = password
              };
              ListaClientes.Add(nuevoCliente);*/
            var cliente = new Cliente
            {
                Nombre = nombre,
                Email = correo,
                Apellido=apellido
            };
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Clientes");
        }
        [HttpPost]
        public IActionResult Clientes(string nombre, string correo, string password)
        {
            // Aquí iría tu lógica para guardar en la base de datos
            return View("Clientes");
        }

        [HttpPost]
        public IActionResult Validar(string correo, string password)
        {
            // Buscamos si el correo y contraseña existen en nuestra lista de clientes
            var usuarioEncontrado = ListaClientes.Find(u => u.Email == correo);

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