using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public GameObject Ccanvas;
    public GameObject sphere;
    public GameObject Book_button;
    public GameObject hotel_info;
    public GameObject Info_tab;
    // Start is called before the first frame update
  
    public void hotel_room(int val)
    {
     if(val==0)
     {
     Book_button.SetActive(false);
      sphere.SetActive(false);
    Info_tab.SetActive(true);
    hotel_info.SetActive(false);
     }
     if(val==1)
     {
          Book_button.SetActive(true);
          hotel_info.SetActive(true);
          sphere.SetActive(true);
          Info_tab.SetActive(false);
     }
     if(val==2)
     {
          Book_button.SetActive(true);
      Info_tab.SetActive(false);
      
     }
    }
    public void pressed_For_Audio()
    {
        FindObjectOfType<Audio_surrounding>().Play("My_house");
    }
    public void pressed_For_Text()
    {
        Transform Text= Ccanvas.transform.Find("information_");
       bool active_= Text.gameObject.activeSelf;
       Text.gameObject.SetActive(!active_);
    }
    // Update is called once per frame
   public void go_back()
   {
     SceneManager.LoadScene(0);
   }
}
