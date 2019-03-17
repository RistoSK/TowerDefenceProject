using UnityEngine;
using UnityEngine.UI;

namespace Resources
{
    public class ResourceDisplay : MonoBehaviour
    {

        [SerializeField] private int resourceAmount = 100;

        private Text _resourceAmountText;

        void Start ()
        {
            _resourceAmountText = GetComponent<Text>();
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            _resourceAmountText.text = resourceAmount.ToString();
        }

        public void AddResources(int amount)
        {
            resourceAmount += amount;
            UpdateDisplay();
        }

        public void RemoveResources(int amount)
        {
            if (resourceAmount - amount < 0) { return; }

            resourceAmount -= amount;
            UpdateDisplay();
        }

        public int GetResourcesAmount()
        {
            return resourceAmount;
        }
    }
}
