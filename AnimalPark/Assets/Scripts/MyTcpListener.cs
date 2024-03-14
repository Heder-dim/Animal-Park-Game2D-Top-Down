using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class MyTcpListener : MonoBehaviour
{
    TcpListener server = null;

    void Start()
    {
        // Inicia o servidor em uma nova thread
        Thread serverThread = new Thread(new ThreadStart(StartListening));
        serverThread.Start();
    }

    void StartListening()
    {
        try
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("192.168.1.157");
            server = new TcpListener(localAddr, port);
            server.Start();
            Debug.Log("Server started. Waiting for connections...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Debug.Log("Client connected!");

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.Start(client);
            }
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }
        finally
        {
            server.Stop();
        }
    }

    void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;

        try
        {
            Byte[] bytes = new Byte[256];
            String data = null;

            NetworkStream stream = client.GetStream();

            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                Debug.Log("Received: " + data);

                // Aqui você pode realizar qualquer ação necessária com a mensagem recebida do cliente

                byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);

                stream.Write(msg, 0, msg.Length);
                Debug.Log("Sent: " + data);
            }
        }
        catch (IOException e)
        {
            Debug.Log("IOException: " + e);
        }
        finally
        {
            client.Close();
        }
    }


    void OnApplicationQuit()
    {
        if (server != null)
            server.Stop();
    }
}
