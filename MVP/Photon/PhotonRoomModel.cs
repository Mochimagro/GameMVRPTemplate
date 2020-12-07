using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UniRx;

namespace Holo5GunGame.Model
{
    public class PhotonRoomModel : MonoBehaviourPunCallbacks
    {
        public PhotonRoomModel()
        {
            RoomMembers = new ReactiveCollection<int>() { 0, 0, 0, 0, 0 };
        }

        public ReactiveCollection<int> RoomMembers { get; private set; }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            for(int i = 0;i < roomList.Count; i++)
            {
                RoomMembers[i] = roomList[i].PlayerCount;
            }
        }


    }
}