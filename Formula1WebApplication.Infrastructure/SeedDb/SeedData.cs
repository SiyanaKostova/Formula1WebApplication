using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Formula1WebApplication.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public IdentityUser OrganizerUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Organizer Organizer { get; set; }
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

        public SeedData()
        {
            SeedUsers();
            SeedOrganizer();
            SeedPilots();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            OrganizerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "organizer@mail.com",
                NormalizedUserName = "organizer@mail.com",
                Email = "organizer@mail.com",
                NormalizedEmail = "organizer@mail.com"
            };

            OrganizerUser.PasswordHash =
                 hasher.HashPassword(OrganizerUser, "organizer123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(OrganizerUser, "guest123");
        }

        private void SeedOrganizer()
        {
            Organizer = new Organizer()
            {
                Id = 1,
                PhoneNumber = "+359123123123",
                UserId = OrganizerUser.Id
            };
        }

        private void SeedPilots()
        {
            MaxVerstappen = new Pilot
            {
                FirstName = "Max",
                LastName = "Verstappen",
                Nationality = "Dutch",
                TeamName = "Red Bull Racing",
                Biography = "He’s Max by name, and max by nature. Arriving as Formula 1’s youngest ever competitor at just 17 years old, Verstappen pushed his car, his rivals and the sport’s record books to the limit. The baby-faced Dutchman with the heart of a lion took the Toro Rosso – and then the Red Bull – by the horns with his instinctive racing style.",
                ImagePath = "\\wwwroot\\images\\pilots\\maxverstappen.png"
            };

            CharlesLeclerc = new Pilot
            {
                FirstName = "Charles",
                LastName = "Leclerc",
                Nationality = "Monegasque",
                TeamName = "Ferrari",
                Biography = "Leclerc arrived in F1 on a tidal wave of expectation. He showcased a dazzling array of skills from scorching pole positions, commanding victories – even when his car caught fire twice at Silverstone – to an ability to muscle his way through the pack. Winning back-to-back championships also taught Leclerc how to handle pressure, another useful tool in Formula 1 racing.",
                ImagePath = "\\wwwroot\\images\\pilots\\charlesleclerc.png"
            };

            SergioPerez = new Pilot
            {
                FirstName = "Sergio",
                LastName = "Perez",
                Nationality = "Mexican",
                TeamName = "Red Bull Racing",
                Biography = "He’s the fighter with a gentle touch from the land of the Lucha Libre.Perez’s reputation in F1 has been built on opposite approaches to Grand Prix racing. On the one hand, he is a punchy combatant who wrestles his way through the pack and into the points. Never afraid to add a bit of spice to his on-track encounters, even his team mates don’t always escape the Mexican’s heat.",
                ImagePath = "\\wwwroot\\images\\pilots\\sergioperez.png"
            };

            CarlosSainz = new Pilot
            {
                FirstName = "Carlos",
                LastName = "Sainz",
                Nationality = "Spanish",
                TeamName = "Ferrari",
                Biography = "He’s the matador from Madrid racing royalty. After entering F1’s Bull Ring paired alongside Max Verstappen at Toro Rosso in 2015, Sainz quickly showed his fighting spirit. A tenacious racer, he puts the car on the edge as he hustles his way through the pack. No wonder Sainz has earned the nickname Chilli.",
                ImagePath = "\\wwwroot\\images\\pilots\\carlossainz.png"
            };

            OscarPiastri = new Pilot
            {
                FirstName = "Oscar",
                LastName = "Piastri",
                Nationality = "Australian",
                TeamName = "McLaren",
                Biography = "Born in Melbourne, just a stone’s throw away from the Australian Grand Prix venue, a young Oscar Piastri’s dreams of one day racing in Formula 1 were ignited by the sport’s star drivers roaring around his local streets, otherwise known as Albert Park.",
                ImagePath = "\\wwwroot\\images\\pilots\\oscarpiastri.png"
            };

            LandoNorris = new Pilot
            {
                FirstName = "Lando",
                LastName = "Norris",
                Nationality = "British",
                TeamName = "McLaren",
                Biography = "He has flair and fighting spirit in bountiful supply. McLaren had the British teenager on their books for two years before fast-tracking him into F1’s galaxy of stars in 2019. A firecracker in his junior career, with a penchant for pole positions and wheel-to-wheel tussles, Norris didn’t let them down.",
                ImagePath = "\\wwwroot\\images\\pilots\\landonorris.png"
            };

            GeorgeRussell = new Pilot
            {
                FirstName = "George",
                LastName = "Russell",
                Nationality = "British",
                TeamName = "Mercedes",
                Biography = "He’s the driver with the motto: “If in doubt, go flat out”. George Russell has lived by it throughout his F1 career to date, out-qualifying seasoned team mate Robert Kubica at all 21 Grands Prix in his rookie season, putting Williams back on the podium in 2021, and landing his first race win with Mercedes in 2022.",
                ImagePath = "\\wwwroot\\images\\pilots\\georgerussel.png"
            };

            FernandoAlonso = new Pilot
            {
                FirstName = "Fernando",
                LastName = "Alonso",
                Nationality = "Spanish",
                TeamName = "Alpine",
                Biography = "Fiercely competitive, Alonso is not shy about his talent, rating himself as 9/10 “in everything”, and few in the know would disagree, with his performances in F1 characterised by blistering speed, brilliant tactical thinking, exemplary race craft, a razor-sharp eye for detail and a relentless determination to win.",
                ImagePath = "\\wwwroot\\images\\pilots\\fernandoalonso.png"
            };

            LanceStroll = new Pilot
            {
                FirstName = "Lance",
                LastName = "Stroll",
                Nationality = "Canadian",
                TeamName = "Aston Martin",
                Biography = "There is no such thing as too much too soon for Stroll, a teenage sensation with a wet weather predilection. One of the cool kids on the grid, Stroll was unveiled shortly after his 18th birthday by Williams – before he finished high school and got his road licence. Stroll meant business in his debut 2017 season, setting records on the way. ",
                ImagePath = "\\wwwroot\\images\\pilots\\lancestroll.png"
            };

            LewisHamilton = new Pilot
            {
                FirstName = "Lewis",
                LastName = "Hamilton",
                Nationality = "British",
                TeamName = "Mercedes",
                Biography = "‘Still I Rise’ – these are the words emblazoned across the back of Lewis Hamilton’s helmet and tattooed across his shoulders, and ever since annihilating expectations with one of the greatest rookie performances in F1 history in 2007, that’s literally all he’s done: risen to the top of the all-time pole positions list.",
                ImagePath = "\\wwwroot\\images\\pilots\\lewishamilton.png"
            };

            YukiTsunoda = new Pilot
            {
                FirstName = "Yuki",
                LastName = "Tsunoda",
                Nationality = "Japanese",
                TeamName = "AlphaTauri",
                Biography = "In the entire history of Formula 1, no Japanese driver has ever won a World Championship Grand Prix. Red Bull certainly think so, with the youngster very much on the path to their senior team if he continues to impress as he has done over the past few years. Tsunoda's ascent to the top tier of motorsport was astonishingly rapid.",
                ImagePath = "\\wwwroot\\images\\pilots\\yukitsunoda.png"
            };

            NicoHulkenberg = new Pilot
            {
                FirstName = "Nico",
                LastName = "Hulkenberg",
                Nationality = "German",
                TeamName = "Aston Martin",
                Biography = "He’s the Superhero with the talent to become a racing superstar – if only he could get to flex his muscles with a top team. F1’s 'Hulk' has shown incredible strength and stamina as a midfield marauder for Williams, Force India, Sauber, Renault, Racing Point, Aston Martin and Haas during a career spanning back to 2010.",
                ImagePath = "\\wwwroot\\images\\pilots\\nicohulkenberg.png"
            };

            KevinMagnussen = new Pilot
            {
                FirstName = "Kevin",
                LastName = "Magnussen",
                Nationality = "Danish",
                TeamName = "Haas",
                Biography = "Call him a lone ranger or a maverick, but Magnussen is in Formula 1 for one reason only – to race. He may be a second-generation F1 driver – following his father, Jan, onto the grid – but Magnussen’s idols are from the ‘golden era’ of Grand Prix racing when the likes of Juan Manuel Fangio and Stirling Moss risked it all for the love of the sport.",
                ImagePath = "\\wwwroot\\images\\pilots\\kevinmagnussen.png"
            };

            AlexAlbon = new Pilot
            {
                FirstName = "Alex",
                LastName = "Albon",
                Nationality = "Thai",
                TeamName = "Williams",
                Biography = "Born in London but racing under the flag of Thailand, Alexander Albon’s first word was in fact Italian. That word was Ferrari – though it was with another Italian team that he got his big F1 break. Idolising Michael Schumacher and dreaming of one day racing in Formula 1, the junior Albon was pipped to the 2016 GP3.",
                ImagePath = "\\wwwroot\\images\\pilots\\alexalbon.png"
            };

            GuanyuZhou = new Pilot
            {
                FirstName = "Guanyu",
                LastName = "Zhou",
                Nationality = "Chinese",
                TeamName = "Alfa Romeo",
                Biography = "China had never boasted a Grand Prix starter among its citizens – until Zhou Guanyu changed that state of affairs, after receiving the call-up to make his F1 debut for Alfa Romeo, now Kick Sauber, in 2022. The Shanghai-born racer attended his home city’s inaugural Grand Prix in 2004 at the age of five, cheering on his hero Fernando Alonso.",
                ImagePath = "\\wwwroot\\images\\pilots\\guanyuzhou.png"
            };

            DanielRicciardo = new Pilot
            {
                FirstName = "Daniel",
                LastName = "Ricciardo",
                Nationality = "Australian",
                TeamName = "McLaren",
                Biography = "The self-styled “Honey Badger” is fuzzy on the outside and feisty on the inside. Drivers beware because behind Ricciardo’s laidback persona and big grin is a razor-sharp racer with a bite. The Australian combines all-out speed with impressive race craft. Never afraid to push to the limits if it means pulling off a pass, Ricciardo is a proven race-winner.",
                ImagePath = "\\wwwroot\\images\\pilots\\danielricciardo.png"
            };

            EstebanOcon = new Pilot
            {
                FirstName = "Esteban",
                LastName = "Ocon",
                Nationality = "French",
                TeamName = "Alpine",
                Biography = "If there’s one word that dominates Esteban Ocon’s career, it’s ‘sacrifice’. Back when he was just a promising karter, Ocon’s parents sold their house, put their jobs on hold, and began a life on the road, living in a caravan and travelling from circuit to circuit to support their son’s burgeoning career.",
                ImagePath = "\\wwwroot\\images\\pilots\\estebanocon.png"
            };

            PierreGasly = new Pilot
            {
                FirstName = "Pierre",
                LastName = "Gasly",
                Nationality = "French",
                TeamName = "AlphaTauri",
                Biography = "The flying Frenchman was called up to make his 2017 debut in Malaysia in place of Daniil Kvyat and, after proving his mettle, he was named a Toro Rosso driver the following year.  A further 21 races into his fledgling career, Gasly was moved up again – this time to replace Red Bull big gun Daniel Ricciardo.",
                ImagePath = "\\wwwroot\\images\\pilots\\pierregasly.png"
            };

            ValtteriBottas = new Pilot
            {
                FirstName = "Valtteri",
                LastName = "Bottas",
                Nationality = "Finnish",
                TeamName = "Alfa Romeo",
                Biography = "Learning his craft on Finnish roads of ice and snow, he was born to be a Grand Prix racer. Bottas explains that if you can drive on the frozen roads of his homeland then you can drive anywhere. Then there’s the Finnish mentality –reserved, diligent and calm the fast lane of F1 doesn’t faze him.",
                ImagePath = "\\wwwroot\\images\\pilots\\valtteribottas.png"
            };

            LoganSargeant = new Pilot
            {
                FirstName = "Logan",
                LastName = "Sargeant",
                Nationality = "American",
                TeamName = "Williams",
                Biography = "Logan Sargeant became F1’s first American driver in almost eight years, giving the country a home favourite to cheer once more. Winner in karting, championship glory eluded Sargeant after he made the transition to single-seater racing, but pole positions and race victories in almost every category he contested underlined his raw speed and potential.",
                ImagePath = "\\wwwroot\\images\\pilots\\logansargeant.png"
            };
        }
    }
}
