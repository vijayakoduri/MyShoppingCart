using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Data.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int quantity { get; set; }

        public Product Product { get; set; }

    }
}
