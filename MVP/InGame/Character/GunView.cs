using UnityEngine;
using System.Collections;
using UniRx.Triggers;
using UniRx;

namespace Holo5GunGame.View
{
    public class GunView: MonoBehaviour
    {
        [SerializeField] private Transform _bulletTransform = null;
        

        public void ShotBullet(Entity.BulletEntity bullet)
        {
            var bul = Instantiate(bullet.BulletPrefab, _bulletTransform.position, _bulletTransform.rotation);
            bul.Rigidbody.AddForce(_bulletTransform.forward * bullet.Speed);
            bul.Power = bullet.Power;
            
        }

    }
}