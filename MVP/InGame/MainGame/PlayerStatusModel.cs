using UnityEngine;
using System.Collections;
using UniRx;

namespace Holo5GunGame.Model
{
    public class PlayerStatusModel
    {
        public PlayerStatusModel(int maxHP)
        {
            NowHP = new IntReactiveProperty(maxHP);
            MaxHP = new IntReactiveProperty(maxHP);
        }

        public IntReactiveProperty NowHP { get; }

        public IntReactiveProperty MaxHP { get; }
    }
}