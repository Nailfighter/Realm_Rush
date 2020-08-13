using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[ExecuteInEditMode]
[SelectionBase]
public class Editor_Modifier : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] float snap_size;
    TextMeshPro coordinate_textmesh;
    private void Update()
    {
        Vector3 Snap_Grid;
        Snap_Grid.x = Mathf.RoundToInt(transform.position.x / snap_size) * snap_size;
        Snap_Grid.z = Mathf.RoundToInt(transform.position.z / snap_size) * snap_size;
        transform.position = new Vector3(Snap_Grid.x, 0f, Snap_Grid.z);

        coordinate_textmesh = GetComponentInChildren<TextMeshPro>();
        coordinate_textmesh.text = Snap_Grid.x + "," + Snap_Grid.z;

    }
}
