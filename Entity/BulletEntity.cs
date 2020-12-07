using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Entity
{
    public class BulletEntity: EntityBase
    {
        public BulletEntity(Data.BulletData baseData)
        {
            BulletPrefab = baseData.LeadOnlyBulletPrefab;

            this.Power = baseData.Power;
            this.Speed = baseData.Speed;
        }

        public Behavior.BulletBehavior BulletPrefab { get; private set; }

        public int Power { get; private set; }
        public int Speed { get; private set; }
    }
}