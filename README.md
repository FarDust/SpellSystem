# Simple Spell System 

Simple Spell System is a spell system for unity to make spells using [Scriptable Objects](https://docs.unity3d.com/Manual/class-ScriptableObject.html]) coding Api provided in Unity

## Usage

To use the System you need

- if the spell type doesn't exist create a new scrpit based in some of spells inside `BasicTypes`
- If you need an spell behaviour create inside `ConcreteTypes` inside the function:
```csharp
public override void Cast(Transform parent, Vector3 position, Vector3 direction)
    {
        base.Cast(parent, position, direction);
    }
```
- make and scriptable object containing the info required for the object from create menu in unity.
- Populate the created scriptable object with the required info.
- Create a Controller Script inside `Behaviours` that uses the info inside your new scriptable object and assign it to a prefab you want to spawn when the spell is trigger.
- Add your spell to an SpellBook Scriptable Object, then create a Controller to handle it, you can see some example inside `ActionTriggers`
- Attach a SpellBook controller to an Scene object or prefab

## Contributing
- Pull requests are welcome following ours `CONTRIBUTING.md`
- If you need more details in the Usage section please summit an issue.

## License
[MIT](https://choosealicense.com/licenses/mit/)
