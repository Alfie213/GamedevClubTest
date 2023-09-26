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
        trackableHealth.OnHpChange += SetHealth;
    }
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    private void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}