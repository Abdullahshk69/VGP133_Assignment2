using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAnchor : MonoBehaviour
{
    [Header("VARIABLES")]
    
    [SerializeField] float lerpSpeed = 20;

    [Header("POSITIONS")]
    private Transform[] hairParts;
    private Transform hairAnchor;

    public Vector2 partOffset { get; set; }


    private void Awake()
    {
        hairAnchor = GetComponent<Transform>();
        hairParts = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        Transform pieceToFollow = hairAnchor;

        foreach (Transform hairPart in hairParts)
        {
            if(!hairPart.Equals(hairAnchor))
            {
                Vector2 targetPosition = (Vector2) pieceToFollow.position + partOffset;
                Vector2 newPositionLerped = Vector2.Lerp(hairPart.position, targetPosition, lerpSpeed * Time.deltaTime);

                hairPart.position = newPositionLerped;
                pieceToFollow = hairPart;
            }
            
        }
    }
}
