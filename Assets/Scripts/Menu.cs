using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] private JoinMenu joinmenu;
    [SerializeField] private LobbyMenu lobbymenu;

    private void Start()
    {
        joinmenu.gameObject.SetActive(false);
        lobbymenu.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        joinmenu.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        ChangeMenu(lobbymenu.gameObject);
        lobbymenu.photonView.RPC("UpdateList", RpcTarget.All);
    }

    public void ChangeMenu(GameObject menu)
    {
        joinmenu.gameObject.SetActive(false);
        lobbymenu.gameObject.SetActive(false);

        menu.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        lobbymenu.UpdateList();
    }

    public void ExitLobby()
    {
        NetworkManager.instance.ExitLobby();
        ChangeMenu(joinmenu.gameObject);
    }

    public void StartGame(string SceneName)
    {
        NetworkManager.instance.photonView.RPC("StartGame", RpcTarget.All, SceneName);
    }
}
