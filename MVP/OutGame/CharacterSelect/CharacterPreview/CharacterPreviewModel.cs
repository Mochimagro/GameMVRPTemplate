using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holo5GunGame.Entity;
using System.Linq;
using UniRx;

namespace Holo5GunGame.Model
{

    public class CharacterPreviewModel : ModelBese
    {
        public CharacterPreviewModel(List<CharacterEntity> characterEntities)
        {
            _characterObjects = new Dictionary<string, GameObject>();

            foreach(var item in characterEntities)
            {
                var obj = Object.Instantiate(item.PlayerControllerPresenter.gameObject);
                _characterObjects.Add(item.CharacterName, obj);

            }

            LoadDataAsset<Data.CharacterSelectSettingData>(CHARACTER_SELECT_SETTING);

            OnCompleteLoadData.Subscribe(data =>
            {
                _animator = (data as Data.CharacterSelectSettingData).CharacterSelectAnimator;
                foreach(var chara in _characterObjects)
                {
                    chara.Value.GetComponent<Animator>().runtimeAnimatorController = _animator;
                }
            });

        }

        private Dictionary<string, GameObject> _characterObjects = null;
        private RuntimeAnimatorController _animator = null;

        public List<GameObject> AllCharacterObjects
        {
            get { return _characterObjects.Values.ToList(); }
        }

        public GameObject GetCharacter(string name)
        {
            return _characterObjects[name];
        }

    }

}