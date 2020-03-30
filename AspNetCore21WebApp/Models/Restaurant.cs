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

        //TODO 2020-03-28 - Add "current menu" property that returns the latest approved menu

        #region *** Navigation properties *************************************
        public int? ShipId { get; set; }    //Restaurant may not be associated with a ship, i.e. property should allow null
        public Ship Ship { get; set; }      //Navigation properties may be null as default, i.e. no ? required
        #endregion

        #region *** Meta data *************************************************
        public DateTime CreatedAt { get; set; }     //Should be set when entity created
        public DateTime? ModifiedAt { get; set; }   //Should be set when entity is modified, i.e. null when entity created

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        #endregion
    }
}
