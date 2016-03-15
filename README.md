InterviewPreperation
====================

This repository contains examples and question for Interview preperation.

#Unity vs. MEF: Picking the Right Dependency Injection Manager
Peter Vogel compares both of the Microsoft dependency injection managers/inversion of control containers and comes up with a decision tree for picking the correct one.

By Peter Vogel04/11/2013

I think dependency injection containers make it so much easier to implement designs that include many dedicated objects that I'm not sure I could live without one anymore. Microsoft, though, provides two: the Managed Extensibility Framework (MEF), which is part of the Microsoft .NET Framework, and the Unity Container (Unity), which is available as a NuGet download. While there are also several open source tools available, these are the two that are easiest to add to your project. So the question is: Which should you use?

I've discussed MEF and Unity separately, but it's worthwhile to take the time to discuss what I like about each of them and when to use each. One caveat: Both tools are sufficiently "feature rich" that I'm almost certain to get something wrong. I hope comments on this article will address any glaring errors on my part.

First, an overview: Both tools allow you to define containers that you can load with classes or objects. Once you load a container with classes, both frameworks will instantiate the classes and hand you back the resulting objects. Both frameworks allow you to specify what values are to be passed to constructors or used to set properties and call methods when classes are instantiated. Both containers allow you to control the lifetime of those objects -- allowing you, for instance, to specify that only a single instance of some object is ever to be created (effectively implementing the singleton pattern).

Out of the box, MEF provides the most functionality, but has an implementation that I still think of as "quirky." And, prior to the .NET Framework 4.5, you must add attributes to a class to have it work with MEF -- you can't use MEF with Plain-Old CLR Objects (POCOs). Unity, on the other hand, works in a more obvious and natural way, making it easier to integrate into your application -- and Unity does work with POCOs.

These two statements, however, are simplifications. Unity has at least one feature (interceptions, which I'll discuss more in a moment) that MEF does not, and supports extensions that can allow Unity to pick up some of the MEF-like functionality that it's missing. The latest version of MEF, in the .NET Framework 4.5, supports establishing rules for selecting classes that let MEF work with POCOs. Even with that blurring of the distinctions between the two, there's still a basis for choosing between them.

##Unity vs. MEF: Binding
While both tools allow you to register multiple objects with a container and retrieve a matching object, the way that you retrieve the objects differs between the two frameworks.

With MEF you define one or more properties on a class and specify that those properties are to accept objects selected by MEF. You then call the MEF Compose method to have those properties bound to objects (this is that quirkiness that I mentioned). This feature can be handy if you have a very "composable" class -- one that acquires functionality by binding to several different kinds of objects. However, if what you want to do is retrieve an object from your container to pass to a method or a constructor (or just to use in code), the process is awkward: You must bind your object to a property on a class before you can access the object.

Unity works in a more obvious way: You call a method on the container and it hands back one or more objects. You can then use those objects any way you want, including storing them in some property as MEF does, but you can also just work with the resulting objects in your code or pass the objects to some method. If you need to retrieve several different kinds of objects, you'll have to make a separate call for each object.

##Unity vs. MEF: Containers 
Out of the box, MEF offers more ways to set up containers than Unity does. For instance, with MEF, I can write code to load individual classes into a container. I can also specify that MEF is to search for classes in a specified class library or among the DLLs in a specific folder. I especially like that last option because it lets me upgrade or extend an application just by adding or removing DLLs in the specified folder. I can even combine multiple catalogues into a single search and have MEF look for matching objects in both a class library and a folder.

Out of the box, Unity doesn't offer those options: You either write code to load individual objects into the container or specify the classes to load in an XML file. This difference alone has often caused me to use MEF, despite my affection for Unity. But Unity does support extending the container with additional functionality, and some environments have provided more options for loading objects. As one example, in Windows Presentation Foundation (WPF), Microsoft Prism extends Unity to include many of the search options that MEF offers, including searching DLLs in a folder. If you're working in WPF, you'd be hard-pressed to choose between MEF and WPF unless you need one of their two unique features.

##Unity vs. MEF: Unique Features
For me, the critical difference between the two is the functionality that MEF offers when it comes to selecting objects. With MEF I can assign an unlimited number of attributes to a class as name/value pairs. I can then use LINQ to query the collection of objects to retrieve the object that my application needs using any combination of those attributes. This allows me to set up loosely coupled object hierarchies where an application can look for a class with very specific attributes and, if it doesn't find one, fall back to a more general-purpose class.

With Unity I can assign a single name to an object when I add it to the container … and that's it. This lets me choose between multiple objects based on that single value, but it doesn't offer the flexibility that MEF does. And if I don't find a matching object, Unity throws an exception (with the resulting hit on performance), while MEF just returns nothing.

On the other hand, Unity does offer support for interception, which MEF does not. Many applications have what are called "crosscutting concerns" that apply throughout the application. Security and auditing are two examples. (See Joe Kunk's article, "Aspect-Oriented Programming with PostSharp," for more on the topic). When retrieving an object from the container, Unity allows you to specify interception functions that run automatically before or after method calls on the object. MEF has no equivalent functionality.

##Unity vs. MEF: The Decision Tree
In one scenario, you have no choice: If you don't have access to the source code for the classes that you want to load into your container and you aren't working in the .NET Framework 4.5, you're going to have to use Unity. If you do have access to your class source code or are using the .NET Framework 4.5 with the new MEF support for establishing rules for selecting classes, then you have a more interesting problem.

If you need the flexibility that MEF provides in selecting objects or in loading objects into containers more than you need the Unity interception features, use MEF. If you need all of those features, look for Unity extensions that will provide them (as Prism does in WPF).

If you need the interception features that Unity provides more than you need flexibility in selecting objects or loading containers, use Unity.

The good news is both MEF and Unity are excellent tools, so neither is a bad choice. The bad news is, three months after picking one, you'll run into a problem that would've been easier to solve with the other tool.

##About the Author
Peter Vogel is a system architect and principal in PH&V Information Services. PH&V provides full-stack consulting from UX design through object modeling to database design. Peter tweets about his VSM columns with the hashtag #vogelarticles. His blog posts on user experience design can be found at http://blog.learningtree.com/tag/ui/. 
