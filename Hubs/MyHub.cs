/*using Microsoft.AspNetCore.SignalR;

namespace webproject.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string senderName, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", senderName, message);
        }
    }
}
*/


using Microsoft.AspNetCore.SignalR;


namespace SignalR.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(TestData data)
        {

            await Clients.All.SendAsync("ReceiveData", data); 

        }

    }

    public class TestData
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public string Status { get; set; }
    }
}