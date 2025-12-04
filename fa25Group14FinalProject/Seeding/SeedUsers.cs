using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using fa25Group14FinalProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fa25Group14FinalProject.Seeding
{
    public class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a counter and a flag so we will know which record is causing problems
            Int32 intUsersAdded = 0;
            String strUser = "Begin";
            List<AddUserModel> Users = new List<AddUserModel>();

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Address = "1898 Schurz Alley",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "cbaker@example.com",
                    UserName = "cbaker@example.com",
                    PhoneNumber = "477-44-9589"
                },
                Password = "bookworm",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Michelle",
                    LastName = "Banks",
                    Address = "97 Elmside Pass",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "banker@longhorn.net",
                    UserName = "banker@longhorn.net",
                    PhoneNumber = "247-31-0787"
                },
                Password = "potato",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Franco",
                    LastName = "Broccolo",
                    Address = "88 Crowley Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78786",
                    Email = "franco@example.com",
                    UserName = "franco@example.com",
                    PhoneNumber = "486-47-8748"
                },
                Password = "painting",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Wendy",
                    LastName = "Chang",
                    Address = "56560 Sage Junction",
                    City = "Eagle Pass",
                    State = "TX",
                    ZipCode = "78852",
                    Email = "wchang@example.com",
                    UserName = "wchang@example.com",
                    PhoneNumber = "182-52-9193"
                },
                Password = "texas1",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Lim",
                    LastName = "Chou",
                    Address = "60 Lunder Point",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    Email = "limchou@gogle.com",
                    UserName = "limchou@gogle.com",
                    PhoneNumber = "679-75-0653"
                },
                Password = "Anchorage",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Shan",
                    LastName = "Dixon",
                    Address = "9448 Pleasure Avenue",
                    City = "Georgetown",
                    State = "TX",
                    ZipCode = "78628",
                    Email = "shdixon@aoll.com",
                    UserName = "shdixon@aoll.com",
                    PhoneNumber = "593-06-9800"
                },
                Password = "aggies",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jim Bob",
                    LastName = "Evans",
                    Address = "51 Emmet Parkway",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "j.b.evans@aheca.org",
                    UserName = "j.b.evans@aheca.org",
                    PhoneNumber = "647-72-4711"
                },
                Password = "hampton1",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Lou Ann",
                    LastName = "Feeley",
                    Address = "65 Darwin Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78704",
                    Email = "feeley@penguin.org",
                    UserName = "feeley@penguin.org",
                    PhoneNumber = "577-89-2279"
                },
                Password = "longhorns",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Tesa",
                    LastName = "Freeley",
                    Address = "7352 Loftsgordon Court",
                    City = "College Station",
                    State = "TX",
                    ZipCode = "77840",
                    Email = "tfreeley@minnetonka.ci.us",
                    UserName = "tfreeley@minnetonka.ci.us",
                    PhoneNumber = "853-72-9538"
                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Margaret",
                    LastName = "Garcia",
                    Address = "7 International Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78756",
                    Email = "mgarcia@gogle.com",
                    UserName = "mgarcia@gogle.com",
                    PhoneNumber = "887-12-0229"
                },
                Password = "onetime",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Charles",
                    LastName = "Haley",
                    Address = "8 Warrior Trail",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    Email = "chaley@thug.com",
                    UserName = "chaley@thug.com",
                    PhoneNumber = "528-58-6911"
                },
                Password = "pepperoni",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jeffrey",
                    LastName = "Hampton",
                    Address = "9107 Lighthouse Bay Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78756",
                    Email = "jeffh@sonic.com",
                    UserName = "jeffh@sonic.com",
                    PhoneNumber = "658-45-9102"
                },
                Password = "raiders",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "John",
                    LastName = "Hearn",
                    Address = "59784 Pierstorff Center",
                    City = "Liberty",
                    State = "TX",
                    ZipCode = "77575",
                    Email = "wjhearniii@umich.org",
                    UserName = "wjhearniii@umich.org",
                    PhoneNumber = "712-69-1666"
                },
                Password = "jhearn22",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Anthony",
                    LastName = "Hicks",
                    Address = "932 Monica Way",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78203",
                    Email = "ahick@yaho.com",
                    UserName = "ahick@yaho.com",
                    PhoneNumber = "179-94-2233"
                },
                Password = "hickhickup",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Brad",
                    LastName = "Ingram",
                    Address = "4 Lukken Court",
                    City = "New Braunfels",
                    State = "TX",
                    ZipCode = "78132",
                    Email = "ingram@jack.com",
                    UserName = "ingram@jack.com",
                    PhoneNumber = "126-14-4287"
                },
                Password = "ingram2015",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    Address = "7 Susan Junction",
                    City = "New York",
                    State = "NY",
                    ZipCode = "10101",
                    Email = "toddj@yourmom.com",
                    UserName = "toddj@yourmom.com",
                    PhoneNumber = "355-61-0890"
                },
                Password = "toddy25",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    Address = "669 Oak Junction",
                    City = "Lockhart",
                    State = "TX",
                    ZipCode = "78644",
                    Email = "thequeen@aska.net",
                    UserName = "thequeen@aska.net",
                    PhoneNumber = "840-91-4997"
                },
                Password = "something",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Erik",
                    LastName = "Lineback",
                    Address = "099 Luster Point",
                    City = "Kingwood",
                    State = "TX",
                    ZipCode = "77325",
                    Email = "linebacker@gogle.com",
                    UserName = "linebacker@gogle.com",
                    PhoneNumber = "303-25-5592"
                },
                Password = "Password1",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Ernest",
                    LastName = "Lowe",
                    Address = "35473 Hansons Hill",
                    City = "Beverly Hills",
                    State = "CA",
                    ZipCode = "90210",
                    Email = "elowe@netscare.net",
                    UserName = "elowe@netscare.net",
                    PhoneNumber = "547-72-1592"
                },
                Password = "aclfest2017",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Chuck",
                    LastName = "Luce",
                    Address = "4 Emmet Junction",
                    City = "Navasota",
                    State = "TX",
                    ZipCode = "77868",
                    Email = "cluce@gogle.com",
                    UserName = "cluce@gogle.com",
                    PhoneNumber = "434-46-8800"
                },
                Password = "nothinggood",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    Address = "3 Orin Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "mackcloud@george.com",
                    UserName = "mackcloud@george.com",
                    PhoneNumber = "219-58-3683"
                },
                Password = "whatever",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    Address = "8171 Commercial Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "cmartin@beets.com",
                    UserName = "cmartin@beets.com",
                    PhoneNumber = "116-38-6529"
                },
                Password = "snowsnow",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Clarence",
                    LastName = "Martin",
                    Address = "96 Anthes Place",
                    City = "Schenectady",
                    State = "NY",
                    ZipCode = "12345",
                    Email = "clarence@yoho.com",
                    UserName = "clarence@yoho.com",
                    PhoneNumber = "220-24-4049"
                },
                Password = "whocares",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Gregory",
                    LastName = "Martinez",
                    Address = "10 Northridge Plaza",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78717",
                    Email = "gregmartinez@drdre.com",
                    UserName = "gregmartinez@drdre.com",
                    PhoneNumber = "559-67-5740"
                },
                Password = "xcellent",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Charles",
                    LastName = "Miller",
                    Address = "87683 Schmedeman Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78727",
                    Email = "cmiller@bob.com",
                    UserName = "cmiller@bob.com",
                    PhoneNumber = "209-79-0473"
                },
                Password = "mydogspot",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Kelly",
                    LastName = "Nelson",
                    Address = "3244 Ludington Court",
                    City = "Beaumont",
                    State = "TX",
                    ZipCode = "77720",
                    Email = "knelson@aoll.com",
                    UserName = "knelson@aoll.com",
                    PhoneNumber = "227-64-1445"
                },
                Password = "spotmydog",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Joe",
                    LastName = "Nguyen",
                    Address = "4780 Talisman Court",
                    City = "San Marcos",
                    State = "TX",
                    ZipCode = "78667",
                    Email = "joewin@xfactor.com",
                    UserName = "joewin@xfactor.com",
                    PhoneNumber = "480-18-2513"
                },
                Password = "joejoejoe",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Bill",
                    LastName = "O'Reilly",
                    Address = "4154 Delladonna Plaza",
                    City = "Bergheim",
                    State = "TX",
                    ZipCode = "78004",
                    Email = "orielly@foxnews.cnn",
                    UserName = "orielly@foxnews.cnn",
                    PhoneNumber = "505-04-1746"
                },
                Password = "billyboy",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Anka",
                    LastName = "Radkovich",
                    Address = "72361 Bayside Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78789",
                    Email = "ankaisrad@gogle.com",
                    UserName = "ankaisrad@gogle.com",
                    PhoneNumber = "772-85-3188"
                },
                Password = "radgirl",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Megan",
                    LastName = "Rhodes",
                    Address = "76875 Hoffman Point",
                    City = "Orlando",
                    State = "FL",
                    ZipCode = "32830",
                    Email = "megrhodes@freserve.co.uk",
                    UserName = "megrhodes@freserve.co.uk",
                    PhoneNumber = "855-90-6552"
                },
                Password = "meganr34",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Address = "048 Elmside Park",
                    City = "South Padre Island",
                    State = "TX",
                    ZipCode = "78597",
                    Email = "erynrice@aoll.com",
                    UserName = "erynrice@aoll.com",
                    PhoneNumber = "208-34-2385"
                },
                Password = "ricearoni",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jorge",
                    LastName = "Rodriguez",
                    Address = "01 Browning Pass",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78744",
                    Email = "jorge@noclue.com",
                    UserName = "jorge@noclue.com",
                    PhoneNumber = "391-71-4611"
                },
                Password = "alaskaboy",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Address = "844 Anderson Alley",
                    City = "Canyon Lake",
                    State = "TX",
                    ZipCode = "78133",
                    Email = "mrrogers@lovelyday.com",
                    UserName = "mrrogers@lovelyday.com",
                    PhoneNumber = "308-74-1186"
                },
                Password = "bunnyhop",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Olivier",
                    LastName = "Saint-Jean",
                    Address = "1891 Docker Point",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78779",
                    Email = "stjean@athome.com",
                    UserName = "stjean@athome.com",
                    PhoneNumber = "832-08-8657"
                },
                Password = "dustydusty",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    Address = "1469 Upham Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78720",
                    Email = "saunders@pen.com",
                    UserName = "saunders@pen.com",
                    PhoneNumber = "485-81-2960"
                },
                Password = "jrod2017",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "William",
                    LastName = "Sewell",
                    Address = "1672 Oak Valley Circle",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "willsheff@email.com",
                    UserName = "willsheff@email.com",
                    PhoneNumber = "845-76-6886"
                },
                Password = "martin1234",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    Address = "816 Kennedy Place",
                    City = "Round Rock",
                    State = "TX",
                    ZipCode = "78680",
                    Email = "sheffiled@gogle.com",
                    UserName = "sheffiled@gogle.com",
                    PhoneNumber = "786-58-8427"
                },
                Password = "penguin12",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Address = "0745 Golf Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78760",
                    Email = "johnsmith187@aoll.com",
                    UserName = "johnsmith187@aoll.com",
                    PhoneNumber = "833-36-3857"
                },
                Password = "rogerthat",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Dustin",
                    LastName = "Stroud",
                    Address = "505 Dexter Plaza",
                    City = "Sweet Home",
                    State = "TX",
                    ZipCode = "77987",
                    Email = "dustroud@mail.com",
                    UserName = "dustroud@mail.com",
                    PhoneNumber = "862-95-5935"
                },
                Password = "smitty444",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Eric",
                    LastName = "Stuart",
                    Address = "585 Claremont Drive",
                    City = "Corpus Christi",
                    State = "TX",
                    ZipCode = "78412",
                    Email = "estuart@anchor.net",
                    UserName = "estuart@anchor.net",
                    PhoneNumber = "401-87-6781"
                },
                Password = "stewball",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Peter",
                    LastName = "Stump",
                    Address = "89035 Welch Circle",
                    City = "Pflugerville",
                    State = "TX",
                    ZipCode = "78660",
                    Email = "peterstump@noclue.com",
                    UserName = "peterstump@noclue.com",
                    PhoneNumber = "414-55-9948"
                },
                Password = "slowwind",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    Address = "4 Stang Trail",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78702",
                    Email = "jtanner@mustang.net",
                    UserName = "jtanner@mustang.net",
                    PhoneNumber = "215-59-9614"
                },
                Password = "tanner5454",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Allison",
                    LastName = "Taylor",
                    Address = "726 Twin Pines Avenue",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78713",
                    Email = "taylordjay@aoll.com",
                    UserName = "taylordjay@aoll.com",
                    PhoneNumber = "263-91-7172"
                },
                Password = "allyrally",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    Address = "06605 Sugar Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "rtaylor@gogle.com",
                    UserName = "rtaylor@gogle.com",
                    PhoneNumber = "774-06-1511"
                },
                Password = "taylorbaylor",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Frank",
                    LastName = "Tee",
                    Address = "3567 Dawn Plaza",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78786",
                    Email = "teefrank@noclue.com",
                    UserName = "teefrank@noclue.com",
                    PhoneNumber = "522-65-3064"
                },
                Password = "teeoff22",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Clent",
                    LastName = "Tucker",
                    Address = "704 Northland Alley",
                    City = "San Antonio",
                    State = "TX",
                    ZipCode = "78279",
                    Email = "ctucker@alphabet.co.uk",
                    UserName = "ctucker@alphabet.co.uk",
                    PhoneNumber = "876-29-4912"
                },
                Password = "tucksack1",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Allen",
                    LastName = "Velasco",
                    Address = "72 Harbort Point",
                    City = "Navasota",
                    State = "TX",
                    ZipCode = "77868",
                    Email = "avelasco@yoho.com",
                    UserName = "avelasco@yoho.com",
                    PhoneNumber = "216-67-9243"
                },
                Password = "meow88",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Janet",
                    LastName = "Vino",
                    Address = "1 Oak Valley Place",
                    City = "Boston",
                    State = "MA",
                    ZipCode = "02114",
                    Email = "vinovino@grapes.com",
                    UserName = "vinovino@grapes.com",
                    PhoneNumber = "565-57-4107"
                },
                Password = "vinovino",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jake",
                    LastName = "West",
                    Address = "48743 Banding Parkway",
                    City = "Marble Falls",
                    State = "TX",
                    ZipCode = "78654",
                    Email = "westj@pioneer.net",
                    UserName = "westj@pioneer.net",
                    PhoneNumber = "390-37-6155"
                },
                Password = "gowest",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Louis",
                    LastName = "Winthorpe",
                    Address = "96850 Summit Crossing",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78730",
                    Email = "winner@hootmail.com",
                    UserName = "winner@hootmail.com",
                    PhoneNumber = "445-77-2754"
                },
                Password = "louielouie",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Reagan",
                    LastName = "Wood",
                    Address = "18354 Bluejay Street",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "rwood@voyager.net",
                    UserName = "rwood@voyager.net",
                    PhoneNumber = "805-38-7710"
                },
                Password = "woodyman1",
                RoleName = "Customer"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Address = "1245 Lake Libris Dr.",
                    City = "Cedar Park",
                    State = "TX",
                    ZipCode = "78613",
                    Email = "c.baker@bevosbooks.com",
                    UserName = "c.baker@bevosbooks.com",
                    PhoneNumber = "3395325649"
                },
                Password = "dewey4",
                RoleName = "Admin"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Susan",
                    LastName = "Barnes",
                    Address = "888 S. Main",
                    City = "Kyle",
                    State = "TX",
                    ZipCode = "78640",
                    Email = "s.barnes@bevosbooks.com",
                    UserName = "s.barnes@bevosbooks.com",
                    PhoneNumber = "9636389416"
                },
                Password = "smitty",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Hector",
                    LastName = "Garcia",
                    Address = "777 PBR Drive",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "h.garcia@bevosbooks.com",
                    UserName = "h.garcia@bevosbooks.com",
                    PhoneNumber = "4547135738"
                },
                Password = "squirrel",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Brad",
                    LastName = "Ingram",
                    Address = "6548 La Posada Ct.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "b.ingram@bevosbooks.com",
                    UserName = "b.ingram@bevosbooks.com",
                    PhoneNumber = "5817343315"
                },
                Password = "changalang",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jack",
                    LastName = "Jackson",
                    Address = "222 Main",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78760",
                    Email = "j.jackson@bevosbooks.com",
                    UserName = "j.jackson@bevosbooks.com",
                    PhoneNumber = "8241915317"
                },
                Password = "rhythm",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    Address = "4564 Elm St.",
                    City = "Georgetown",
                    State = "TX",
                    ZipCode = "78628",
                    Email = "t.jacobs@bevosbooks.com",
                    UserName = "t.jacobs@bevosbooks.com",
                    PhoneNumber = "2477822475"
                },
                Password = "approval",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Lester",
                    LastName = "Jones",
                    Address = "999 LeBlat",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78747",
                    Email = "l.jones@bevosbooks.com",
                    UserName = "l.jones@bevosbooks.com",
                    PhoneNumber = "4764966462"
                },
                Password = "society",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Bill",
                    LastName = "Larson",
                    Address = "1212 N. First Ave",
                    City = "Round Rock",
                    State = "TX",
                    ZipCode = "78665",
                    Email = "b.larson@bevosbooks.com",
                    UserName = "b.larson@bevosbooks.com",
                    PhoneNumber = "3355258855"
                },
                Password = "tanman",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    Address = "6639 Bookworm Ln.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "v.lawrence@bevosbooks.com",
                    UserName = "v.lawrence@bevosbooks.com",
                    PhoneNumber = "7511273054"
                },
                Password = "longhorns",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Marshall",
                    LastName = "Lopez",
                    Address = "90 SW North St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    Email = "m.lopez@bevosbooks.com",
                    UserName = "m.lopez@bevosbooks.com",
                    PhoneNumber = "7477907070"
                },
                Password = "swansong",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    Address = "2504 Far West Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "j.macleod@bevosbooks.com",
                    UserName = "j.macleod@bevosbooks.com",
                    PhoneNumber = "2621216845"
                },
                Password = "fungus",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    Address = "7861 Chevy Chase",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78785",
                    Email = "e.markham@bevosbooks.com",
                    UserName = "e.markham@bevosbooks.com",
                    PhoneNumber = "5028075807"
                },
                Password = "median",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Gregory",
                    LastName = "Martinez",
                    Address = "8295 Sunset Blvd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "g.martinez@bevosbooks.com",
                    UserName = "g.martinez@bevosbooks.com",
                    PhoneNumber = "1994708542"
                },
                Password = "decorate",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jack",
                    LastName = "Mason",
                    Address = "444 45th St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78701",
                    Email = "j.mason@bevosbooks.com",
                    UserName = "j.mason@bevosbooks.com",
                    PhoneNumber = "1748136441"
                },
                Password = "rankmary",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Charles",
                    LastName = "Miller",
                    Address = "8962 Main St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78709",
                    Email = "c.miller@bevosbooks.com",
                    UserName = "c.miller@bevosbooks.com",
                    PhoneNumber = "8999319585"
                },
                Password = "kindly",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Mary",
                    LastName = "Nguyen",
                    Address = "465 N. Bear Cub",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78734",
                    Email = "m.nguyen@bevosbooks.com",
                    UserName = "m.nguyen@bevosbooks.com",
                    PhoneNumber = "8716746381"
                },
                Password = "ricearoni",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Suzie",
                    LastName = "Rankin",
                    Address = "23 Dewey Road",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "s.rankin@bevosbooks.com",
                    UserName = "s.rankin@bevosbooks.com",
                    PhoneNumber = "5239029525"
                },
                Password = "walkamile",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Megan",
                    LastName = "Rhodes",
                    Address = "4587 Enfield Rd.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78729",
                    Email = "m.rhodes@bevosbooks.com",
                    UserName = "m.rhodes@bevosbooks.com",
                    PhoneNumber = "1232139514"
                },
                Password = "ingram45",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Address = "3405 Rio Grande",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    Email = "e.rice@bevosbooks.com",
                    UserName = "e.rice@bevosbooks.com",
                    PhoneNumber = "2706602803"
                },
                Password = "arched",
                RoleName = "Admin"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Address = "4965 Oak Hill",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78705",
                    Email = "a.rogers@bevosbooks.com",
                    UserName = "a.rogers@bevosbooks.com",
                    PhoneNumber = "4139645586"
                },
                Password = "lottery",
                RoleName = "Admin"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    Address = "332 Avenue C",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78733",
                    Email = "s.saunders@bevosbooks.com",
                    UserName = "s.saunders@bevosbooks.com",
                    PhoneNumber = "9036349587"
                },
                Password = "nostalgic",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "William",
                    LastName = "Sewell",
                    Address = "2365 51st St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78755",
                    Email = "w.sewell@bevosbooks.com",
                    UserName = "w.sewell@bevosbooks.com",
                    PhoneNumber = "7224308314"
                },
                Password = "offbeat",
                RoleName = "Admin"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    Address = "3886 Avenue A",
                    City = "San Marcos",
                    State = "TX",
                    ZipCode = "78666",
                    Email = "m.sheffield@bevosbooks.com",
                    UserName = "m.sheffield@bevosbooks.com",
                    PhoneNumber = "9349192978"
                },
                Password = "evanescent",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Cindy",
                    LastName = "Silva",
                    Address = "900 4th St",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78758",
                    Email = "c.silva@bevosbooks.com",
                    UserName = "c.silva@bevosbooks.com",
                    PhoneNumber = "4874328170"
                },
                Password = "stewboy",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Eric",
                    LastName = "Stuart",
                    Address = "5576 Toro Ring",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78758",
                    Email = "e.stuart@bevosbooks.com",
                    UserName = "e.stuart@bevosbooks.com",
                    PhoneNumber = "1967846827"
                },
                Password = "instrument",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    Address = "4347 Almstead",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78712",
                    Email = "j.tanner@bevosbooks.com",
                    UserName = "j.tanner@bevosbooks.com",
                    PhoneNumber = "5923026779"
                },
                Password = "hecktour",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Allison",
                    LastName = "Taylor",
                    Address = "467 Nueces St.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78727",
                    Email = "a.taylor@bevosbooks.com",
                    UserName = "a.taylor@bevosbooks.com",
                    PhoneNumber = "7246195827"
                },
                Password = "countryrhodes",
                RoleName = "Employee"
            });

            Users.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    Address = "345 Longview Dr.",
                    City = "Austin",
                    State = "TX",
                    ZipCode = "78746",
                    Email = "r.taylor@bevosbooks.com",
                    UserName = "r.taylor@bevosbooks.com",
                    PhoneNumber = "9071236087"
                },
                Password = "landus",
                RoleName = "Admin"
            });
            IdentityResult result = IdentityResult.Success;

            try
            {
                foreach (AddUserModel aum in Users)
                {
                    strUser = aum.User.Email;

                    // This MUST be awaited so the method is truly async
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the employee with email: "
                                    + strUser, ex);
            }

            // This fixes CS0161 (we now always return something)
            return result;
        }
    }
}
