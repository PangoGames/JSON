using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using  UnityEngine.UI;
public class Remoteconfigsseedy : MonoBehaviour
{

    public static Remoteconfigsseedy _instance;

    private const string diggerspeedval = "DSPEEDPRICE";             //KAZMA SURESI
    private const string diggerpowerval = "DPOWERPRICE";             //KAZMA GUCU
    private const string seederSpeedval = "SSPEEDPRICE";             //DIKMEHIZI
    private const string seederValueval= "SVALUEPRICE";              //DIKMESIKLIGI
    private const string waterCapval= "WCAPPRICE";                    //SUKAPASITESI
    private const string waterSizeval= "WSIZEPRICE";                  //SUKALINLIGI
    private const string marketmultiplierval= "MMTRPRICE";    //MARKETCARPANI
    private const string marketCapval= "MCAPPRICE";                  //MARKETKAPASITESI    
    private const string pickingSpeedval= "PSPEEDPRICE";            //TOPLAMAHIZIUPGRADE   

    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(getData());
        GameAnalytics.Initialize();
        Invoke("Checker",1);
    }

    public void Checker()
    {
        CheckUpgradeVal();
    }

  
    public void  CheckUpgradeVal()
    {
        
    }

    private Text text1, text2, text3, text4, text5, text6, text7, text8,text9,text10,text11;
    void check_test()
    {
        text1.text=PrefManagerSeedy.GetDailyBonus().ToString();
        text2.text=PrefManagerSeedy.GetDailyBonusday().ToString();
        
    }
    //ilk başta  daily bonus prefi
    
        //ortalama session süresi 
        //loop sayısı  
        //ürünlerden gelecek gelir 
        
        //kazma sayısı input degeri
        //ortalama sulama suresi
        
        //Eğer kazma süreleri uzun gelirse
                //-->kazma yerinin uzunlugu
                    //-->tohum atma  yerleri ve tohumlar etkilenecek
                    //-->su miktarı değişecek
                    //-->ürün kasası etkilenecek
                    
         //su miktarı update fiyatları
         //kazma hızı gücü fiyatı
         
         //hava şartları değikeni  
         //TOPLAMA UGRAGE HIZLANDIRMA
         // kazmahızı,kazma gücü,dikmehızı,dikmesıklıgı,sukapasitesi,sukalınlıgı,carpan,vitrinkapasitesi seviyeli olacak
        
         //cıkan objeleri satın aldı yada almadı
         //satın alınmıs objeler
         //sıcak siparişi kabul etti
         //sıcak siparişi reddetti
         //soğuk siparişi rewarded izledi
         //experience sınırını değiştirme
        
         //Kazarken mi cıktı
         //Sularken mi cıktı
         //Tohum atarken mi cıktı
         //toplarken mi cıktı
         
         
         //soguk,sıcak sipariş geldiğinde mi cıktı
         
         
         
        private const string alldiggertime = "ALLDIGGERTIME";  //KAZMA SURESI
        private const string leveldiggertime = "LOOPDIGGERTIME";  //LOOPTA KAZMA SURESI
        
        
        private const string marketCap= "MARKETCAP";                  //MARKETKAPASITESI    
        
     
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

        // Update is called once per frame
        private void processJSOnData(string _url)
        {
            jsonDataClass jsnData = JsonUtility.FromJson<jsonDataClass>(_url);
          
         /*
            text3.text = jsnData.DSPEEDPRICE;
            text4.text = jsnData.DPOWERPRICE;
            text5.text = jsnData.SSPEEDPRICE;
            text6.text = jsnData.SVALUEPRICE;
            text7.text = jsnData.WCAPPRICE;
            text8.text = jsnData.WSIZEPRICE;
            text9.text = jsnData.MMTRPRICE;
            text10.text = jsnData.MCAPPRICE;
            text11.text = jsnData.PSPEEDPRICE;
          */  
             int diggerspeedvalue;
             string value = jsnData.DSPEEDPRICE;
            int.TryParse(value, out diggerspeedvalue);
            SetDiggerSpeedval(diggerspeedvalue);
            
            int diggerpowervalue;
            string value2 = jsnData.DPOWERPRICE;
            int.TryParse(value2, out diggerpowervalue);
            SetDiggerPowerval(diggerpowervalue);
            
            int seederSpeedvalue;
            string value3 = jsnData.SSPEEDPRICE;
            int.TryParse(value3, out seederSpeedvalue);
            SetSeederSpeedval(seederSpeedvalue);
            
            int seederValuevalue;
            string value4 = jsnData.SVALUEPRICE;
            int.TryParse(value4, out seederValuevalue);
            SetSeederValueval(seederValuevalue);
            
            int waterCapvalue;
            string value5 = jsnData.WCAPPRICE;
            int.TryParse(value5, out waterCapvalue);
            SetwaterCapval(waterCapvalue);

            int waterSizevalue;
            string value6 = jsnData.WSIZEPRICE;
            int.TryParse(value6, out waterSizevalue);
            SetwaterSizeval(waterSizevalue);
            
            int marketmultipliervalue;
            string value7 = jsnData.MMTRPRICE;
            int.TryParse(value7, out marketmultipliervalue);
            Setmarketmultiplierval(marketmultipliervalue);
            
            int marketCapvalue;
            string value8 = jsnData.MCAPPRICE;
            int.TryParse(value8, out marketCapvalue);
            SetmarketCapval(marketCapvalue);
            
            int pickingSpeedvalue;
            string value9 = jsnData.PSPEEDPRICE;
            int.TryParse(value9, out pickingSpeedvalue);
            SetpickingSpeedval(pickingSpeedvalue);
            
            
        }
}



