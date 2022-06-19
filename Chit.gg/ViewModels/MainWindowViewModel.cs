using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Websocket.Client;

namespace Chit.gg.ViewModels;
public class MainWindowViewModel : ViewModelBase
{

    public void Connect()
    {
        var exitEvent = new ManualResetEvent(false);
        var url = new Uri("wss://chit.gg/gateway");
        var client = new WebsocketClient(url);
        client.ReconnectTimeout = TimeSpan.FromSeconds(30);
        
        client.ReconnectionHappened.Subscribe(info =>
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Wss reconnect (type): " + info.Type);
            Console.ResetColor();
        });
        
        client.MessageReceived.Subscribe(msg =>
        {
            Console.WriteLine("Message received: " + msg);
            if (msg.ToString().ToLower() == "connected")
                client.Send("0");
        });
        
        client.Start();
    }
}