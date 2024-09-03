﻿using Dapper;
using Multishop.Discount.Context;
using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
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
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate);";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "Delete From Coupons where CouponId = @couponId;";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "Select * From Coupons;";
            using (var connection = _context.CreateConnection())
            {
               var values =  await connection.QueryAsync<ResultDiscountCouponDto>(query);
               return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "Select * From Coupons Where CouponId = @couponId;";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate Where CouponId=@couponId;";
            var parameters = new DynamicParameters();
            parameters.Add("@code",updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
