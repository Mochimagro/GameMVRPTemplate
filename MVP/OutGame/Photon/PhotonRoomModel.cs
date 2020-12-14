using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Holo5GunGame.Model
{
    public class PhotonRoomModel
    {
        public PhotonRoomModel()
        {
            RoomMembers = new ReactiveCollection<int>(Enumerable.Repeat(0, 5).ToList());
        }

        public ReactiveCollection<int> RoomMembers { get; private set; }

        public void UpDateRoomList(List<RoomInfo> roomList)
        {

            foreach(var room in roomList)
            {
                var number = int.Parse(room.Name.Replace("Room", ""));

                Debug.Log(string.Format("Number : {0}", number));

                RoomMembers[number] = room.PlayerCount;
            }
        }

    }
}