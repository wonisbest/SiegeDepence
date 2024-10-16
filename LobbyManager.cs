using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class LobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private string gameVersion = "1";
    public Text connectionInfoText;
    public Button SubButton;
  
    void Start()
    {
        //���� ���� ����
        PhotonNetwork.GameVersion = gameVersion;
        //������ ���� ���� �õ�
        PhotonNetwork.ConnectUsingSettings();
        //sub��ư ��Ȱ��ȭ
        SubButton.interactable = false;
        //���� �õ� �� �ؽ�Ʈ
        connectionInfoText.text = "������ ������ ������";
    }
    //������ ���� ���� ���� �� �ڵ� ����
    public override void OnConnectedToMaster()
    {
        SubButton.interactable = true;
        connectionInfoText.text = "�¶��� : ������ ����";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        SubButton.interactable = false;
        connectionInfoText.text = "�������� : ������ ������ ���� ���� ����\n���� ��õ� ��...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public void Connect()
    {
        SubButton.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            //�� ���� ����
            connectionInfoText.text = "�뿡 ����...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //������ ������ ���� ���� �ƴϸ�, ������ ������ ���� �õ�
            connectionInfoText.text = "�������� : ������ ������ ���� ���� ����\n���� ��õ� ��...";
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "���ο� �� ���� ��";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "�� ���� ����";
        PhotonNetwork.LoadLevel("Main");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Connect();
        }
    }
}
