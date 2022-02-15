using System.Collections;
using UnityEngine;

namespace Effects
{
    public class HitPauseEffect
    {
        private static bool _isPaused;

        public static IEnumerator HitPause(float pauseTime = 0.1f)
        {
            if (!_isPaused)
            {
                _isPaused = true;
                var originalTimeScale = Time.timeScale;
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(pauseTime);
                Time.timeScale = originalTimeScale;
                _isPaused = false;
            }
        }
    }
}