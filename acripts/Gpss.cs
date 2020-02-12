using System;
using System.Collections;

using UnityEngine;

public class Gpss : MonoBehaviour
{
    
    public static Gpss Instance {set;get;}
    public float lat;
    public float lon;
    bool isCoroutineReady = true;
    // Start is called before the first frame update
    void Start()
    {
           Instance=this;
        DontDestroyOnLoad(gameObject);
    }
   void Update()
    {
     if(isCoroutineReady==true)
     {
         isCoroutineReady=false;
         StartCoroutine(Starttofindgps());
     }
        
    }
    private IEnumerator Starttofindgps()
    {
        if (!Input.location.isEnabledByUser)
            yield break;
         Input.location.Start();
         int maxWait=20;
         while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
         {
              yield return new WaitForSeconds(1);
            maxWait--;
         }
         if(maxWait<1)
         {
             Debug.Log("error");
             yield break;
         }
         if(Input.location.status == LocationServiceStatus.Failed)
         {
             Debug.Log("error as unable to detect locaation");
             yield break;
         }
         lat=Input.location.lastData.latitude;
         lon=Input.location.lastData.longitude;
         isCoroutineReady=true;
         yield break;
    }
    // Update is called once per frame

}
