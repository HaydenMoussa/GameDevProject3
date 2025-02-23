using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//original from AdamCYounis
public class ParallaxEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;

    //starting positiong for the parallax game object
    Vector2 startingPosition;

    //Start z value of the parallax game object
    float startingZ;
    
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position-startingPosition;

    float zDistanceFromTraget => transform.position.z - followTarget.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTraget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(zDistanceFromTraget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
