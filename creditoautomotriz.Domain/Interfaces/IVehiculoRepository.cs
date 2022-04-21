using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetVehiculos();
        Task<Vehiculo> GetVehiculo(int id);
        Task InsertVehiculo(Vehiculo cliente);
        Task<bool> UpdateVehiculo(int id, Vehiculo vehiculo);
        Task<bool> DeleteVehiculo(int id);

    }
}
