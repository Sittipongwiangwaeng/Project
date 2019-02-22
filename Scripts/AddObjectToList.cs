using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectToList : MonoBehaviour {

    public GameObject itemTemplat;

    public GameObject content;

    public void AddButton_Click()
    {
        var copy = Instantiate(itemTemplat);
        copy.transform.parent = content.transform;
        copy.transform.localPosition = Vector3.zero;
    }
}
