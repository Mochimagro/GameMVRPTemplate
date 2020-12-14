using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using Holo5GunGame.Model;
using Holo5GunGame.View;
using UniRx;
using Doozy.Engine;
using System.Collections.Generic;

namespace Holo5GunGame.Presenter
{
    public class PhotonRoomPresenter : MonoBehaviourPunCallbacks,IPresenter
    {
        // TODO: しっかりとLobyに入室したときにボタンを表示する
        // TODO: 部屋から出るときも(退出したとき用に)ボタンを再表示する

        private PhotonRoomModel _photonRoomModel = null;
        [SerializeField]private PhotonRoomView _photonRoomView = null;

        public void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();

            Init();
        }

        public void  Init()
        {

            _photonRoomModel = new PhotonRoomModel();
            _photonRoomView.Init();

            Bind();

            return;
        }

        public void Bind()
        {

            // リストを選択
            _photonRoomView.OnClickRoomButton.TakeUntilDisable(this).Subscribe(value =>
            {
                PhotonNetwork.JoinOrCreateRoom(value, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
                GameEventMessage.SendEvent("SelectedRoom");
            
            });

            // リストが更新されたら
            _photonRoomModel.RoomMembers.ObserveReplace().TakeUntilDisable(this).Subscribe(value =>
           {
               _photonRoomView.ChangeRoomPlayerCount(value.Index, value.NewValue);
           });

            // 通信開始ボタン
            _photonRoomView.OnClickConnectButton.TakeUntilDisable(this).Subscribe(_ =>
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
            GameEventMessage.SendEvent("JoinedRoom");
        }


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            GameEventMessage.SendEvent("RoomLeaved");
        }

    }

}