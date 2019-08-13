# Hello World Example

In this example we will use regular and generic events to print "Hello World". Exciting I know.

## Code

To start things off, create a new C# script called `HelloWorld` and paste the following code into it:

``` cs
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public void SayHelloWorld ()
    {
        Debug.Log ("Hello World");
    }

    public void SayHelloWorldManyTimes (int count)
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log ("Hello World " + i.ToString ());
        }
    }
}
```

For a second script, call it `EventRaiser` and paste the following code into it:

``` cs
using UnityEngine;
using ScriptableFramework;

public class EventRaiser : MonoBehaviour
{
    public AppEvent regularEvent;
    public IntEvent genericEvent;
    public bool raiseRegular = true;
	
    private void Start()
    {
        if (raiseRegular)
        {
            regularEvent.RaiseEvent ();
        }
        else
        {
            genericEvent.RaiseEvent (5);
        }
    }
}
```

## Events

Next, create a folder called Resources and create both an AppEvent and IntEvent inside of it. A few things to note here are that we included the `Scriptable Framework` namespace at the top, we have public references to our events so that they can be assigned with a drag and drop and that the generic event is being raised with a number being passed through it.

## Scene

Finally, create 3 empty GameObjects in your scene:

1. On the first one, attach your `HelloWorld` script and call it "Hello World".
2. On the second one, attach your `EventRaiser`, assign your two event objects to its public variables and call it "EventRaiser".
3. On the last one, attach both an `AppEventListener` and an `IntEventListener`, assign your two event objects to their public variables and call it "Listener".

Like on a canvas button's OnClick event, add one response to both listener components and drag your Hello World object into both. For the `AppEventListener`, assign `HelloWorld.SayHelloWorld ()` as the response. For the `IntEventListener`, assign `HelloWorld.SayHelloWorldManyTimes ()` as a **Dynamic int** and not a static parameter.

The final result should look like this:

![Figure1](~/images/eventsHelloWorld1.png)

Now when we go into play mode, depending on the current value of the bool on our Event Raiser, we should see either 1 or 5 prints in the console window. Without code you can also manually raise either event or manually trigger either listener with the buttons provided to control the effect yourself. Additionally, you can set the Value For Manual Trigger on either your IntEvent or IntEventListener to to pass your own number to the for loop for testing purposes.

You can use this process to allow different parts of your code to function without any direct reference to each other, making it significantly easier for someone else to add, remove or edit your code.