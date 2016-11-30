using System.Collections.Generic;

class Entity
{
    List<Component> components = new List<Component>();

    public void AddComponent(Component component)
    {
        component.Container = this;
        components.Add(component);
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (Component component in components)
            if (component.GetType().Equals(typeof(T)))
                return component as T;
        return null;
    }

    public void Update()
    {
        foreach (Component component in components)
            component.Update();
    }
}

