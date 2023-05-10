using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private float _spawnTime;

    private void Awake()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                var cube = Instantiate(_prefab, new Vector3((j / 2f) - 3, -1 * ((i / 2f) - 4.75f), 0), Quaternion.identity, transform);
                yield return new WaitForSeconds(_spawnTime);
            }
        }
    }
}
