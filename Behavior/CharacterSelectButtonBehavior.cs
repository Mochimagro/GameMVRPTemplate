using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Holo5GunGame.Behavior
{

    public class CharacterSelectButtonBehavior : MonoBehaviour
    {
        [SerializeField] private Button _button = null;
        private Subject<string> _onClickSubject = new Subject<string>();
        public IObservable<string> OnClickButton => _onClickSubject;
    }
}