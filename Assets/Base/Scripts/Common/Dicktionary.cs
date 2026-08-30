using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dicktionary is a serializable version of default C# dictionary data type.
// The reason why it is necessary is because 'serializing' a variable
// enables capsulizing the data, being able to be visible from unity inspector
// and thus 'dragging and dropping' data, writing the data from inspector becomes also possible
// However, default C# Dictionary data type doesn't support serialization
// Hence, we need to come up with new version
//
// Below code is taken from https://github.com/GameDevEducation/UnityTutorial_SerializableDictionary/blob/master/Assets/SerializableDictionary/SerializableDictionary.cs
// under MIT licence
//
// Despite the necessity, the new name 'Dicktionary' is obviously not a good name.
// It provides information that it IS indeed a dictionary, however it doesn't
// provide information that this is a new one, only being retarded
// So for now, this name will be used, until I think of something better
// - R3V

// TODO : Find a better name for this class : Dicktionary

[System.Serializable]
public class Dicktionary<KeyType, ValueType> : Dictionary<KeyType, ValueType>, ISerializationCallbackReceiver
{
    public List<KeyType> SerializedKeys = new();
    public List<ValueType> SerializedValues = new();

    public void OnAfterDeserialize()
    {
        SynchroniseToSerializedData();
    }

    public void OnBeforeSerialize() { }

#if UNITY_EDITOR
    public void EditorOnly_Add(KeyType InKey, ValueType InValue)
    {
        SerializedKeys.Add(InKey);
        SerializedValues.Add(InValue);
    }
#endif // UNITY_EDITOR

    public void SynchroniseToSerializedData()
    {
        this.Clear();

        // if we have valid data then build the dictionary
        if ((SerializedKeys != null) && (SerializedValues != null)) 
        { 
            int NumElements = Mathf.Min(SerializedKeys.Count, SerializedValues.Count);
            for (int Index = 0; Index < NumElements; ++Index)
            {
                this[SerializedKeys[Index]] = SerializedValues[Index];
            }
        }
        else
        {
            SerializedKeys = new();
            SerializedValues = new();
        }

        // if the lists are out of sync then rebuild
        if (SerializedKeys.Count != SerializedValues.Count) 
        {
            SerializedKeys = new(Keys);
            SerializedValues = new(Values);
        }
    }
}