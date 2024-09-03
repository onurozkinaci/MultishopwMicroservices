using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int couponId);
        Task<GetByIdDiscountCouponDto>GetByIdDiscountCouponAsync(int couponId);
    }
}
