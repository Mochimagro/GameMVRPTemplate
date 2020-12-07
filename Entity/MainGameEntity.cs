using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Holo5GunGame.Entity
{
    public class MainGameEntity : EntityBase
    {
        public MainGameEntity(Data.MainGameData mainGameData)
        {

            foreach(var data in mainGameData.CharacterDatas)
            {
                CharacterEntities.Add(new CharacterEntity(data));
            }
            PlayerEntity = new PlayerEntity(mainGameData.PlayerData);
        }

        public List<CharacterEntity> CharacterEntities { get; private set; } = new List<CharacterEntity>();
        public PlayerEntity PlayerEntity { get;private set; }
    }
}