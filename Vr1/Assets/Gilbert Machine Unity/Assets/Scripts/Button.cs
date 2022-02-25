using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private float Threshold = 0.1f;
    [SerializeField] private float DeadZone = 0.025f;

    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    private void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if(!isPressed && GetValue() + Threshold >= 1)
        {
            Pressed();
        }

        if (isPressed && GetValue() - Threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        float value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < DeadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        Debug.Log($"Pressed button");
        OnPressed.Invoke();
    }

    private void Released()
    {
        isPressed = false;
        Debug.Log($"Released button");
        OnReleased.Invoke();
    }
}
