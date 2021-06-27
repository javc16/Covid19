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
    
    public class CiudadanoAppService
    {
        private readonly CovidContext _context;

        public CiudadanoAppService(CovidContext context)
        {
            _context = context;
        }

        public IEnumerable<Ciudadano> GetAll()
        {
            var ciudadanos = _context.Ciudadano.Where(x => x.estado == 1);           
            return ciudadanos;
        }

        public async Task<Response> GetById(long id)
        {
            var ciudadano = await _context.Ciudadano.FirstOrDefaultAsync(r => r.id == id);
            if (ciudadano == null)
            {
                return new Response { mensaje = "Este ciudadano no existe" };
            }
          
            return new Response { datos = ciudadano };
        }

        public async Task<Response> Post(Ciudadano ciudadano)
        {
            var SavedUser = await _context.Ciudadano.FirstOrDefaultAsync(r => r.numeroIdentidad == ciudadano.numeroIdentidad);
            if (SavedUser.estado == 0)
            {
                SavedUser.estado = 1;
                await Put(SavedUser);
                return new Response { mensaje = $"Ciudadano {ciudadano.nombre} con id {ciudadano.numeroIdentidad} agregado correctamente" };
            }
            if (SavedUser != null)
            {
                return new Response { mensaje = "Este ciudadano ya existe en el sistema" };
            }
        
            
            _context.Ciudadano.Add(ciudadano);
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Ciudadano {ciudadano.nombre} con id {ciudadano.numeroIdentidad} agregado correctamente" };
        }

        public async Task<Response> Put(Ciudadano ciudadano)
        {
            _context.Entry(ciudadano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Ciudadano {ciudadano.nombre} y  id {ciudadano.numeroIdentidad} modificado correctamente" };
        }

        public async Task<Response> Delete(Ciudadano ciudadano)
        {
            var ciudadanoEncontrado = await _context.Ciudadano.FindAsync(ciudadano.id);
            if (ciudadanoEncontrado == null)
            {
                return new Response { mensaje = $"No tenemos un ciudadano con id {ciudadano.numeroIdentidad}" }; ;
            }
            ciudadanoEncontrado.estado = 0;
            _context.Entry(ciudadanoEncontrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Ciudadano {ciudadanoEncontrado.numeroIdentidad} eliminado correctamente" };
        }


    }
}
