using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

class UIHelper 
{
    
    public static string  printOfflineEarning()
    { 
        float final_earning=0;
        for (int i = 0; i < 8; i++)
        {
            float offlineEarning =  Economy.EconomyHelper.GetEarning(
                                                                    PrefManagerSeedy.GetFruitLifeSpan(i),
                                                                    PrefManagerSeedy.GetFruitPrice(i),
                                                                    PrefManagerSeedy.GetfruitCount(i),
                                                                    PrefManagerSeedy.GetofflineCoefficient(),
                                                                    SimpleTimer._instance.getElapsedTimeSeconds());
            final_earning += (int)offlineEarning;
        }

       

        return final_earning.ToString("0");
    }
    
    public static string printRevenueForSecond()
    {
        float final_revenue=0;
        for (int i = 0; i < 8; i++)
        {
            float onlineEarning =  Economy.EconomyHelper.GetEarning(
                                            PrefManagerSeedy.GetFruitLifeSpan(i),
                                            PrefManagerSeedy.GetFruitPrice(i),
                                            PrefManagerSeedy.GetfruitCount(i),
                                            PrefManagerSeedy.GetonlineCoefficient()/*,
                                            SimpleTimer._instance.getElapsedTimeSeconds()*/);
            final_revenue += onlineEarning;
        }
        return final_revenue.ToString("0.##");
    }
    
    public static  string printexperienceBar()
    {
        float final_experience=0;
        
        return printCOINCount(final_experience);
    }
    
    
    
    public  static string printCOINCount(float coincount)
    {   
       
        if (coincount<1000000 &&  coincount > 10000)
        {
            coincount = coincount / 1000f;
            return coincount.ToString("0.#")+"K";
        }
        else if (coincount > 1000000)
        {
            coincount = coincount / 100000;
            return coincount.ToString("0.##")+"M";
        }
        else
        {
            return coincount.ToString();
        }
    }
    
    public  static string printALLCOINCount()
    {  
        float coincount=0;
        coincount = PrefManagerSeedy.GetCoin();
        return printCOINCount(coincount);
    }
    
}
