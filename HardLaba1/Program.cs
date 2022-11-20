﻿using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HardLaba1
{
    public class Reader
    {
        public uint Id;
        public string FullName;
    }
    public class Book
    {
        public uint Id;
        public string Author;
        public string Name;
        public DateTime PublicationDate;
        public uint BookcaseNumber;
        public uint ShelfNumber;
    }
    public class Statistic
    {
        public uint Id;
        public Reader Reader;
        public Book Book;
        public DateTime TakeDate;
        public DateTime ReturnDate;
    }
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            
            try
            {
                List<Reader> readers = ReadersInitialization();
                List<Book> books = BooksInitialization();
                List<Statistic> Statistics = StatisticsInitialization(books, readers);

            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.Write("Ошибка:");
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Reader> ReadersInitialization()
        {
            List < Reader > readers = new List < Reader >();
            string[] allLinesReader = File.ReadAllLines("Reader.csv");
            for (int i = 0; i < allLinesReader.Length; i++)
            {
                string line = allLinesReader[i];
                string[] elementsOfLine = line.Split(";");
                if (elementsOfLine.Length > 2)
                {
                    throw new ArgumentException($"В файле Reader.csv в строке {i + 1} столбцов больше чем 2");
                }
                if (uint.TryParse(elementsOfLine[0], out uint id))
                {
                    id = id;
                }
                else
                {
                    throw new ArgumentException($"В файле Reader.csv в строке {i + 1} в столбце 1 записаны некорректные данные");
                }

                readers.Add(new Reader { Id = id, FullName = elementsOfLine[1] });
            }
            return readers;
        }
        private static List<Book> BooksInitialization()
        {
            var cultureInfo = new CultureInfo("ru-RU", false);
            List<Book> books = new List<Book>();
            string[] allLinesBook = File.ReadAllLines("Book.csv");
            for (int i = 0; i < allLinesBook.Length; i++)
            {
                string line = allLinesBook[i];
                string[] elementsOfLine = line.Split(";");
                if (elementsOfLine.Length > 6)
                {
                    throw new ArgumentException($"В файле Book.csv в строке {i + 1} столбцов больше чем 6");
                }

                if (uint.TryParse(elementsOfLine[0], out uint id))
                {
                    id = id;
                }
                else
                {
                    throw new ArgumentException($"В файле Book.csv в строке {i + 1} в столбце 1 записаны некорректные данные");
                }

                if (DateTime.TryParse(elementsOfLine[3], out DateTime publicationDate))
                {
                    publicationDate = publicationDate;
                }
                else
                {
                    throw new ArgumentException($"В файле Book.csv в строке {i + 1} в столбце 4 записаны некорректные данные");
                }

                if (uint.TryParse(elementsOfLine[4], out uint bookcaseNumber))
                {
                    bookcaseNumber = bookcaseNumber;
                }
                else
                {
                    throw new ArgumentException($"В файле Book.csv в строке {i + 1} в столбце 5 записаны некорректные данные");
                }

                if (uint.TryParse(elementsOfLine[5], out uint shelfNumber))
                {
                    shelfNumber = shelfNumber;
                }
                else
                {
                    throw new ArgumentException($"В файле Book.csv в строке {i + 1} в столбце 6 записаны некорректные данные");
                }

                books.Add(new Book { 
                    Id = id,
                    Author = elementsOfLine[1],
                    Name = elementsOfLine[2],
                    PublicationDate=publicationDate,
                    BookcaseNumber=bookcaseNumber,
                    ShelfNumber=shelfNumber
                });
            }
            return books;
        }

        private static List<Statistic> StatisticsInitialization(List<Book> books, List<Reader> readers)
        {
            
            List<Statistic> statistics = new List<Statistic>();
            string[] allLinesStatistics = File.ReadAllLines("Statistics.csv");

            for (int i = 0; i < allLinesStatistics.Length; i++)
            {
                string line = allLinesStatistics[i];

                string[] elementsOfLine = line.Split(";");

                if (elementsOfLine.Length > 5)
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} столбцов больше чем 5");
                }

                if (uint.TryParse(elementsOfLine[0], out uint id))
                {
                    id = id;
                }
                else
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} в столбце 1 записаны некорректные данные");
                }

                if (uint.TryParse(elementsOfLine[1], out uint readerId))
                {
                    readerId = readerId;
                }
                else
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} в столбце 2 записаны некорректные данные");
                }

                if (uint.TryParse(elementsOfLine[2], out uint bookId))
                {
                    bookId = bookId;
                }
                else
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} в столбце 3 записаны некорректные данные");
                }

                if (DateTime.TryParse(elementsOfLine[3], out DateTime takeDate))
                {
                    takeDate = takeDate;
                }
                else
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} в столбце 4 записаны некорректные данные");
                }

                if (DateTime.TryParse(elementsOfLine[4], out DateTime returnDate))
                {
                    returnDate = returnDate;
                }
                else
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} в столбце 5 записаны некорректные данные");
                }

                if (takeDate > returnDate)
                {
                    throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} читатель вернул книгу до того как её взять");
                }

                
                Reader readerStatistics = StatisticsReaderInitialization(readers, i, readerId);

                Book bookStatistics = StatisticsBookInitialization(books, i, bookId);


            }
            return statistics;
        }

        private static Reader StatisticsReaderInitialization(List<Reader> readers, int i, uint readerId)
        {
            Reader readerStatistics = null;
            bool readerFlag = false;
            foreach (Reader reader in readers)
            {
                if (reader.Id == readerId)
                {
                    readerStatistics = reader;
                    readerFlag = true;
                    break;
                }
            }

            if (!readerFlag)
            {
                throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} введено id несуществующего читателя");
            }

            return readerStatistics;
        }

        private static Book StatisticsBookInitialization(List<Book> books, int i, uint bookId)
        {
            Book bookStatistics = null;
            bool bookFlag = false;
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    bookStatistics = book;
                    bookFlag = true;
                    break;
                }
            }

            if (!bookFlag)
            {
                throw new ArgumentException($"В файле Statistics.csv в строке {i + 1} введено id несуществующей книги");
            }

            return bookStatistics;
        }
    }
}