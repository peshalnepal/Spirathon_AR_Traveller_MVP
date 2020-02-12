using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARController : MonoBehaviour
{
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();
    public GameObject GridPrefab;
    public GameObject Portal;
    public GameObject door;
    public GameObject place;
    public GameObject room;
    public GameObject ARCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // return;
        //check ARCore Session status

        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        for (int i= 0;i< m_NewTrackedPlanes.Count;++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);
            //this will set the position of grid and modify vertices
            grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);
        }
        Touch touch;
        if(Input.touchCount <1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        //if touched 
        TrackableHit hit;
        if(Frame.Raycast(touch.position.x, touch.position.y,TrackableHitFlags.PlaneWithinPolygon,out hit))
        {
            //let's place the portal on the top of portal
            //enable portal
            Portal.SetActive(true);
            room.SetActive(false);
            place.SetActive(true);
            door.SetActive(true);
            //creat new anchor
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
            //set position

            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;
            //we want portal to face camera
            Vector3 cameraPosition = ARCamera.transform.position;

            cameraPosition.y = hit.Pose.position.y;
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);

            Portal.transform.parent = anchor.transform;

        }
    }
}
