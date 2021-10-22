using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using CarSharing_Database.Dao;
using CarSharing_Database.ModelData;

namespace CarSharing_Database.Mediator
{
    public class ClientHandler
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private IVehicleDao VehicleDao;

        public ClientHandler(TcpClient client)
        {
            _client = client;
            _stream = _client.GetStream();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    // receive request from Client
                    byte[] dataFromClient = new byte[2048];
                    int bytesRead = _stream.Read(dataFromClient, 0, dataFromClient.Length);
                    string requestJson = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                    RequestReply request = JsonSerializer.Deserialize<RequestReply>(requestJson);
                    RequestReply reply = null;
                    
                    // analyze the request
                    // create the reply
                    switch (request?.Action)
                    {
                        case "GetVehicle":
                            Vehicle vehicle = GetVehicle(request);
                            reply = new RequestReply
                            {
                                Action = "GetVehicle",
                                ObjType = "Vehicle",
                                ObjJson = JsonSerializer.Serialize(vehicle)
                            };
                            break;
                        case "AddVehicle":
                            break;
                    }
                    
                    // send reply to Client
                    string replyJson = JsonSerializer.Serialize(reply);
                    byte[] bytesToSend = Encoding.ASCII.GetBytes(replyJson);
                    _stream.Write(bytesToSend, 0, bytesToSend.Length);
                }
                catch (Exception e) when( e is ObjectDisposedException | e is IOException | e is JsonException)
                {
                    Console.WriteLine(
                        $"Client {((IPEndPoint) _client.Client.RemoteEndPoint)?.Address} disconnected...");
                    Close();
                    break;
                }
                
            }
        }

        private Vehicle GetVehicle(RequestReply request)
        {
            if (!request.ObjType.Equals("FilterParam"))
            {
                // read by licenseNo
                return VehicleDao.Read(request.ObjJson);
            }

            FilterParam param = JsonSerializer.Deserialize<FilterParam>(request.ObjJson);
            Debug.Assert(param != null);
            return VehicleDao.Read(param.Location, param.DateFrom, param.DateTo);
        }


        private void Close()
        {
            _client.Dispose();
            _stream.Close();
            Thread.CurrentThread.Interrupt();
        }
        

    }
}