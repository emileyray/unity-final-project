using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PrizeCanvas : MonoBehaviour
{
    public RectTransform[] images;
    public Transform target;

    private void Start()
    {
        StartCoroutine("Move");
    }
    
    IEnumerator Move(){
        for (int i = 0; i < images.Length; i++)
        {
            Vector3 nextOffset = new Vector3(
                Mathf.Cos(Mathf.PI * i / 5) * 100,
                Mathf.Sin(Mathf.PI * i / 5) * 100,
                images[i].transform.position.z
            );
            images[i].DOMove(images[i].transform.position + nextOffset, 1);
            
            images[i].DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
        }
        
        yield return new WaitForSeconds(1f);
        
        foreach (var image in images)
        {
            image.DOMove(target.position, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
