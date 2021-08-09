using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private ButtonController buttoncontroller;

    public void Restart()
    {
        buttoncontroller.photonView.RPC("Restart", RpcTarget.All);
    }

    public void SetGroupButton()
    {
        buttoncontroller.photonView.RPC("SetGroupButton", RpcTarget.All, PhotonNetwork.NickName);
    }
}
