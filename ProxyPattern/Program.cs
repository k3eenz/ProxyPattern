using ProxyPattern;

RealSubject realSubject = new RealSubject();

Proxy adminProxy = new Proxy(realSubject, "Admin");
Proxy userProxy = new Proxy(realSubject, "User");

Console.WriteLine(adminProxy.Request("Запрос админа"));
Console.WriteLine(adminProxy.Request("Запрос админа"));
Console.WriteLine(userProxy.Request("Запрос юзера"));