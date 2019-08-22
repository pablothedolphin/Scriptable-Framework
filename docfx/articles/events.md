# Events

The event system of Scriptable Framework, like most other event systems, works by first defining some instance of an event that can be raised or triggered. Other objects like your cameras, interface or AI agents would then **listen** for when the event gets raised. Once the event is raised, the listeners will **respond** by calling some function that is supposed to run when the event is called.

![Figure1](~/images/events1.png)

If you have never used an event API before and have gotten used to referencing other MonoBehaviours in your scenes to call other functions, this process may come across as unnesasary. Just assigning a public reference to your other script and directly calling the function you want through it is much quicker and easier to understand. But doing this **couples** your code.

Tightly coupled code is bloated, messy and hard for other developers to quickly understand, what's worse is, if you want to change something, you may find yourself breaking something else without realising. The image below shows how messy your code references can be.

![Figure1](~/images/events2.png)

## Writing "Wireless" Code

Using events can enable you to to write ClassA to raise some event without any reference to the listeners that would respond to the event. ClassA could even raise an event without any listeners at all! This "wireless" code design is crucial to writing modular code. However, this does force you as a programmer to plan further ahead and write most of your code as if its components were written in isolation from one another so that they can communicate with each other through events.

## When Not To Use Events

Events are very useful tools for when you need to send data to and from a module or to just trigger a bunch of functionality at the same time with a single line. But, like most tools, aren't necessarily best suited for every usecase. Generally, you are free to make "hard references" to other scripts so long as those scripts were specifically designed to work together (like if they are on the same GameObject). 

Without using events, it becomes very difficult to seperate your code from the rest of the application for use else where. So when you decide to intentionally not use an event, it should be because the scripts your are hard referencing are not designed to be seperated from the script that is referencing them. In other words, those scripts when used together, define a whole module and therefore shouldn't be designed to work seperately and link up with wireless programming.