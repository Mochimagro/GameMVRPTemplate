using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using UniRx;

namespace Holo5GunGame.View
{
    public class PhotonRoomView : MonoBehaviour
    {
        [SerializeField] private Button _connectButton = null;
        [SerializeField] private List<RoomButtonBehavior> _roomButtons = new List<RoomButtonBehavior>();
        public Subject<string> _subject = new Subject<string>();
        public IObservable<string> OnClickRoomButton => _subject;
        public IObservable<Unit> OnClickConnectButton => _connectButton.OnClickAsObservable();
        public void Init()
        {
            _connectButton.interactable = true;
            OnClickConnectButton.Subscribe(_ =>
            {
                _connectButton.interactable = false;
            });

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