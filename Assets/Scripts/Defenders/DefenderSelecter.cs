using UnityEngine;

namespace Defenders
{
    public class DefenderSelecter : MonoBehaviour
    {
        [SerializeField] Defender defenderPrefab;

        DefenderSpawner _defenderSpawner;
        DefenderSelecter[] defenders;

        void Start ()
        {
            _defenderSpawner = FindObjectOfType<DefenderSpawner>(); 
        }

        void OnMouseDown ()
        {
            if (_defenderSpawner == null)
            {
                Debug.Log("Defender is missing");
                return;
            }

            DisableDefenderSelecterColors();

            GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        }

        public void DisableDefenderSelecterColors()
        {
            defenders = FindObjectsOfType<DefenderSelecter>();

            if (defenders == null)
            {
                Debug.Log("Defenders[] is null");
                return;
            }

            foreach (DefenderSelecter defender in defenders)
            {
                defender.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
            }
        }
    }
}
