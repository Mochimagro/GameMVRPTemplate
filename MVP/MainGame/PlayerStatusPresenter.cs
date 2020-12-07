using UnityEngine;
using System.Collections;
using Holo5GunGame.View;
using Holo5GunGame.Model;
using UniRx;

namespace Holo5GunGame.Presenter
{
    public class PlayerStatusPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerStatusView _playerStatusView = null;
        
        public int HPText
        {
            set { _playerStatusView.NowHP = value; }
        }

        public void Init(int maxHP)
        {
            //_minePlayerStatusModel = new MinePlayerStatusModel(maxHP);
            Bind();
        }

        private void Bind()
        {
            /*
            _minePlayerStatusModel.NowHP.Subscribe(value =>
            {
                _minePlayerStatusView.NowHP = value;
            });

            _minePlayerStatusModel.MaxHP.Subscribe(value =>
            {
                _minePlayerStatusView.MaxHP = value;
            });
            */
        }
    }
}