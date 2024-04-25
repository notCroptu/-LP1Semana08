```mermaid
classDiagram
    abstract class Animal{
    }
    class Bat{
    }
    class Bee{
    }
    class Cat{
    }
    class Dog{
    }

    Animal <|-- Bat
    Animal <|-- Bee
    Animal <|-- Cat
    Animal <|-- Dog

    <<interface>> IMammal{
    }
    <<interface>> ICanFly{
    }

    IMammal <|.. Bat
    IMammal <|.. Cat
    IMammal <|.. Dog

    ICanFly <|.. Bat
    ICanFly <|.. Bee
```