using UnityEngine;
using System.Collections;

namespace Holo5GunGame.Entity
{
    //[CreateAssetMenu(menuName = "Entity/PlayerDefaultData")]
    public class PlayerEntity : EntityBase
    {
        public PlayerEntity(Data.PlayerData playerData)
        {
            DefaultHP = playerData.DefaultHP;
            BulletEntity = new BulletEntity(playerData.BulletData);
        }
        public BulletEntity BulletEntity { get; private set; }
        public int DefaultHP { get; private set; }
    }
}