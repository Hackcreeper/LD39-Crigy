using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnergyBar : MonoBehaviour
    {
        public Energy energy;

        public RectTransform bar;

        public Text text;

        public RectTransform warning;
        
        private void Update()
        {
            const int maxWidth = 180;
            var maxEnergy = energy.max;
            var current = energy.energy;

            var width = maxWidth / maxEnergy * current;
            var percentage = 100f / maxEnergy * current;

            if (Player.instance.won)
            {
                text.text = "Infinite%";
                width = 180;
            }
            else
            {
                text.text = percentage + "%";
            }
            
            bar.sizeDelta = new Vector2(width, bar.sizeDelta.y);

            warning.gameObject.SetActive(percentage <= 20);
        }
    }
}