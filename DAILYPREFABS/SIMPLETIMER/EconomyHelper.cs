using System;

namespace Economy
{
    public class EconomyHelper
    {

        public static int GetRemainingItemCount(int lastCount, float duration, float lifespan,float OfflineCoefficient)
        {   
            return (int)Math.Max(lastCount - (duration / (Math.Pow(lifespan, OfflineCoefficient))), 0);
        }
        
        public static float GetOfflineEarning(float lifespan, float revenue, int lastCount, float duration,float OfflineCoefficient)
        {
            var itemLeft = GetRemainingItemCount(lastCount, duration, lifespan, OfflineCoefficient);
            return (float) (Math.Pow(lifespan, OfflineCoefficient) * revenue * itemLeft * (itemLeft + 1) * 0.5f);
        }

        public static float GetOfflineEarning(float lifespan, float revenue, int remainingItemCount,float OfflineCoefficient)
        {
            return (float) (Math.Pow(lifespan, OfflineCoefficient) * revenue * remainingItemCount * (remainingItemCount + 1) * 0.5f);
        }
    }
}