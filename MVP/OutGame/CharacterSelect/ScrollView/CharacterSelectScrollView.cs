using System.Collections;
using UnityEngine;
using FancyScrollView;
using System.Collections.Generic;
using System;

namespace Holo5GunGame.View
{
    public class CharacterSelectScrollView : FancyScrollView<Entity.CharacterSelectItemEntity,Context>
    {
        [SerializeField] private Scroller _scroller = null;
        [SerializeField] private GameObject _cellPrefab = null;

        Action<int> onSelectionChanged;

        protected override GameObject CellPrefab =>_cellPrefab;

        protected override void Initialize()
        {
            base.Initialize();
            Context.OnCellClicked = SelectCell;

            _scroller.OnValueChanged(UpdatePosition);
            _scroller.OnSelectionChanged(UpdateSelection);
        }
        void UpdateSelection(int index)
        {
            if (Context.SelectedIndex == index)
            {
                return;
            }

            Context.SelectedIndex = index;
            Refresh();

            onSelectionChanged?.Invoke(index);


        }

        public void UpdateData(IList<Entity.CharacterSelectItemEntity> items)
        {
            base.UpdateContents(items);
            _scroller.SetTotalCount(items.Count);
        }


        public void OnSelectionChanged(Action<int> callback)
        {
            onSelectionChanged = callback;
        }


        public void SelectNextCell()
        {
            SelectCell(Context.SelectedIndex + 1);
        }

        public void SelectPrevCell()
        {
            SelectCell(Context.SelectedIndex - 1);
        }

        public void SelectCell(int index)
        {
            if (index < 0 || index >= ItemsSource.Count || index == Context.SelectedIndex)
            {
                return;
            }

            UpdateSelection(index);
            _scroller.ScrollTo(index, 0.35f, EasingCore.Ease.OutCubic);
        }
    }
}