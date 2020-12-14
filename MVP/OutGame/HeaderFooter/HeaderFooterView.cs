using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.UI.ModernUIPack;

namespace Holo5GunGame.View
{
    public class HeaderFooterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleLabel = null;
        [SerializeField] private ButtonManagerBasic _nextButton = null;
        [SerializeField] private ButtonManagerBasic _prevButton = null;

        public string TitleLabel
        {
            set { _titleLabel.text = value; }
        }

        public string NextButton
        {
            set 
            { 
                _nextButton.buttonText = value;
                _nextButton.UpdateUI();
            }
        } 
        
        public string PrevButton
        {
            set 
            { 
                _prevButton.buttonText = value;
                _prevButton.UpdateUI();
            }
        }

    }
}