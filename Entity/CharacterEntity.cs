using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Holo5GunGame.Entity
{
    public class CharacterEntity : EntityBase
    {
        public CharacterEntity(Data.CharacterData data)
        {
            PlayerControllerPresenter = data.PlayerControllerPresenter;
            BulletEntity = new BulletEntity(data.NormalBullet);
        }
        
        public Presenter.PlayerControllerPresenter PlayerControllerPresenter { get; private set; }
        public BulletEntity BulletEntity { get; private set; }

    }
}