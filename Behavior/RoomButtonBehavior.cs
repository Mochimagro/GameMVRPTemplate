using UnityEngine;
using UniRx;
using System;
using Michsky.UI.ModernUIPack;
using UniRx.Triggers;

namespace Holo5GunGame.Behavior
{
    public class RoomButtonBehavior : MonoBehaviour
    {
        [SerializeField] private ButtonManager _buttonManger = null;
        private string RoomName;
        private string RoomMember;
        private Subject<string> _onClickButton = new Subject<string>();
        public IObservable<string> OnClickNumberButton => _onClickButton;


        public void Init(int index)
        {
            RoomName = string.Format("Room{0}", index);
            ChangeRoomMember(0);

            _buttonManger.clickEvent.AsObservable().Subscribe(_ =>
            {
                _onClickButton.OnNext(RoomName);
            });
        }

        public void ChangeRoomMember(int value)
        {
            RoomMember = string.Format("{0} / 4", value);
            _buttonManger.buttonText = RoomName + "\n" + RoomMember;
            _buttonManger.UpdateUI();

        }
    }
}