using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces
{
    //Dışarında bir T değeri alacak ve bu alınan T değeri class olmak zorundadır.
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Entity framework'te filtreleme işlemi için bir lambda işareti vardır.
        //Func bir giriş bir çıkış değeri istiyor, giriş değeri T çıkış değeri bool'dur. filter ifadesi ise yolladığımız değeri tutar.
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
