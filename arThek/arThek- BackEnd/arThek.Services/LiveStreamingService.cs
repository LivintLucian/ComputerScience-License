using arThek.ServiceAbstraction;
using Fleck;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class LiveStreamingService : ILiveStreamingService
    {
        public LiveStreamingService()
        {

        }

        public Task LiveStreaming()
        {
            List<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

            var wsServer = new WebSocketServer("ws://0.0.0.0:9010");
            wsServer.Start(socket =>
                {
                    socket.OnOpen = () =>
                    {
                        Console.WriteLine("Open!");
                        sockets.Add(socket);
                    };
                    socket.OnClose = () => Console.WriteLine("Close!");
                    socket.OnMessage = message =>
                    {
                        Console.WriteLine(sockets.Count);
                        sockets.ForEach(s => s.Send(message));
                    };
                });

            return Task.CompletedTask;
        }
    }
}
