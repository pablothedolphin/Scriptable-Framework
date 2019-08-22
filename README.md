# Scriptable Framework

In this repository you will find the source code, assets and project settings of the Scriptable Framework for Unity app development (Unity 2018.3.11 or newer recommended) along with a DocFX project containing documentation assets and articles.

---

## NOTICE

> The master branch contains our most stable and release with accurate documentation.
> [Documentation can be found here](https://pablothedolphin.github.io/Scriptable-Framework/).

## How To Install

In order to install Scriptable Framework in your project, add the following to the top of your manifest.json file right before the dependencies object. Next, save the file and restart the editor. You should then find the package in the package manager UI which can be installed like any other Unity package. You can even view a list of all previous versions of the framework that are available in our registry.

``` js
"scopedRegistries": [
    {
        "name": "Scriptable Framework Packages",
        "url": "http://35.227.114.200:8080",
        "scopes": [
            "com.open"
        ]
    }
],
```

The manifest.json file can be found under:

"YOUR-PROJECT-FOLDER" > Packages > manifest.json

This needs to be done once for each Unity project you intend to use Scriptable Framework with because new Unity projects are always created with the default manifest.json file for that editor version.

If you can't see the latest version of Scriptable Framework in the package manager UI, it's likely because it supports only a later version of Unity than you are currently using.

---

## Roadmap

> Roadmap is subject to change. Last reviewed 19th of August 2019.

| Version | Defining Feature                  						  				    |
| ------- | --------------------------------------------------------------------------- |
| 2.0     | Decouple RuntimeObjects from Resources folder using a RuntimeObjectDatabase |
| 2.1     | Automatic script and dependancy generation wizard                           |

---

## History

| Version | Defining Feature                  						  				    |
| ------- | --------------------------------------------------------------------------- |
| 1.2     | Added AppVersion API and string types for ValueList and ValueItem  		    |
| 1.1     | Create a menu item to toggle event logging within the editor		        |
| 1.0     | Deploy on an internal npm registry									        |
| 0.10    | Add StateMachineController to control many StateMachines at once            |
| 0.9     | Create scripting API documentation via DocFX and host on gitlab pages       |
| 0.8     | Extracted styling API into its own package							        |
| 0.7     | Provide full unit test coverage for the core Scriptable Framework APIs      |
| 0.6     | Complete Styling API                  	     			  		            |
| 0.5     | Provide icons for the various data and component types                      |
| 0.4     | Extend RuntimeItems and Lists with Reference and Value typing               |
| 0.3     | RuntimeItems added           	     			  				            |
| 0.2     | Upgrade to Unity 2018.3 for nested and variant prefabs         			    |
| 0.1     | RuntimeLists, Event API and Statemachines					 			    |

---

## Contacts

For more information contact:

* Jak Hussain - [GitHub](https://github.com/pablothedolphin), [Email](jak.hussain@arup.com)
* Dean Giddy - [GitHub](https://github.com/DeanGiddy), [Email](dean.giddy@arup.com)
* Conor Galvin - [GitHub](https://github.com/Cvnvr), [Email](conor.galvin@arup.com)