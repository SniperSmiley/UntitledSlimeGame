using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    //constants
    private const float splineOffset = 1f;
    //fields
    [SerializeField] public SpriteShapeController spriteshape;
    [SerializeField] public Transform[] points;
    //Monobehaviour Callbacks
    private void Awake()
    {
        UpdateVerticies();
    }
    private void Update()
    {
        UpdateVerticies();
    }
    //Private Methods

    private void UpdateVerticies()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 vertex = points[i].localPosition;

            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;

            float colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;

                spriteshape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));



            Vector2 lt = spriteshape.spline.GetLeftTangent(i);

            Vector2 newRt = Vector2.Perpendicular(towardsCenter) * lt.magnitude;

            Vector2 newLt = Vector2.zero - (newRt);

            spriteshape.spline.SetRightTangent(i, newRt);

            spriteshape.spline.SetLeftTangent(i, newLt);
        }
    }
}
