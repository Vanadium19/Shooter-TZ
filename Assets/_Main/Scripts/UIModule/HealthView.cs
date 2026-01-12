using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetHealth(float fillAmount) => image.fillAmount = fillAmount;
    }
}