using Unity.Entities;
public struct Health : IComponentData
{
    public int Value;
    public int MaxValue;
    public bool CanOverheal;
}