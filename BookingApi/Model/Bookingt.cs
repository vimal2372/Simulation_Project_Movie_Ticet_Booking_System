using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingtApi.Model
{
    public class Bookingt
    {
        public int Id { get; set; }
        public string seatno { get; set; }
        public string UserName { get; set; }
        public string Datetopresent { get; set; }
        public int MovieDetailsId { get; set; }
        public string MovieName { get; set; }

    }
}
