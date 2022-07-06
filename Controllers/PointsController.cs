using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PointsMicroservice.Infrastructure;
using PointsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        Helper _api = new Helper();
        private readonly ILike _like;
        public PointsController(ILike like)
        {
            _like = like;
        }

        [HttpGet]
        [Route("RefreshPointsByEmployee/{employeeId}")]
        public async Task<ActionResult> RefreshPointsByEmployee(int employeeId)
        {
            List<OfferData> newOffers = await GetList();
            var points = _like.Refersh(employeeId, newOffers);
            return Ok(points);
        }

        [HttpGet]
        [Route("GetPointsByEmployeeId/{employeeId}")]
        public ActionResult GetPointsByEmployeeId(int employeeId)
        {
            Points point = _like.PointsByEmployeeId(employeeId);
            return Ok(point);
        }




        [HttpGet]
        [Route("GetList")]
        public async Task<List<OfferData>> GetList()
        {
            List<OfferData> offers = new List<OfferData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/offer/GetOffersList");



            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<OfferData>>(results);
            }

            //List<OfferDto> lists = offers.ToList();
            return offers;
        }

        [HttpGet]
        [Route("GetLikeIn2Days/{id}/{date}")]
        public int GetLikesInTwoDays(int id, DateTime date)
        {
            // List<OfferProvider> newOffers = await GetList();
            int count = _like.LikeInTwoDaysCount(id, date);

            int count1 = _like.LikeInTwoDaysCount1(id, date);

            // int count2 = Likes.Where(c => c.LikeDate == date.AddDays(2) && c.OfferId == id).Count();
            int totalLikes = count + count1;

            return totalLikes;

        }



    }
}
