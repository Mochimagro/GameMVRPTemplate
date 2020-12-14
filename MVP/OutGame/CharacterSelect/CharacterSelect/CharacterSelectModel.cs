using System.Collections;
using System.Collections.Generic;
using System;
using Holo5GunGame.Entity;
using UniRx;

namespace Holo5GunGame.Model
{
    public class CharacterSelectModel : ModelBese
    {
        public CharacterSelectModel() 
        {
            LoadDataAsset<Data.MainGameData>(MAIN_GAME_DATA);

            OnCompleteLoadData.Subscribe(data =>
            {
                var characterDatas = (data as Data.MainGameData).CharacterDatas;

                foreach(var item in characterDatas)
                {
                    _charaSelectEntities.Add(new CharacterSelectItemEntity(item.CharacterName));
                    _characterEntities.Add(new CharacterEntity(item));

                }

                _onReady.OnNext(this);
            });
        
        }

        private List<CharacterSelectItemEntity> _charaSelectEntities = new List<CharacterSelectItemEntity>();
        private List<CharacterEntity> _characterEntities = new List<CharacterEntity>();

        public string GetSelectedName(int index)
        {
            return _charaSelectEntities[index].Message;
        }

        public List<CharacterSelectItemEntity> CharacterSelectEntities
        {
            get { return _charaSelectEntities; }
        }

        public List<CharacterEntity> CharacterEntities
        {
            get { return _characterEntities; }
        }
    }
}