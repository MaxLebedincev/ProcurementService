# ProcurementService.API

> Бальные танцы интерфейс серверной части

### Проект работает на:

1. net8.0
2. Entity Framework
3. SQL Server (MS SQL)

### Включает в себя:

- Controllers - точки входа
	- Interaction - объекты взаимодействия с точками входа
- DAL - слой доступа к данным
	- Configurations - конфигурация сущностей таблиц
	- Interfaces 	 - интерфейсы сущностей DAL
	- Repositories 	 - представление таблиц в виде сущностей
	- ApplicationDbContext - контекст приложения
	- UnitOfWork - единица работы (выполняет все операции с бд)
- Domain - домен
	- Entity - сущности таблиц
- Migrations - миграции бд
	- AllSelect  - все select
	- databaseMS - бэкап БД
	- FillData   - заполнение данных
- Service - сервисы
	- Registeration    - регистрация сервисов
	- ExceptionHandler - обработчик ошибок
- Tools - инструменты
	- Security - безопасности
- appsettings 	  - конфигурация приложения
- Scheme_DataBase - схема БД

> [!TIP] 
> Проект использует паттерны: <br />
> [Unit of Work](https://bool.dev/blog/detail/unit-of-work-patterny-obektno-relyatsionnoy-logiki-poeaa) <br />
> [Repository](https://bool.dev/blog/detail/pattern-repozitoriy-poeaa) <br />
