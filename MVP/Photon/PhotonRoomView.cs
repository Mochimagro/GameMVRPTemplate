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
        public Subject<string> _subject = new Subject<string>();
        public IObservable<string> OnClickButton => _subject;
        public void Init()
        {
            for(int i = 0;i < _roomButtons.Count; i++)
            {
                _roomButtons[i].Init(i);
                _roomButtons[i].OnClickNumberButton.Subscribe(value => 
                {
                    _subject.OnNext(value); 
                });
            }
        }

        public void ChangeRoomPlayerCount(int index,int newValue)
        {
            _roomButtons[index].ChangeRoomMember(newValue);
        }

    }
}