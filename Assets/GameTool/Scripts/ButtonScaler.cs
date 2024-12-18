using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameTool
{
    public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private float scale = 0.85f;

        public void OnPointerDown(PointerEventData eventData)
        {
            AudioManager.Instance.Shot(eSoundName.ButtonClick);
            transform.DOKill();
            transform.DOScale(scale, 0.25f).SetUpdate(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DOTween.Sequence().SetUpdate(true).Append(transform.DOScale(1.05f, 0.15f).SetUpdate(true))
            .Append(transform.DOScale(0.95f, 0.1f).SetUpdate(true))
            .Append(transform.DOScale(1f, 0.1f).SetUpdate(true));
        }
    }
}