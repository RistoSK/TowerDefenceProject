using UnityEngine;

namespace Defenders
{
    public class DefenderSelecter : MonoBehaviour
    {
        [SerializeField] private Defender defenderPrefab;
        [SerializeField] private DefenderSpawner _defenderSpawner;

        private DefenderSelecter[] defenders;

        private void OnMouseDown ()
        {
            if (_defenderSpawner == null)
            {
                Debug.Log("Defender Spawner has not been assigned");
                return;
            }

            _defenderSpawner.DisableDefenderSelecterColors();

            GetComponent<SpriteRenderer>().color = Color.white;
            _defenderSpawner.SetSelectedDefender(defenderPrefab);
        }
    }
}
