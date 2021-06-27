using Covid19.Context;
using Covid19.Helpers;
using Covid19.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.AppServices
{
    public class DireccionAppService
    {
        private readonly CovidContext _context;

        public DireccionAppService(CovidContext context)
        {
            _context = context;
        }

        public IEnumerable<Direccion> GetAll()
        {
            var direcciones = _context.Direccion.Where(x => x.estado == 1);
            return direcciones;
        }

        public async Task<Response> GetById(long id)
        {
            var direccion = await _context.Direccion.FirstOrDefaultAsync(r => r.id == id);
            if (direccion == null)
            {
                return new Response { mensaje = "Esta direccion no existe" };
            }

            return new Response { datos = direccion };
        }

        public async Task<Response> Post(Direccion direccion)
        {
            var direccionGuardada = await _context.Direccion.FirstOrDefaultAsync(r => r.centroVacunacion == direccion.centroVacunacion);
            if (direccionGuardada.estado == 0)
            {
                direccionGuardada.estado = 1;
                await Put(direccionGuardada);
                return new Response { mensaje = $"Direccion {direccion.ciudad} {direccion.centroVacunacion} agregado correctamente" };
            }
            if (direccionGuardada != null)
            {
                return new Response { mensaje = "Esta direccion ya existe en el sistema" };
            }


            _context.Direccion.Add(direccion);
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Direccion {direccion.ciudad} {direccion.centroVacunacion} agregado correctamente" };
        }

        public async Task<Response> Put(Direccion direccion)
        {
            _context.Entry(direccion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Direccion {direccion.ciudad} {direccion.centroVacunacion} modificada correctamente" };
        }

        public async Task<Response> Delete(Direccion direccion)
        {
            var direccionEncontrado = await _context.Direccion.FindAsync(direccion.id);
            if (direccionEncontrado == null)
            {
                return new Response { mensaje = $"No tenemos esa direccion en el sistema" }; ;
            }
            direccionEncontrado.estado = 0;
            _context.Entry(direccionEncontrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Direccion {direccionEncontrado.centroVacunacion} eliminada correctamente" };
        }
    }
}
