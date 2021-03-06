﻿using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName ="Data/CharacterData")]
    public class CharacterData: DataBase
    {
        [SerializeField] private string _characterName = string.Empty;
        [SerializeField] private Presenter.PlayerControllerPresenter _playerControllerPresenter = null;
        [SerializeField] private BulletData _normalBullet = null;

        public string CharacterName
        {
            get { return _characterName; }
        }

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