using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManagerSeedy
{
        private const string experience = "EXPERIENCE";  //ADA GECMEK ICIN EXPERIENCE BARI
        private const string currentLoop= "CURRENTLOOP"; // SU ANKI DONGU DEGERI
        private  const string island= "ISLAND";          // SU ANKI ADA DEGERI
        private const string firstOpen = "FIRSTOPEN";    //OYUN ILK KEZ MI ACILDI
        private  const string coin= "COIN";              //TOPLAM PARAMIZ
        private const string fruit = "FRUIT";            //FRUIT
        private const string fruitCount = "FRUITCOUNT";  //FRUITCOUNT
        private const string fruitCountName = "FRUITCOUNTNAME";  //FRUITCOUNT
        private const string fruitPrice= "FRUITPRICE";  //FRUITCOUNT
        
        //UPGRADES    kazmahızı,kazma gücü,dikmehızı,dikmesıklıgı,sukapasitesi,sukalınlıgı,carpan,vitrinkapasitesi
        private const string diggerSpeed = "DIGGERSPEED";             //KAZMAHIZI
        private const string diggerPower = "DIGGERPOWER";             //KAZAMAGUCU
        private const string seederSpeed = "SEEDERSPEED";             //DIKMEHIZI
        private const string seederValue= "SEEDERVALUE";              //DIKMESIKLIGI
        private const string waterCap= "WATERCAP";                    //SUKAPASITESI
        private const string waterSize= "WATERSIZE";                  //SUKALINLIGI
        private const string marketmultiplier= "MARKETMULTIPlIER";    //MARKETCARPANI
        private const string marketCap= "MARKETCAP";                  //MARKETKAPASITESI    
        
        private const string pickingSpeed= "PICKINGSPEED";                  //SEPETE TOPLAMA HIZI    
        
        
        //EARNINGS
        private const string offlineEarning = "OFFLINEEARNING";       //offline durumdayken kazanılan para
        private const string instantEarning = "INSTANTEARNING";       //sürede ne kadar getirdiği  ürünlerin 
        
       
  
        
        public  enum fruit_counter { tomato, pepper, eggplant , strawberry , dragonfruit , cucumber , corn , blackberry };
        public static string[] fruitsx = {"tomato", "pepper", "eggplant", "strawberry", "dragonfruit", "cucumber","corn", "blackberry" };

        public static fruit_counter fruit_counters;
        
        #region fruit_count
        
        public static void SetfruitCount(fruit_counter _fruit_counters,int fruitCountval)
        {
            PlayerPrefs.SetInt(fruitCount+_fruit_counters, fruitCountval);
            
            PlayerPrefs.SetString(fruitCountName+_fruit_counters,fruitsx[(int)(_fruit_counters)]);
        }
        public static void SetfruitCount(int _fruit_counters, int fruitCountval)
        {
        PlayerPrefs.SetInt(fruitCount + _fruit_counters, fruitCountval);

         PlayerPrefs.SetString(fruitCountName + _fruit_counters, fruitsx[(_fruit_counters)]);
         }

    public static int GetfruitCount(fruit_counter fruitval)
        {
            return PlayerPrefs.GetInt(fruitCount+fruitval);
        }
    public static int GetfruitCount(int fruitval)
    {
        return PlayerPrefs.GetInt(fruitCount + fruitval);
    }

    public static string GetfruitCountName(fruit_counter fruit_countersx)
        {
            return PlayerPrefs.GetString(fruitCountName+fruit_countersx);
        }
        
        #endregion
        
        #region experience

        public static void SetExperience(int experienceval)
        {
            PlayerPrefs.SetInt(experience,experienceval);
        }

        public static int GetExperience()
        {
            return PlayerPrefs.GetInt(experience);
        }

        #endregion
        
        #region firstopened
        // if first opened
        public static void SetFirstopen(bool value)
        {
            if (value)
            {
                PlayerPrefs.SetInt(firstOpen, 1);
            }
            else
            {
                PlayerPrefs.SetInt(firstOpen, 0);
            }
        }
        public static bool GetFirstopen()
        {
            if (PlayerPrefs.GetInt(firstOpen) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Looping

            public static void SetCurrentLoop(int loopvalue)
            {
                PlayerPrefs.SetInt(currentLoop,loopvalue);
            }

            public static int GetCurrentLoop()
            {
                return PlayerPrefs.GetInt(currentLoop);
            }

        #endregion

        #region island

            public static void SetCurrentIsland(int islandvalue)
            {
                PlayerPrefs.SetInt(island,islandvalue);
            }

            public static int GetCurrentIsland()
            {
                return PlayerPrefs.GetInt(island);
            }
        #endregion
        
        #region coin
        
            public static void SetCoin(int gainedCoin)
            {
                PlayerPrefs.SetInt(coin, gainedCoin);
            }

            public static int GetCoin()
            {
                return PlayerPrefs.GetInt(coin);
            }
        #endregion
        
        #region fruit
        
            public static void SetFruit(fruit_counter fruit_counters,int open)
            {
                PlayerPrefs.SetInt(fruit+fruit_counters, open);
            }

            public static int GetFruit(fruit_counter fruit_counters)
            {
                return PlayerPrefs.GetInt(fruit+fruit_counters);
            }
        #endregion
        
        //FRUIT PRICE
        #region fruitprice
        
        public static void SetFruitPrice(fruit_counter fruit_counters,int value)
        {
            PlayerPrefs.SetInt(fruitPrice+fruit_counters, value);
        }

        public static int GetFruitPrice(fruit_counter fruit_counters)
        {
            return PlayerPrefs.GetInt(fruitPrice+fruit_counters);
        }
        #endregion
        //OFFLINE EARNING
        #region offlineEarning
        
        public static void SetofflineEarning(int offlineEarningval)
        {
            PlayerPrefs.SetInt(marketCap, offlineEarningval);
        }

        public static int GetofflineEarning()
        {
            return PlayerPrefs.GetInt(offlineEarning);
        }
        #endregion
        
        #region instantEarning
        
        public static void SetinstantEarning(int instantEarningval)
        {
            PlayerPrefs.SetInt(instantEarning, instantEarningval);
        }

        public static int GetinstantEarning()
        {
            return PlayerPrefs.GetInt(instantEarning);
        }
        #endregion
        
        // MARKET UPGRADES
        #region diggerSpeed
        
        public static void SetDiggerSpeed(int diggerSpeedval)
        {
            PlayerPrefs.SetInt(diggerSpeed, diggerSpeedval);
        }

        public static int GetDiggerSpeed()
        {
            return PlayerPrefs.GetInt(diggerSpeed);
        }
        #endregion
        
        #region diggerPower
        
        public static void SetdiggerPower(int diggerPowerval)
        {
            PlayerPrefs.SetInt(diggerPower, diggerPowerval);
        }

        public static int GetdiggerPower()
        {
            return PlayerPrefs.GetInt(diggerPower);
        }
        #endregion
        
        #region seederSpeed
        
        public static void SetseederSpeed(int seederSpeedval)
        {
            PlayerPrefs.SetInt(seederSpeed, seederSpeedval);
        }

        public static int GetseederSpeed()
        {
            return PlayerPrefs.GetInt(seederSpeed);
        }
        #endregion
        
        #region seederValue
        
        public static void SetseederValue(int seederValueval)
        {
            PlayerPrefs.SetInt(seederValue, seederValueval);
        }

        public static int GetseederValue()
        {
            return PlayerPrefs.GetInt(seederValue);
        }
        #endregion
        
        #region waterCap
        
        public static void SetwaterCap(int waterCapval)
        {
            PlayerPrefs.SetInt(waterCap, waterCapval);
        }

        public static int GetwaterCap()
        {
            return PlayerPrefs.GetInt(waterCap);
        }
        #endregion
        
        #region waterSize
        
        public static void SetwaterSize(int waterSizeval)
        {
            PlayerPrefs.SetInt(waterSize, waterSizeval);
        }

        public static int GetwaterSize()
        {
            return PlayerPrefs.GetInt(waterSize);
        }
        #endregion
    
        #region marketmultiplier
        
        public static void Setmarketmultiplier(int marketmultiplierval)
        {
            PlayerPrefs.SetInt(marketmultiplier, marketmultiplierval);
        }

        public static int Getmarketmultiplier()
        {
            return PlayerPrefs.GetInt(marketmultiplier);
        }
        #endregion
        
        #region marketCap
        
        public static void SetmarketCap(int marketCapval)
        {
            PlayerPrefs.SetInt(marketCap, marketCapval);
        }

        public static int GetmarketCap()
        {
            return PlayerPrefs.GetInt(marketCap);
        }
        #endregion
        
        #region pickingSpeed
        
        public static void SetpickingSpeed(int pickingSpeedval)
        {
            PlayerPrefs.SetInt(pickingSpeed, pickingSpeedval);
        }

        public static int GetpickingSpeed()
        {
            return PlayerPrefs.GetInt(pickingSpeed);
        }
        #endregion
        
     
     
}



