using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform saw;

    [SerializeField] private float speed;

    private int direcction = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        saw.position = Vector2.Lerp(saw.position, target, speed * Time.deltaTime);

        float distance = Vector2.Distance(target, saw.position);

        if (distance <= 0.1f)
        {
            direcction *= -1;
        }
    }

    private Vector2 currentMovementTarget ()
    {
        if (direcction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (saw != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(saw.position, startPoint.position);
            Gizmos.DrawLine(saw.position, endPoint.position);
        }
    }
}
