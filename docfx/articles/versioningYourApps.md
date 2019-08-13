# Versioning Your Apps

[Semantic Versioning](https://semver.org/) is a really good practice you should stick to in software development. It helps you keep track of progress, identify previous versions and understand the differences between them, convey progress to the client and more. But when trying to add a version number to multiple spots in your interface, it can become tedious updating several text objects sometimes across several scenes.

`AppVersion` is a type of scriptable object in Scripbtable Framework that can make it significantly easier to convey your current version anywhere in your UI. They can be created under "Create > App Version".

![Figure1](~/images/versioningYourApps1.png)

**Note**: You only ever need one instance of this object per project. 

What makes this object special is that you can set your current version number in the inspector and then in your code, just assign the whole object into the text field of your UI. An `AppVersion` **implicitly** casts into a string of the current version number. Here's a demo of how that works.

``` cs
using UnityEngine;
using UnityEngine.UI;
using ScriptableFramework;

public class AppVersionDemo : MonoBehaviour
{
    public Text versionLabel;
    public AppVersion versionNumber;

    void Start()
    {
        versionLabel.text = versionNumber;
    }
}
```

No conversion code is needed. It just does it for you.

What's more is, whenever you update your version number, the version number saved in player settings is also updated for you so even your builds will reflect the current version you specified.

Here is a breakdown of each of the fields you'll find in the inspector:

| Property       | Description  |
|----------------|---|
| Major          | Increase this number when this version of the app is intended to entirely replace the previous version. Can also be used to reflect progress according to your roadmap. |
| Minor          | Represents any notable improvments or additional functionality that is backwards compatible within the current major version or a milestone in a roadmap. |
| Patch          | Indicates any bug fixes or slight improvements that may be done day to day. |
| Release        | The type of release this is intended for. Development for when their is still significant work to be done. Alpha for when the app is released to a small subset of users for testing and feedback. Beta for when the app is considered feature complete but may still have bugs or usability issues. Production is for marking this as a stable product for wider use.  |
| Release Update | Appends a number at the end to mark incremental improvements for alpha and beta releases only.  |