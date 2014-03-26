# Dependency Injection #

Demo application for my presentation on Dependency Injection at CoderCamp 18 in Hamilton, ON.

The presentation is [available here](https://drive.google.com/file/d/0B8OyBgym9Nl7THRuRGphanNXOHc/edit?usp=sharing).

## Terms ##

- **Dependency Inversion** – A design principal that high level modules should not depend on low level modules, but both should depend on abstractions
- **Inversion of Control** – A design pattern where objects are coupled at run-time rather than compile time
- **Dependency Injection** – One form of IoC where functionality is passed into an object through constructors or parameters

## Advantages ##

- Makes adapting to changing requirements easier
- Makes unit testing much easier
- New functionality can be plugged in
- Applications can be composed from smaller modules
- Promotes loose coupling between modules

## Disadvantages ##

- Code can be hard to follow
- Run-time errors instead of compile-time errors
- Programming to the least common denominator
- Possible performance issues

## Useful Links ##

- [Martin Fowler’s paper on the Dependency Inversion Principle](http://www.objectmentor.com/resources/articles/dip.pdf)
- [Castle Windsor](http://www.castleproject.org/projects/windsor/)
- [StructureMap](http://structuremap.sourceforge.net/)
- [Spring.net](http://www.springframework.net/)
- [Autofac](http://code.google.com/p/autofac/)
- [Unity](http://codeplex.com/unity)
- [Ninject](http://ninject.org/)
- [Funq](http://funq.codeplex.com/)
