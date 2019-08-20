# Extending The Framework

Sometimes you need to work with data types or functionality that Scriptable Framework doesn't offer out of the box. Or you need a certain part of the framework to do more than it already offers to suit your specific needs. It's called "Scriptable" for a reason. Using inheritence, you can extend the class types that come with Scriptable Framework and override almost any method of your choosing because most of them are virtual. This is also true for any modules developed to be used with the framework. The code was written with flexibility in mind so that you as a developer can shape it the way you need it to be. Overriding methods is also a good way to work around any small bugs you may discover while using Scriptable Framework.

## To Contribute Or Not To Contribute?

When extending the framework with your own types, you would usually keep their source code within the assets folder for your project because they would normally only be applicable to your project. In the event that you feel your extension should be included in the main code base for Scriptable Framework, feel free to create your own branch on the repo with your changes/additions and submit a pull request. Our team will review the changes and contact you if we have any questions. This is also true for bug fixes or any completely new functionality.

## Create Your Own RuntimeItems and RuntimeLists

Creating your own RuntimeItem or RuntimeList is really easy. Just duplicate the source code for one of the existing types, open it and replace any references to the current type to your new type. Note that you should ensure your value types inherit from `ValueItem` or `ValueList` and your reference types inherit from `ReferenceItem` or `ReferenceList`.

Below is an example of where your changes need to be made for your own ValueItem where "MYTYPE" stands for the type of your choice:

*Custom ValueItem*
``` cs
using UnityEngine;
using ScriptableFramework;

[CreateAssetMenu (menuName = "Runtime Objects/Value/Item/MYTYPE")]
public class MYTYPEValue : ValueItem<MYTYPE>
{

}
```

## Create Your Own Events

Creating your own event types is a bit more involved but not by much. You'll just need to create your own event type, your own listener type and your own response type which you can duplicate from the existing source code.

Below are examples of where your changes need to be made for all three scripts where "MYTYPE" stands for the type of your choice:

*Custom Event*
``` cs
using UnityEngine;
using ScriptableFramework;

[CreateAssetMenu (menuName = "Runtime Objects/Events/MYTYPE Event")]
public class MYTYPEEvent : AppEvent<MYTYPE>
{

}
```

*Custom Listener*
``` cs
using UnityEngine;
using ScriptableFramework;

[AddComponentMenu ("Scriptable Framework/Event Listeners/MYTYPE Event Listener")]
public class MYTYPEEventListener : AppEventListener<MYTYPE>
{

    public MYTYPEEvent MYTYPEEvent;

    public MYTYPEResponse MYTYPEResponse;

    private void Awake ()
    {
        Event = MYTYPEEvent;
        Response = MYTYPEResponse;
    }

    public override void SetInternalEventAndResponse ()
    {
        Event = MYTYPEEvent;
        Response = MYTYPEResponse;
    }
}
```

*Custom Response*
``` cs
using UnityEngine;

[System.Serializable]
public class MYTYPEResponse : UnityEvent<MYTYPE>
{

}
```