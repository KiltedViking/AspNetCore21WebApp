using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore21WebApp.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        #region *** Navigation properties *************************************
        public int? ShipId { get; set; }
        public Ship Ship { get; set; }
        #endregion

        #region *** Meta data *************************************************
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
