using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using Holo5GunGame.Model;
using Holo5GunGame.View;
using UniRx;
using Doozy.Engine;
using System.Collections.Generic;
using UniRx.Triggers;

namespace Holo5GunGame.Presenter
{
    public class PhotonRoomPresenter : MonoBehaviourPunCallbacks
    {
        private PhotonRoomModel _photonRoomModel = null;
        [SerializeField]private PhotonRoomView _photonRoomView = null;


        private void Start()
        {
            Init();
            Bind();
        }

        public PhotonRoomPresenter Init()
        {
            _photonRoomModel = new PhotonRoomModel();

            _photonRoomView.Init();

            return this;
        }

        public void Bind()
        {

            // リストを選択
            _photonRoomView.OnClickRoomButton.Subscribe(value =>
            {
                PhotonNetwork.JoinOrCreateRoom(value, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
                GameEventMessage.SendEvent("SelectedRoom");
            
            });

            // リストが更新されたら
            _photonRoomModel.RoomMembers.ObserveReplace().Subscribe(value =>
           {
               Debug.Log(string.Format("Index:{0} Value:{1}", value.Index, value.NewValue));
               _photonRoomView.ChangeRoomPlayerCount(value.Index, value.NewValue);
           });

            // 通信開始ボタン
            _photonRoomView.OnClickConnectButton.Subscribe(_ =>
            {
                PhotonNetwork.ConnectUsingSettings();
            });

        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            GameEventMessage.SendEvent("JoinedLoby");
            _photonRoomModel.UpDateRoomList(roomList);
        }

        public override void OnJoinedRoom()
        {
            GameEventMessage.SendEvent("RoomJoined");
        }

    }

}