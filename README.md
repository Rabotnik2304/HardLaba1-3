# HardLaba1-3
Лаба 1
Создайте новый solution в visual studio, тип Console Application. Создайте на GitLab новый репозиторий и подключите свой solution к этому репозиторию.
Нужно разработать программу по ведению библиотеки. В библиотеке есть книги за чьим-то авторством, названием и годом издания. Также у книги известно, в шкафу с каким номером и на какой полке она стоит. Книги могут брать читатели, о которым известно их ФИО и уникальный номер читательского билета. Известно кто какую книгу когда взял и когда вернул.
Разработайте схему базы данных, заполните примером данных. Схема хранится в отдельных файлах в формате json, данные в других файлах в формате csv.
Затем спроектируйте классы, которые позволили бы отражали структуру БД. Создайте объекты этих классов, проинициализировав их тестовыми данными.

Лаба 2
Заполнять тестовые данные в коде, т.е. создавать объекты с предзаданными значения - нежизнеспособно. Данные уже есть в текстовых файлах, оттуда их нужно извлечь.
Во-первых, при старте программы добавьте проверку, что данные в csv файлах не содержат ошибок и соответствуют схеме БД, описанной в json файлах. Кол-во столбцов должно совпадать, тип данных в каждом столбце не должны соответствовать типу столбца - это значит, что если в схеме БД, указано, что столбец имеет тип int, то в файле с данными не может быть в этом столбце записана строка.
Если проверка неуспешна, тюкю файлы с данными содержат ошибки, выведите соответствующее сообщение: что не совпало, какой столбец не совпал по данным и т.д.
Если проверка успешна, то считайте данные из файлов в объекты классов. Для провереки, что данные считаны корректно, выведите на экран список всех книг. Если книга у кого-то на руках, то напишите его имя и когда книгу взяли.

Лаба 3
Теперь сделайте красивое форматирование вывода на экран информации. Плохой пример оформления вывода:

Автор | Название | Читает | Взял
|----|------|----
Толстой | Война и мир | Иван И. | 01.08.2022
Достоевский | Преступление и наказание |  |


Такую таблицу тяжело анализировать человеку. Поэтому ее нужно форматировать, например, вот так:

| Автор       | Название                 | Читает  | Взял       |
| ----------- | ------------------------ | ------- | ---------- |
| Толстой     | Война и мир              | Иван И. | 01.08.2022 |
| Достоевский | Преступление и наказание |         |            |


Обратите внимание, что ширина столбца подгоняется под самую длинную строку, чтобы таблица не выглядела "лесенкой".
