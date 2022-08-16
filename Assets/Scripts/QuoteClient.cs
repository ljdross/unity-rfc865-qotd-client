using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class QuoteClient : MonoBehaviour
{
    public TextMeshProUGUI display;
    public string server;

    int port;
    TcpClient client;
    NetworkStream stream;
    byte[] receivedData;
    string quote;
    bool processing;
    bool stateChanged;
    Renderer colorRenderer;

    // Start is called before the first frame update
    void Start()
    {
        colorRenderer = GetComponent<Renderer>();

        if (string.IsNullOrEmpty(server))
        {
            server = "djxmmx.net";
        }
        port = 17;

        processing = true;
        stateChanged = true;
        GetNewQuote();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateChanged)
        {
            if (processing)
            {
                colorRenderer.material.color = Color.red;
            }
            else
            {
                colorRenderer.material.color = Color.green;
            }
            stateChanged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!processing)
        {
            processing = true;
            stateChanged = true;
            Debug.Log($"Quoting:\n{quote}");
            display.text = quote;
            GetNewQuote();
        }
    }

    private void GetNewQuote()
    {
        if (true)
        {
            receivedData = new byte[512];
            quote = string.Empty;
            client = new TcpClient();
            client.BeginConnect(server, port, ConnectCallback, null);
        }
    }

    private void ConnectCallback(IAsyncResult result)
    {
        client.EndConnect(result);
        stream = client.GetStream();
        stream.BeginRead(receivedData, 0, receivedData.Length, ReadCallback, null);
    }

    private void ReadCallback(IAsyncResult result)
    {
        stream = client.GetStream();
        Int32 bytes = stream.EndRead(result);
        quote = System.Text.Encoding.ASCII.GetString(receivedData, 0, bytes);
        Debug.Log($"Received quote:\n{quote}");
        stream.Close();
        client.Close();
        processing = false;
        stateChanged = true;
    }
}
