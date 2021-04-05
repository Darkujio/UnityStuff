using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Gate : MonoBehaviour
{
    public Material Material;
    private MeshRenderer MeshRendererChild;
    private MeshRenderer MeshRendererSelf;
    void Start()
    {
        MeshRendererChild = gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        MeshRendererSelf = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MeshRendererChild.material = Material;
        MeshRendererSelf.material = Material;
    }
}
