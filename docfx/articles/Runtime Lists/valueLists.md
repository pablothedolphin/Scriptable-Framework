# Value Lists

ValueLists are a kind of RuntimeList that are designed to handle value types like floats, Vector3s and bools. Below is an example of an IntList which can be created via "Create > Runtime Objects > Value > List > Ints". All ValueLists have an `items` property which actually contains the values in question.

![Figure1](~/images/runtimeLists1.png)

In addion to the items it hols, there are some editor propeties that are immune to the global reset effect.

1. The `Custom Default Values` is an optional property that can be used to determine what the internal list should reset to on application start/on entering play mode.
2. The `Use Custom Default Values` is an optional toggle that will determine whether or not the internal list will reset to zero or reset to your custom default value.

Custom default values are a great way to test an unfinished interaction between your scripts. Usually when data is shared, one script will read from some file or database and store the results in a variable while the other script was written to read that variable and do stuff with it. With ValueLists and their custom default values, you don't need the database reading code immediately, you can just simulate that the database was already read from because your other script is only aware of your ValueList and the values provided to it. The values being some custom default values or the real values doesn't matter anymore.