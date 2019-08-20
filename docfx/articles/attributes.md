# Attributes

Scriptable Framework also comes with a couple of attributes that can help you get more out of your inspector by easily extending it for your script:

![Figure1](~/images/attributes1.png)

The image above shows an example of what your inspector can look like when using these attributes.

The first is the `SearchableEnumAttribute` which, when added to an exposed enum variable, will alter how the options for the enum get rendered and even add a scroll bar and search field to help you find your desired value!

The second attribute is the `FoldoutAttribute` which can be used similarly to Unity's `HeaderAttribute` (which you can learn more about [here](https://docs.unity3d.com/ScriptReference/HeaderAttribute.html)). What makes this different to headers is that it can wrap one or many variables into a collapsable fold out. This is great for inspectors that grow to have several exposed variables and end up forcing you to scoll down to the variable you wish to access.

Here is an example of how to use them:

``` cs
using UnityEngine;
using ScriptableFramework;

public class AttributeDemo : MonoBehaviour
{
    public KeyCode keyInput;

    [SearchableEnum]
    public KeyCode searchableKeyInput;

    [Foldout ("String variables", true)]
    public string text1;
    public string text2;

    [Foldout ("Foldout for one")]
    public string text3;
}
```

Credit to [Dimitry](https://github.com/dimmpixeye) and [Ryan Hipple](https://github.com/roboryantron) as the original authors of these attributes.