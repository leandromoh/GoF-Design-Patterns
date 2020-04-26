Bridge: Decouple an abstraction from its implementation so that the two can vary independently.
https://blog.usejournal.com/design-patterns-a-quick-guide-to-bridge-pattern-9ebf6a77baed
https://fpierin.wordpress.com/2011/08/02/explorando-os-beneficios-do-uso-do-design-pattern-bridge/

void Main()
{
    MoveLogic crawl = new Crawl();
    MoveLogic walk = new Walk();
    MoveLogic swim  = new Swim();

    Animal fish = new Fish(swim);
    fish.Move(); // swimming

    Animal person = new Person(crawl);
    person.Move(); // crawling

    person = new Person(walk);
    person.Move(); // walking

    person = new Person(swim);
    person.Move(); // swimming
}