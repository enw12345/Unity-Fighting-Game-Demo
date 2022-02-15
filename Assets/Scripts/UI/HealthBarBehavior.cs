using System.Collections;
using Health;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarBehavior : MonoBehaviour
    {
        [SerializeField] private FighterHealth fighterHealth;
        [SerializeField] private Image healthBarGUI;

        [SerializeField] private Image damageBarGUI;
        [SerializeField] private float maxDelta = 1;

        private void Start()
        {
            healthBarGUI.fillAmount = 1;
            damageBarGUI.fillAmount = 1;
        }

        private void OnEnable()
        {
            fighterHealth.OnDamaged += UpdateHealthBar;
        }

        private void OnDisable()
        {
            fighterHealth.OnDamaged -= UpdateHealthBar;
        }

        private void UpdateHealthBar(float maxHealth, float currentHealth, float damage)
        {
            StartCoroutine(AnimateHealthBar(maxHealth, currentHealth, damage));
        }

        private IEnumerator AnimateHealthBar(float maxHealth, float currentHealth, float damage)
        {
            var healthLeft = currentHealth - damage;
            var value = currentHealth;

            while (currentHealth > healthLeft + maxDelta)
            {
                currentHealth = Mathf.MoveTowards(currentHealth, healthLeft, maxDelta);

                healthBarGUI.fillAmount = currentHealth / maxHealth;
                yield return new WaitForSeconds(.05f);
            }

            StartCoroutine(AnimateDamageBar(maxHealth, value, damage));
        }

        private IEnumerator AnimateDamageBar(float maxHealth, float currentHealth, float damage)
        {
            var damageHealth = currentHealth - damage;
            var value = currentHealth;

            while (value > damageHealth + 1)
            {
                value = Mathf.MoveTowards(value, damageHealth, maxDelta);
                damageBarGUI.fillAmount = value / maxHealth;
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}