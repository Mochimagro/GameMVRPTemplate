using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName ="Data/PlayerDefaultData")]
    public class PlayerData :DataBase
    {
        [SerializeField] private int _defaultHP = 10;
        [SerializeField] private BulletData _bulletData = null;
        public int DefaultHP
        {
            get { return _defaultHP; }
        }
        public BulletData BulletData
        {
            get { return _bulletData; }
        }
    }

}
