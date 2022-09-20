using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class MenuManager : MonoBehaviourPunCallbacks
{


    public GameObject UserNameScreen, ConnectScreen;
    public Button CreateUserNameButton;
    public TMP_InputField UserInput, CreateRoomInput, JoinRoominput;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby");
        UserNameScreen.SetActive(true);

    }


    public void CreateUserInputButton()
    {
        if(UserInput.text.Length>2)
        {
            PhotonNetwork.NickName = UserInput.text;
            ConnectScreen.SetActive(true);
            UserNameScreen.SetActive(false);
        }
    }

    public void OnNameFieldChanged()
    {
        if (UserInput.text.Length > 2)
        {
            CreateUserNameButton.interactable = true;
        }
        else
        {
            CreateUserNameButton.interactable = false;

        }
    }


    public void OnClickJoinedRoom()
    {
        RoomOptions Ro = new RoomOptions();
        Ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinRoominput.text, Ro, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

   public void OnClickCreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateRoomInput.text, new RoomOptions { MaxPlayers = 4 }, null);
    }
}
