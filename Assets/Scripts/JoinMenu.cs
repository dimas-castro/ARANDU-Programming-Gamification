using UnityEngine;
using UnityEngine.UI;

public class JoinMenu : MonoBehaviour
{
    [SerializeField] private Text GroupName;
    [SerializeField] private Text RoomName;

    public void CreateRoom()
    {
        NetworkManager.instance.ChangeNickname(GroupName.text);
        NetworkManager.instance.CreateRoom(RoomName.text);
    }

    public void JoinRoom()
    {
        NetworkManager.instance.ChangeNickname(GroupName.text);
        NetworkManager.instance.JoinRoom(RoomName.text);
    }
}
