using System;

// ReSharper disable once CheckNamespace
namespace Economy
{
    public static class EconomyHelper
    {
        public static int GetRemainingItemCount(int lastCount, float duration, float lifespan, float coefficient)
        {
            return (int)Math.Max(lastCount - (duration / (Math.Pow(lifespan, coefficient))), 0);
        }
        
        public static float GetEarning(float lifespan, float revenue, int lastCount, float coefficient, float duration = 1f)
        {
            var lifespanCoefficient = Math.Pow(lifespan, 1.55f);
            var itemLeft = Math.Max(lastCount - duration / lifespanCoefficient, 0f);
            var remainingItemCount = lastCount - itemLeft;
            var result = lifespanCoefficient * (revenue * (remainingItemCount * (remainingItemCount + 1) / 2f));
            return (float)result;
        }
        
    }
}