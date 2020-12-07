using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName ="Data/MainGameData")]
    public class MainGameData : DataBase
    {
        [SerializeField] private List<CharacterData> _characterDatas = new List<CharacterData>();

        [SerializeField] private PlayerData _playerData = null;

        public List<CharacterData> CharacterDatas { get { return _characterDatas; } }
        public PlayerData PlayerData { get { return _playerData; } }

    }
}