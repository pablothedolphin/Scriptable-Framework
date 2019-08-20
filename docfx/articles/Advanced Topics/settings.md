# Settings

Once Scriptable Framework is added to your project, a new menu item will appear in the top left corner of the editor:

![Figure1](~/images/settings1.png)

This menu contains some useful settings that allow users control what the framework does and how it behaves at the editor level.

## Editor Event Logging

The first option is a global toggle for event logging in Scriptable Framework. By default, this value is turned off, but to assist with understanding the dominos of events you may have triggering in your app, you can enable event logging so that in the console, logs will appear describing which event got triggered, where it got called and if there was a value passed with it, what the value was. This can be extremely useful if you're trying to debug some unexpected behaviour and are having trouble understanding the execution order of events.

## Reset All RuntimeObjects

Manually, you can choose to call the reset method of all of your RuntimeObjects both in and out of playmode. In most cases this just clears the data, but with `ValueItem`s and `ValueList`s this editor function can be a great way to globally reinitialise your data back to their custom default values without needing to write code for it.

## Clear All RuntimeObjects

Similarly to resetting all data, this function calls the clear method on all your RuntimeObjects. This is called automatically when exiting runtime anyway, but having this available to you in the editor offers that added bit of convenience during development.