using UnityEngine;

public class AbstractGameObjectStates : IGameObjectState
{

    protected MonoBehaviour parent;

    public AbstractGameObjectStates(MonoBehaviour parent)
    {
        this.parent = parent;
    }

    public virtual void Update () {}
    public virtual void FixedUpdate() {}
    public virtual void LateUpdate() {}
}
