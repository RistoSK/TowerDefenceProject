using UnityEngine;

namespace Resources
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] Sprite[] _sprites;
        [SerializeField] private ResourceData _resourceData;

        private int _resourcePoints;
        private float _resourceSpeed;
        private float _resourceLifeTime;

        private SpriteRenderer _spriteRenderer;
        private int _resourceSpriteAmount;
     
        private void Start()
        {
            int resourceSpriteIndex = Random.Range(0, _sprites.Length);

            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _sprites[resourceSpriteIndex];
            
            _resourcePoints = _resourceData.points;
            _resourceSpeed = _resourceData.speed;
            _resourceLifeTime = _resourceData.lifeTime;

            Destroy(gameObject, _resourceLifeTime);
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector2.up * _resourceSpeed * Time.deltaTime);
            transform.localScale += new Vector3(0.003f, 0.003f);
        }

        private void OnMouseDown()
        {
            AddResources(_resourcePoints);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.sprite = _sprites[1];

        }

        private void AddResources(int amount)
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

