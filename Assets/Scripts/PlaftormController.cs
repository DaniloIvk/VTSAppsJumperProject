using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaftormController : MonoBehaviour
{

    [SerializeField] private float _platformXOffset = 0;

    [SerializeField] Transform _resetGameTransform = null;

    private float _platformYOffset = -0.3f;

    [SerializeField] private GameObject[] _platformTypes;

    private IList<GameObject> _platforms;

    void Start()
    {
        _platforms = _platformTypes.ToList<GameObject>();

        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Platform"))
        {

            SpawnPlatform();
            Destroy(collision.gameObject);
            var newResetPositionY = _resetGameTransform.position.y + 4;
            var newResetPosition = new Vector2(0f, newResetPositionY);
            _resetGameTransform.position = newResetPosition;

        }

    }

    private void SpawnPlatform()
    {
        if (_platforms.Count == 4 && PlayerPrefs.GetFloat("height") > 250f)
            _platforms.RemoveAt(0);
        if (_platforms.Count == 3 && PlayerPrefs.GetFloat("height") > 1000f)
            _platforms.RemoveAt(2);

        var platformIndex = Random.Range(0, _platforms.Count);
        GameObject currentPlatform;

        currentPlatform = Instantiate(_platforms[platformIndex]);

        var positionX = Random.Range(-_platformXOffset, _platformXOffset);

        currentPlatform.transform.position = new Vector2(positionX, _platformYOffset);
        _platformYOffset += 4;
    }
}
