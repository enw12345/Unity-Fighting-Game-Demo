using System;
using System.Collections;
using System.Globalization;
using Effects;
using TMPro;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        private bool _gameStart = false;
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
            _countDownText.fontSize = 50;
            _countDownText.text = "Press Any Key To Start";
        }

        private void Update()
        {
            if (_gameStart) return;
            if (!Input.anyKey) return;
            _gameStart = true;
            _countDownText.fontSize = 150;
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
                StartCoroutine(roundStarts > 0
                    ? _countDown.CountDown(roundStarts.ToString(CultureInfo.CurrentCulture))
                    : _countDown.CountDown("FIGHT!"));
                yield return new WaitForSeconds(1);
            }
            RoundStart = true;
            print("ROUND START!");
        }

        private void GameOver()
        {
            
        }
    }
}