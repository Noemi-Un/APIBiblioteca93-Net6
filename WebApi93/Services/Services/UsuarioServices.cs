using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi93.Context;
using WebApi93.Services.IServices;

namespace WebApi93.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly AplicationDbContext _context;
        public string Mensaje;

        //Creación de un constructor
        public UsuarioServices(AplicationDbContext context)
        {
            //_ significa que es privado
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }

        }

        //Obtener Usuario
        public async Task<Response<Usuario>> ByID(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                //Usuario usuario = _context.Usuarios.Find(id);

                return new Response<Usuario>(usuario);


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        //Crear Usuario
        public async Task<Response<Usuario>> Crear(UsuarioResponse request)
        {
            try
            {
                //instanciar un objeto
                //Forma uno 
                //Usuario usuario = new Usuario();

                //usuario.Nombre = request.Nombre;
                //usuario.User = request.User;
                //usuario.Password = request.Password;
                //usuario.FkRol = request.FkRol;

                //Forma dos 
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Se agrego");


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }

        }


        // Actualizar Usuario
        public async Task<Response<Usuario>> Actualizar(int id, UsuarioResponse request)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                if (usuario == null)
                    return new Response<Usuario>("Usuario no encontrado");

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Usuario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        // Eliminar Usuario
        public async Task<Response<bool>> Eliminar(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                if (usuario == null)
                    return new Response<bool>("Usuario no encontrado");

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, "Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

    }
}