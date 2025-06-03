using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    [SerializeField] private string description;
    [SerializeField] private GameObject displayModel;

    public string Description() => description;
    public GameObject DisplayModel() => displayModel;

    public void Inspect(GameObject obj) {
        Instantiate(obj);
    }
}
