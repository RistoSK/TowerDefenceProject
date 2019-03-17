using UnityEngine;

namespace Resources
{
    public class Resource : MonoBehaviour
    {
        //[SerializeField] Sprite[] sprites;
        [SerializeField] private ResourceData resourceData;

        private int _resourcePoints;
        private float _resourceSpeed;
        private float _resourceLifeTime;
     
        void Start()
        {
            _resourcePoints = resourceData.points;
            _resourceSpeed = resourceData.speed;
            _resourceLifeTime = resourceData.lifeTime;

            Destroy(gameObject, _resourceLifeTime);
        }

        void Update()
        {
            transform.Translate(Vector2.up * _resourceSpeed * Time.deltaTime);
            transform.localScale += new Vector3(0.003f, 0.003f);
        }

        private void OnMouseDown()
        {
            AddResources(_resourcePoints);
            Destroy(gameObject);
        }

        void AddResources(int amount)
        {
            if (FindObjectOfType<ResourceDisplay>() == null)
            {
                Debug.Log("Resource display is missing");
                return;
            }
            FindObjectOfType<ResourceDisplay>().AddResources(amount);
        }
    }
}

