using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public class RestaurantTypeRepository : BaseRepository<RestaurantType>
    {
        public RestaurantTypeRepository()
        {
            _table = _db.RestaurantTypes;
        }
    }
}