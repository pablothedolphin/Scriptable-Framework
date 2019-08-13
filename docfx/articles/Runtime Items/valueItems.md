# Value Items

ValueItems are a kind of RuntimeItem that are designed to handle value types like floats, Vector3s and bools. Below is an example of an IntValue which can be created via "Create > Runtime Objects > Value > Item > Int". All ValueItems have a `value` property which actually contains the value in question.

![Figure1](~/images/runtimeItems1.png)

In addion to the value, there are some editor propeties that are immune to the global reset effect.

1. The `Custom Default Value` is an optional value that can be used to determine what the value property should reset to on application start/on entering play mode.
2. The `Use Custom Default Value` is an optional toggle that will determine whether or not the value property will reset to zero or reset to your custom default value.

Custom default values are a great way to test an unfinished interaction between your scripts. Usually when data is shared, one script will read from some file or database and store the results in a variable while the other script was written to read that variable and do stuff with it. With ValueItems and their custom default values, you don't need the database reading code immediately, you can just simulate that the database was already read from because your other script is only aware of your ValueItem and the value provided to it. It being a default value or the real value doesn't matter anymore.