  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transform_camera;
    void Update()
    {
        transform.position=transform_camera.position;
    }
}
