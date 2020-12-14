using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Holo5GunGame.Entity
{
    public class CharacterEntity : EntityBase
    {
        public CharacterEntity(Data.CharacterData data)
        {
            CharacterName = data.CharacterName;
            PlayerControllerPresenter = data.PlayerControllerPresenter;
            BulletEntity = new BulletEntity(data.NormalBullet);
        }
        
        public string CharacterName { get; private set; }
        public Presenter.PlayerControllerPresenter PlayerControllerPresenter { get; private set; }
        public BulletEntity BulletEntity { get; private set; }

    }
}