using System.Collections;
using TMPro;
using UnityEngine;

namespace Effects
{
    public class CountDownEffect
    {
        private readonly RectTransform _countDownRect;
        private readonly float _countDownTime;
        private readonly TMP_Text _countDownText;
        
        public CountDownEffect(RectTransform countDownRect, TMP_Text countDownText, float countDownTime)
        {
            _countDownRect = countDownRect;
            _countDownTime = countDownTime;
            _countDownText = countDownText;
        }

        public IEnumerator CountDown(string message)
        {
            //scale down to zero
            _countDownText.text = message;
            LeanTween.scale(_countDownRect, new Vector3(0, 0, 0), _countDownTime);
            yield return new WaitForSeconds(0.1f);
        }
    }
}