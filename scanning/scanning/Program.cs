using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace scanning
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "";
            string text = File.ReadAllText("b.txt");
            var AllLines = text.Split('\n');
            var heder = AllLines[0].Split(' ');
            var score = AllLines[1].Split(' ').Select(s => int.Parse(s)).ToList();
            int IndexJenerator = 0;
            var usige = Enumerable.Repeat(0, score.Count).ToList();
            List<Library> Librarys = new List<Library>();
            Int32 lineCounter = 0;
            int deadline = 0;
            foreach (string line in AllLines)
            {
                if (lineCounter >= 2)
                {

                    if (lineCounter % 2 == 0)
                    {
                        Library spl = new Library();
                        var lineSpl = line.Split(' ');
                        spl.index = IndexJenerator;
                        spl.NumberOfBooks = lineSpl[0];
                        spl.SignUp = lineSpl[1];
                        spl.BookaPerDay = lineSpl[2];
                        var BooksInLib = AllLines[lineCounter + 1].Split(' ').Select(b => int.Parse(b)).ToList();
                        var splitBooks = new List<BookInLib>();
                        foreach(var book in BooksInLib)
                        {
                            BookInLib b = new BookInLib();
                            b.Index = book;
                            b.Score = score[book];
                            splitBooks.Add(b);
                        }
                        splitBooks = splitBooks.OrderBy(s => s.Score).ToList();
                        splitBooks.Reverse();
                        spl.BookIndexes = splitBooks;
                        // = AllLines[lineCounter + 1];
                        IndexJenerator++;
                        Librarys.Add(spl);
                    }

                }
                lineCounter++;
            }// end for
            Librarys = Librarys.OrderBy(s => s.SignUp).ToList();
 
            var content = Librarys.Count + Environment.NewLine;
            foreach (var lib in Librarys)
            {
                
                string ScannedBook = null;
                int BookCounter = 0;
                foreach (var book in lib.BookIndexes)
                {
                    if (usige[book.Index] == 0)
                    {
                        ScannedBook += book.Index + " ";
                        usige[book.Index]=1;
                        BookCounter += 1;
                    }
                }
                content += lib.index + " " + BookCounter + Environment.NewLine;
                content += ScannedBook;
                BookCounter = 0;
                content += Environment.NewLine;
            }
            save(content);

            void save(string Data)
            {
                filename = @"C:\Users\HP\source\repos\scanning\scanning\bin\Debug" + DateTime.Now.TimeOfDay.Hours
                                                         + "-" + DateTime.Now.TimeOfDay.Minutes
                                                         + "-" + DateTime.Now.TimeOfDay.Seconds
                                                         + ".txt";
                File.WriteAllText(filename, Data);
            }
 
        }
    }
}
