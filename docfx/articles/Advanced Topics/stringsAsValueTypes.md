# Strings As Value Types?

Some of you may already be aware that `System.String` is a reference type. But when you go to create a reference list or reference item, the string option is nowhere to be found. Instead, it can be found under value list and value item.

What we've done is define a new struct type called `DataString` which acts as a wrapper around a regular string object. We then wrote some implicit casts, overloads and overrides to make the scripting experience almost identical to using a regular string or collection of strings. Finally, we wrote a custom property drawer so that in the inspector, a DataString will render and behave exactly like a normal string. You can try it for yourself with this example code:

``` cs
using UnityEngine;
using ScriptableFramework;

public class Example : MonoBehaviour
{
    public string myString;
    public DataString myDataString;

    private void Start ()
    {
        myDataString = myString;
    }
}
```

Generally though, you'll never need to directly interact with the DataString type because Scriptable Framework already gives you `StringList` and `StringValue` out of the box. So you can just use normal string objects as you always have without the need to concern yourself with any conversions.

## Limitations

Firstly, ValueList.ToNativeArray() will return a working NativeArray object but it will not be possible to pass a NativeArray of strings or of DataStrings to a C# Job. Unity is working on a NativeString type which is similar in principal to DataString but also threadsafe but it is still in preview and only available in the Entities package at the time of writing.

Also, since DataString is just a wrapper type, it doesn't offer string specific methods like `String.Split ()`. If you want to use these, you'll need to store your DataString in a seperate string variable and then continue working from there. If there's enough demand to change this, we will incorporate those methods into the DataString type.