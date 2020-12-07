using UnityEngine;
using System.Collections;
using System;
using UniRx;
using UniRx.Triggers;
using Holo5GunGame.View;
using Holo5GunGame.Model;

namespace Holo5GunGame.Presenter
{
    public class PlayerControllerPresenter : MonoBehaviour
    {
        private Subject<int> _onHitBullet = new Subject<int>();
        public IObservable<int> OnHitBullet => _onHitBullet;
        public IObservable<int> OnHPChange => _playerModel.HP;

        private PlayerStatusPresenter _minePlayerStatusPresenter = null;

        [Header("View")]
        [SerializeField] private PlayerControllerView _playerControllerView = null;
        [SerializeField] private GunView _gunView = null;

        [Header("Model")]
        private GunModel _gunModel = null;
        private PlayerModel _playerModel = null;

        public PlayerControllerPresenter Init(Entity.PlayerEntity playerEntity)
        {
            _playerModel = new PlayerModel(playerEntity);
            _gunModel = new GunModel(playerEntity.BulletEntity);

            Bind();
            DebugInit();

            return this;
        }

        private void DebugInit()
        {
        }
        private void Bind()
        {
            // キー入力
            InputUpdate();

            // 弾に被弾したとき
            _playerControllerView.OnBulletHit.Subscribe(bullet =>
            {
                _onHitBullet.OnNext(bullet.Power);

                bullet.HitBullet();
                _playerModel.HP.Value -= bullet.Power;
            });

            _playerModel.HP.Where(v => v <= 0).Subscribe(value =>
            {
                Debug.Log("死亡確認");
            });
        }
        private void InputUpdate()
        {
            this.UpdateAsObservable()
                .Select(_ => new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")))
                .Subscribe(v =>
                {
                    _playerControllerView.Move = v.normalized;
                    _playerControllerView.AnimatorMoveSpeed = v.magnitude;
                    
                });

            InputAsObservable.GetButtonDown("Jump").Subscribe(_ =>
            {
                _gunView.ShotBullet(_gunModel.BulletEntity);
            });
        }

        public void InitText(PlayerStatusPresenter minePlayerStatusPresenter)
        {
            _minePlayerStatusPresenter = minePlayerStatusPresenter;

            _playerModel.HP.Subscribe(value =>
            {
                _minePlayerStatusPresenter.HPText = value;
            });
        }
    }
}