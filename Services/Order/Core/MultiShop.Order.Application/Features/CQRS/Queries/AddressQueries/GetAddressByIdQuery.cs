using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public int Id { get; set; }
        //Controller'da çaığırıken constructor üzerinden çağırılacağı için constructor oluşturduk.
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
