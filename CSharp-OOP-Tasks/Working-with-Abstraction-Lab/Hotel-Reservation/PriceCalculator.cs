using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class PriceCalculator
    {
       
        public decimal CalculatePrice(
            decimal pricePerDay, int numberOfDays, 
            SeasonMultiplier season, DiscountPercentage discount)
        {
            int multiplier = (int)season;
            decimal discountAmount = Math.Abs(((int)discount / 100m) - 1);

            decimal totalPrice = ((pricePerDay * numberOfDays) * multiplier) * discountAmount;

            return totalPrice;
        }
    }
}
