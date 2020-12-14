using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holo5GunGame.View;
using Holo5GunGame.Model;

namespace Holo5GunGame.Presenter
{
    public class HeaderFooterPresenter : MonoBehaviour
    {
        [SerializeField] private HeaderFooterView _headerFooterView = null;

        public void SetTitleLabel(string value)
        {
            _headerFooterView.TitleLabel = value;
        }

        public void SetNextButtonLabel(string value)
        {
            _headerFooterView.NextButton = value;
        }

        public void SetPrevButtonLabel(string value)
        {
            _headerFooterView.PrevButton = value;
        }
    }

}