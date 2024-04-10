using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static Formula1WebApplication.Infrastructure.Constants.CustomClaims;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
		public IdentityUserClaim<string> OrganizerUserClaim { get; set; }
		public IdentityUserClaim<string> GuestUserClaim { get; set; }
		public IdentityUserClaim<string> AdminUserClaim { get; set; }

		public ApplicationUser OrganizerUser { get; set; }
        public ApplicationUser GuestUser { get; set; }
		public ApplicationUser AdminUser { get; set; }

		public Organizer Organizer { get; set; }
		public Organizer AdminOrganizer { get; set; }

		public Pilot MaxVerstappen { get; set; }
        public Pilot CharlesLeclerc { get; set; }
        public Pilot SergioPerez { get; set; }
        public Pilot CarlosSainz { get; set; }
        public Pilot OscarPiastri { get; set; }
        public Pilot LandoNorris { get; set; }
        public Pilot GeorgeRussell { get; set; }
        public Pilot FernandoAlonso { get; set; }
        public Pilot LanceStroll { get; set; }
        public Pilot LewisHamilton { get; set; }
        public Pilot YukiTsunoda { get; set; }
        public Pilot NicoHulkenberg { get; set; }
        public Pilot KevinMagnussen { get; set; }
        public Pilot AlexAlbon { get; set; }
        public Pilot GuanyuZhou { get; set; }
        public Pilot DanielRicciardo { get; set; }
        public Pilot EstebanOcon { get; set; }
        public Pilot PierreGasly { get; set; }
        public Pilot ValtteriBottas { get; set; }
        public Pilot LoganSargeant { get; set; }

        public Race BahrainGrandPrix { get; set; }
        public Race SaudiArabiaGrandPrix { get; set; }
        public Race AustraliaGrandPrix { get; set; }

        public Event MeetAndGreet { get; set; }
        public Event AutographSession { get; set; }
        public Event ExclusivePreview { get; set; }

        public NewsArticle TheStrategist { get; set; }
        public NewsArticle NotWhereIExpectedToBe { get; set; }
        public NewsArticle HinchsHeroes { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedOrganizer();
            SeedPilots();
            SeedRaces();
            SeedEvents();
            SeedNewsArticles();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            OrganizerUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "organizer@mail.com",
                NormalizedUserName = "organizer@mail.com",
                Email = "organizer@mail.com",
                NormalizedEmail = "organizer@mail.com",
                FirstName = "Organizer",
                LastName = "Organizerov"
            };

            OrganizerUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Organizer Organizerov",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
			};

            OrganizerUser.PasswordHash =
                 hasher.HashPassword(OrganizerUser, "organizer123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov"
            };

			GuestUserClaim = new IdentityUserClaim<string>()
			{
				Id = 4,
				ClaimType = UserFullNameClaim,
				ClaimValue = "Guest Guestov",
				UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
			};

			GuestUser.PasswordHash =
            hasher.HashPassword(OrganizerUser, "guest123");

			AdminUser = new ApplicationUser()
			{
				Id = "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9",
				UserName = "admin@mail.com",
				NormalizedUserName = "ADMIN@MAIL.COM",
				Email = "admin@mail.com",
				NormalizedEmail = "ADMIN@MAIL.COM",
				FirstName = "Admin",
				LastName = "Adminov"
			};

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 5,
                ClaimType = UserFullNameClaim,
                UserId = "eb9175e5-1e90-4a71-b89e-a1ee5d0cc9e9",
                ClaimValue = "Admin Adminov"
            };

            AdminUser.PasswordHash =
				hasher.HashPassword(AdminUser, "admin123");
		}

        private void SeedOrganizer()
        {
            Organizer = new Organizer()
            {
                Id = 1,
                PhoneNumber = "+359123123123",
                UserId = OrganizerUser.Id
            };

			AdminOrganizer = new Organizer()
			{
				Id = 3,
				PhoneNumber = "+359321321321",
				UserId = AdminUser.Id
			};
		}

        private void SeedPilots()
        {
            MaxVerstappen = new Pilot
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Verstappen",
                Nationality = "Dutch",
                TeamName = "Red Bull Racing",
                Biography = "He’s Max by name, and max by nature. Arriving as Formula 1’s youngest ever competitor at just 17 years old, Verstappen pushed his car, his rivals and the sport’s record books to the limit. The baby-faced Dutchman with the heart of a lion took the Toro Rosso – and then the Red Bull – by the horns with his instinctive racing style.",
                ImagePath = "/images/pilots/maxverstappen.png"
            };

            CharlesLeclerc = new Pilot
            {
                Id = 2,
                FirstName = "Charles",
                LastName = "Leclerc",
                Nationality = "Monegasque",
                TeamName = "Ferrari",
                Biography = "Leclerc arrived in F1 on a tidal wave of expectation. He showcased a dazzling array of skills from scorching pole positions, commanding victories – even when his car caught fire twice at Silverstone – to an ability to muscle his way through the pack. Winning back-to-back championships also taught Leclerc how to handle pressure, another useful tool in Formula 1 racing.",
                ImagePath = "/images/pilots/charlesleclerc.png"
            };

            SergioPerez = new Pilot
            {
                Id = 3,
                FirstName = "Sergio",
                LastName = "Perez",
                Nationality = "Mexican",
                TeamName = "Red Bull Racing",
                Biography = "He’s the fighter with a gentle touch from the land of the Lucha Libre.Perez’s reputation in F1 has been built on opposite approaches to Grand Prix racing. On the one hand, he is a punchy combatant who wrestles his way through the pack and into the points. Never afraid to add a bit of spice to his on-track encounters, even his team mates don’t always escape the Mexican’s heat.",
                ImagePath = "/images/pilots/sergioperez.png"
            };

            CarlosSainz = new Pilot
            {
                Id = 4,
                FirstName = "Carlos",
                LastName = "Sainz",
                Nationality = "Spanish",
                TeamName = "Ferrari",
                Biography = "He’s the matador from Madrid racing royalty. After entering F1’s Bull Ring paired alongside Max Verstappen at Toro Rosso in 2015, Sainz quickly showed his fighting spirit. A tenacious racer, he puts the car on the edge as he hustles his way through the pack. No wonder Sainz has earned the nickname Chilli.",
                ImagePath = "/images/pilots/carlossainz.png"
            };

            OscarPiastri = new Pilot
            {
                Id = 5,
                FirstName = "Oscar",
                LastName = "Piastri",
                Nationality = "Australian",
                TeamName = "McLaren",
                Biography = "Born in Melbourne, just a stone’s throw away from the Australian Grand Prix venue, a young Oscar Piastri’s dreams of one day racing in Formula 1 were ignited by the sport’s star drivers roaring around his local streets, otherwise known as Albert Park.",
                ImagePath = "/images/pilots/oscarpiastri.png"
            };

            LandoNorris = new Pilot
            {
                Id = 6,
                FirstName = "Lando",
                LastName = "Norris",
                Nationality = "British",
                TeamName = "McLaren",
                Biography = "He has flair and fighting spirit in bountiful supply. McLaren had the British teenager on their books for two years before fast-tracking him into F1’s galaxy of stars in 2019. A firecracker in his junior career, with a penchant for pole positions and wheel-to-wheel tussles, Norris didn’t let them down.",
                ImagePath = "/images/pilots/landonorris.png"
            };

            GeorgeRussell = new Pilot
            {
                Id = 7,
                FirstName = "George",
                LastName = "Russell",
                Nationality = "British",
                TeamName = "Mercedes",
                Biography = "He’s the driver with the motto: “If in doubt, go flat out”. George Russell has lived by it throughout his F1 career to date, out-qualifying seasoned team mate Robert Kubica at all 21 Grands Prix in his rookie season, putting Williams back on the podium in 2021, and landing his first race win with Mercedes in 2022.",
                ImagePath = "/images/pilots/georgerussel.png"
            };

            FernandoAlonso = new Pilot
            {
                Id = 8,
                FirstName = "Fernando",
                LastName = "Alonso",
                Nationality = "Spanish",
                TeamName = "Alpine",
                Biography = "Fiercely competitive, Alonso is not shy about his talent, rating himself as 9/10 “in everything”, and few in the know would disagree, with his performances in F1 characterised by blistering speed, brilliant tactical thinking, exemplary race craft, a razor-sharp eye for detail and a relentless determination to win.",
                ImagePath = "/images/pilots/fernandoalonso.png"
            };

            LanceStroll = new Pilot
            {
                Id = 9,
                FirstName = "Lance",
                LastName = "Stroll",
                Nationality = "Canadian",
                TeamName = "Aston Martin",
                Biography = "There is no such thing as too much too soon for Stroll, a teenage sensation with a wet weather predilection. One of the cool kids on the grid, Stroll was unveiled shortly after his 18th birthday by Williams – before he finished high school and got his road licence. Stroll meant business in his debut 2017 season, setting records on the way. ",
                ImagePath = "/images/pilots/lancestroll.png"
            };

            LewisHamilton = new Pilot
            {
                Id = 10,
                FirstName = "Lewis",
                LastName = "Hamilton",
                Nationality = "British",
                TeamName = "Mercedes",
                Biography = "‘Still I Rise’ – these are the words emblazoned across the back of Lewis Hamilton’s helmet and tattooed across his shoulders, and ever since annihilating expectations with one of the greatest rookie performances in F1 history in 2007, that’s literally all he’s done: risen to the top of the all-time pole positions list.",
                ImagePath = "/images/pilots/lewishamilton.png"
            };

            YukiTsunoda = new Pilot
            {
                Id = 11,
                FirstName = "Yuki",
                LastName = "Tsunoda",
                Nationality = "Japanese",
                TeamName = "AlphaTauri",
                Biography = "In the entire history of Formula 1, no Japanese driver has ever won a World Championship Grand Prix. Red Bull certainly think so, with the youngster very much on the path to their senior team if he continues to impress as he has done over the past few years. Tsunoda's ascent to the top tier of motorsport was astonishingly rapid.",
                ImagePath = "/images/pilots/yukitsunoda.png"
            };

            NicoHulkenberg = new Pilot
            {
                Id = 12,
                FirstName = "Nico",
                LastName = "Hulkenberg",
                Nationality = "German",
                TeamName = "Aston Martin",
                Biography = "He’s the Superhero with the talent to become a racing superstar – if only he could get to flex his muscles with a top team. F1’s 'Hulk' has shown incredible strength and stamina as a midfield marauder for Williams, Force India, Sauber, Renault, Racing Point, Aston Martin and Haas during a career spanning back to 2010.",
                ImagePath = "/images/pilots/nicohulkenberg.png"
            };

            KevinMagnussen = new Pilot
            {
                Id = 13,
                FirstName = "Kevin",
                LastName = "Magnussen",
                Nationality = "Danish",
                TeamName = "Haas",
                Biography = "Call him a lone ranger or a maverick, but Magnussen is in Formula 1 for one reason only – to race. He may be a second-generation F1 driver – following his father, Jan, onto the grid – but Magnussen’s idols are from the ‘golden era’ of Grand Prix racing when the likes of Juan Manuel Fangio and Stirling Moss risked it all for the love of the sport.",
                ImagePath = "/images/pilots/kevinmagnussen.png"
            };

            AlexAlbon = new Pilot
            {
                Id = 14,
                FirstName = "Alex",
                LastName = "Albon",
                Nationality = "Thai",
                TeamName = "Williams",
                Biography = "Born in London but racing under the flag of Thailand, Alexander Albon’s first word was in fact Italian. That word was Ferrari – though it was with another Italian team that he got his big F1 break. Idolising Michael Schumacher and dreaming of one day racing in Formula 1, the junior Albon was pipped to the 2016 GP3.",
                ImagePath = "/images/pilots/alexalbon.png"
            };

            GuanyuZhou = new Pilot
            {
                Id = 15,
                FirstName = "Guanyu",
                LastName = "Zhou",
                Nationality = "Chinese",
                TeamName = "Alfa Romeo",
                Biography = "China had never boasted a Grand Prix starter among its citizens – until Zhou Guanyu changed that state of affairs, after receiving the call-up to make his F1 debut for Alfa Romeo, now Kick Sauber, in 2022. The Shanghai-born racer attended his home city’s inaugural Grand Prix in 2004 at the age of five, cheering on his hero Fernando Alonso.",
                ImagePath = "/images/pilots/guanyuzhou.png"
            };

            DanielRicciardo = new Pilot
            {
                Id = 16,
                FirstName = "Daniel",
                LastName = "Ricciardo",
                Nationality = "Australian",
                TeamName = "McLaren",
                Biography = "The self-styled “Honey Badger” is fuzzy on the outside and feisty on the inside. Drivers beware because behind Ricciardo’s laidback persona and big grin is a razor-sharp racer with a bite. The Australian combines all-out speed with impressive race craft. Never afraid to push to the limits if it means pulling off a pass, Ricciardo is a proven race-winner.",
                ImagePath = "/images/pilots/danielricciardo.png"
            };

            EstebanOcon = new Pilot
            {
                Id = 17,
                FirstName = "Esteban",
                LastName = "Ocon",
                Nationality = "French",
                TeamName = "Alpine",
                Biography = "If there’s one word that dominates Esteban Ocon’s career, it’s ‘sacrifice’. Back when he was just a promising karter, Ocon’s parents sold their house, put their jobs on hold, and began a life on the road, living in a caravan and travelling from circuit to circuit to support their son’s burgeoning career.",
                ImagePath = "/images/pilots/estebanocon.png"
            };

            PierreGasly = new Pilot
            {
                Id = 18,
                FirstName = "Pierre",
                LastName = "Gasly",
                Nationality = "French",
                TeamName = "AlphaTauri",
                Biography = "The flying Frenchman was called up to make his 2017 debut in Malaysia in place of Daniil Kvyat and, after proving his mettle, he was named a Toro Rosso driver the following year.  A further 21 races into his fledgling career, Gasly was moved up again – this time to replace Red Bull big gun Daniel Ricciardo.",
                ImagePath = "/images/pilots/pierregasly.png"
            };

            ValtteriBottas = new Pilot
            {
                Id = 19,
                FirstName = "Valtteri",
                LastName = "Bottas",
                Nationality = "Finnish",
                TeamName = "Alfa Romeo",
                Biography = "Learning his craft on Finnish roads of ice and snow, he was born to be a Grand Prix racer. Bottas explains that if you can drive on the frozen roads of his homeland then you can drive anywhere. Then there’s the Finnish mentality –reserved, diligent and calm the fast lane of F1 doesn’t faze him.",
                ImagePath = "/images/pilots/valtteribottas.png"
            };

            LoganSargeant = new Pilot
            {
                Id = 20,
                FirstName = "Logan",
                LastName = "Sargeant",
                Nationality = "American",
                TeamName = "Williams",
                Biography = "Logan Sargeant became F1’s first American driver in almost eight years, giving the country a home favourite to cheer once more. Winner in karting, championship glory eluded Sargeant after he made the transition to single-seater racing, but pole positions and race victories in almost every category he contested underlined his raw speed and potential.",
                ImagePath = "/images/pilots/logansargeant.png"
            };
        }

        private void SeedRaces()
        {
            BahrainGrandPrix = new Race
            {
                Id = 1,
                Name = "Bahrain Grand Prix",
                Location = "Bahrain International Circuit",
                Date = new DateTime(2024, 3, 2),
                ImageUrl = "https://cdn.racingnews365.com/2024/Verstappen/_1092x683_crop_center-center_85_none/SI202403020340_hires_jpeg_24bit_rgb.jpg?v=1709395733",
                Laps = 57,
                CircuitInfo = "Built for the Bahrain International Circuit in December 2002. It has a blank, sandy canvas to work with, and with that fashioned the technical, 5.4km track designed by Hermann Tilke.",
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };

            SaudiArabiaGrandPrix = new Race
            {
                Id = 2,
                Name = "Saudi Arabia Grand Prix",
                Location = "Jeddah Corniche Circuit",
                Date = new DateTime(2024, 3, 9),
                ImageUrl = "https://cdn.racingnews365.com/2024/_1092x683_crop_center-center_85_none/Qiddiya-street-track-2.jpg?v=1709640021",
                Laps = 50,
                CircuitInfo = "The Jeddah Corniche Circuit is a temporary street circuit, located on the Corniche – a 30km coastal resort area of the ancient Saudi Arabian city of Jeddah.",
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };

            AustraliaGrandPrix = new Race
            {
                Id = 3,
                Name = "Australia Grand Prix",
                Location = "Melbourne Grand Prix Circuit",
                Date = new DateTime(2024, 3, 24),
                ImageUrl = "https://media.formula1.com/image/upload/f_auto/q_auto/v1677245019/content/dam/fom-website/2018-redesign-assets/Racehub%20header%20images%2016x9/Australia.jpg.transform/9col/image.jpg",
                Laps = 58,
                CircuitInfo = "The deal to host Formula 1 in Melbourne was done in 1993, using a mixture of the existing roads around the city’s Albert Park – mainly Aughtie Drive and Lakeside Drive.",
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };
        }

        private void SeedEvents()
        {
            MeetAndGreet = new Event
            {
                Id = 1,
                Name = "F1 Meet and Greet",
                Description = "An exclusive opportunity to meet your favorite Formula 1 drivers.",
                ImageUrl = "https://www.circuitcat.com/wp-content/uploads/2019/05/1805100318_sainz.jpg",
                Location = "Melbourne, Australia",
                Date = new DateTime(2024, 3, 10),
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };

            AutographSession = new Event
            {
                Id = 2,
                Name = "Autograph Session",
                Description = "Get the chance to take autographs from the top F1 pilots.",
                ImageUrl = "https://cdn-5.motorsport.com/images/amp/0R5W8yZ6/s6/f1-british-gp-2018-max-verstappen-red-bull-racing-signs-autographs-for-fans-8649080.jpg",
                Location = "Jeddah, Saudi Arabia",
                Date = new DateTime(2024, 3, 17),
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };

            ExclusivePreview = new Event
            {
                Id= 3,
                Name = "Exclusive Team Garage Preview",
                Description = "A behind-the-scenes look at the teams' preparations for the race weekend.",
                ImageUrl = "https://d3cm515ijfiu6w.cloudfront.net/wp-content/uploads/2022/06/16115532/Charles-Leclercs-car-in-the-Ferrari-garage-planetF1.jpg",
                Location = "Sakhir, Bahrain",
                Date = new DateTime(2024, 3, 24),
                OrganizerId = Organizer.Id,
                UserId = GuestUser.Id
            };
        }

        private void SeedNewsArticles()
        {
            TheStrategist = new NewsArticle
            {
                Id = 1,
                Title = "The Strategist",
                Description = "Norris reckons he could have beaten Leclerc in Melbourne with a better strategy – but is he right? Max Verstappen’s retirement from Australian Grand Prix in the opening laps, along with Sergio Perez’s P6 start from the grid, set up an exciting battle for the race win and resulted in a very different looking podium. Ferrari finished the race on the top two steps closely followed by Lando Norris, with all of the top three showing the speed capable of taking the fastest lap (ultimately secured by Charles Leclerc). However, was a better finish possible for Norris? Former Aston Martin Head of Strategy Bernie Collins investigates…",
                ImageUrl = "https://cdn-1.motorsport.com/images/amp/2wBdPEq0/s1000/lando-norris-mclaren-prepares-.jpg",
                OrganizerId = Organizer.Id
            };

            NotWhereIExpectedToBe = new NewsArticle
            {
                Id = 2,
                Title = "Not where I expected to be",
                Description = "Daniel Ricciardo didn’t manage to score points on home soil in Melbourne, on a day where his team mate finished seventh and got the team’s account up and running in the constructors’. Having now been out-qualified by Yuki Tsunoda in the first three races, the Australian was in a reflective mood after coming home in 12th place. Ricciardo’s woes in Australia stretched back to qualifying when he lost his lap time in Q1 for a clear track limits infringement, which dropped him to P18 on the grid. Although there were three retirements in the race and two Virtual Safety Car periods, Ricciardo ran out of time to climb into the points.",
                ImageUrl = "https://thejudge13.com/wp-content/uploads/2024/02/daniel-ricciardo.webp",
                OrganizerId = Organizer.Id
            };

            HinchsHeroes = new NewsArticle
            {
                Id = 3,
                Title = "Hinch's heroes",
                Description = "The Australian Grand Prix in Melbourne served up a superb victory for Carlos Sainz, with plenty of other impressive performances throughout the field. As usual, former IndyCar star and F1 TV pundit James Hinchcliffe was watching closely and has picked out the five drivers who impressed him the most across the race weekend at the Albert Park circuit… Carlos Sainz – P1 - This one is an inevitability, so let’s get it out of the way first. In what many pundits have labeled as Sainz’s greatest drive in F1, the Spaniard capitalised on a rare reliability misstep from Red Bull that eliminated Max Verstappen from contention only a handful of laps into the race.",
                ImageUrl = "https://i.cbc.ca/1.6509174.1656870708!/fileImage/httpImage/1406549790.jpg",
                OrganizerId = Organizer.Id
            };
        }
    }
}
