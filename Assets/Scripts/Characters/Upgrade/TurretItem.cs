using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretItem : MonoBehaviour
{
    [SerializeField] private float SpeedAnim = 2f;
    private Vector3 UpPos;
    private void Awake()
    {
        transform.DORotate(new Vector3(0,360,0), SpeedAnim * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        UpPos = transform.position;
        UpPos.y += 0.2f;
        transform.DOMove(UpPos, SpeedAnim * 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DOTween.KillAll();
            Destroy(gameObject);
        }    
    }
}
