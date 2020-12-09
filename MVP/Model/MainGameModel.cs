using UnityEngine;
using System;
using UniRx;
using System.Collections.Generic;

namespace Holo5GunGame.Model
{
    // [CreateAssetMenu(menuName ="Model/MainGameModel")]
    public class MainGameModel : ModelBese
    {
        // データを非同期用にする。(各EntityをReactivePropatyに)
        public MainGameModel() : base()
        {
            LoadDataAsset(MAIN_GAME_DATA);

            OnCompleteLoadData.Subscribe(value =>
            {
                var entity = new Entity.MainGameEntity(value as Data.MainGameData);

                PlayerEntity = entity.PlayerEntity;
                CharacterEntitys = entity.CharacterEntities;

                _onReady.OnNext(this);
                });

        }

        public List<Entity.CharacterEntity> CharacterEntitys { get; private set; }
        
        public Entity.PlayerEntity PlayerEntity { get; private set; }



    }
}