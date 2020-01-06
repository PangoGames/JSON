using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class offlineearnings : MonoBehaviour
{
    public Text earning_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            printOfflineEarning();
        }
    }

    void printOfflineEarning()
    {
        PrefManagerSeedy.SetfruitCount(1,20);
        
        float final_earning=0;
       
       for (int i = 0; i < 8; i++)
        {
            float offlineEarning =  Economy.EconomyHelper.GetOfflineEarning(
                                                                             PrefManagerSeedy.GetFruitLifeSpan(i),
                                                                             PrefManagerSeedy.GetFruitPrice(i),
                                                                                      PrefManagerSeedy.GetfruitCount(i),
                                                                             SimpleTimer._instance.getElapsedTimeSeconds(),
                                                                                      PrefManagerSeedy.GetofflineCoefficient());
            final_earning += (int)offlineEarning;

        }
            
        /*Debug.Log(PrefManagerSeedy.GetFruitLifeSpan(1));
        Debug.Log(PrefManagerSeedy.GetFruitPrice(1));
        Debug.Log(PrefManagerSeedy.GetfruitCount(1));
        Debug.Log(SimpleTimer._instance.getElapsedTimeSeconds());
        Debug.Log(PrefManagerSeedy.GetofflineCoefficient());*/
       
       earning_text.text = final_earning.ToString();
    }
}
