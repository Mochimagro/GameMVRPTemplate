using System;
using System.Collections.Generic;
using UnityEngine;
using Holo5GunGame.View;
using Holo5GunGame.Model;
using UniRx;

namespace Holo5GunGame.Presenter
{

    public class CharacterSelectPresenter : MonoBehaviour,IPresenter
    {
        [SerializeField] private CharacterSelectView _characterSelectView = null;
        [SerializeField] private CharacterPreviewPresenter _characterPreviewPresenter = null;

        private CharacterSelectModel _characterSelectModel = null;

        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {

            _characterSelectModel = new CharacterSelectModel();

            _characterSelectModel.OnReady.Subscribe(model =>
            {
                Bind();
                _characterPreviewPresenter.Init(_characterSelectModel.CharacterEntities);
                _characterSelectView.Init(_characterSelectModel.CharacterSelectEntities);

            });


        }

        public void Bind()
        {
            _characterSelectView.OnSelectionCell.TakeUntilDisable(this).Subscribe(index =>
            {
                _characterPreviewPresenter.ChangeShowCharacter(_characterSelectModel.GetSelectedName(index));
            });
        }


    }
}