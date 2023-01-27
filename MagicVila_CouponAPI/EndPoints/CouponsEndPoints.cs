using AutoMapper;
using FluentValidation;
using MagicVila_CouponAPI.Models.DTO;
using MagicVila_CouponAPI.Models;
using MagicVila_CouponAPI.Repository.IRepository;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MagicVila_CouponAPI.EndPoints
{
    public static class CouponsEndPoints
    {
        public static void ConfigureCouponsEndPoint(this WebApplication app)
        {
            app.MapGet("/api/Coupon", GetAllCoupons).WithName("GetCoupons").Produces<APIResponse>(200);

            app.MapGet("/api/Coupon/{id:int}", GetCouponById).WithName("GetCoupon").Produces<APIResponse>(200);

            app.MapPost("/api/Coupon", CreateCoupon).WithName("CreateCoupon").Produces<APIResponse>(201).Produces(400);


            app.MapPut("api/Coupon", UpdateCoupon).WithName("UpdateCoupon").Produces<APIResponse>(200).Produces(404);

            app.MapDelete("/api/deleteCoupon{id:int}", DeleteCoupon).WithName("DeleteCoupon");

        }
        private async static Task<IResult>GetAllCoupons(ICouponRepository _db)
        {

            APIResponse response = new();
            response.IsSuccess = true;
            response.Result = await _db.GetAllAsync();
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);

        }
        private async static Task<IResult> GetCouponById(ICouponRepository _db, int id)
        {
            APIResponse response = new();
            response.IsSuccess = true;
            response.Result = await _db.GetByIdAsync(id);
            response.StatusCode = HttpStatusCode.OK;
            return Results.Ok(response);
        }
        private async static Task<IResult>DeleteCoupon(ICouponRepository _db, int Id)
        {
            APIResponse response = new();
            Coupon coupon = await _db.GetByIdAsync(Id);
            if (coupon != null)
            {

                await _db.DeleteAsync(coupon);
                await _db.Save();
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;

            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage.Add("Invalid Id");

            }
            return Results.Ok(response);
        }
        private async static Task<IResult>CreateCoupon(ICouponRepository _db, IMapper _mapper,
                IValidator<CouponCreatedDTO> _validator, [FromBody] CouponCreatedDTO Model)
        {
            APIResponse response = new();
            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.BadRequest;
            var validateresult = _validator.Validate(Model);
            if (!validateresult.IsValid)
            {
                response.ErrorMessage.Add(validateresult.Errors.FirstOrDefault().ToString());
                return Results.BadRequest(response);
            }
            //if (_db.Coupons.FirstOrDefault(x => x.Name == Model.Name) != null)
            //{
            //    response.ErrorMessage.Add(validateresult.Errors.FirstOrDefault().ToString());
            //    return Results.BadRequest(response);
            //}
            Coupon coupon = _mapper.Map<Coupon>(Model);
            await _db.CreateAsync(coupon);
            await _db.Save();
            response.StatusCode = HttpStatusCode.Created;
            response.Result = coupon;
            response.IsSuccess = true;
            // return Results.CreatedAtRoute("GetCoupon", new { id = coupon.Id }, coupon);
            //return Results.Created($"/api/GetCoupon/{Model.Id}", Model); 
            return Results.Ok(response);
        }
        private async static Task<IResult>UpdateCoupon(ICouponRepository _db, IMapper mapper, IValidator<CouponUpdatedDTO> validator, CouponUpdatedDTO Model)
        {
            APIResponse response = new();
            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.BadRequest;
            var validateResult = validator.Validate(Model);
            if (!validateResult.IsValid)
            {
                response.ErrorMessage.Add(validateResult.Errors.FirstOrDefault().ToString());
                Results.BadRequest(response);
            }

            Coupon coupon = mapper.Map<Coupon>(Model);
            await _db.UpdateAsync(coupon);
            await _db.Save();
            response.Result = coupon;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;
            return Results.Ok(response);
        }
    }
}
