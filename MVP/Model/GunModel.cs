using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Model
{
    // [CreateAssetMenu(menuName ="Model/Gun")]
    public class GunModel
    {
        public GunModel(Entity.BulletEntity _entity)
        {
            BulletEntity = _entity;
        }

        public Entity.BulletEntity BulletEntity { get; private set; }
    }
}