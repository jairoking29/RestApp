using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public RestaurantBranchViewModel GetAsViewModel(int idRestaurantBranch)
        {
            return _table.Include(rb => rb.Location).Where(rb => rb.Id == idRestaurantBranch).Select(rb => new RestaurantBranchViewModel()
            {
                Id = rb.Id,
                IdRestaurant = rb.IdRestaurant,
                IdLocation = rb.IdLocation,
                Name = rb.Name,
                Phone = rb.Phone,
                Latitude = rb.Location.Latitude,
                Longitude = rb.Location.Longitude,
            }).FirstOrDefault();
        }
    }
}