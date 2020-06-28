--Создание таблиц с удаление уже имеющихся
IF OBJECT_ID('Person' ) IS NOT NULL DROP TABLE Person;
CREATE TABLE Person
(
id INT IDENTITY(1,1) NOT NULL,
fam NVARCHAR(256) NOT NULL,
name NVARCHAR(256) NOT NULL,
CONSTRAINT PK_id_Employee PRIMARY KEY (id),
);
--Тестовые данные
DECLARE @count_persons INT = 1000;
DECLARE @i INT = 1;
WHILE @i <= @count_persons
BEGIN
	INSERT INTO Person(fam, name)
	VALUES (CONCAT(N'Тестов', @i),CONCAT(N'Тест', @i));
	SET @i = @i + 1;
END
--Сформированные тестовые данные
SELECT id,fam,name FROM Person;

