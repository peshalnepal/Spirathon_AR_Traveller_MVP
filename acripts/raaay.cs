using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raaay : MonoBehaviour
{
    public GameObject CCanvas;
    private bool enter = false;
    private bool enter_speaker = false;
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
       {
           var ray=Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hitinfo;
           if(Physics.Raycast(ray,out hitinfo))
           {
               var rig=hitinfo.collider.GetComponent<Rigidbody>();
               if(rig!=null)
               {
                  string name= hitinfo.collider.name;
                  if(name=="info_tab")
                  {
                      if (enter == false)
                      {
                            StartCoroutine(your_timer());
                      }
                  }
                   if(name=="sp")
                  {
                      if (enter_speaker== false)
                      {
                            StartCoroutine(sounnds());
                      }
                    
                    
                  }
                  if(name=="information_")
                  {
                      Debug.Log("hit");
                  }
               }
           }
       }
       Transform child_=CCanvas.transform.Find("information_");
       
    }
    private IEnumerator your_timer() {
        enter = true;
                   if(CCanvas!=null)
                   {
                       bool isActive = CCanvas.activeSelf;
                    if(isActive==false)
                    {
                        Transform info_text=CCanvas.transform.Find("information_");
                        info_text.gameObject.SetActive(false);
                    }
                        CCanvas.SetActive(!isActive);
                   }
             yield return new WaitForSeconds(0.2f);
        enter = false;
      }
    
    private IEnumerator sounnds() {
        enter_speaker = true;
       FindObjectOfType<Audio_surrounding>().Play("My_house");       
        enter_speaker = false;
         yield return new WaitForSeconds(0.2f);
      }
}
