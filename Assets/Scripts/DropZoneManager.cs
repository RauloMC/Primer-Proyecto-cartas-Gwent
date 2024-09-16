using System.Collections.Generic;
using UnityEngine;

public class DropZoneManager : MonoBehaviour
{
    public List<DropZone> dropZones = new List<DropZone>();

    void Awake()
    {
        // Asegúrate de que solo haya una instancia de DropZoneManager
        if (FindObjectsOfType<DropZoneManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Encuentra y almacena todas las DropZones en la escena actual
        DropZone[] zones = FindObjectsOfType<DropZone>();
        dropZones.AddRange(zones);
    }

    public DropZone FindDropZoneByPlayerAndZoneType(Player player, AttackType zoneType)
    {
        foreach (DropZone zone in dropZones)
        {
            if (zone.player == player && zone.zoneType == zoneType)
            {
                return zone;
            }
        }
        return null;
    }

    public void RegisterDropZone(DropZone dropZone)
    {
        if (!dropZones.Contains(dropZone))
        {
            dropZones.Add(dropZone);
        }
    }

    public void UnregisterDropZone(DropZone dropZone)
    {
        if (dropZones.Contains(dropZone))
        {
            dropZones.Remove(dropZone);
        }
    }
}
