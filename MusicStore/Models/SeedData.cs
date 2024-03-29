﻿using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.OrderStatus.Any())
                {
                    return;   // DB has been seeded
                }

                context.OrderStatus.AddRange(

                    new OrdStat { StatusId = 1, StatusName = "Pending" },
                    new OrdStat { StatusId = 2, StatusName = "Shipped" },
                    new OrdStat { StatusId = 3, StatusName = "Delivered" },
                    new OrdStat { StatusId = 4, StatusName = "Cancelled" },
                    new OrdStat { StatusId = 5, StatusName = "Returned" },
                    new OrdStat { StatusId = 6, StatusName = "Refunded" });


                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Genres.Any())
                {
                    return;   // DB has been seeded
                }
                context.Genres.AddRange(

                    new Genre { Name = "Rock" },
                    new Genre { Name = "Jazz" },
                    new Genre { Name = "Metal" },
                    new Genre { Name = "Alternative" },
                    new Genre { Name = "Disco" },
                    new Genre { Name = "Blues" },
                    new Genre { Name = "Latin" },
                    new Genre { Name = "Reggae" },
                    new Genre { Name = "Pop" },
                    new Genre { Name = "Classical" }
                );


                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Artists.Any())
                {
                    return;   // DB has been seeded
                }
                context.Artists.AddRange(

                    new Artist { Name = "Aaron Copland & London Symphony Orchestra" },
                    new Artist { Name = "Aaron Goldberg" },
                    new Artist { Name = "AC/DC" },
                    new Artist { Name = "Accept" },
                    new Artist { Name = "Adrian Leaper & Doreen de Feis" },
                    new Artist { Name = "Aerosmith" },
                    new Artist { Name = "Aisha Duo" },
                    new Artist { Name = "Alanis Morissette" },
                    new Artist { Name = "Alberto Turco & Nova Schola Gregoriana" },
                    new Artist { Name = "Alice In Chains" },
                    new Artist { Name = "Amy Winehouse" },
                    new Artist { Name = "Anita Ward" },
                    new Artist { Name = "Antônio Carlos Jobim" },
                    new Artist { Name = "Apocalyptica" },
                    new Artist { Name = "Audioslave" }, //15
                    new Artist { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                    new Artist { Name = "Berliner Philharmoniker & Hans Rosbaud" },
                    new Artist { Name = "Berliner Philharmoniker & Herbert Von Karajan" },
                    new Artist { Name = "Billy Cobham" },
                    new Artist { Name = "Black Label Society" },
                    new Artist { Name = "Black Sabbath" },
                    new Artist { Name = "Boston Symphony Orchestra & Seiji Ozawa" },
                    new Artist { Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" },
                    new Artist { Name = "Bruce Dickinson" },
                    new Artist { Name = "Buddy Guy" },
                    new Artist { Name = "Caetano Veloso" },
                    new Artist { Name = "Cake" },
                    new Artist { Name = "Calexico" },
                    new Artist { Name = "Cássia Eller" },
                    new Artist { Name = "Chic" },
                    new Artist { Name = "Chicago Symphony Orchestra & Fritz Reiner" },
                    new Artist { Name = "Chico Buarque" },
                    new Artist { Name = "Chico Science & Nação Zumbi" },
                    new Artist { Name = "Choir Of Westminster Abbey & Simon Preston" },
                    new Artist { Name = "Chris Cornell" },
                    new Artist { Name = "Christopher O'Riley" },
                    new Artist { Name = "Cidade Negra" },
                    new Artist { Name = "Cláudio Zoli" },
                    new Artist { Name = "Creedence Clearwater Revival" },
                    new Artist { Name = "David Coverdale" },
                    new Artist { Name = "Deep Purple" },
                    new Artist { Name = "Dennis Chambers" },
                    new Artist { Name = "Djavan" },
                    new Artist { Name = "Donna Summer" },
                    new Artist { Name = "Dread Zeppelin" },
                    new Artist { Name = "Ed Motta" },
                    new Artist { Name = "Edo de Waart & San Francisco Symphony" },
                    new Artist { Name = "Elis Regina" },
                    new Artist { Name = "English Concert & Trevor Pinnock" },
                    new Artist { Name = "Eric Clapton" },
                    new Artist { Name = "Eugene Ormandy" },
                    new Artist { Name = "Faith No More" },
                    new Artist { Name = "Falamansa" },
                    new Artist { Name = "Foo Fighters" },
                    new Artist { Name = "Frank Zappa & Captain Beefheart" },
                    new Artist { Name = "Fretwork" },
                    new Artist { Name = "Funk Como Le Gusta" },
                    new Artist { Name = "Gerald Moore" },
                    new Artist { Name = "Gilberto Gil" },
                    new Artist { Name = "Godsmack" },
                    new Artist { Name = "Gonzaguinha" },
                    new Artist { Name = "Göteborgs Symfoniker & Neeme Järvi" },
                    new Artist { Name = "Guns N' Roses" },
                    new Artist { Name = "Gustav Mahler" },
                    new Artist { Name = "Incognito" },
                    new Artist { Name = "Iron Maiden" },
                    new Artist { Name = "James Levine" },
                    new Artist { Name = "Jamiroquai" },
                    new Artist { Name = "Jimi Hendrix" },
                    new Artist { Name = "Joe Satriani" },
                    new Artist { Name = "Jorge Ben" },
                    new Artist { Name = "Jota Quest" },
                    new Artist { Name = "Judas Priest" },
                    new Artist { Name = "Julian Bream" },
                    new Artist { Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" },
                    new Artist { Name = "Kiss" },
                    new Artist { Name = "Led Zeppelin" },
                    new Artist { Name = "Legião Urbana" },
                    new Artist { Name = "Lenny Kravitz" },
                    new Artist { Name = "Les Arts Florissants & William Christie" },
                    new Artist { Name = "London Symphony Orchestra & Sir Charles Mackerras" },
                    new Artist { Name = "Luciana Souza/Romero Lubambo" },
                    new Artist { Name = "Lulu Santos" },
                    new Artist { Name = "Marcos Valle" },
                    new Artist { Name = "Marillion" },
                    new Artist { Name = "Marisa Monte" },
                    new Artist { Name = "Martin Roscoe" },
                    new Artist { Name = "Maurizio Pollini" },
                    new Artist { Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" },
                    new Artist { Name = "Men At Work" },
                    new Artist { Name = "Metallica" },
                    new Artist { Name = "Michael Tilson Thomas & San Francisco Symphony" },
                    new Artist { Name = "Miles Davis" },
                    new Artist { Name = "Milton Nascimento" },
                    new Artist { Name = "Mötley Crüe" },
                    new Artist { Name = "Motörhead" },
                    new Artist { Name = "Nash Ensemble" },
                    new Artist { Name = "Nicolaus Esterhazy Sinfonia" },
                    new Artist { Name = "Nirvana" },
                    new Artist { Name = "O Terço" },
                    new Artist { Name = "Olodum" },
                    new Artist { Name = "Orchestra of The Age of Enlightenment" },
                    new Artist { Name = "Os Paralamas Do Sucesso" },
                    new Artist { Name = "Ozzy Osbourne" },
                    new Artist { Name = "Page & Plant" },
                    new Artist { Name = "Paul D'Ianno" },
                    new Artist { Name = "Pearl Jam" },
                    new Artist { Name = "Pink Floyd" },
                    new Artist { Name = "Queen" },
                    new Artist { Name = "R.E.M." },
                    new Artist { Name = "Raul Seixas" },
                    new Artist { Name = "Red Hot Chili Peppers" },
                    new Artist { Name = "Roger Norrington, London Classical Players" },
                    new Artist { Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" },
                    new Artist { Name = "Rush" },
                    new Artist { Name = "Santana" },
                    new Artist { Name = "Scholars Baroque Ensemble" },
                    new Artist { Name = "Scorpions" },
                    new Artist { Name = "Sergei Prokofiev & Yuri Temirkanov" },
                    new Artist { Name = "Sir Georg Solti & Wiener Philharmoniker" },
                    new Artist { Name = "Skank" },
                    new Artist { Name = "Soundgarden" },
                    new Artist { Name = "Spyro Gyra" },
                    new Artist { Name = "Stevie Ray Vaughan & Double Trouble" },
                    new Artist { Name = "Stone Temple Pilots" },
                    new Artist { Name = "System Of A Down" },
                    new Artist { Name = "Temple of the Dog" },
                    new Artist { Name = "Terry Bozzio, Tony Levin & Steve Stevens" },
                    new Artist { Name = "The 12 Cellists of The Berlin Philharmonic" },
                    new Artist { Name = "The Black Crowes" },
                    new Artist { Name = "The Cult" },
                    new Artist { Name = "The Doors" },
                    new Artist { Name = "The King's Singers" },
                    new Artist { Name = "The Police" },
                    new Artist { Name = "The Posies" },
                    new Artist { Name = "The Rolling Stones" },
                    new Artist { Name = "The Who" },
                    new Artist { Name = "Tim Maia" },
                    new Artist { Name = "Ton Koopman" },
                    new Artist { Name = "U2" },
                    new Artist { Name = "UB40" },
                    new Artist { Name = "Van Halen" },
                    new Artist { Name = "Various Artists" },
                    new Artist { Name = "Velvet Revolver" },
                    new Artist { Name = "Vinícius De Moraes" },
                    new Artist { Name = "Wilhelm Kempff" },
                    new Artist { Name = "Yehudi Menuhin" },
                    new Artist { Name = "Yo-Yo Ma" },
                    new Artist { Name = "Zeca Pagodinho" }
                );


                context.SaveChanges();
            }

            
        }
    }
}