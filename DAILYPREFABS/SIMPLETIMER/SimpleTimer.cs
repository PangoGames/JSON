using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;
using UnityEngine.Experimental.PlayerLoop;

public class SimpleTimer: MonoBehaviour
{
    public static SimpleTimer _instance;
    DateTime currentDate;
    DateTime oldDate;
    private DateTime oldDateDaily;
    private TimeSpan difference;
    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;
 
        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        long tempdaily = Convert.ToInt64(PlayerPrefs.GetString("sysStringDaily"));
 
        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);
        
        oldDateDaily = DateTime.FromBinary(tempdaily);
        DateTime tempcurrentDate = System.DateTime.Now;
         difference = tempcurrentDate.Subtract(oldDate);
    }
    //Gecen süreyi saniye cinsinden gonderiyor
    public float  getElapsedTimeSeconds()
    { 
        return (float)difference.TotalSeconds;
    }
    
    //Gecen süreyi gun cinsinden gonderiyor
    public int  getElapsedTimeDays()
    {
        TimeSpan difference = currentDate.Subtract(oldDateDaily);
        return (int)difference.TotalDays;
    }

    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

       if (getElapsedTimeDays() > 0)
        {
            PlayerPrefs.SetString("sysStringDaily", System.DateTime.Now.ToBinary().ToString());
           
            print("Saving this date to prefs: " + System.DateTime.Now);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(getElapsedTimeSeconds());
            Debug.Log("getElapsedTimeDays"+getElapsedTimeDays());
        }
    }
}