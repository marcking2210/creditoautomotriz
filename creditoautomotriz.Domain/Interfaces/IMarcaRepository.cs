using creditoautomotriz.Entities;
using creditoautomotriz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Domain.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcas();
        Task<Marca> GetMarca(int id);
        public void InsertMarcasMasivo(List<Marca> marcas);
    }
}
