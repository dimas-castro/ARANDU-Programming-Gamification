using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text PlayerList;
    [SerializeField] private Button StartGame;

    [PunRPC]
    public void UpdateList()
    {
        PlayerList.text = NetworkManager.instance.GetPlayerList();
        StartGame.interactable = NetworkManager.instance.IsMasterClient();
    }
}
