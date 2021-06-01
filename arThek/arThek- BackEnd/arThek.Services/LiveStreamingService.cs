using arThek.ServiceAbstraction;
using Fleck;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arThek.Services
{
    public class LiveStreamingService : ILiveStreamingService
    {
        private const string SOCKET_URL = "ws://0.0.0.0:9010";
        public Task LiveStreaming()
        {
            List<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

            var wsServer = new WebSocketServer(SOCKET_URL);
            wsServer.Start(socket =>
                {
                    socket.OnOpen = () =>
                    {
                        sockets.Add(socket);
                    };
                    socket.OnClose = () => Console.WriteLine("Close!");
                    socket.OnMessage = message =>
                    {
                        sockets.ForEach(s => s.Send(message));
                    };
                });
            return Task.CompletedTask;
        }
    }
}
