using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task;

public static class ListExtension
{
    public static Person OlderPerson(this List<Person> persons)
    {
        var olderPerson = new Person();
        foreach (var person in persons)
        {
            if(person.Age > olderPerson.Age)
            {
                olderPerson = person;
            }
        }
        return olderPerson;
    } 
    public static double TotalPrice(this List<Book> books)
    {
        var totalBook = 0d;
        foreach (var book in books)
        {
            totalBook += book.Price;
        }
        return totalBook;
    }
}
