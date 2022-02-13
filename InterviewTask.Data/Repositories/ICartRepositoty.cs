using InterviewTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Data.Repositories
{
    public interface ICartRepositoty
    {
        IEnumerable<Item> GetAllCartItems();

        void AddItemToCart(Item item);
        int RemoveItemFromCart(Item item);

    }
}
