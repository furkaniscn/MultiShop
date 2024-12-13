using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;
        public DiscountService(DapperContext context)
        {
            _context = context;
        }


        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "Insert Into Coupons (CouponCode, CouponRate, CouponIsActive, CouponValidDate) Values(@couponCode, @couponRate, @couponIsActive, @couponValidDate)";
            var parameters = new DynamicParameters();//Dapper'da parametre göndermek için oluşturulan kullanım
            parameters.Add("@couponCode", createCouponDto.CouponCode);
            parameters.Add("@couponRate", createCouponDto.CouponRate);
            parameters.Add("@couponIsActive", createCouponDto.CouponIsActive);
            parameters.Add("@couponValidDate", createCouponDto.CouponValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "Delete From Coupons Where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("couponId", couponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set CouponCode=@couponCode, CouponRate=@couponRate, CouponIsActive=@couponIsActive, CouponValidDate=@couponValidDate Where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@couponCode", updateCouponDto.CouponCode);
            parameters.Add("@couponRate", updateCouponDto.CouponRate);
            parameters.Add("@couponIsActive", updateCouponDto.CouponIsActive);
            parameters.Add("@couponValidDate", updateCouponDto.CouponValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
