using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Server : MonoBehaviour
{
    private TcpListener tcpListener;
    private Thread tcpListenerThread;
    private TcpClient connectedTcpClient;

    public PlayerS player;

    void Start()
    {
        tcpListenerThread = new Thread(new ThreadStart(ListenForIncomingRequests));
        tcpListenerThread.IsBackground = true;
        tcpListenerThread.Start();
    }

    private void ListenForIncomingRequests()
    {
        try
        {
            tcpListener = new TcpListener(IPAddress.Parse("192.168.1.154"), 5555);
            tcpListener.Start();
            Debug.Log("Server is listening");

            while (true)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {
                    Debug.Log("Client connected");

                    NetworkStream stream = connectedTcpClient.GetStream();
                    byte[] buffer = new byte[1024];
                    int length;

                    try
                    {
                        while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            var incomingData = new byte[length];
                            Array.Copy(buffer, 0, incomingData, 0, length);
                            string clientMessage = Encoding.ASCII.GetString(incomingData);
                            Debug.Log("Client message received as: " + clientMessage);

                            player.SetDirection(clientMessage);
                        }
                    }
                    catch (IOException ioException)
                    {
                        Debug.LogError("IOException: " + ioException.Message);
                    }
                    catch (Exception exception)
                    {
                        Debug.LogError("Exception: " + exception.Message);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.LogError("SocketException: " + socketException.ToString());
        }
        catch (ThreadAbortException abortException)
        {
            Debug.LogError("ThreadAbortException: " + abortException.Message);
        }
        catch (Exception exception)
        {
            Debug.LogError("Exception: " + exception.Message);
        }
    }
}
