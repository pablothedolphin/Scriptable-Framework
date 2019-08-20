# Reference Lists

ReferenceLists are a kind of RuntimeList that are designed to handle reference types like strings and GameObjects. Below is an example of a GameObjectList which can be created via "Create > Runtime Objects > Reference > List > GameObjects". All ReferenceLists have an `items` property which actually contains the references in question.

![Figure2](~/images/runtimeLists2.png)

There are some limitations with ReferenceLists. It's mainly due to the fact that, in Unity, scene objects can maintain references to assets outside of play mode, but assets cannot maintain references to scene objects outside of play mode. So unless your ReferenceList is storing a reference to another asset like a prefab, it will not be possible for it to go into play mode with a reference already set. This means you'll need to set the reference yourself during runtime.

However, you can also use these objects to store direct references to other assets **instead** of referencing objects in your scene during runtime. To do this, simply drag in your asset references and be sure to check the `forAssetReferencingOnly` box so that this `RuntimeObject` will ignore all calls for clearing and resetting its data. This will ensure that your references persist  both in and out of playmode. 

This feature is especially useful for referencing prefabs that you need to access in many parts of your code. Naturally, you won't need to use any populators when using these objects in this way.