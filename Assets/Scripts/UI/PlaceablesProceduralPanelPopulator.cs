using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlaceablesProceduralPanelPopulator : MonoBehaviour
{
    public GameObject exampleGridElement;
    void Start()
    {
        foreach (var(key, value) in PlaceablesDatabase.Instance.PlaceableSOs)
        {
            GameObject clone = Instantiate(exampleGridElement);
            clone.transform.SetParent(exampleGridElement.transform.parent);

            clone.name = key;
            clone.transform.Find("Image").GetComponent<Image>().sprite = value.icon;
            clone.transform.Find("NameHolder").transform.Find("Name").GetComponent<TextMeshProUGUI>().text = key;

            clone.GetComponent<Button>().onClick.AddListener(() => {
                PlaceablesSystem.Instance.ClearCurrentGhostPlaceable();
                PlaceablesSystem.Instance.SetCurrentGhostPlaceable(clone.name);
            });
        }

        Destroy(exampleGridElement);
    }
}
