Deep is an `Object Oriented` `Entity Component System` for the Unity game engine.

Deep is **not** mega-performant, data-oriented, burst-compiled, multithreaded, cache-optomizied.....

Deep is designed for ease of content creation, re-useability, and simplicity.

> Its basically like monoBehaviors, but you do it all in C# instead of the inspector.

---

This project is WIP. Here is an example of defining an entity:

```csharp
//an entity is defined as a "template" which can be used to instantiate
public static EntityTemplate ExampleEnemy()
{
    EntityTemplate t = BaseEntity();

    //attributes are floats that drive entity behavior and can be modified by behaviors
    t.attributes[D_Attribute.MoveSpeed] = new A(Random.Range(20f, 40f));
    t.attributes[D_Attribute.MaxMoveSpeed] = new A(Random.Range(20f, 40f));

    //behaviors are like monoBehaviors 
    t.behaviors = new DeepBehavior[]{
        new MoveTowardsPlayer(),
        new AvoidOtherEntities(D_Team.Enemy,D_EntityType.Actor,60f),
        new VFXOnDeath(
            new VFX.Sparks(new Color(1f,.256f,.256f),5),
            new VFX.SquarePop(new Color(1f,.256f,.256f),5f,.2f)
        ),
    };

    t.team = D_Team.Enemy;
    t.type = D_EntityType.Actor;

    return t;
}
```
