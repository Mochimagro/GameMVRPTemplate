using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using System;

namespace Holo5GunGame.Presenter
{
    public class MainGamePresenter : MonoBehaviour
    {
        private Model.MainGameModel _mainGameModel = null;
        [SerializeField] private List<Transform> _startPosition = new List<Transform>();

        private List<PlayerControllerPresenter> _players = new List<PlayerControllerPresenter>();

        [SerializeField]private List<PlayerStatusPresenter> _minePlayerStatusPresenter = null;

        public void Ready()
        {
            _mainGameModel = new Model.MainGameModel();

            _mainGameModel.OnReady.Subscribe(model =>
            {
                Init();
                Bind();
            });
        }

        public MainGamePresenter Init()
        {

            for (int i = 0; i < _mainGameModel.CharacterEntitys.Count; i++)
            {
                var player = Instantiate(
                    _mainGameModel.CharacterEntitys[i].PlayerControllerPresenter,
                    _startPosition[i].position,
                    _startPosition[i].rotation);

                player.Init(_mainGameModel.PlayerEntity);
                _players.Add(player);
            }

            return this;
        }

        public void Bind()
        {
                _players[0].InitText(_minePlayerStatusPresenter[0]);
            
        }
    }
}