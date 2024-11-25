using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// made with the help of github copilot
public class HeadTracking : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject cameraObject;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();
    bool start = false;
    float xStart;
    float yStart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        print(points[0]);

        float x = (float.Parse(points[0])) / 2;
        float y = (float.Parse(points[1])) / 25;
        if (!start)
        {
            xStart = x;
            yStart = y;
            start = true;
        }

        Debug.Log("X: " + x + " Y: " + y);
        // Create a new rotation based on the x and y values
        Quaternion newRotation = Quaternion.Euler(y - yStart, xStart - x, 0);

        // Apply the new rotation to the cameraObject
        cameraObject.transform.rotation = newRotation;
        


    }
}