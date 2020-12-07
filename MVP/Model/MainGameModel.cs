using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Holo5GunGame.Model
{
    // [CreateAssetMenu(menuName ="Model/MainGameModel")]
    public class MainGameModel
    {
        public MainGameModel(Entity.MainGameEntity mainGameEntity)
        {
            PlayerEntity = mainGameEntity.PlayerEntity;
            CharacterEntitys = mainGameEntity.CharacterEntities;
        }

        public List<Entity.CharacterEntity> CharacterEntitys { get; private set; }
        
        public Entity.PlayerEntity PlayerEntity { get; private set; }
    }
}