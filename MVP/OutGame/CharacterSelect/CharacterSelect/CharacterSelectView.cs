using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Holo5GunGame.Entity;
using System.Collections.Generic;

namespace Holo5GunGame.View
{

    public class CharacterSelectView : MonoBehaviour
    {
        [SerializeField] private Button _nextButton = null;

        [SerializeField] private CharacterSelectScrollView _scrollView = null;
        [SerializeField] private Button _prevCellButton = null;
        [SerializeField] private Button _nextCellButton = null;

        private Subject<int> _onSelectionCell = new Subject<int>();
        public IObservable<int> OnSelectionCell => _onSelectionCell;

        public void Init(List<CharacterSelectItemEntity> characterSelectItemEntities)
        {

            _prevCellButton.OnClickAsObservable().TakeUntilDisable(this).Subscribe(_ => _scrollView.SelectPrevCell());
            _nextCellButton.OnClickAsObservable().TakeUntilDisable(this).Subscribe(_ => _scrollView.SelectNextCell());
            _scrollView.OnSelectionChanged(OnSelectionChanged);

            _scrollView.UpdateData(characterSelectItemEntities);
            _scrollView.SelectCell(0);

        }

        void OnSelectionChanged(int index)
        {
            _onSelectionCell.OnNext(index);
        }

    }
}