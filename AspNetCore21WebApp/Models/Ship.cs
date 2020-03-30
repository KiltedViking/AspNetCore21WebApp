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
        public DateTime CreatedAt { get; set; }     //Should be set when entity created
        public DateTime? ModifiedAt { get; set; }   //Should be set when entity is modified, i.e. null when entity created

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        #endregion

        //TODO 2020-03-28 - Add constructor, in which list of restaurants are created? Or should accessor test??
        //TODO 2020-03-28 - If adding constructor, is more than one necessary?
    }
}
