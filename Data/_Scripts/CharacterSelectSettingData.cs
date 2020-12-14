using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Holo5GunGame.Data
{
    [CreateAssetMenu(menuName = "Data/CharacterSelectSetting")]
    public class CharacterSelectSettingData : DataBase
    {
        [SerializeField] private RuntimeAnimatorController _characterSelectAniator = null;

        public RuntimeAnimatorController CharacterSelectAnimator
        {
            get { return _characterSelectAniator; }
        }
    }

}
