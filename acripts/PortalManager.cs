using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Sponza;
    private Material[] SponzaMaterials;
    // Start is called before the first frame update
    private Material PortalPlaneMaterial;
    public GameObject hotel;
    void Start()
    {
        SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        PortalPlaneMaterial = GetComponent<Renderer>().sharedMaterial;
    }
    private void OnTriggerStay(Collider other)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.transform.position);
       
        if ((MainCamera.transform.position.z-transform.position.z)<0f )
        {
            hotel.SetActive(false);
            Debug.Log(MainCamera.transform.position.z-transform.position.z);
            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_disappear", (int)CompareFunction.Equal);
            }

            PortalPlaneMaterial.SetInt("_CullMode",(int)CullMode.Front);
        }

        else if ((MainCamera.transform.position.z-transform.position.z)>=0f )
        {
            hotel.SetActive(true);
            for(int i=0;i < SponzaMaterials.Length;i++)
            {
                Debug.LogWarning(i);
                SponzaMaterials[i].SetInt("_disappear", (int)CompareFunction.NotEqual);
            }
            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Off);

        }
        else
        {
            hotel.SetActive(false);
            for (int i = 0; i < SponzaMaterials.Length;i++)
            {
                SponzaMaterials[i].SetInt("_disappear", (int)CompareFunction.NotEqual);
            }
            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Back);

        }


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
