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
        //게임 버젼 설정
        PhotonNetwork.GameVersion = gameVersion;
        //마스터 서버 접속 시도
        PhotonNetwork.ConnectUsingSettings();
        //sub버튼 비활성화
        SubButton.interactable = false;
        //접속 시도 중 텍스트
        connectionInfoText.text = "마스터 서버에 접속중";
    }
    //마스터 서버 접속 성공 시 자동 실행
    public override void OnConnectedToMaster()
    {
        SubButton.interactable = true;
        connectionInfoText.text = "온라인 : 마스터 서버";
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        SubButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결 되지 않음\n접속 재시도 중...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public void Connect()
    {
        SubButton.interactable = false;
        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "룸에 접속...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //마스터 서버와 접속 중이 아니면, 마스터 서버에 접속 시도
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결 되지 않음\n접속 재시도 중...";
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "새로운 방 생성 중";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
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
