# Test C
Тестовое задание на ASP.NET Core (.NET 6):
Реализовать веб-службу REST API. В качестве БД использовать PostreSQL + EntityFramework Есть несколько сущностей:
1.	Блок обуривания (DrillBlock), поля: DrillBlockId, Name, UpdateDate
2.	Скважина (Hole), поля: HoleId, Name, DrillBlockId, DEPTH
3.	Точки блока (DrillBlockPoints), соединяются последовательно, являются географическим контуром блока обуривания.
4.	Поля: Id, DrillBlockId, Sequence, X, Y, Z
5.	Точки скважин (HolePoints) - координаты скважин. Поля: Id, HoleId, X, Y, Z
Реализовать CRUD для перечисленных сущностей. Данные передаются в формате JSON.
