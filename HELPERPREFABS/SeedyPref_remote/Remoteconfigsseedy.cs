using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using  UnityEngine.UI;
using  Facebook.Unity;
public class Remoteconfigsseedy : MonoBehaviour
{

    public static Remoteconfigsseedy _instance;

    private const string diggerspeedval = "DSPEEDPRICE";             //KAZMA SURESI
    private const string diggerpowerval = "DPOWERPRICE";             //KAZMA GUCU
    private const string seederSpeedval = "SSPEEDPRICE";             //DIKMEHIZI
    private const string seederValueval= "SVALUEPRICE";              //DIKMESIKLIGI
    private const string waterCapval= "WCAPPRICE";                    //SUKAPASITESI
    private const string waterSizeval= "WSIZEPRICE";                  //SUKALINLIGI
    private const string marketmultiplierval= "MMTRPRICE";            //MARKETCARPANI
    private const string marketCapval= "MCAPPRICE";                  //MARKETKAPASITESI    
    private const string pickingSpeedval= "PSPEEDPRICE";            //TOPLAMAHIZIUPGRADE   
    
    private  const string experience = "EXPERIENCE";
    private  const string diggerLimit = "DIGGERLIMIT";                //KAZMASURESIUZUN GELIRSE 1 YAP YADA 2 YAP KAZMA ALANI KISALSIN!
    
    //DAILYBONUS
    private  const string dailyBonus="DAILYBONUS";
    private  const string dailybonusday ="DAILYBNSDAY";
    private  const string adsfrequency = "ADSFREQUENCY";

    //EXIT
    public  enum exit_counter { digging, seeeding,watering ,picking,hotorder,coldorder};
    public static exit_counter exit_counters;
    
    #region Cameraposition
        
        private  const string camerapos="CAMERAPOS";
    
        private const string CAM1POSX = "CAM1POSX"; 
        private const string CAM1POSY = "CAM1POSY"; 
        private const string CAM1POSZ = "CAM1POSZ";
        
        private const string CAM1ROTX = "CAM1ROTX"; 
        private const string CAM1ROTY = "CAM1ROTY"; 
        private const string CAM1ROTZ = "CAM1ROTZ";
        
        private const string CAM2POSX = "CAM2POSX"; 
        private const string CAM2POSY = "CAM2POSY"; 
        private const string CAM2POSZ = "CAM2POSZ"; 
        
        private const string CAM2ROTX = "CAM2ROTX"; 
        private const string CAM2ROTY = "CAM2ROTY"; 
        private const string CAM2ROTZ = "CAM2ROTZ"; 
        
        private const string CAM3POSX = "CAM3POSX";
        private const string CAM3POSY = "CAM3POSY"; 
        private const string CAM3POSZ = "CAM3POSZ"; 
        
        private const string CAM3ROTX = "CAM3ROTX";
        private const string CAM3ROTY = "CAM3ROTY"; 
        private const string CAM3ROTZ = "CAM3ROTZ"; 
        
        private const string CAM4POSX = "CAM4POSX";
        private const string CAM4POSY = "CAM4POSY"; 
        private const string CAM4POSZ = "CAM4POSZ"; 
        
        private const string CAM4ROTX = "CAM4ROTX";
        private const string CAM4ROTY = "CAM4ROTY"; 
        private const string CAM4ROTZ = "CAM4ROTZ"; 

    #endregion
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        facebookSendMessage();
        
        StartCoroutine(getData());
        GameAnalytics.Initialize();
        
