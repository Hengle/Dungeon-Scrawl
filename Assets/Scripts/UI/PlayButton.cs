﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="PlayButton.cs" author="Lars" company="None">
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
// and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// // </copyright>
// // <summary>
// //   TODO - Insert file description
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace UI
{
    using DG.Tweening;

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private CanvasGroup _canvas;

        [SerializeField]
        private RectTransform _rect;

        public void OnClick()
        {
            _button.interactable = false;
            _canvas.DOFade(0f, 0.5f).SetEase(Ease.OutCirc).OnComplete(() => SceneManager.LoadScene("Game"));
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            DOTween.To(
                () => _button.transform.localScale,
                x => _button.transform.localScale = x,
                new Vector3(1.25f, 1.25f, 1f),
                0.25f).SetEase(Ease.OutBack);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DOTween.To(
                () => _button.transform.localScale,
                x => _button.transform.localScale = x,
                new Vector3(1f, 1f, 1f),
                0.25f).SetEase(Ease.OutBack);
        }

        // Use this for initialization
        private void Start()
        {
            _rect.DOAnchorPos(new Vector2(0, -300), 1.0f).From().SetEase(Ease.OutQuart);
        }
    }
}