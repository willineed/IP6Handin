using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPReceiverNiels : MonoBehaviour
{
    public int port = 5005; // Port number to match the Python sender

    private UdpClient udpClient;
    private IPEndPoint remoteEndPoint;

    // This function runs once, at the start of the program
    void Start()
    {
        // Initialize the UdpClient to listen on the specified port
        udpClient = new UdpClient(port);
        remoteEndPoint = new IPEndPoint(IPAddress.Any, port);

        // Start listening for incoming UDP data
        Debug.Log("Listening for UDP data on port " + port);
    }

    // This function is called once per frame
    void Update()
    {
        // Check if there's any data available
        if (udpClient.Available > 0)
        {
            // Receive UDP data from the sender
            byte[] data = udpClient.Receive(ref remoteEndPoint);

            // Convert byte data to string and then to float
            string receivedString = Encoding.UTF8.GetString(data);
            if (float.TryParse(receivedString, out float sineValue))
            {
                Debug.Log("Received Sine Value: " + sineValue);
            }
            else
            {
                Debug.LogWarning("Failed to parse received data.");
            }
        }
    }

    // This function runs when the Unity application quits
    void OnApplicationQuit()
    {
        // Close the UDP client when the application quits
        if (udpClient != null)
        {
            udpClient.Close();
        }
    }
}
