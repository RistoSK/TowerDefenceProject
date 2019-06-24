using Resources;
using UnityEngine;

namespace Defenders
{
    public class DefenderSpawner : MonoBehaviour
    {
        [SerializeField] private DefenderSelecter[] _selectableDefenders;
        [SerializeField] private ResourceDisplay _resourceDisplay;

        private Defender _defender;

        private Vector2 _clickPos;
        private Vector2 _worldPos;
        private Vector2 _gridPos;

        public void SetSelectedDefender(Defender defenderToSelect)
        {
            _defender = defenderToSelect;
        }

       private void OnMouseDown ()
        {
            if (_defender == null)
            {
                Debug.Log("Defender is missing");
                return;
            }

            PlaceDefender(GetSquareClicked());
            
            DisableDefenderSelecterColors();
        }

        private Vector2 GetSquareClicked()
        {
            _clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _worldPos = Camera.main.ScreenToWorldPoint(_clickPos);
            _gridPos = FitToGrid(_worldPos);

            return _gridPos;
        }

        private Vector2 FitToGrid(Vector2 worldPos)
        {
            float newX = Mathf.RoundToInt(worldPos.x);
            float newY = Mathf.RoundToInt(worldPos.y);

            return new Vector2(newX, newY);
        }

        private void PlaceDefender(Vector2 spawnPosition)
        {
            //TODO make more generic
            int defenderCost = _defender.GetResourcesCost();

            if (defenderCost <= _resourceDisplay.GetResourcesAmount())
            {
                _resourceDisplay.RemoveResources(defenderCost);
                Defender defenderToSpawn = Instantiate(_defender, spawnPosition, transform.rotation);
                // De-select the defender from the list so the user has to click it again
                _defender = null;
            }
        }

        public void DisableDefenderSelecterColors()
        {
            foreach (DefenderSelecter defender in _selectableDefenders)
            {
                defender.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
            }
        }
    }
}
