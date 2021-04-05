using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MaterialPresenter : MonoBehaviour
{
    public MaterialHandler[] Indexes;

    void Update()
    {
        foreach (MaterialHandler Index in Indexes)
        {
            foreach(CarIndex IndexedCar in FindObjectsOfType<CarIndex>())
            {
                if (IndexedCar.CarMultIndex == Index.Index)
                {
                    IndexedCar.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = Index.CarMaterial;
                    IndexedCar.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = Index.CarMaterial;
                }
            }
            foreach(Opener Opener in FindObjectsOfType<Opener>())
            {
                if (Opener.GateIndex == Index.Index)
                {
                    Opener.gameObject.GetComponent<Gate>().Material = Index.GatesMaterial;
                }
            }
        }
    }
    void Start()
    {
        if (Application.isPlaying) Destroy(this);
    }
}
