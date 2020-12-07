using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName ="Data/Bullet")]
    public class BulletData : DataBase
    {
        [SerializeField] private Behavior.BulletBehavior _bulletPrefab = null;
        [SerializeField] int _power = 0;
        [SerializeField] int _speed = 0;

        public Behavior.BulletBehavior LeadOnlyBulletPrefab
        {
            get { return _bulletPrefab; }
        }

        public int Power
        {
            get { return _power; }
        }

        public int Speed
        {
            get { return _speed; }
        }
    }
}