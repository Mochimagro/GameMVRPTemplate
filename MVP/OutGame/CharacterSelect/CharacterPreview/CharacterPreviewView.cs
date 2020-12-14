using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Holo5GunGame.View
{
    public class CharacterPreviewView : MonoBehaviour
    {
        [SerializeField] private Transform _previewStageTransform = null;
        private GameObject _character = null;
        private Sequence _sequence = null;

        public void Init(List<GameObject> characterObjects)
        {
            CreateAnimation();
            HideAllCharacter(characterObjects);

            _sequence.Restart();
        }

        private void CreateAnimation()
        {
            if (_sequence != null) return;

            _sequence = DOTween.Sequence();

            _sequence.Append(_previewStageTransform.DORotate(new Vector3(0, 360, 0), 4f,RotateMode.FastBeyond360).SetEase(Ease.Linear)).SetLoops(-1,LoopType.Incremental);

            _sequence.SetAutoKill(false);
        }

        public void HideAllCharacter(List<GameObject> characters)
        {
            foreach(var item in characters)
            {
                item.SetActive(false);
                item.transform.position = _previewStageTransform.position;
                item.transform.rotation = _previewStageTransform.rotation;
                item.transform.SetParent(_previewStageTransform);

            }
        }

        public void ShowCharacter(GameObject character)
        {
            _character?.SetActive(false);

            _character = character;
            _character.SetActive(true);

            _sequence.Restart();
        }

    }
}

