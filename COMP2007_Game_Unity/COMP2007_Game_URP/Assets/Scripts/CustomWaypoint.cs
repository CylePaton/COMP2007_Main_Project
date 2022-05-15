using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomWaypoint : MonoBehaviour
{
    //Game objects
    public Image img;
    public Transform target;
    public TextMeshProUGUI meter;
    public Vector3 offset;
    public Camera cam;
    public CustomWaypoint waypoint;

    //Variables
    public bool vanishOnArrive = false;
    public bool hideMarker = false;
    public bool markerVisited = false;
    public float vanishDistance = 5f;


    // Update is called once per frame
    void Update()
    {
        //Setting the min and max amount the waypoint can go on each side of the screen
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        //Getting the targets position on the screen
        Vector2 pos = cam.WorldToScreenPoint(target.position + offset);

        //if the target is behind the cam, stick the waypoint to the left or right of the screen
        if(Vector3.Dot((target.position - cam.transform.position), cam.transform.forward) < 0)
        {
            //Target is behind player
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        //Calmping the screen position
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        //Setting the waypoint image to the position
        img.transform.position = pos;
        //Setting the waypoint text to the distance between the target and camera
        meter.text = ((int)Vector3.Distance(target.position, cam.transform.position)).ToString() + "m";

        ArrivedAtWaypoint();
        showMarker();

    }

    void ArrivedAtWaypoint()
    {
        if (vanishOnArrive)
        {
            if(Vector3.Distance(target.position, cam.transform.position) < vanishDistance)
            {
                img.gameObject.SetActive(false);
                markerVisited = true;
            }
        }
    }

    void showMarker()
    {
        if (hideMarker)
        {
            if (waypoint.markerVisited && markerVisited == false)
            {
                img.gameObject.SetActive(true);
            }
        }
    }
}
