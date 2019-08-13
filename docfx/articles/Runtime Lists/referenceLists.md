# Reference Lists

ReferenceLists are a kind of RuntimeList that are designed to handle reference types like strings and GameObjects. Below is an example of a GameObjectList which can be created via "Create > Runtime Objects > Reference > List > GameObjects". All ReferenceLists have an `items` property which actually contains the references in question.

![Figure2](~/images/runtimeLists2.png)

There are some limitations with ReferenceLists. It's mainly due to the fact that, in Unity, scene objects can maintain references to assets outside of play mode, but assets cannot maintain references to scene objects outside of play mode. So unless your ReferenceList is storing a reference to another asset like a prefab, it will not be possible for it to go into play mode with a reference already set. This means you'll need to set the reference yourself during runtime.