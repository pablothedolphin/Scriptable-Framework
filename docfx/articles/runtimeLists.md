# Runtime Lists

A RuntimeList is a type of RuntimeObject designed to store multiple **references** or **values** that are meant to be accessed and shared accross more than one GameObject in a scene or across more than one scene.

These objects extend upon the `List<T>` class in C# and can act as a 1 to 1 replacement for anything in your existing code already using a list. This includes everything from getting the total number of elements with `RuntimeList.Count` to accessing a specific element with `RuntimeList[index]`.

RuntimeLists are heavily influenced by the differences between reference types and value types. You can learn more about reference and value types in C# [here](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types).

**NOTE:** RuntimeLists will globally reset themselves to their default state on application start/when you hit the play button. However, this does not happen when changing scenes during runtime.