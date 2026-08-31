using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TagLayer", menuName = "SO/TagLayerSO")]
public class TagLayerSO : ScriptableObject
{
    [Serializable]
    public struct TagT
    {

    };

    [Serializable]
    public struct LayersT
    {
        public LayerMask player;
        public LayerMask enemy;
        public LayerMask ground;
        public LayerMask firstPersonModel;
    };

    public TagT tags;
    public LayersT layers;
}
