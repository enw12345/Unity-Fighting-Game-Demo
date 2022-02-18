using System.Collections;
using System.Globalization;
using Effects;
using TMPro;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float countDownTime = 4;
        public static GameManager Instance { get; private set; }
        public bool RoundStart { get; private set; }

        [SerializeField] private RectTransform _countDownRect;
        [SerializeField] private TMP_Text _countDownText;
        private CountDownEffect _countDown;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;

            RoundStart = false;
        }

        private void Start()
        {
            StartCoroutine(StartMatch());
        }

        private IEnumerator StartMatch()
        {
            _countDown = new CountDownEffect(_countDownRect, _countDownText, 1);
            
            float timer = 0;
            while (timer < countDownTime)
            {
                float roundStarts = 0;
                _countDownRect.localScale = Vector3.one;
                timer += 1;
                roundStarts = countDownTime - timer;
                print("Round Starts in: " + roundStarts);
                if(roundStarts > 0)
                StartCoroutine(_countDown.CountDown(roundStarts.ToString(CultureInfo.CurrentCulture)));
                else
                    StartCoroutine(_countDown.CountDown("FIGHT!"));
                yield return new WaitForSeconds(1);
            }
            RoundStart = true;
            print("ROUND START!");
        }
    }
}