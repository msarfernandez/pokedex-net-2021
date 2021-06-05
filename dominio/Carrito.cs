using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        public DateTime FechaCarrito { get; set; }
        public List<ItemCarrito> Items { get; set; }
    }

    public class ItemCarrito
    {
        public int Cantidad { get; set; }
        public Pokemon Pokemon { get; set; }
        public double SubTotal { get; set; }
    }
}
