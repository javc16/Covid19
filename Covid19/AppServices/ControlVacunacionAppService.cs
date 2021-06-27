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
    public class ControlVacunacionAppService
    {
        private readonly CovidContext _context;

        public ControlVacunacionAppService(CovidContext context)
        {
            _context = context;
        }

        public IEnumerable<ControlVacunas> GetAll()
        {
            var controlVacunas = _context.ControlVacunas.Include(e => e.ciudadano).Include(e => e.direccion).Where(x => x.estado == 1);
            return controlVacunas;
        }

        public async Task<Response> GetById(long id)
        {
            var controlVacunas = await _context.ControlVacunas.Include(e => e.ciudadano).Include(e => e.direccion).FirstOrDefaultAsync(r => r.id == id);
            if (controlVacunas == null)
            {
                return new Response { mensaje = "Este ciudadano no tiene asociado un control de vacunacion" };
            }

            return new Response { datos = controlVacunas };
        }

        public async Task<Response> Post(ControlVacunas controlVacunas)
        {
            var controlVacunasGuardado = await _context.ControlVacunas.FirstOrDefaultAsync(r => r.ciudadano == controlVacunas.ciudadano);
            if (controlVacunasGuardado != null && controlVacunasGuardado.estado == 0)
            {
                controlVacunasGuardado.estado = 1;
                await Put(controlVacunasGuardado);
                return new Response { mensaje = $"Control de Vacunas para el ciudadano {controlVacunas.ciudadano.nombre} con id {controlVacunas.ciudadano.numeroIdentidad} agregado correctamente" };
            }
            if (controlVacunasGuardado != null)
            {
                return new Response { mensaje = "Este ciudadano ya posee un control de vacunas en el sistema" };
            }
            var ciudadano = await _context.Ciudadano.FirstOrDefaultAsync(x => x.id == controlVacunas.idCiudadano);
            var direccion = await _context.Direccion.FirstOrDefaultAsync(x => x.id == controlVacunas.idDireccion);
            controlVacunas.ciudadano = ciudadano;
            controlVacunas.direccion = direccion;
            _context.ControlVacunas.Add(controlVacunas);
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Control de Vacunas para el ciudadano {controlVacunas.ciudadano.nombre} con id {controlVacunas.ciudadano.numeroIdentidad} agregado correctamente" };
        }

        public async Task<Response> Put(ControlVacunas controlVacunas)
        {
            _context.Entry(controlVacunas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Control de Vacunas para el ciudadano {controlVacunas.ciudadano.nombre} con id {controlVacunas.ciudadano.numeroIdentidad} modificado correctamente" };
        }

        public async Task<Response> Delete(ControlVacunas controlVacunas)
        {
            var controlVacunasEncontrado = await _context.ControlVacunas.FindAsync(controlVacunas.id);
            if (controlVacunasEncontrado == null)
            {
                return new Response { mensaje = $"No tenemos un control de vacunas para  el ciudadano con id {controlVacunas.ciudadano.numeroIdentidad}" }; ;
            }
            controlVacunasEncontrado.estado = 0;
            _context.Entry(controlVacunasEncontrado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { mensaje = $"Control de Vacunas para el ciudadano {controlVacunasEncontrado.ciudadano.numeroIdentidad} eliminado correctamente" };
        }
    }
}
