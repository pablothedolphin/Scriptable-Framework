# Modular Scene Loading

When developing a large application, you may find yourself breaking up your user interface into different scenes with their own purposes. And to load into a different scene, the easiest way to do that is to just call `SceneManager.LoadScene (0)` by or `SceneManager.LoadScene ("My Scene Name")` where you can pass a number for the index of your scene in build settings or the string of the scene file name.

Working this way is fine in small scales but things can become clunky when you have many scenes you need to load between. Scene index orders can change and so can their file names. It is for this reason that Scriptable Framework includes `SceneAsset`s which can let you store a reference to the scene asset itself without needing to hard code its name or index.

![Figure1](~/images/modularSceneLoading1.png)

The image above shows what the object type looks like in the inspector. Like with everything eles in Scriptable Framework, you can just drag and drop your scene files into the variables you choose to reference them by. A helpful error icon aswel as a popup dialog will appear if your scene being referenced isn't in your build settings (which prevents switching to your new scene as per how Unity was designed).

Here is an example of how to use scene references:

``` cs
using UnityEngine;
using ScriptableFramework;

public class Example : MonoBehaviour
{
    public SceneAsset myScene;

    public void ButtonClickFunction ()
    {
        myScene.LoadScene ();	
    }
}
```

As you can see, you can use a `SceneAsset` like any other object type. This gives you the flexibility to even work with an array of scenes if you needed to group certain scenes together. Loading a given scene through a scene reference is as simple as calling `LoadScene ()` on the object itself. Nothing else to it.

You can also load scenes acynchronously with the `LoadSceneAsync ()` method if your scene is particularly large. It returns an `AsyncOperation` which you can learn more about [here](https://docs.unity3d.com/ScriptReference/AsyncOperation.html).

In most cases you may find yourself not needing this handy little object type, but its good to familiarise yourself with this so that later on, you can take advantage of this feature and manage larger projects much more easily. Starting off a project using SceneAssets will also ensure that your project is that much more scalable and testable in the long run.

Credit to [Ryan Hipple](https://github.com/roboryantron).