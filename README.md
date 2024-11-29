## Разработка веб-приложений с использованием технологии ASP.NET Core. Модуль 2. Inversion of Control. Dependency Injection. Часть 3.

 Задание 1

 Создайте класс Заметка. В нём нужно хранить такую  
информацию:

 ■ Название заметки;

 ■ Текст заметки;

 ■ Дата создания заметки;

 ■ Теги.

 Реализуйте необходимые методы и поля. Реализуйте вывод информации на экран и в файл. Используйте 
паттерн MVC в коде этой программы.

---

###  Установка необходимых пакетов

- Autofac для Dependency Injection: 

`dotnet add package Autofac.Extensions.DependencyInjection`

- System.Text.Json для работы с JSON:

 `dotnet add package System.Text.Json`

- System.Xml для работы с XML: 

`dotnet add package System.Xml`
