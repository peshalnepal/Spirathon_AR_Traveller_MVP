using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PanelShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
  public void ColorPanel ()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}

