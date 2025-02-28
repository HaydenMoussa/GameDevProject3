using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject playerSprite;
    public float xBoundaryPercent; // Separate boundary for X-axis
    public float yBoundaryPercent; // Separate boundary for Y-axis
    public float easing;

    private float lBound;
    private float rBound;
    private float uBound;
    private float dBound;

    // Use this for initialization
    void Start()
    {
        lBound = xBoundaryPercent * Camera.main.pixelWidth;
        rBound = Camera.main.pixelWidth - lBound;
        dBound = yBoundaryPercent * Camera.main.pixelHeight;
        uBound = Camera.main.pixelHeight - dBound;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerSprite)
        {
            Vector3 spriteLoc = Camera.main.WorldToScreenPoint(playerSprite.transform.position);
            Vector3 pos = transform.position;

            if (spriteLoc.x < lBound)
            {
                pos.x -= lBound - spriteLoc.x;
            }
            else if (spriteLoc.x > rBound)
            {
                pos.x += spriteLoc.x - rBound;
            }

            if (spriteLoc.y < dBound)
            {
                pos.y -= dBound - spriteLoc.y;
            }
            else if (spriteLoc.y > uBound)
            {
                pos.y += spriteLoc.y - uBound;
            }

            pos = Vector3.Lerp(transform.position, pos, easing);
            transform.position = pos;
        }
    }
}
