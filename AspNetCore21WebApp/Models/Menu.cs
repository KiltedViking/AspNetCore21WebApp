using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore21WebApp.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        //TODO 2020-03-28 - Add some test data to database and then add mandatory property (with default value)
        //public int YearValid { get; set; }

        #region *** Navigation properties *************************************
        public int RestaurantId { get; set; }       //A menu must be for a restaurant, i.e. mandatory
        public Restaurant Restaurant { get; set; }
        #endregion

        #region *** Meta data *************************************************
        public DateTime CreatedAt { get; set; }     //Should be set when entity created
        public DateTime? ModifiedAt { get; set; }   //Should be set when entity is modified, i.e. null when entity created
        public DateTime? ApprovedAt { get; set; }   //Should be set when menu is apporved, i.e. null when entity created or modified

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        #endregion
    }
}
