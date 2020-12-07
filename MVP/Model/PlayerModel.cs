using UnityEngine;
using System.Collections;
using UniRx;


namespace Holo5GunGame.Model
{
    public class PlayerModel
    {
        public PlayerModel(Entity.PlayerEntity playerDefaultEntity)
        {
            _hp.Value = playerDefaultEntity.DefaultHP;
        }

        private readonly IntReactiveProperty _hp = new IntReactiveProperty();
        public IntReactiveProperty HP
        {
            get { return _hp; }
        }
    }
}