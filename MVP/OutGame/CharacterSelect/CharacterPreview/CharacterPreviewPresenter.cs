using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holo5GunGame.Model;
using Holo5GunGame.View;
using UniRx;

namespace Holo5GunGame.Presenter
{

    public class CharacterPreviewPresenter : MonoBehaviour
    {
        [SerializeField] private CharacterPreviewView _characterPreviewView = null;
        private CharacterPreviewModel _characterPreviewModel = null;

        public void Init(List<Entity.CharacterEntity> characterEntities)
        {
            _characterPreviewModel = new CharacterPreviewModel(characterEntities);
            _characterPreviewView.Init(_characterPreviewModel.AllCharacterObjects);

            _characterPreviewModel.OnReady.Subscribe(value =>
            {

                Bind();
            });
        }

        private void Bind()
        {

        }

        public void ChangeShowCharacter(string targetName)
        {
            _characterPreviewView.ShowCharacter(_characterPreviewModel.GetCharacter(targetName));
        }
    }
}