using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] private TypeColor teleporter;

    public string GetTeleportColor()
    {
        return teleporter.Color;
    }

    public Transform GetDestination()
    {
        return destination;
    }
}
