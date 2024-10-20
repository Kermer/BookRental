using BookRental.Api.Data;
using BookRental.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Api.IntegrationTests.DataSeeding;
internal class BookContextWithData : BookContext
{
    public BookContextWithData(DbContextOptions<BookContext> options) : base(options)
    {
        SeedData();
    }

    private void SeedData()
    {
        if (_dataSeeded)
        {
            return;
        }

        Books.Add(new Book()
        {
            Id = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            ISBN = "9780061120084",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("74b3e10d-080e-4cc5-ae98-76a622acaa0e"),
            Title = "1984",
            Author = "George Orwell",
            ISBN = "9780451524935",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("bcf5c1bc-5126-4e34-845f-3e290b1c234c"),
            Title = "Pride and Prejudice",
            Author = "Jane Austen",
            ISBN = "9780141439518",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("8cf6d12d-e7c7-41b7-bf01-978d1840c7b4"),
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            ISBN = "9780743273565",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("1b08e5f1-497e-4510-b41b-b66c2f2b1702"),
            Title = "Moby Dick",
            Author = "Herman Melville",
            ISBN = "9781503280786",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("afba9984-2b69-47c6-8898-b17c5d66b141"),
            Title = "War and Peace",
            Author = "Leo Tolstoy",
            ISBN = "9780199232765",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("7de3a0c8-8e8b-41c0-8445-4e07d8d03dc2"),
            Title = "Crime and Punishment",
            Author = "Fyodor Dostoevsky",
            ISBN = "9780140449136",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("ee21d748-fb3a-4f44-a2f3-e4da82a20d6b"),
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            ISBN = "9780316769488",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("ffbb8d95-bb5c-4ee2-9cb6-cc72cf0af9c1"),
            Title = "Brave New World",
            Author = "Aldous Huxley",
            ISBN = "9780060850524",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("ab65e6a1-bc81-48bb-b11d-0c69e3d651ae"),
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            ISBN = "9780544003415",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("4c21da44-6eb3-4876-8eb5-94c39b63d74f"),
            Title = "Harry Potter and the Sorcerer's Stone",
            Author = "J.K. Rowling",
            ISBN = "9780590353427",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("4b775e8e-64ed-4b7f-80d3-1c9b2a28f95f"),
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            ISBN = "9780547928227",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("6c6a5b0d-f4b2-4780-927f-cc8648b8f8b2"),
            Title = "Ulysses",
            Author = "James Joyce",
            ISBN = "9781840226355",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("47cb1b2a-bbfb-4482-a426-cf19a69ae0b2"),
            Title = "Jane Eyre",
            Author = "Charlotte Brontë",
            ISBN = "9780141441146",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("c1873fc5-8e01-4e46-bb2d-1db746408c79"),
            Title = "Wuthering Heights",
            Author = "Emily Brontë",
            ISBN = "9780141439556",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("6f378d6f-bc4c-4eab-bd54-d927ef6d3f05"),
            Title = "The Brothers Karamazov",
            Author = "Fyodor Dostoevsky",
            ISBN = "9780374528379",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("c6da4b18-d3bb-45a4-9db8-144d48cc61f0"),
            Title = "Frankenstein",
            Author = "Mary Shelley",
            ISBN = "9780486282114",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("aa8d1d8a-07e0-4875-bf3b-e1ab6357f267"),
            Title = "Fahrenheit 451",
            Author = "Ray Bradbury",
            ISBN = "9781451673319",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("c0a6b73e-88cb-4594-8440-d599cc5d0482"),
            Title = "Slaughterhouse-Five",
            Author = "Kurt Vonnegut",
            ISBN = "9780440180296",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("f23c9d7e-d0b4-4fd4-bc85-4e2bce1b4d7c"),
            Title = "One Hundred Years of Solitude",
            Author = "Gabriel García Márquez",
            ISBN = "9780060883287",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("61eec294-bc64-44f1-8e7b-dab818fa3620"),
            Title = "Anna Karenina",
            Author = "Leo Tolstoy",
            ISBN = "9780143035008",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("61c54eb6-e6c1-491f-9a31-930b6d3fa3bb"),
            Title = "The Odyssey",
            Author = "Homer",
            ISBN = "9780140268867",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("53db02c7-b2a5-487f-b96b-558cbe0e3541"),
            Title = "The Iliad",
            Author = "Homer",
            ISBN = "9780140275360",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("b705647d-6e44-4c3c-8f1b-19c607007bcf"),
            Title = "Les Misérables",
            Author = "Victor Hugo",
            ISBN = "9780140444308",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("3b65d6f0-2b7b-4c0c-bd90-5c8c6b67eb5b"),
            Title = "Don Quixote",
            Author = "Miguel de Cervantes",
            ISBN = "9780060934347",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("58306269-3d70-46b0-b44b-21f1cb6f1c77"),
            Title = "Meditations",
            Author = "Marcus Aurelius",
            ISBN = "9780486298238",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("0de26493-8993-4ac0-89b6-1cf9f155fb37"),
            Title = "The Picture of Dorian Gray",
            Author = "Oscar Wilde",
            ISBN = "9780141439570",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("58f072fc-37bb-4693-9668-5d06aa4dfb5a"),
            Title = "The Divine Comedy",
            Author = "Dante Alighieri",
            ISBN = "9780142437223",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("7d32b77e-fcc1-4ba2-a6cf-3bde481e6bde"),
            Title = "The Stranger",
            Author = "Albert Camus",
            ISBN = "9780679720201",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("53b0ec76-c08d-44ab-94bb-60729d5c7ebf"),
            Title = "The Old Man and the Sea",
            Author = "Ernest Hemingway",
            ISBN = "9780684801223",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("eb96c6e0-24b5-4db5-a8f8-4c6cb7d44ab7"),
            Title = "Dracula",
            Author = "Bram Stoker",
            ISBN = "9780486411095",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("34d03f3e-ef8f-4c1f-baf4-8484d72f008b"),
            Title = "Gulliver's Travels",
            Author = "Jonathan Swift",
            ISBN = "9780486292731",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("328cfc73-7543-4428-8958-c4d60729d3d7"),
            Title = "Heart of Darkness",
            Author = "Joseph Conrad",
            ISBN = "9780486264646",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("af6e80a0-1c6b-4d30-8a64-2911c44e2820"),
            Title = "Madame Bovary",
            Author = "Gustave Flaubert",
            ISBN = "9780140449129",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("c1dfdc1f-01f7-407b-9b0e-5dff3e4d4505"),
            Title = "The Sun Also Rises",
            Author = "Ernest Hemingway",
            ISBN = "9780743297333",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("3a92366e-87e8-4a81-bcc1-1e1b4c73728b"),
            Title = "Of Mice and Men",
            Author = "John Steinbeck",
            ISBN = "9780140177398",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("6f67b19e-c2f0-4f54-b8b1-635f503805c3"),
            Title = "On the Road",
            Author = "Jack Kerouac",
            ISBN = "9780140042598",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("c6a77c9a-f236-44d0-b8e5-9f1f7b61c69f"),
            Title = "Beloved",
            Author = "Toni Morrison",
            ISBN = "9781400033416",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("00c4e11f-cdad-4c54-bb01-4c0832db15c2"),
            Title = "The Handmaid's Tale",
            Author = "Margaret Atwood",
            ISBN = "9780385490818",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("7c314bc9-8e92-4734-8a09-9d7a8e23c1c5"),
            Title = "Invisible Man",
            Author = "Ralph Ellison",
            ISBN = "9780679732761",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("ffb06d34-5b3a-49e8-8a88-e1cc1a30e207"),
            Title = "The Sound and the Fury",
            Author = "William Faulkner",
            ISBN = "9780679732242",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("2e06b2d0-1f9e-48eb-83c5-e4f8c0c87c68"),
            Title = "The Grapes of Wrath",
            Author = "John Steinbeck",
            ISBN = "9780143039433",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("4d8b75c2-11af-44d6-b2b7-5d2419e04d1c"),
            Title = "Catcher in the Rye",
            Author = "J.D. Salinger",
            ISBN = "9780316769174",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("ec01d1e4-1d58-4e52-a22c-0d536f716fef"),
            Title = "The Kite Runner",
            Author = "Khaled Hosseini",
            ISBN = "9781594631931",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("61072f5a-c679-4c38-b7ed-7a77b7c70b68"),
            Title = "Life of Pi",
            Author = "Yann Martel",
            ISBN = "9780156027328",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("29deeb44-89ea-4ab6-a4f3-ec931ea06564"),
            Title = "The Road",
            Author = "Cormac McCarthy",
            ISBN = "9780307387899",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("98fef4be-e689-43a4-8322-07f928a9093a"),
            Title = "The Alchemist",
            Author = "Paulo Coelho",
            ISBN = "9780061122415",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("927d158d-b707-4b80-8bc4-7f9d58f68bdb"),
            Title = "A Tale of Two Cities",
            Author = "Charles Dickens",
            ISBN = "9780141439600",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("f56f8f6d-d2f1-4fa9-b946-6d08681a9f02"),
            Title = "The Count of Monte Cristo",
            Author = "Alexandre Dumas",
            ISBN = "9780140449266",
            Status = BookStatus.OnShelf
        });

        Books.Add(new Book()
        {
            Id = new Guid("bbf9658d-4894-4d41-b60e-19550cc94ef1"),
            Title = "Sense and Sensibility",
            Author = "Jane Austen",
            ISBN = "9780141439662",
            Status = BookStatus.OnShelf
        });

        SaveChanges();

        _dataSeeded = true;
    }
}
