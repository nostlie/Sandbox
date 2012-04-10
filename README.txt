This is a repo to add demo projects. The .gitignore file works for Microsoft solutions and you might have to NuGet some packages to get them to work.

MVCExample1 is a MVC 3 Razor demo project, following a tutorial.
	- Prereqs: MVC 3 framework

PrismNavigationTest is a Silverlight project using the Unity and Prism frameworks along with WCF RIA Services to set up a project. This includes a working navigation framework, domain service call, domain context class, and a configured Unity container with modularity.
	- Prereqs: Silverlight 4, Silverlight 4 SDK, Silverlight 4 Toolkit, Silverlight Tools for VS2010, WCF RIA Services SP1, 
	- Add reference packages: Unity, Prism, Prism.UnityExtensions

MvcWithAutomapper is a MVC 3 Razor project demoing the Automapper <https://github.com/AutoMapper/AutoMapper>
	- Prereqs: MVC 3 framework
	
WcfService1 is a basic working WCF service project that uses the Automapper
	- Prereqs: Automapper.dll in Data project bin

MvcUnitTest is a MVC 3 project demoing Unit Testing using Moq and the Repository Pattern
	- Prereqs: MVC 3, Install Moq

MvcNinject is a MVC 3 project configured to use Ninject for a dependency injection framework and Moq as a object mocking framework
	- Prereqs: MVC 3, Install Ninject, NinjectMVC, Moq and AutoMapper through Nuget

MvcNinjectCars is a MVC 3 project similar to the above MvcNinject, but as a more concrete example. 
	- Prereqs: none, this is ready to run