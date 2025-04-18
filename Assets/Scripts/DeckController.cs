using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    [SerializeField]
    Transform DirectionMarker;
    [SerializeField]
    GameObject CardPrefab;
    [SerializeField]
    float MinVelocity, MaxVelocity, LerpSpeed;
    Vector3 Direction = Vector3.up + Vector3.right;
    float Velocity  = 7;
    public static DeckController Instance;
    float LerpTimer;
    [SerializeField]
    private float CameraXOffset;
    
    private void Awake()
    {
        XPos = transform.position.x;

        Instance = this;
    }

    void Update()
    {
        GetDirection();
        if (Input.GetMouseButtonDown(1))
        {
            LerpTimer = 0;
            VelocityFillBar.Instance.Activate();
        }
        else if (Input.GetMouseButton(1))
        {
            LerpTimer += Time.deltaTime;
            float t = 0;
            if(LerpTimer <= 1)
            {
                t = LerpTimer;
            }else if (LerpTimer <= 2)
            {
                t = 2 - LerpTimer;
            }
            else
            {
                t = LerpTimer = 0;
            }
            VelocityFillBar.Instance.SetFillAmount(t);
            Velocity = Mathf.Lerp(MinVelocity, MaxVelocity, t);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            VelocityFillBar.Instance.Deactivate();
            ThrowCard();
        }
    }
    float XPos;
    void GetDirection()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Direction = (pos - transform.position).normalized;
        float angle = Vector3.SignedAngle(Vector3.up, Direction, Vector3.forward);
        DirectionMarker.rotation = Quaternion.Euler(0, 0, angle);
        AimAssist.Instance?.SetInitialVelocity(Velocity);
        CameraMovement.Instance?.MoveCamera(transform.position.x + (Direction.x < 0 ? -1 : 1) * CameraXOffset);
    }
    public void ThrowCard()
    {
        GameObject g = Instantiate(CardPrefab, transform.position + Direction * 1, transform.rotation) as GameObject;
        g.GetComponent<CardBehaviour>().FireCard(Direction * Velocity);
        GameManager.Instance?.OnSpawnCard();
    }

    public void Swap(Transform t)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform parent = transform.parent;
        transform.position = t.position;
        transform.rotation = t.rotation;
        transform.parent = t.parent;
        t.position = pos;
        t.rotation = rot;
        t.parent = parent;
        XPos = transform.position.x;
    }
}
