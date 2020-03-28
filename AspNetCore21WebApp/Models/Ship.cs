using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore21WebApp.Models
{
    public class Ship
    {
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public int NumberOfPassangers { get; set; }

        #region *** Navigation properties *************************************
        public ICollection<Restaurant> Restaurants { get; set; }
        #endregion

        #region *** Meta data *************************************************
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
