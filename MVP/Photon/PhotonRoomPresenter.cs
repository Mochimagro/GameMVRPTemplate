using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using Holo5GunGame.Model;
using Holo5GunGame.View;
using UniRx;
using Doozy.Engine;

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
            PhotonNetwork.ConnectUsingSettings();
        }

        public PhotonRoomPresenter Init()
        {
            _photonRoomModel = new PhotonRoomModel();

            _photonRoomView.Init();

            return this;
        }

        public void Bind()
        {
            _photonRoomView.OnClickButton.Subscribe(value =>
            {
                PhotonNetwork.JoinOrCreateRoom(value, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
                GameEventMessage.SendEvent("SelectedRoom");
            
            });

            _photonRoomModel.RoomMembers.ObserveReplace().Subscribe(value =>
           {
               _photonRoomView.ChangeRoomPlayerCount(value.Index, value.NewValue);
           });

        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedRoom()
        {
            GameEventMessage.SendEvent("RoomJoined");
        }

    }

}