using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private float _timeDuration;

    [SerializeField]
    private float _threadTimeDuration;

    private Color _newColor;
    private int _countChildren;
    public void Recoloring()
    {
        _countChildren = transform.childCount;
      
        _newColor = Random.ColorHSV();
        
        StartCoroutine(ChangeColorCoroutine());
    }
    private IEnumerator ChangeColorCoroutine()
    {

        for (int i = 0; i < _countChildren; i++)
        {
            var startColor = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
            var currentTime = 0f;
            while (currentTime < _timeDuration)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color =
                    Color.Lerp(startColor, _newColor, currentTime / _timeDuration);

                currentTime += Time.deltaTime;
            }
            currentTime = 0;
            yield return new WaitForSeconds(_threadTimeDuration);
        }
    }
}
