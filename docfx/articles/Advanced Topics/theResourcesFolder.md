# Why The Resources Folder?

The Scriptable Framework, like many other Unity extensions, makes heavy use of the Resources folder. It does this so that the `Resources.LoadAll<T> ()` API can be used to load all objects of a certain type into memory in order to initialise them. 

## Resetting Objects

All objects of `RuntimeObject` type have a `Reset ()` and `Clear ()` method. In the `RuntimeObjectManager` class, you will find that on runtime initialisation (which you can read more about [here](https://docs.unity3d.com/ScriptReference/RuntimeInitializeLoadType.html)) all assets in the resources folder that inherit from RuntimeObject will have their reset method called. In most cases, this just calls the clear method indirectly, but for `ValueItem`s and `ValueList`s that have the option for using custom default values turned on, these objects will assign their custom values to their internal runtime values.

This may be a small bit of code, but thanks to this design choice, the entire workflow of using default values during development is made possible and it's one of the main reasons that **Scriptable Framework** stands out from other development frameworks for Unity.

The same happens with clearing data once exiting playmode. All of this works for your in the background so there's no need to do any configuring to this system. Just install Scriptable Framework into your project and that's it.

In most cases, Unity recommends that you do *not* use the resources folder for development because it generally causes performance issues. Despite this, when it comes to just loading ScriptableObjects, using this folder is totally fine.