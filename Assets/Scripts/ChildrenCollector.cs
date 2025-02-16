using UnityEngine;

public class ChildrenCollector : MonoBehaviour
{
    public Transform[] Childrens { get; private set; }

    public void CollectChildren()
    {
        Childrens = GetComponentsInChildren<Transform>();
    }
}