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
        //public int YearValid { get; set; }

        #region *** Navigation properties *************************************
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        #endregion

        #region *** Meta data *************************************************
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        #endregion
    }
}