        SetDailyBonusDay();
        Invoke("Checker",1);
    }

    public void Checker()
    {
        CheckUpgradeVal();
    }
    public void  CheckUpgradeVal()
    {
        
    }
    
    public Text text1, text2, text3, text4, text5, text6, text7, text8,text9,text10,text11;
    void check_test()
    {
        text1.text=GetDailyBonus().ToString();
        text2.text=GetDailyBonusDay().ToString();
        
    }
          //YAPILACAKLAR VE YAPILANLAR
    //ALINACAK VERİLER------------------------------------------------------
          //ilk başta  daily bonus prefi++++
          //su miktarı update fiyatları++
          //kazma hızı gücü fiyatı++
          //TOPLAMA UGRAGE HIZLANDIRMA++
          //kazmahızı,kazma gücü,dikmehızı,dikmesıklıgı,sukapasitesi,sukalınlıgı,carpan,vitrinkapasitesi seviyeli olacak++
          //experience sınırını değiştirme++
          //4 adet kamera acısı * 3 * 3++
          //kazmayı % kacla bitirdi++
          
    //GONDERILECEK VERİLER------------------------------------------------------     
        //ortalama session süresi ++
        //ortalama kazma süresi++
        //ortalama sulama suresi++
        //kazma sayısı input degeri
        
        //Kazarken mi cıktı++
        //Sularken mi cıktı++
        //Tohum atarken mi cıktı++
        //toplarken mi cıktı++
        //soguk,sıcak sipariş geldiğinde mi cıktı++
        
        //level sonu toplam gelir ++
        
        //loop sayısı ++
        
        //sıcak siparişi kabul etti
        //sıcak siparişi reddetti
        //soğuk siparişi rewarded izledi
        
        
    //GONDERILECEK ALINACAK VERİLER------------------------------------------------------        
        
        //Eğer kazma süreleri uzun gelirse
                //-->kazma yerinin uzunlugu
                    //-->tohum atma  yerleri ve tohumlar etkilenecek
                    //-->su miktarı değişecek
                    //-->ürün kasası etkilenecek
                    
        private const string alldiggertime = "ALLDIGGERTIME";     //KAZMA SURESI
        private const string leveldiggertime = "LOOPDIGGERTIME";  //LOOPTA KAZMA SURESI
        private const string marketCap= "MARKETCAP";              //MARKETKAPASITESI    
        
        #region CAMERA!
        public static (float,float,float,float,float,float) GetCamera1()
        {
            return  (PlayerPrefs.GetFloat(CAM1POSX),
                     PlayerPrefs.GetFloat(CAM1POSY),
                     PlayerPrefs.GetFloat(CAM1POSZ),
                     PlayerPrefs.GetFloat(CAM1ROTX),
                     PlayerPrefs.GetFloat(CAM1ROTY),
                     PlayerPrefs.GetFloat(CAM1ROTZ));
        }
        
        public static (float,float,float,float,float,float) GetCamera2()
        {
            return  (PlayerPrefs.GetFloat(CAM2POSX),
                PlayerPrefs.GetFloat(CAM2POSY),
                PlayerPrefs.GetFloat(CAM2POSZ),
                PlayerPrefs.GetFloat(CAM2ROTX),
                PlayerPrefs.GetFloat(CAM2ROTY),
                PlayerPrefs.GetFloat(CAM2ROTZ));
        }
        
        public static (float,float,float,float,float,float) GetCamera3()
        {
            return  (PlayerPrefs.GetFloat(CAM3POSX),
                PlayerPrefs.GetFloat(CAM3POSY),
                PlayerPrefs.GetFloat(CAM3POSZ),
                PlayerPrefs.GetFloat(CAM3ROTX),
                PlayerPrefs.GetFloat(CAM3ROTY),
                PlayerPrefs.GetFloat(CAM3ROTZ));
        }
        
        public static (float,float,float,float,float,float) GetCamera4()
        {
            return  (PlayerPrefs.GetFloat(CAM4POSX),
                PlayerPrefs.GetFloat(CAM4POSY),
                PlayerPrefs.GetFloat(CAM4POSZ),
                PlayerPrefs.GetFloat(CAM4ROTX),
                PlayerPrefs.GetFloat(CAM4ROTY),
                PlayerPrefs.GetFloat(CAM4ROTZ));
        }
        #endregion
        #region diggerlimit
        public static void SetDiggerLimit(int diggerlimitx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.diggerLimit, diggerlimitx);
        }

        public static int GetDiggerLimit()
        {
            return PlayerPrefs.GetInt(diggerLimit);
        }
        #endregion
        
        #region experiencebar
        public static void SetExperienceLimit(int experience)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.experience, experience);
        }

        public static int GetExperienceLimit()
        {
            return PlayerPrefs.GetInt(experience);
        }
        #endregion
        
        #region diggerspeedval
        public static void SetDiggerSpeedval(int diggerspeedvalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.diggerspeedval, diggerspeedvalx);
        }

        public static int GetDiggerSpeedval()
        {
            return PlayerPrefs.GetInt(diggerspeedval);
        }
        #endregion
        
        #region diggerpowerval
        public static void SetDiggerPowerval(int diggerpowervalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.diggerpowerval, diggerpowervalx);
        }

        public static int GetDiggerPowerval()
        {
            return PlayerPrefs.GetInt(diggerpowerval);
        }
        #endregion
        
        #region seederSpeedval
        public static void SetSeederSpeedval(int seederSpeedvalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.seederSpeedval, seederSpeedvalx);
        }

        public static int GetSeederSpeedval()
        {
            return PlayerPrefs.GetInt(seederSpeedval);
        }
        #endregion
        
        #region seederValueval
        public static void SetSeederValueval(int seederValuevalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.seederValueval, seederValuevalx);
        }

        public static int GetSeederValueval()
        {
            return PlayerPrefs.GetInt(seederValueval);
        }
        #endregion
        
        #region waterCapvalval
        public static void SetwaterCapval(int waterCapvalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.waterCapval, waterCapvalx);
        }

        public static int GetwaterCapval()
        {
            return PlayerPrefs.GetInt(waterCapval);
        }
        #endregion
        
        #region waterSizevalval
        public static void SetwaterSizeval(int waterSizevalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.waterSizeval, waterSizevalx);
        }

        public static int GetwaterSizeval()
        {
            return PlayerPrefs.GetInt(waterSizeval);
        }
        #endregion
        
        #region marketmultiplierval
        public static void Setmarketmultiplierval(int marketmultipliervalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.marketmultiplierval, marketmultipliervalx);
        }

        public static int Getmarketmultiplierval()
        {
            return PlayerPrefs.GetInt(marketmultiplierval);
        }
        #endregion
        
        #region marketCapval
        public static void SetmarketCapval(int marketCapvalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.marketCapval, marketCapvalx);
        }

        public static int GetmarketCapval()
        {
            return PlayerPrefs.GetInt(marketCapval);
        }
        #endregion
        
        #region pickingSpeedval
        public static void SetpickingSpeedval(int pickingSpeedvalx)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.pickingSpeedval, pickingSpeedvalx);
        }

        public static int GetpickingSpeedval()
        {
            return PlayerPrefs.GetInt(pickingSpeedval);
        }
        #endregion
        
        #region dailybonuscheck
        
        public static void SetDailyBonus(int dailybonus)
        {
            PlayerPrefs.SetInt(dailyBonus, dailybonus);
        }

        public static int GetDailyBonus()
        {
            return PlayerPrefs.GetInt(dailyBonus);
        }
        
        public static void SetDailyBonusDay()
        {
            PlayerPrefs.SetInt(dailybonusday, SimpleTimer._instance.getElapsedTimeDays());
        }

        public static int GetDailyBonusDay()
        {
            return PlayerPrefs.GetInt(dailybonusday);
        }
        #endregion
        
        #region adsfrequency
        
        public static void SetDADFrequency(int adsfrequency)
        {
            PlayerPrefs.SetInt(Remoteconfigsseedy.adsfrequency, adsfrequency);
        }

        public static int GetADFrequency()
        {
          return   PlayerPrefs.GetInt(Remoteconfigsseedy.adsfrequency);
        }

        #endregion
        
        

        #region Remote Config JSON
        //---------------------Remote Config JSON-------------------------//
        public string jsonURL;
      
        IEnumerator getData()
        {
            Debug.Log("Processing Data");
        
            WWW _www = new WWW(jsonURL);
            yield return _www;
            if (_www.error == null)
            {
                processJSOnData(_www.text);
            }
            else
            {
                Debug.Log("wrong way");
            }

        }

        public static float floatTRYPARSE(string stringx)
        {
            float val;
            float.TryParse(stringx, out val);
            return val;
        }
        
        public static int intTRYPARSE(string stringx)
        {
            int val;
            int.TryParse(stringx, out val);
            return val;
        }

        // Update is called once per frame
        private void processJSOnData(string _url)
        {
            jsonDataClass jsnData = JsonUtility.FromJson<jsonDataClass>(_url);
          
             
            SetDiggerSpeedval(intTRYPARSE(jsnData.DSPEEDPRICE));
            SetDiggerPowerval(intTRYPARSE(jsnData.DPOWERPRICE));
            SetSeederSpeedval(intTRYPARSE(jsnData.SSPEEDPRICE));
            SetSeederValueval(intTRYPARSE(jsnData.SVALUEPRICE));
            SetwaterCapval(intTRYPARSE(jsnData.WCAPPRICE));
            SetwaterSizeval(intTRYPARSE(jsnData.WSIZEPRICE));
            Setmarketmultiplierval(intTRYPARSE(jsnData.MMTRPRICE));
            SetmarketCapval(intTRYPARSE(jsnData.MCAPPRICE));
            SetpickingSpeedval(intTRYPARSE(jsnData.PSPEEDPRICE));

            SetExperienceLimit(intTRYPARSE(jsnData.EXPERIENCE));
            
            SetDailyBonus(intTRYPARSE(jsnData.DAILYBONUS));
            SetDADFrequency(intTRYPARSE(jsnData.ADSFREQUENCY));
            
            SetDiggerLimit(intTRYPARSE(jsnData.DIGGERLIMIT));
            
            
            
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1POSX,floatTRYPARSE(jsnData.CAM1POSX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1POSY,floatTRYPARSE(jsnData.CAM1POSY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1POSZ,floatTRYPARSE(jsnData.CAM1POSZ));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1ROTX,floatTRYPARSE(jsnData.CAM1ROTX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1ROTY,floatTRYPARSE(jsnData.CAM1ROTY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM1ROTZ,floatTRYPARSE(jsnData.CAM1ROTZ));
            
            
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2POSX,floatTRYPARSE(jsnData.CAM2POSX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2POSY,floatTRYPARSE(jsnData.CAM2POSY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2POSZ,floatTRYPARSE(jsnData.CAM2POSZ));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2ROTX,floatTRYPARSE(jsnData.CAM2ROTX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2ROTY,floatTRYPARSE(jsnData.CAM2ROTY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM2ROTZ,floatTRYPARSE(jsnData.CAM2ROTZ));
            
            
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3POSX,floatTRYPARSE(jsnData.CAM3POSX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3POSY,floatTRYPARSE(jsnData.CAM3POSY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3POSZ,floatTRYPARSE(jsnData.CAM3POSZ));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3ROTX,floatTRYPARSE(jsnData.CAM3ROTX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3ROTY,floatTRYPARSE(jsnData.CAM3ROTY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM3ROTZ,floatTRYPARSE(jsnData.CAM3ROTZ));
            
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4POSX,floatTRYPARSE(jsnData.CAM4POSX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4POSY,floatTRYPARSE(jsnData.CAM4POSY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4POSZ,floatTRYPARSE(jsnData.CAM4POSZ));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4ROTX,floatTRYPARSE(jsnData.CAM4ROTX));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4ROTY,floatTRYPARSE(jsnData.CAM4ROTY));
            PlayerPrefs.SetFloat(Remoteconfigsseedy.CAM4ROTZ,floatTRYPARSE(jsnData.CAM4ROTZ));

            
            
            PrefManagerSeedy.SetFruitPrice(0,floatTRYPARSE(jsnData.tomato));
            PrefManagerSeedy.SetFruitPrice(1,floatTRYPARSE(jsnData.strawberry));
            PrefManagerSeedy.SetFruitPrice(2,floatTRYPARSE(jsnData.pepper));
            PrefManagerSeedy.SetFruitPrice(3,floatTRYPARSE(jsnData.eggplant));
            PrefManagerSeedy.SetFruitPrice(4,floatTRYPARSE(jsnData.dragonfruit));
            PrefManagerSeedy.SetFruitPrice(5,floatTRYPARSE(jsnData.cucumber));
            PrefManagerSeedy.SetFruitPrice(6,floatTRYPARSE(jsnData.corn));
            PrefManagerSeedy.SetFruitPrice(7,floatTRYPARSE(jsnData.blackberry));

            
            PrefManagerSeedy.SetFruitLifeSpan(0,floatTRYPARSE(jsnData.tomatolife));
            PrefManagerSeedy.SetFruitLifeSpan(1,floatTRYPARSE(jsnData.strawberrylife));
            PrefManagerSeedy.SetFruitLifeSpan(2,floatTRYPARSE(jsnData.pepperlife));
            PrefManagerSeedy.SetFruitLifeSpan(3,floatTRYPARSE(jsnData.eggplantlife));
            PrefManagerSeedy.SetFruitLifeSpan(4,floatTRYPARSE(jsnData.dragonfruitlife));
            PrefManagerSeedy.SetFruitLifeSpan(5,floatTRYPARSE(jsnData.cucumberlife));
            PrefManagerSeedy.SetFruitLifeSpan(6,floatTRYPARSE(jsnData.cornlife));
            PrefManagerSeedy.SetFruitLifeSpan(7,floatTRYPARSE(jsnData.blackberrylife));
            
            
            
            PrefManagerSeedy.SetofflineCoefficient(floatTRYPARSE(jsnData.offlineCoefficient));
            PrefManagerSeedy.SetonlineCoefficient( floatTRYPARSE(jsnData.onlineCoefficient));
            
          /*  text1.text = GetDailyBonus().ToString();
            text2.text = GetCamera2().ToString();
            text3.text = GetADFrequency().ToString();
            text4.text = GetSeederValueval().ToString();
            text5.text = GetwaterCapval().ToString();
            text6.text = GetwaterSizeval().ToString();
            text7.text = Getmarketmultiplierval().ToString();
            text8.text = GetmarketCapval().ToString();
            text9.text = GetpickingSpeedval().ToString();
         */
            
        }

        #endregion
        //---------------------Facebook Sending Message-------------------------//
        public void facebookSendMessage()
        {
            if (!FB.IsInitialized)
            {
                FB.Init(() =>
                    {
                        if (FB.IsInitialized)
                        {
                            FB.ActivateApp();
                            FB.GetAppLink(DeepLinkCallback);

                            setAverageLoopingTime(5);
                            setAverageLoopingTime(6);
                            setAverageLoopingTime(7);
                            
                            setAverageDiggingTime(7);
                            setAverageDiggingTime(8);
                            setAverageDiggingTime(9);
                            
                            
                            setAverageWateringTime(9);
                            setAverageWateringTime(10);
                            setAverageWateringTime(11);

                            setRevenueforLoop(1000, 60);
                            setRevenueforLoop(2000, 40);
                            
                            setExit(1);
                            setExit(3);

                            setLoopCount(2);
                            setLoopCount(4);

                            setAverageDiggerPercentage(1);
                        }
                        else
                            Debug.LogError("Couldn't Initialized Facebook!");
                    });
            }
            else {
                FB.ActivateApp();
            }
            
        }
        void DeepLinkCallback(IAppLinkResult result)
        {
            if (!String.IsNullOrEmpty(result.Url))
            {
                var index = (new Uri(result.Url)).Query.IndexOf("request_ids");
                if (index != -1)
                {
                    // ...have the user interact with the friend who sent the request,
                    // perhaps by showing them the gift they were given, taking them
                    // to their turn in the game with that friend, etc.
                }
            }
        }

        public static void setAverageDiggerPercentage(float averageDiggerPercentage)
        {
            FB.LogAppEvent(
                "averageDiggerPercentage",
                averageDiggerPercentage,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, "x"}
                });
        }
        
        public static void setLoopCount(int loop)
        {
            FB.LogAppEvent(
                "setLoopCount",
                1,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, loop.ToString()}
                });
        }
        
        public static void setAverageLoopingTime(float averageLoopingTime)
        {
            FB.LogAppEvent(
                "averageLoopingTime",
                averageLoopingTime,
            new Dictionary<string, object>()
            {
                { AppEventParameterName.Level, "10x"}
            });
        }
        
        public static void setAverageDiggingTime(float averageDigingTime)
        {
            FB.LogAppEvent(
                "averageDigingTime",
                averageDigingTime,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, "10x"}
                });
        }
        
        public static void setAverageWateringTime(float averageWateringTime)
        {
            FB.LogAppEvent(
                "averageWateringTime",
                averageWateringTime,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, "10x"}
                });
        }
        
        public static void setRevenueforLoop(float RevenueforLoop,int loop)
        {
            FB.LogAppEvent(
                "RevenueforLoop",
                RevenueforLoop,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, loop.ToString()}
                });
        }
        
        public static void setExit(int where)
        {
            FB.LogAppEvent(
                "exitvalue",
                1,
                new Dictionary<string, object>()
                {
                    { AppEventParameterName.Level, where.ToString()}
                    
                });
        }
        
}



