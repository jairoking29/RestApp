using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public class RestaurantBranchRepository : BaseRepository<RestaurantBranch>
    {
        public RestaurantBranchRepository()
        {
            _table = _db.RestaurantBranches;
        }
    }
}