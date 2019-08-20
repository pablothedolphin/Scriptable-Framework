# Reference Items

ReferenceItems are a kind of RuntimeItem that are designed to handle reference types like strings and GameObjects. Below is an example of a GameObjectReference which can be created via "Create > Runtime Objects > Reference > Item > GameObject". All ReferenceItems have a `reference` property which actually contains the reference in question.

![Figure2](~/images/runtimeItems2.png)

There are some limitations with ReferenceItems. It's mainly due to the fact that, in Unity, scene objects can maintain references to assets outside of play mode, but assets cannot maintain references to scene objects outside of play mode. So unless your ReferenceItem is storing a reference to another asset like a prefab, it will not be possible for it to go into play mode with a reference already set. This means you'll need to set the reference yourself during runtime.

However, you can also use these objects to store a direct reference to another asset **instead** of referencing an object in your scene during runtime. To do this, simply drag in your asset reference and be sure to check the `forAssetReferencingOnly` box so that this `RuntimeObject` will ignore all calls for clearing and resetting its data. This will ensure that your reference persists both in and out of playmode. 

This feature is especially useful for referencing a prefab that you need to access in many parts of your code. Naturally, you won't need to use any populators when using these objects in this way.