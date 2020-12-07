using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Holo5GunGame.View
{

    public class PlayerStatusView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHpValue = null;
        [SerializeField] private TextMeshProUGUI _textMaxHpValue = null;

        public int MaxHP
        {
            set { _textMaxHpValue.text = value.ToString(); }
        }
        public int NowHP
        {
            set { _textHpValue.text = value.ToString(); }
        }


    }

}