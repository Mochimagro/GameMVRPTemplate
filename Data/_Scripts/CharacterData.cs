using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName ="Data/CharacterData")]
    public class CharacterData: DataBase
    {
        [SerializeField] private Presenter.PlayerControllerPresenter _playerControllerPresenter = null;

        [SerializeField] private BulletData _normalBullet = null;

        public Presenter.PlayerControllerPresenter PlayerControllerPresenter
        {
            get { return _playerControllerPresenter; }
        }

        public BulletData NormalBullet
        {
            get { return _normalBullet; }
        }

    }
}