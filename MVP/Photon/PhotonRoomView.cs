using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using UniRx;

namespace Holo5GunGame.View
{
    public class PhotonRoomView : MonoBehaviour
    {
        [SerializeField] private List<RoomButtonBehavior> _roomButtons = new List<RoomButtonBehavior>();
        public IObservable<string> OnClickButton { get; set; }

        public void Init()
        {
            for(int i = 0;i < _roomButtons.Count; i++)
            {
                _roomButtons[i].Init(i);
            }
        }

        public void ChangeRoomPlayerCount(int index,int newValue)
        {
            _roomButtons[index].ChangeRoomMember(newValue);
        }

    }
}