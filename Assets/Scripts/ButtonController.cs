using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ButtonController : MonoBehaviourPunCallbacks
{
    [SerializeField] private Image GreenButton;
    [SerializeField] private Button RedButton;
    [SerializeField] private Button RestartBtn;
    [SerializeField] private Text Group;
    [SerializeField] private Text Count;
    private float CurrentTime;
    private float StartTime;
    private bool isPressed;

    private void Start()
    {
        StartTime = Time.time;
        isPressed = false;
    }

    private void FixedUpdate()
    {
        CurrentTime = Time.time - StartTime;

        if (!isPressed)
        {
            Count.text = "Tempo: " + (int)CurrentTime + "s";
        }
    }

    [PunRPC]
    public void Restart()
    {
        isPressed = false;
        StartTime = Time.time;
        GreenButton.gameObject.SetActive(false);
        RedButton.gameObject.SetActive(true);
        Group.text = "Grupo: ";
    }

    [PunRPC]
    public void SetGroupButton(string Name)
    {
        isPressed = true;
        RedButton.gameObject.SetActive(false);
        GreenButton.gameObject.SetActive(true);
        Group.text = "Grupo: " + Name;
    }

}
