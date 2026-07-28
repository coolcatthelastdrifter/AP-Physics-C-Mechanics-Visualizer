using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBody : MonoBehaviour
{
    public ThreeBody[] others;

    public float mass = 1f;
    public Vector2 velocity;

    public float gravityStrength = 1f;

    void Update()
    {
        Vector2 acceleration = Vector2.zero;

        foreach (ThreeBody other in others)
        {
            Vector2 direction = (Vector2)other.transform.position - (Vector2)transform.position;

            float distance = direction.magnitude;

            // Prevent explosion at close range
            distance = Mathf.Max(distance, 0.5f);

            float force = gravityStrength * other.mass / (distance * distance);

            acceleration += direction.normalized * force;
        }

        velocity += acceleration * Time.deltaTime;

        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}
