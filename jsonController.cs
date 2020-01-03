using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonController : MonoBehaviour
{
    public string jsonURL;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData());
    }

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
      //  Debug.Log(jsnData.d); 
       // Debug.Log(jsnData.size); 
    }
}
