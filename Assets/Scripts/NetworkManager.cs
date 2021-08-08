using Photon.Pun;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Successful Connection");
    }

    public void CreateRoom(string RoomName)
    {
        PhotonNetwork.CreateRoom(RoomName);
    }

    public void JoinRoom(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public void ChangeNickname(string Nickname)
    {
        PhotonNetwork.NickName = Nickname;
    }

    public string GetPlayerList()
    {
        var list = "";

        foreach(var player in PhotonNetwork.PlayerList)
        {
            list += player.NickName + "\n";
        }

        return list;
    }

    public bool IsMasterClient()
    {
        return PhotonNetwork.IsMasterClient;
    }

    public void ExitLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    public void StartGame(string SceneGame)
    {
        PhotonNetwork.LoadLevel(SceneGame);
    }
}
