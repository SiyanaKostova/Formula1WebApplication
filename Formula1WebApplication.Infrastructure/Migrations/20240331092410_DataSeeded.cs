using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1WebApplication.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "e2daa778-2223-43c3-b7bc-eacf8c008b59", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEAh3NH09bw4bqJYSKJ8QL2bpvA4yoADG6fElzg59g/vprRjEMS52YfeLEhCvbsWUuA==", null, false, "c4391048-353f-4129-aa19-fcf8551b2ec9", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "9ecf8983-890a-42af-aa3f-1adb99a4b68b", "organizer@mail.com", false, false, null, "organizer@mail.com", "organizer@mail.com", "AQAAAAEAACcQAAAAELhYFf97FnRnDubWxvTwtd2A19oO19HKuFY/DH8Fvoy/1Nt48OBwMTIDHPffA9bHHw==", null, false, "1636cf4c-82ff-4c1e-80f8-ebdcd65239c8", false, "organizer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "Id", "Biography", "FirstName", "ImagePath", "LastName", "Nationality", "TeamName" },
                values: new object[,]
                {
                    { 1, "He’s Max by name, and max by nature. Arriving as Formula 1’s youngest ever competitor at just 17 years old, Verstappen pushed his car, his rivals and the sport’s record books to the limit. The baby-faced Dutchman with the heart of a lion took the Toro Rosso – and then the Red Bull – by the horns with his instinctive racing style.", "Max", "\\wwwroot\\images\\pilots\\maxverstappen.png", "Verstappen", "Dutch", "Red Bull Racing" },
                    { 2, "Leclerc arrived in F1 on a tidal wave of expectation. He showcased a dazzling array of skills from scorching pole positions, commanding victories – even when his car caught fire twice at Silverstone – to an ability to muscle his way through the pack. Winning back-to-back championships also taught Leclerc how to handle pressure, another useful tool in Formula 1 racing.", "Charles", "\\wwwroot\\images\\pilots\\charlesleclerc.png", "Leclerc", "Monegasque", "Ferrari" },
                    { 3, "He’s the fighter with a gentle touch from the land of the Lucha Libre.Perez’s reputation in F1 has been built on opposite approaches to Grand Prix racing. On the one hand, he is a punchy combatant who wrestles his way through the pack and into the points. Never afraid to add a bit of spice to his on-track encounters, even his team mates don’t always escape the Mexican’s heat.", "Sergio", "\\wwwroot\\images\\pilots\\sergioperez.png", "Perez", "Mexican", "Red Bull Racing" },
                    { 4, "He’s the matador from Madrid racing royalty. After entering F1’s Bull Ring paired alongside Max Verstappen at Toro Rosso in 2015, Sainz quickly showed his fighting spirit. A tenacious racer, he puts the car on the edge as he hustles his way through the pack. No wonder Sainz has earned the nickname Chilli.", "Carlos", "\\wwwroot\\images\\pilots\\carlossainz.png", "Sainz", "Spanish", "Ferrari" },
                    { 5, "Born in Melbourne, just a stone’s throw away from the Australian Grand Prix venue, a young Oscar Piastri’s dreams of one day racing in Formula 1 were ignited by the sport’s star drivers roaring around his local streets, otherwise known as Albert Park.", "Oscar", "\\wwwroot\\images\\pilots\\oscarpiastri.png", "Piastri", "Australian", "McLaren" },
                    { 6, "He has flair and fighting spirit in bountiful supply. McLaren had the British teenager on their books for two years before fast-tracking him into F1’s galaxy of stars in 2019. A firecracker in his junior career, with a penchant for pole positions and wheel-to-wheel tussles, Norris didn’t let them down.", "Lando", "\\wwwroot\\images\\pilots\\landonorris.png", "Norris", "British", "McLaren" },
                    { 7, "He’s the driver with the motto: “If in doubt, go flat out”. George Russell has lived by it throughout his F1 career to date, out-qualifying seasoned team mate Robert Kubica at all 21 Grands Prix in his rookie season, putting Williams back on the podium in 2021, and landing his first race win with Mercedes in 2022.", "George", "\\wwwroot\\images\\pilots\\georgerussel.png", "Russell", "British", "Mercedes" },
                    { 8, "Fiercely competitive, Alonso is not shy about his talent, rating himself as 9/10 “in everything”, and few in the know would disagree, with his performances in F1 characterised by blistering speed, brilliant tactical thinking, exemplary race craft, a razor-sharp eye for detail and a relentless determination to win.", "Fernando", "\\wwwroot\\images\\pilots\\fernandoalonso.png", "Alonso", "Spanish", "Alpine" },
                    { 9, "There is no such thing as too much too soon for Stroll, a teenage sensation with a wet weather predilection. One of the cool kids on the grid, Stroll was unveiled shortly after his 18th birthday by Williams – before he finished high school and got his road licence. Stroll meant business in his debut 2017 season, setting records on the way. ", "Lance", "\\wwwroot\\images\\pilots\\lancestroll.png", "Stroll", "Canadian", "Aston Martin" },
                    { 10, "‘Still I Rise’ – these are the words emblazoned across the back of Lewis Hamilton’s helmet and tattooed across his shoulders, and ever since annihilating expectations with one of the greatest rookie performances in F1 history in 2007, that’s literally all he’s done: risen to the top of the all-time pole positions list.", "Lewis", "\\wwwroot\\images\\pilots\\lewishamilton.png", "Hamilton", "British", "Mercedes" },
                    { 11, "In the entire history of Formula 1, no Japanese driver has ever won a World Championship Grand Prix. Red Bull certainly think so, with the youngster very much on the path to their senior team if he continues to impress as he has done over the past few years. Tsunoda's ascent to the top tier of motorsport was astonishingly rapid.", "Yuki", "\\wwwroot\\images\\pilots\\yukitsunoda.png", "Tsunoda", "Japanese", "AlphaTauri" },
                    { 12, "He’s the Superhero with the talent to become a racing superstar – if only he could get to flex his muscles with a top team. F1’s 'Hulk' has shown incredible strength and stamina as a midfield marauder for Williams, Force India, Sauber, Renault, Racing Point, Aston Martin and Haas during a career spanning back to 2010.", "Nico", "\\wwwroot\\images\\pilots\\nicohulkenberg.png", "Hulkenberg", "German", "Aston Martin" },
                    { 13, "Call him a lone ranger or a maverick, but Magnussen is in Formula 1 for one reason only – to race. He may be a second-generation F1 driver – following his father, Jan, onto the grid – but Magnussen’s idols are from the ‘golden era’ of Grand Prix racing when the likes of Juan Manuel Fangio and Stirling Moss risked it all for the love of the sport.", "Kevin", "\\wwwroot\\images\\pilots\\kevinmagnussen.png", "Magnussen", "Danish", "Haas" },
                    { 14, "Born in London but racing under the flag of Thailand, Alexander Albon’s first word was in fact Italian. That word was Ferrari – though it was with another Italian team that he got his big F1 break. Idolising Michael Schumacher and dreaming of one day racing in Formula 1, the junior Albon was pipped to the 2016 GP3.", "Alex", "\\wwwroot\\images\\pilots\\alexalbon.png", "Albon", "Thai", "Williams" },
                    { 15, "China had never boasted a Grand Prix starter among its citizens – until Zhou Guanyu changed that state of affairs, after receiving the call-up to make his F1 debut for Alfa Romeo, now Kick Sauber, in 2022. The Shanghai-born racer attended his home city’s inaugural Grand Prix in 2004 at the age of five, cheering on his hero Fernando Alonso.", "Guanyu", "\\wwwroot\\images\\pilots\\guanyuzhou.png", "Zhou", "Chinese", "Alfa Romeo" },
                    { 16, "The self-styled “Honey Badger” is fuzzy on the outside and feisty on the inside. Drivers beware because behind Ricciardo’s laidback persona and big grin is a razor-sharp racer with a bite. The Australian combines all-out speed with impressive race craft. Never afraid to push to the limits if it means pulling off a pass, Ricciardo is a proven race-winner.", "Daniel", "\\wwwroot\\images\\pilots\\danielricciardo.png", "Ricciardo", "Australian", "McLaren" },
                    { 17, "If there’s one word that dominates Esteban Ocon’s career, it’s ‘sacrifice’. Back when he was just a promising karter, Ocon’s parents sold their house, put their jobs on hold, and began a life on the road, living in a caravan and travelling from circuit to circuit to support their son’s burgeoning career.", "Esteban", "\\wwwroot\\images\\pilots\\estebanocon.png", "Ocon", "French", "Alpine" },
                    { 18, "The flying Frenchman was called up to make his 2017 debut in Malaysia in place of Daniil Kvyat and, after proving his mettle, he was named a Toro Rosso driver the following year.  A further 21 races into his fledgling career, Gasly was moved up again – this time to replace Red Bull big gun Daniel Ricciardo.", "Pierre", "\\wwwroot\\images\\pilots\\pierregasly.png", "Gasly", "French", "AlphaTauri" },
                    { 19, "Learning his craft on Finnish roads of ice and snow, he was born to be a Grand Prix racer. Bottas explains that if you can drive on the frozen roads of his homeland then you can drive anywhere. Then there’s the Finnish mentality –reserved, diligent and calm the fast lane of F1 doesn’t faze him.", "Valtteri", "\\wwwroot\\images\\pilots\\valtteribottas.png", "Bottas", "Finnish", "Alfa Romeo" },
                    { 20, "Logan Sargeant became F1’s first American driver in almost eight years, giving the country a home favourite to cheer once more. Winner in karting, championship glory eluded Sargeant after he made the transition to single-seater racing, but pole positions and race victories in almost every category he contested underlined his raw speed and potential.", "Logan", "\\wwwroot\\images\\pilots\\logansargeant.png", "Sargeant", "American", "Williams" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359123123123", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "Location", "Name", "OrganizerId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "An exclusive opportunity to meet your favorite Formula 1 drivers.", "https://www.circuitcat.com/wp-content/uploads/2019/05/1805100318_sainz.jpg", "Melbourne, Australia", "F1 Meet and Greet", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get the chance to take autographs from the top F1 pilots.", "https://cdn-5.motorsport.com/images/amp/0R5W8yZ6/s6/f1-british-gp-2018-max-verstappen-red-bull-racing-signs-autographs-for-fans-8649080.jpg", "Jeddah, Saudi Arabia", "Autograph Session", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A behind-the-scenes look at the teams' preparations for the race weekend.", "https://d3cm515ijfiu6w.cloudfront.net/wp-content/uploads/2022/06/16115532/Charles-Leclercs-car-in-the-Ferrari-garage-planetF1.jpg", "Sakhir, Bahrain", "Exclusive Team Garage Preview", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

            migrationBuilder.InsertData(
                table: "NewsArticles",
                columns: new[] { "Id", "Description", "ImageUrl", "OrganizerId", "Title" },
                values: new object[,]
                {
                    { 1, "Norris reckons he could have beaten Leclerc in Melbourne with a better strategy – but is he right? Max Verstappen’s retirement from Australian Grand Prix in the opening laps, along with Sergio Perez’s P6 start from the grid, set up an exciting battle for the race win and resulted in a very different looking podium. Ferrari finished the race on the top two steps closely followed by Lando Norris, with all of the top three showing the speed capable of taking the fastest lap (ultimately secured by Charles Leclerc). However, was a better finish possible for Norris? Former Aston Martin Head of Strategy Bernie Collins investigates…", "https://cdn-1.motorsport.com/images/amp/2wBdPEq0/s1000/lando-norris-mclaren-prepares-.jpg", 1, "The Strategist" },
                    { 2, "Daniel Ricciardo didn’t manage to score points on home soil in Melbourne, on a day where his team mate finished seventh and got the team’s account up and running in the constructors’. Having now been out-qualified by Yuki Tsunoda in the first three races, the Australian was in a reflective mood after coming home in 12th place. Ricciardo’s woes in Australia stretched back to qualifying when he lost his lap time in Q1 for a clear track limits infringement, which dropped him to P18 on the grid. Although there were three retirements in the race and two Virtual Safety Car periods, Ricciardo ran out of time to climb into the points.", "https://thejudge13.com/wp-content/uploads/2024/02/daniel-ricciardo.webp", 1, "Not where I expected to be" },
                    { 3, "The Australian Grand Prix in Melbourne served up a superb victory for Carlos Sainz, with plenty of other impressive performances throughout the field. As usual, former IndyCar star and F1 TV pundit James Hinchcliffe was watching closely and has picked out the five drivers who impressed him the most across the race weekend at the Albert Park circuit… Carlos Sainz – P1 - This one is an inevitability, so let’s get it out of the way first. In what many pundits have labeled as Sainz’s greatest drive in F1, the Spaniard capitalised on a rare reliability misstep from Red Bull that eliminated Max Verstappen from contention only a handful of laps into the race.", "https://i.cbc.ca/1.6509174.1656870708!/fileImage/httpImage/1406549790.jpg", 1, "Hinch's heroes" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CircuitInfo", "Date", "ImageUrl", "Laps", "Location", "Name", "OrganizerId", "UserId" },
                values: new object[,]
                {
                    { 1, "Built for the Bahrain International Circuit in December 2002. It has a blank, sandy canvas to work with, and with that fashioned the technical, 5.4km track designed by Hermann Tilke.", new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.racingnews365.com/2024/Verstappen/_1092x683_crop_center-center_85_none/SI202403020340_hires_jpeg_24bit_rgb.jpg?v=1709395733", 57, "Bahrain International Circuit", "Bahrain Grand Prix", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 2, "The Jeddah Corniche Circuit is a temporary street circuit, located on the Corniche – a 30km coastal resort area of the ancient Saudi Arabian city of Jeddah.", new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.racingnews365.com/2024/_1092x683_crop_center-center_85_none/Qiddiya-street-track-2.jpg?v=1709640021", 50, "Jeddah Corniche Circuit", "Saudi Arabia Grand Prix", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "The deal to host Formula 1 in Melbourne was done in 1993, using a mixture of the existing roads around the city’s Albert Park – mainly Aughtie Drive and Lakeside Drive.", new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://media.formula1.com/image/upload/f_auto/q_auto/v1677245019/content/dam/fom-website/2018-redesign-assets/Racehub%20header%20images%2016x9/Australia.jpg.transform/9col/image.jpg", 58, "Melbourne Grand Prix Circuit", "Australia Grand Prix", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pilots",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
