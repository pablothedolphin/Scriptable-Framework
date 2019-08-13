# Event Listeners

An event listener, in the context of Scriptable Framework, is a component that you put on the GameObjects in your scene that are supposed to respond to an event. You can find these components under "Scriptable Framework > Event Listeners" or just search "listener" as you add a component.

![Figure1](~/images/eventListeners1.png)

## App Event Listeners

AppEventListeners are the simplest and most basic types of listeners you will use. Here is an example of a GameObject with one attached:

![Figure2](~/images/eventListeners2.png)

Using the Event field, you can drag and drop an event of your choosing for the component to listen to. In the example above, the component will only accept instances of type AppEvent.

The box below the Event field will be very reminicent of Unity's canvas UI components. Just like with a button, toggle or slider, you can add references to the MonoBehaviour scripts in your scene and select a function to be triggered by the listener.

Listeners will trigger their responses once the event they are listening to is raised or, if you haven't written that code yet, you can simulate the method call by clicking the button shown above while in play mode. Triggering responses via raised event or manually with the provided button will call each of the responses on the listener.

Manually triggering responses with the button in the inspector allows you to test your code without having all of it completely written. It also gives you the freedom to experiment with what would happen if a response were to trigger during a certain unexpected usecase without writing the code for it first.

Event listeners are very useful tools in your development. But more often than not, you'll want your listeners to pass along some data for your response functions to use. This is where the other listener types come into play.

## Generic Event Listeners

When adding a listener component, every other option you see that isn't an AppEventListener is a generic event listener. You can read more about C# generics [here](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/). 

In short, these other event listener components still behave like an AppEventListener does but with some added quirks that also allow them to pass along some value to the responses you've assigned. The name of the component is a hint at what data type it is made to pass along. For example, a FloatEventListener can pass a single float value along to its responses.

![Figure3](~/images/eventListeners3.png)

In the inspector you will find, in addition to the things found on an AppEventListener, a "Value For Manual Trigger". You can adjust this value so that when pressing the "Trigger this response" button, your specified value will be what's passed to the listeners. The value for manual trigger is only ever used for this purposed and has no other effect on the listener itself.

## Organising Listeners in Your Scene

When a single GameObject needs to respond to lots of different events, it can get quite messy to attach all your listener components for each different event on the same object. To avoid this, You can simply attach your listener components to some other empty GameObject and name it something like "Listeners for X". 