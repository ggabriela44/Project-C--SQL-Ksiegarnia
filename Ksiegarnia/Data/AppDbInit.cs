using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ksiegarnia.Data;
using Ksiegarnia.Models;
using System.Linq;

namespace Ksiegarnia.Data
{
    public class AppDbInit
    {
        public static async void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new KsiegarniaDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<KsiegarniaDbContext>>()))

            //   var context = serviceScope.ServiceProvider.GetService<KsiegarniaDbContext>();
            {
                context.Database.EnsureCreated();
                
                //Ksiazka
                if (!context.Ksiazka.Any())
                {
                    context.Ksiazka.AddRange(new List<Ksiazka>()
                    {
                        new Ksiazka()
                        {
                            Tytul = "Ania z Zielonego Wzgórza",
                            Autor = "Lucy Maud Montgomery",
                            GatunekID = 6,
                            Ocena = 8,
                            Wydawnictwo = "Nie wiem",
                            Data_wydania = DateTime.Parse("1989-2-12"),
                            Cena = 35,
                            Opis = "Lorem Ipsum..."
                        },
                        new Ksiazka()
                        {
                            Tytul = "Królewna",
                            Autor = "Marczak Weronika",
                            GatunekID = 6,
                            Ocena = 6,
                            Wydawnictwo = "Nie wiem",
                            Data_wydania =  DateTime.Parse("1999-5-14"),
                            Cena = 35,
                            Opis = "Lorem Ipsum..."
                        },
                        new Ksiazka()
                        {
                            Tytul = "Hobbit",
                            Autor = "Nie pamiętam",
                            GatunekID = 5,
                            Ocena = 5,
                            Wydawnictwo = "Nie wiem bo nie wiem",
                            Data_wydania = DateTime.Now.AddDays(7),
                            Cena = 35,
                            Opis = "Lorem Ipsum..2."
                        }
                    });
                    context.SaveChanges();
                }
                

                //Gatunek
                if (!context.Gatunek.Any())
                {
                    context.Gatunek.AddRange(new List<Gatunek>()
                    {
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Akcja,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Baśń,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Romantyka,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Horror,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Drama,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Fantasty,
                        },
                        new Gatunek()
                        {
                            Gatunek_ksiazki = Category.Komedia,
                        }
                    });
                    context.SaveChanges();

                }

                
                //KsiazkaZamowiona
                if (!context.KsiazkaZamowienie.Any())
                {
                    context.KsiazkaZamowienie.AddRange(new List<KsiazkaZamowienie>()
                    {
                        new KsiazkaZamowienie()
                        {
                            ZamowienieID = 1,
                            KsiazkaID = 2
                        },
                        new KsiazkaZamowienie()
                        {
                            ZamowienieID = 2,
                            KsiazkaID = 4
                        }

                    });
                    context.SaveChanges();
                }
                
                
            //Zamowienie
            if (!context.Zamowienie.Any())
            {
                context.Zamowienie.AddRange(new List<Zamowienie>()
                {
                    new Zamowienie()
                    {
                        KlientID = 1,
                        DostawaID  = 1,
                        Cena_ksiazek = 35,
                        Cena_dostawy = 10,
                        Typ_zaplaty = "Karta",
                        Ulica = "Sezamkowa",
                        Nr_domu = "3",
                        Miejscowosc = "Muppets",
                        Kod_pocztowy = "00-000"
                    },
                    new Zamowienie()
                    {
                        KlientID = 2,
                        DostawaID  = 2,
                        Cena_ksiazek = 35,
                        Cena_dostawy = 15,
                        Typ_zaplaty = "Gotówka",
                        Ulica = "Szkolana",
                        Nr_domu = "12b/3",
                        Miejscowosc = "Marek",
                        Kod_pocztowy = "00-000"
                    }
                });
                context.SaveChanges();
            }
            
                //Klient
                if (!context.Klient.Any())
                {
                    context.Klient.AddRange(new List<Klient>()
                    {
                        new Klient()
                        {
                            Imie ="Miłosz",
                            Nazwisko = "Sezam",
                            Nr_telefon = "100000000",
                            Email = "emaiol@s.pl"
                        },
                        new Klient()
                        {
                            Imie ="Zdzisław",
                            Nazwisko = "Kól",
                            Nr_telefon = "5555555",
                            Email = "emai2ol@s.pl"
                        }

                    });
                    context.SaveChanges();
                }

                //Dostawca
                if (!context.Dostawa.Any())
                {
                    context.Dostawa.AddRange(new List<Dostawa>()
                    {
                        new Dostawa()
                        {
                            Typ = "Karta",
                            Oplata = 10
                        },
                        new Dostawa()
                        {
                            Typ = "Gotówka",
                            Oplata = 15
                        },
                        new Dostawa()
                        {
                            Typ = "Paczkomat",
                            Oplata = 2
                        }

                    });
                    context.SaveChanges();
                }


                // context.SaveChanges();
            }
        }
    }
}
