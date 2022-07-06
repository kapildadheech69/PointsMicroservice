using PointsMicroservice.Models;
using System;
using System.Collections.Generic;

namespace PointsMicroservice.Infrastructure
{
    public interface ILike
    {
        int LikeInTwoDaysCount(int id, DateTime date);
        int LikeInTwoDaysCount1(int id, DateTime date);
        Points PointsByEmployeeId(int employeeId);
        Points Refersh(int employeeId, List<OfferData> newOffer);
    }
}
