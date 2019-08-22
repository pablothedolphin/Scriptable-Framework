# Populators

To help support the shortcomings of `ReferenceList`s and `ReferenceItem`s, Populator components have been written to help populate these objects on Awake for you. To add a populator component, you can find it in the component menu under "Scriptable Framework > Populators". Below is an example of a GameObjectListPopulator

![Figure1](~/images/populators1.png)

You can use these components by assigning the ReferenceList or ReferenceItem that you want the component to populate and assining the item(s) you want to populate it. For ReferenceLists populators, the order of the items matter because the same order will be used by the ReferenceList.

Bare in mind that this is purely for when you would like your scene to initialise on Awake with your references set. In other cases where you want to set your references during runtime, you would simply write the code yourself to add elements to your lists or change out your single references. 

## Types of Populators

At the time of writing, Populator scripts are available for:

+ GameObjects
+ Transforms
+ MeshRenderers
+ Animators

And for each of these types, there is a variant for both the ReferenceItem version and the ReferenceList version.