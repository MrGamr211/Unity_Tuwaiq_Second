using Unity.Netcode;
using UnityEngine;

public class MultiplayerSystem : MonoBehaviour
{
    public void Client()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void Server()
    {
        NetworkManager.Singleton.StartServer();
    }
}
