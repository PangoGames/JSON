using System.Collections;
using System.Collections.Generic;
using Economy;
using UnityEngine;
using  UnityEngine.UI;
public class UICODES : MonoBehaviour
{
    public Text offlineEarning, revenueforsecond,coin;
    // Start is called before the first frame update

    public void printOfflineEarning()
    {
        offlineEarning.text = UIHelper.printOfflineEarning();
    }
    
    public void printRevenueForSecond()
    {
        revenueforsecond.text = UIHelper.printRevenueForSecond()+"/sec";
    }
    public void printALLCOINCount()
    {
        coin.text = UIHelper.printALLCOINCount();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            printOfflineEarning();
            printRevenueForSecond();
            printALLCOINCount();

        }
    }
}
