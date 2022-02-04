using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    private Transform mainCam;

    private void Awake()
    {
        mainCam = Camera.main.transform;
        transform.localScale = Vector3.one * 0.005f;
    }

    public void SetUIRotation()
    {
        transform.LookAt(transform.position + mainCam.forward);
        LeanTween.scale(this.gameObject, Vector3.one, 0.2f);
    }
}
