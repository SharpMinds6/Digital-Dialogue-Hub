using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace DigitalDialogueHub.Hubs
{
    public class NotificationHub : Hub
    {
        // Mapa: userId → connectionId lista (možda više tabova)
        private static readonly ConcurrentDictionary<int, List<string>> userConnections = new();

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userIdString = httpContext?.Request.Query["userId"];
            if (int.TryParse(userIdString, out int userId))
            {
                var connectionId = Context.ConnectionId;
                userConnections.AddOrUpdate(userId,
                    new List<string> { connectionId },
                    (key, existingList) =>
                    {
                        existingList.Add(connectionId);
                        return existingList;
                    });
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            foreach (var pair in userConnections)
            {
                if (pair.Value.Contains(Context.ConnectionId))
                {
                    pair.Value.Remove(Context.ConnectionId);
                    if (pair.Value.Count == 0)
                    {
                        userConnections.TryRemove(pair.Key, out _);
                    }
                    break;
                }
            }

            return base.OnDisconnectedAsync(exception);
        }

        public static List<string> GetConnections(int userId)
        {
            return userConnections.TryGetValue(userId, out var connections)
                ? connections
                : new List<string>();
        }
    }
}
