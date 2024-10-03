using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Voucher
    {
        public string CodVoucher { get; set; }
        public int? IdCli { get; set; }
        public int? IdArt { get; set; }
        public DateTime? FechCanje { get; set; }

    }
}
