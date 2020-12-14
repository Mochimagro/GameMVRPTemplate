using System.Collections;
using UnityEngine;
using FancyScrollView;
using TMPro;
using Holo5GunGame.Entity;
using UnityEngine.UI;
using UniRx;
using System;

namespace Holo5GunGame.View
{
    public class CharacterSelectCell : FancyCell<CharacterSelectItemEntity,Context>
    {
        [SerializeField] private TextMeshProUGUI _message = null;
        [SerializeField] private Animator _animator = null;
        [SerializeField] private Image _image = null;
        [SerializeField] private Button _button = null;

        static class AniamtorHash
        {
            public static readonly int Scroll = Animator.StringToHash("scroll");
        }

        public override void Initialize()
        {
            _button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
        }

        public override void UpdateContent(CharacterSelectItemEntity itemEntity)
        {
            _message.text = itemEntity.Message;

            var selected = Context.SelectedIndex == Index;

            _image.color = selected ? new Color32(0, 255, 255, 100) : new Color32(255, 255, 255, 77);
        }

        public override void UpdatePosition(float position)
        {
            currentPositon = position;

            if (_animator.isActiveAndEnabled)
            {
                _animator.Play(AniamtorHash.Scroll, -1, position);
            }

            _animator.speed = 0;
        }

        float currentPositon = 0;

        void OnEnable() => UpdatePosition(currentPositon);

    }
}