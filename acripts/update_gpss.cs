using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_gpss : MonoBehaviour
{
    public Text coordinatess;
    public Text value_of_pie;
    public GameObject CCanvas;
    public GameObject info_tabb;
    public GameObject info_to_show_you_are_far;
    double lat=27.684045f;
    double lon=85.333365f;
    // Update is called once per frame
    void Update()
    {
       if(coordinatess!=null)
       {
             coordinatess.text="lat"+Gpss.Instance.lat.ToString()+"lon:"+Gpss.Instance.lon.ToString();
       }
       
        //will take radian only
        double value=distance_between(lat,lon);
        if(value_of_pie!=null)
        {
         value_of_pie.text="distance:"+value.ToString();
        }
        
        if(value<50)
        {
            if(CCanvas !=null)
            {
             CCanvas.SetActive(true);
             info_tabb.SetActive(true);
             info_to_show_you_are_far.SetActive(false);
            }
             
        }
        else
        {
            if(CCanvas!=null)
            {
              CCanvas.SetActive(false);
         info_tabb.SetActive(false);
         info_to_show_you_are_far.SetActive(true);
            }
        
        }
    }
    double converts_dtr(double degree)
    {
        return degree * Math.PI / 180;
    }
    double distance_between(double place_lat‍‍‍‍,double place_lon‍‍‍‍‍‍‍‍‍‍)
    {
        double earth_radius=6371000;
        double dlat=converts_dtr(place_lat-(double)Gpss.Instance.lat);
        double dlon=converts_dtr(place_lon-(double)Gpss.Instance.lon);
        double lat1=converts_dtr(Gpss.Instance.lat);
        double lat2=converts_dtr(place_lat);
        double a=Math.Sin(dlat/2) * Math.Sin(dlat/2) +Math.Sin(dlon/2) * Math.Sin(dlon/2) * Math.Cos(lat1) * Math.Cos(lat2); 
        double c=2*Math.Atan2(Math.Sqrt(a),Math.Sqrt(1-a));
         return c*earth_radius;
    }
}
