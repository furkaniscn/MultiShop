using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    //Dışarında bir T değeri alacak ve bu alınan T değeri class olmak zorundadır.
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        //Entity framework'te filtreleme işlemi için bir lambda işareti vardır.
        //Func bir giriş bir çıkış değeri istiyor, giriş değeri T çıkış değeri bool'dur. filter ifadesi ise yolladığımız değeri tutar.
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
