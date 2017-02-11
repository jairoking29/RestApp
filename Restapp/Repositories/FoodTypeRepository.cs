using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public class FoodTypeRepository : BaseRepository<FoodType>
    {
        public FoodTypeRepository()
        {
            _table = _db.FoodTypes;
        }
    }
}