using UnityEngine;

public static class GameObjectExtentions{

	public static T GetComponentOrAdd<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (component != null) return component;
        else return gameObject.AddComponent<T>();
    }
}
