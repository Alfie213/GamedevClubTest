using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient gradient;

    private HealthBase trackableHealth;
    
    private Slider slider;
    private Image fill;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        fill = GetComponentInChildren<Image>();
    }

    public void SetTrackableHealth(HealthBase health)
    {
        trackableHealth = health;
        trackableHealth.OnHpChange += Handle_OnHpChange;
        trackableHealth.OnDeath += Handle_OnDeath;
    }
    
    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
        slider.value = value;
        fill.color = gradient.Evaluate(1f);
    }

    private void SetHealth(int value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Handle_OnHpChange(int value)
    {
        SetHealth(value);
    }

    private void Handle_OnDeath()
    {
        Destroy(gameObject);
    }
}