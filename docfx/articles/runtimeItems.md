# Runtime Items

A `RuntimeItem` is a type of RuntimeObject designed to store a single **reference** or **value** that is meant to be accessed and shared accross more than one GameObject in a scene or across more than one scene.

`RuntimeItem` are heavily influenced by the differences between **reference** types and **value** types. You can learn more about reference and value types in C# [here](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types).

**NOTE:** RuntimeItems will globally reset themselves to their default state on application start/when you hit the play button. However, this does not happen when changing scenes during runtime.